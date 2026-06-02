# RedLab Technology - Control de Inventario & Productos

Aplicación full-stack desarrollada como solución a la prueba técnica para el puesto de desarrollador en **React & .NET 8**. La aplicación incluye un panel completo para la administración física de mercancía, autenticación robusta mediante JWT, auditorías automatizadas de transacciones y emisión de reportes contables nativos en PDF.

## ✨ Características Técnicas
- **Backend:** .NET 8 Web API estructurada de forma minimalista basada en Controladores, Entity Framework Core y generación fluida de reportes con QuestPDF.
- **Frontend:** React 19 / Next.js 15 (App Router), TypeScript 5 para un control estricto de tipos, Tailwind CSS para la maquetación y Lucide-React para iconografía.
- **Base de Datos:** Microsoft SQL Server 2022 empaquetado en contenedores aislados.

---

## 🚀 Instrucciones de Ejecución Rapida

Sigue estos 3 simples pasos para correr la aplicación completa de forma local sin requerir configuraciones adicionales:

### Paso 1: Clonar el Repositorio
```
git clone https://github.com/Hefziben/redlab-prueba.git
cd redlab-prueba
```
### Paso 2: Encender la Infraestructura (Docker)
```
docker compose up -d
```
### Paso 3: Lanzar Proyectos (Backend y Frontend)
**Iniciar el Backend:**
```
cd backend/RedLab.API
dotnet run
```
**Iniciar el Frontend:**
```
cd frontend
npm install
```
renombrar env.example a

```
env.local
```

Correr proyecto

```
npm run dev
```
Abre http://localhost:3000 en tu navegador para interactuar con el sistema.

