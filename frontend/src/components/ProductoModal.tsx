'use client';

import { useState, useEffect } from 'react';
import { useAuth } from '@/context/AuthContext';
import { X } from 'lucide-react';

interface Producto {
  id: string;
  nombre: string;
  descripcion?: string;
  precio: number;
  estado: boolean;
}

interface ProductoModalProps {
  producto: Producto | null; // Si es null, el modo es "Crear". Si tiene datos, es "Editar".
  onClose: () => void;
  onSuccess: () => void;
}

export default function ProductoModal({ producto, onClose, onSuccess }: ProductoModalProps) {
  const { token } = useAuth();
  
  // Estados del Formulario
  const [nombre, setNombre] = useState('');
  const [descripcion, setDescripcion] = useState('');
  const [precio, setPrecio] = useState('');
  const [estado, setEstado] = useState(true);
  
  const [error, setError] = useState('');
  const [enviando, setEnviando] = useState(false);

  const esEdicion = !!producto;

  // Cargar datos si el modo es edición
  useEffect(() => {
    if (producto) {
      setNombre(producto.nombre);
      setDescripcion(producto.descripcion || '');
      setPrecio(producto.precio.toString());
      setEstado(producto.estado);
    }
  }, [producto]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setError('');
    setEnviando(true);

    // Validaciones básicas de cliente antes de enviar
    if (parseFloat(precio) <= 0 || isNaN(parseFloat(precio))) {
      setError('El precio debe ser un número mayor a 0.');
      setEnviando(false);
      return;
    }

    try {
      const url = esEdicion 
        ? `${process.env.NEXT_PUBLIC_API_URL}/productos/${producto.id}`
        : `${process.env.NEXT_PUBLIC_API_URL}/productos`;

      const method = esEdicion ? 'PUT' : 'POST';

      const res = await fetch(url, {
        method: method,
        headers: {
          'Content-Type': 'application/json',
          Authorization: `Bearer ${token}`,
        },
        body: JSON.stringify({
          nombre,
          descripcion: descripcion || null,
          precio: parseFloat(precio),
          estado,
        }),
      });

      const data = await res.json();

      if (!res.ok) throw new Error(data.message || 'Error al procesar la solicitud con el servidor.');

      onSuccess(); // Recargar la tabla principal
    } catch (err: any) {
      setError(err.message);
    } finally {
      setEnviando(false);
    }
  };

  return (
    <div className="fixed inset-0 z-50 flex items-center justify-center bg-slate-900/40 p-4 backdrop-blur-xs">
      <div className="w-full max-w-md rounded-2xl bg-white shadow-2xl border border-slate-100 overflow-hidden">
        
        {/* Cabecera del Modal */}
        <div className="flex items-center justify-between border-b border-slate-100 bg-slate-50/50 px-6 py-4">
          <h2 className="text-lg font-bold text-slate-900">
            {esEdicion ? 'Editar Producto' : 'Agregar Nuevo Producto'}
          </h2>
          <button 
            onClick={onClose} 
            className="rounded-lg p-1.5 text-slate-400 hover:bg-slate-100 hover:text-slate-600 transition"
          >
            <X className="h-5 w-5" />
          </button>
        </div>

        {/* Contenido / Formulario */}
        <form onSubmit={handleSubmit} className="p-6 space-y-4">
          {error && (
            <div className="rounded-lg bg-red-50 p-3 text-sm font-medium text-red-600">
              {error}
            </div>
          )}

          <div>
            <label className="block text-sm font-semibold text-slate-700">Nombre del Producto</label>
            <input
              type="text"
              required
              maxLength={150}
              placeholder="Ej. Teclado Mecánico RGB"
              className="mt-1 w-full rounded-lg border border-slate-200 p-2.5 text-sm outline-none focus:border-slate-900 text-black"
              value={nombre}
              onChange={(e) => setNombre(e.target.value)}
            />
          </div>

          <div>
            <label className="block text-sm font-semibold text-slate-700">Descripción (Opcional)</label>
            <textarea
              rows={3}
              placeholder="Detalles específicos del artículo..."
              className="mt-1 w-full rounded-lg border border-slate-200 p-2.5 text-sm outline-none focus:border-slate-900 resize-none text-black"
              value={descripcion}
              onChange={(e) => setDescripcion(e.target.value)}
            />
          </div>

          <div className="grid grid-cols-2 gap-4">
            <div>
              <label className="block text-sm font-semibold text-slate-700">Precio ($)</label>
              <input
                type="number"
                step="0.01"
                required
                placeholder="0.00"
                className="mt-1 w-full rounded-lg border border-slate-200 p-2.5 text-sm outline-none focus:border-slate-900 text-black"
                value={precio}
                onChange={(e) => setPrecio(e.target.value)}
              />
            </div>

            <div>
              <label className="block text-sm font-semibold text-slate-700">Estado del Inventario</label>
              <select
                className="mt-1 w-full rounded-lg border border-slate-200 p-2.5 text-sm outline-none focus:border-slate-900 bg-white text-black"
                value={estado ? 'activo' : 'inactivo'}
                onChange={(e) => setEstado(e.target.value === 'activo')}
              >
                <option value="activo">Activo</option>
                <option value="inactivo">Inactivo</option>
              </select>
            </div>
          </div>

          {/* Acciones del Pie */}
          <div className="flex justify-end gap-3 pt-4 border-t border-slate-100 mt-6">
            <button
              type="button"
              onClick={onClose}
              className="rounded-lg border border-slate-200 bg-white px-4 py-2.5 text-sm font-semibold text-slate-700 hover:bg-slate-50 transition"
            >
              Cancelar
            </button>
            <button
              type="submit"
              disabled={enviando}
              className="rounded-lg bg-slate-900 px-4 py-2.5 text-sm font-semibold text-white shadow-sm hover:bg-slate-800 transition disabled:bg-slate-400"
            >
              {enviando ? 'Guardando...' : esEdicion ? 'Actualizar' : 'Guardar'}
            </button>
          </div>
        </form>

      </div>
    </div>
  );
}