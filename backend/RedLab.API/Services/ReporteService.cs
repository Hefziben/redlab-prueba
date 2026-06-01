using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using RedLab.API.Entities;

namespace RedLab.API.Services
{
    public class ReporteService
    {
        public byte[] GenerarReporteProductosPdf(List<Producto> productos)
        {
            // QuestPDF requiere licencia comunitaria para uso educativo/pruebas técnicas
            QuestPDF.Settings.License = LicenseType.Community;

            return Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(10).FontFamily("Helvetica"));
                    
// 1. ENCABEZADO
                    page.Header().Row(row =>
                    {
                        row.RelativeItem().Column(col =>
                        {
                            col.Item().Text("REDLAB TECHNOLOGY").FontSize(18).Bold().FontColor("0F172A");
                            col.Item().Text("Reporte General de Control de Inventario").FontSize(11).FontColor("64748B");
                        });

                        row.ConstantItem(120).AlignRight().AlignMiddle().Column(col =>
                        {
                            col.Item().Text($"Fecha: {DateTime.Now:dd/MM/yyyy}").FontSize(9).FontColor("64748B");
                        });
                    });

                    // 2. TABLA DE PRODUCTOS
                    page.Content().PaddingTop(1, Unit.Centimetre).Table(table =>
                    {

                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn(3); // Nombre
                            columns.RelativeColumn(4); // Descripción
                            columns.RelativeColumn(2); // Precio
                            columns.RelativeColumn(2); //Estado
                        });

                        // 2. Encabezado de la Tabla
                        table.Header(header =>
                        {
                                var colorCabecera = "0F172A";
                                header.Cell().Background(colorCabecera).Padding(6).Text("Nombre").Bold().FontColor(Colors.White);
                                header.Cell().Background(colorCabecera).Padding(6).Text("Descripción").Bold().FontColor(Colors.White);
                                header.Cell().Background(colorCabecera).Padding(6).Text("Precio").Bold().FontColor(Colors.White).AlignRight();
                                header.Cell().Background(colorCabecera).Padding(6).Text("Estado").Bold().FontColor(Colors.White).AlignCenter();
                        });

                        // 3. Filas de Datos Dinámicos
                        foreach (var prod in productos)
                        {
                            // SOLUCIÓN AL COLOR ALTERNO: Usamos Colors.FromHex SIN el '#' para evitar errores del parser
                            var fondoFila = productos.IndexOf(prod) % 2 == 0 
                                ? Colors.White 
                                : Colors.White; // Slate 50 limpio

                            table.Cell().Background(fondoFila).BorderBottom(1).BorderColor(Colors.Grey.Lighten3).Padding(5).Text(prod.Nombre);

                             table.Cell().Background(fondoFila).BorderBottom(1).BorderColor(Colors.Grey.Lighten3).Padding(5).Text(prod.Descripcion);
                          
                            table.Cell().Background(fondoFila).BorderBottom(1).BorderColor(Colors.Grey.Lighten3).Padding(5).Text($"${prod.Precio:N2}");
                             
                             var textoEstado = prod.Estado ? "Activo" : "Inactivo";
                             var colorEstado = prod.Estado ? "15803D" : "B91C1C";
                             table.Cell().Background(fondoFila).BorderBottom(1).BorderColor(Colors.Grey.Lighten3).Padding(5).Text(textoEstado).FontColor(colorEstado).AlignCenter();                            ;
                        }
                    });

                    // --- PIE DE PÁGINA ---
                    page.Footer().AlignCenter().Text(x =>
                    {
                        x.CurrentPageNumber();
                        x.Span(" / ");
                        x.TotalPages();
                    });
                });
            }).GeneratePdf();
        }
    }
}