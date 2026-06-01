'use client';

import { useEffect, useState } from 'react';
import { useAuth } from '@/context/AuthContext';
import { useRouter } from 'next/navigation';
import { LogOut, FileText, Plus, Search, ChevronLeft, ChevronRight, Trash2, SquarePen } from 'lucide-react';
import ProductoModal from '../../components/ProductoModal';

interface Producto {
  id: string;
  nombre: string;
  descripcion?: string;
  precio: number;
  estado: boolean;
  usuarioCreacion: string;
  fechaCreacion: string;
  usuarioModificacion?: string;
  fechaModificacion?: string;
}

export default function DashboardPage() {
  const { usuario, token, logout, cargando } = useAuth();
  const router = useRouter();

  // Estados de datos
  const [productos, setProductos] = useState<Producto[]>([]);
  const [totalRegistros, setTotalRegistros] = useState(0);
  const [totalPaginas, setTotalPaginas] = useState(1);

  // Estados de Filtros y Paginación
  const [filtroNombre, setFiltroNombre] = useState('');
  const [filtroEstado, setFiltroEstado] = useState<string>('todos');
  const [paginaActual, setPaginaActual] = useState(1);
  const [cargandoDatos, setCargandoDatos] = useState(true);

  // Estados del Modal (Agregar/Editar)
  const [modalAbierto, setModalAbierto] = useState(false);
  const [productoSeleccionado, setProductoSeleccionado] = useState<Producto | null>(null);

  // Descarga del Reporte PDF
  const [descargandoPdf, setDescargandoPdf] = useState(false);

  const cargarProductos = async () => {
    if (!token) return;
    setCargandoDatos(true);
    try {
      let url = `${process.env.NEXT_PUBLIC_API_URL}/productos?pagina=${paginaActual}&tamanoPagina=5`;
      if (filtroNombre) url += `&nombre=${encodeURIComponent(filtroNombre)}`;
      if (filtroEstado !== 'todos') url += `&estado=${filtroEstado === 'activo'}`;

      const res = await fetch(url, {
        headers: { Authorization: `Bearer ${token}` },
      });

      if (res.status === 401) logout();

      const data = await res.json();
      setProductos(data.datos || []);
      setTotalRegistros(data.totalRegistros || 0);
      setTotalPaginas(data.totalPaginas || 1);
    } catch (err) {
      console.error('Error al cargar productos:', err);
    } finally {
      setCargandoDatos(false);
    }
  };

  useEffect(() => {
    if (!cargando && !token) {
      router.push('/login');
    } else if (token) {
      cargarProductos();
    }
  }, [token, cargando, paginaActual, filtroEstado]);

  // Ejecutar búsqueda por nombre por botón o enter
  const manejarBusqueda = (e: React.FormEvent) => {
    e.preventDefault();
    setPaginaActual(1);
    cargarProductos();
  };

  // Función para descargar el PDF consumiendo el Blob del backend
  const descargarReportePdf = async () => {
    if (!token) return;
    setDescargandoPdf(true);
    try {
      const res = await fetch(`${process.env.NEXT_PUBLIC_API_URL}/productos/reporte`, {
        headers: { Authorization: `Bearer ${token}` },
      });

      if (!res.ok) throw new Error('No se pudo generar el reporte');

      const blob = await res.blob();
      const urlBlob = window.URL.createObjectURL(blob);
      const a = document.createElement('a');
      a.href = urlBlob;
      a.download = `Reporte_Productos_${new Date().toISOString().slice(0,10)}.pdf`;
      document.body.appendChild(a);
      a.click();
      document.body.removeChild(a);
    } catch (err) {
      alert('Error descargando el PDF');
    } finally {
      setDescargandoPdf(false);
    }
  };

  // Formateador personalizado con "del 2026"
  const formatearFecha2026 = (fechaStr: string) => {
    const fecha = new Date(fechaStr);
    const dia = String(fecha.getDate()).padStart(2, '0');
    const mes = fecha.toLocaleString('es-ES', { month: 'long' });
    return `${dia} de ${mes} del 2026`;
  };

  const abrirModalCrear = () => {
    setProductoSeleccionado(null);
    setModalAbierto(true);
  };

  const abrirModalEditar = (producto: Producto) => {
    setProductoSeleccionado(producto);
    setModalAbierto(true);
  };
   const eliminarProducto = async (id: string) => {
    if (!window.confirm('¿Estás seguro de que deseas eliminar este producto?')) return;
    if (!token) return;

    try {
      const res = await fetch(`${process.env.NEXT_PUBLIC_API_URL}/productos/${id}`, {
        method: 'DELETE',
        headers: { Authorization: `Bearer ${token}` },
      });

      if (!res.ok) {
        const data = await res.json();
        throw new Error(data.message || 'Error al eliminar el producto');
      }

      alert('Producto eliminado con éxito');
      cargarProductos();
    } catch (err: any) {
      alert(err.message);
    }
  };

  if (cargando || !token) {
    return <div className="flex min-h-screen items-center justify-center">Cargando aplicación...</div>;
  }

  return (
    <div className="min-h-screen bg-slate-50">
      {/* NAVBAR SUPERIOR */}
      <nav className="border-b border-slate-200 bg-white px-6 py-4 shadow-sm">
        <div className="mx-auto flex max-w-7xl items-center justify-between">
          <div>
            <span className="text-xl font-bold tracking-tight text-slate-900">REDLAB</span>
            <span className="text-xs font-semibold uppercase text-slate-400 block tracking-widest">Technology</span>
          </div>
          <div className="flex items-center gap-4">
            <div className="text-right">
              <p className="text-sm font-medium text-slate-700">{usuario?.nombre}</p>
              <p className="text-xs text-slate-400">{usuario?.email}</p>
            </div>
            <button
              onClick={logout}
              className="rounded-lg p-2 text-slate-400 hover:bg-slate-100 hover:text-slate-600 transition"
              title="Cerrar Sesión"
            >
              <LogOut className="h-5 w-5" />
            </button>
          </div>
        </div>
      </nav>

      <main className="mx-auto max-w-7xl p-4 sm:p-6 lg:p-8 space-y-6">
        {/* ENCABEZADO DE SECCIÓN */}
        <div className="flex flex-col sm:flex-row sm:items-center sm:justify-between gap-4 bg-white p-6 rounded-xl border border-slate-100 shadow-sm">
          <div>
            <h1 className="text-2xl font-bold text-slate-900 tracking-tight">Panel de Control</h1>
            <p className="text-sm text-slate-500">Administración general e inventario físico de productos.</p>
          </div>
          <div className="flex flex-wrap items-center gap-3">
            <button
              onClick={descargarReportePdf}
              disabled={descargandoPdf}
              className="inline-flex items-center gap-2 rounded-lg border border-slate-200 bg-white px-4 py-2.5 text-sm font-semibold text-slate-700 shadow-sm hover:bg-slate-50 transition disabled:opacity-50"
            >
              <FileText className="h-4 w-4 text-slate-500" />
              {descargandoPdf ? 'Generando...' : 'Exportar PDF'}
            </button>
            <button
              onClick={abrirModalCrear}
              className="inline-flex items-center gap-2 rounded-lg bg-slate-900 px-4 py-2.5 text-sm font-semibold text-white shadow-sm hover:bg-slate-800 transition"
            >
              <Plus className="h-4 w-4" />
              Nuevo Producto
            </button>
          </div>
        </div>

        {/* FILTROS DE BÚSQUEDA */}
        <div className="bg-white p-4 rounded-xl border border-slate-100 shadow-sm">
          <form onSubmit={manejarBusqueda} className="flex flex-col md:flex-row gap-4 items-end">
            <div className="flex-1 w-full">
              <label className="block text-xs font-semibold text-slate-500 uppercase tracking-wider mb-1">Buscar por nombre</label>
              <div className="relative">
                <Search className="absolute left-3 top-3 h-4 w-4 text-slate-400" />
                <input
                  type="text"
                  placeholder="Escribe el nombre del artículo..."
                  className="w-full rounded-lg border border-slate-200 pl-10 pr-4 py-2 text-sm outline-none focus:border-slate-400 text-black"
                  value={filtroNombre}
                  onChange={(e) => setFiltroNombre(e.target.value)}
                />
              </div>
            </div>

            <div className="w-full md:w-48">
              <label className="block text-xs font-semibold text-slate-500 uppercase tracking-wider mb-1">Filtrar por Estado</label>
              <select
                className="w-full rounded-lg border border-slate-200 p-2 text-sm outline-none focus:border-slate-400 bg-white text-black"
                value={filtroEstado}
                onChange={(e) => setFiltroEstado(e.target.value)}
              >
                <option value="todos">Todos</option>
                <option value="activo">Activos</option>
                <option value="inactivo">Inactivos</option>
              </select>
            </div>

            <button
              type="submit"
              className="w-full md:w-auto bg-slate-100 hover:bg-slate-200 text-slate-700 font-semibold px-5 py-2 rounded-lg text-sm transition"
            >
              Filtrar
            </button>
          </form>
        </div>

        {/* TABLA PRINCIPAL */}
        <div className="bg-white rounded-xl border border-slate-100 shadow-sm overflow-hidden">
          <div className="overflow-x-auto">
            <table className="w-full text-left border-collapse">
              <thead>
                <tr className="bg-slate-50/70 border-b border-slate-200 text-xs font-semibold uppercase tracking-wider text-slate-500">
                  <th className="p-4">Producto</th>
                  <th className="p-4">Precio</th>
                  <th className="p-4">Estado</th>
                  <th className="p-4">Auditoría Creación</th>
                  <th className="p-4 text-right">Acciones</th>
                </tr>
              </thead>
              <tbody className="divide-y divide-slate-100 text-sm">
                {cargandoDatos ? (
                  <tr>
                    <td colSpan={5} className="p-8 text-center text-slate-400">Cargando registros...</td>
                  </tr>
                ) : productos.length === 0 ? (
                  <tr>
                    <td colSpan={5} className="p-8 text-center text-slate-400">No se encontraron productos con los filtros aplicados.</td>
                  </tr>
                ) : (
                  productos.map((prod) => (
                    <tr key={prod.id} className="hover:bg-slate-50/50 transition">
                      <td className="p-4">
                        <p className="font-semibold text-slate-900">{prod.nombre}</p>
                        <p className="text-xs text-slate-400 max-w-xs truncate">{prod.descripcion || 'Sin descripción'}</p>
                      </td>
                      <td className="p-4 font-medium text-slate-900">${prod.precio.toFixed(2)}</td>
                      <td className="p-4">
                        <span className={`inline-flex items-center rounded-full px-2 py-1 text-xs font-semibold ${
                          prod.estado ? 'bg-green-50 text-green-700 border border-green-200' : 'bg-red-50 text-red-700 border border-red-200'
                        }`}>
                          {prod.estado ? 'Activo' : 'Inactivo'}
                        </span>
                      </td>
                      <td className="p-4 text-xs text-slate-500">
                        <p>Por: <span className="font-medium text-slate-700">{prod.usuarioCreacion}</span></p>
                        <p className="text-slate-400">{formatearFecha2026(prod.fechaCreacion)}</p>
                      </td>
                      <td className="p-4 text-right">
                        <button
                          onClick={() => abrirModalEditar(prod)}
                          className="text-sm font-semibold text-slate-900 hover:underline mr-2"
                        >
                          <SquarePen className="h-4 w-4" />
                        </button>
                        <button
                            onClick={() => eliminarProducto(prod.id)}
                            className="text-red-500 hover:text-red-700 transition"
                            title="Eliminar"
                          >
                            <Trash2 className="h-4 w-4" />
                          </button>
                      </td>
                    </tr>
                  ))
                )}
              </tbody>
            </table>
          </div>

          {/* PAGINACIÓN */}
          <div className="flex items-center justify-between border-t border-slate-100 px-6 py-4 bg-slate-50/30">
            <p className="text-xs font-medium text-slate-500">
              Mostrando página <span className="text-slate-800">{paginaActual}</span> de <span className="text-slate-800">{totalPaginas}</span> ({totalRegistros} registros en total)
            </p>
            <div className="flex gap-2">
              <button
                onClick={() => setPaginaActual(p => Math.max(p - 1, 1))}
                disabled={paginaActual === 1 || cargandoDatos}
                className="inline-flex h-8 w-8 items-center justify-center rounded-lg border border-slate-200 bg-white text-slate-600 shadow-sm hover:bg-slate-50 disabled:opacity-40"
              >
                <ChevronLeft className="h-4 w-4" />
              </button>
              <button
                onClick={() => setPaginaActual(p => Math.min(p + 1, totalPaginas))}
                disabled={paginaActual === totalPaginas || cargandoDatos}
                className="inline-flex h-8 w-8 items-center justify-center rounded-lg border border-slate-200 bg-white text-slate-600 shadow-sm hover:bg-slate-50 disabled:opacity-40"
              >
                <ChevronRight className="h-4 w-4" />
              </button>
            </div>
          </div>
        </div>
      </main>

      {/* COMPONENTE MODAL (Fase H) */}
      {modalAbierto && (
        <ProductoModal
          producto={productoSeleccionado}
          onClose={() => setModalAbierto(false)}
          onSuccess={() => {
            setModalAbierto(false);
            cargarProductos();
          }}
        />
      )}
    </div>
  );
}