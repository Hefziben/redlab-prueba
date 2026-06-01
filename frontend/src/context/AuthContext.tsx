'use client';

import React, { createContext, useContext, useState, useEffect } from 'react';
import { useRouter } from 'next/navigation';

interface Usuario {
  id: string;
  nombre: string;
  email: string;
}

interface AuthContextType {
  usuario: Usuario | null;
  token: string | null;
  login: (token: string, usuario: Usuario) => void;
  logout: () => void;
  cargando: boolean;
}

const AuthContext = createContext<AuthContextType | undefined>(undefined);

export function AuthProvider({ children }: { children: React.ReactNode }) {
  const [usuario, setUsuario] = useState<Usuario | null>(null);
  const [token, setToken] = useState<string | null>(null);
  const [cargando, setCargando] = useState(true);
  const router = useRouter();

  useEffect(() => {
    // Recuperar sesión guardada al cargar la app
    const tokenGuardado = localStorage.getItem('redlab_token');
    const usuarioGuardado = localStorage.getItem('redlab_usuario');

    if (tokenGuardado && usuarioGuardado) {
      setToken(tokenGuardado);
      setUsuario(JSON.parse(usuarioGuardado));
    }
    setCargando(false);
  }, []);

  const login = (nuevoToken: string, nuevoUsuario: Usuario) => {
    setToken(nuevoToken);
    setUsuario(nuevoUsuario);
    localStorage.setItem('redlab_token', nuevoToken);
    localStorage.setItem('redlab_usuario', JSON.stringify(nuevoUsuario));
    router.push('/dashboard');
  };

  const logout = () => {
    setToken(null);
    setUsuario(null);
    localStorage.removeItem('redlab_token');
    localStorage.removeItem('redlab_usuario');
    router.push('/login');
  };

  return (
    <AuthContext.Provider value={{ usuario, token, login, logout, cargando }}>
      {children}
    </AuthContext.Provider>
  );
}

export function useAuth() {
  const context = useContext(AuthContext);
  if (!context) throw new Error('useAuth debe usarse dentro de un AuthProvider');
  return context;
}