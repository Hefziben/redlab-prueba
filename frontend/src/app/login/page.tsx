'use client';

import { useState } from 'react';
import { useAuth } from '@/context/AuthContext';
import Link from 'next/link';

export default function LoginPage() {
  const { login } = useAuth();
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');
  const [enviando, setEnviando] = useState(false);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setError('');
    setEnviando(true);

    try {
      const res = await fetch(`${process.env.NEXT_PUBLIC_API_URL}/auth/login`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ email, password }),
      });

      const data = await res.json();

      if (!res.ok) throw new Error(data.message || 'Error al iniciar sesión');

      login(data.token, data.usuario);
    } catch (err: any) {
      setError(err.message);
    } finally {
      setEnviando(false);
    }
  };

  return (
    <div className="flex min-h-screen items-center justify-center p-4">
      <div className="w-full max-w-md space-y-6 rounded-2xl bg-white p-8 shadow-xl border border-slate-100">
        <div className="space-y-2 text-center">
          <h1 className="text-3xl font-bold tracking-tight text-slate-900">Bienvenido</h1>
          <p className="text-sm text-slate-500">Ingresa a tu cuenta de RedLab Technology</p>
        </div>

        {error && (
          <div className="rounded-lg bg-red-50 p-3 text-sm font-medium text-red-600">
            {error}
          </div>
        )}

        <form onSubmit={handleSubmit} className="space-y-4">
          <div>
            <label className="block text-sm font-medium text-slate-700">Correo Electrónico</label>
            <input
              type="email"
              required
              className="mt-1 w-full rounded-lg border border-slate-200 p-2.5 outline-none focus:border-slate-900 text-black"
              placeholder="correo@redlab.com"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
            />
          </div>

          <div>
            <label className="block text-sm font-medium text-slate-700">Contraseña</label>
            <input
              type="password"
              required
              className="mt-1 w-full rounded-lg border border-slate-200 p-2.5 outline-none focus:border-slate-900 text-black"
              placeholder="••••••••"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
            />
          </div>

          <button
            type="submit"
            disabled={enviando}
            className="w-full rounded-lg bg-slate-900 p-3 font-semibold text-white transition hover:bg-slate-800 disabled:bg-slate-400"
          >
            {enviando ? 'Iniciando sesión...' : 'Iniciar Sesión'}
          </button>
        </form>

        <p className="text-center text-sm text-slate-500">
          ¿No tienes una cuenta?{' '}
          <Link href="/register" className="font-semibold text-slate-900 hover:underline">
            Regístrate aquí
          </Link>
        </p>
      </div>
    </div>
  );
}