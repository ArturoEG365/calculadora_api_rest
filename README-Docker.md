# 🐳 Docker Setup para Core.NET Service

Este proyecto ha sido dockerizado para facilitar su despliegue y desarrollo.

## 📋 Requisitos Previos

- Docker Desktop instalado
- Docker Compose instalado

## 🚀 Inicio Rápido

### Opción 1: Usar el script automatizado

```bash
# Construir y ejecutar todo
./docker-start.sh

# O usar comandos específicos
./docker-start.sh build    # Solo construir
./docker-start.sh up       # Solo iniciar
./docker-start.sh down     # Detener
./docker-start.sh logs     # Ver logs
./docker-start.sh clean    # Limpiar todo
```

### Opción 2: Usar Docker Compose manualmente

```bash
# Construir las imágenes
docker-compose build

# Iniciar los servicios
docker-compose up -d

# Ver logs
docker-compose logs -f api

# Detener los servicios
docker-compose down
```

## 🌐 Acceso a la Aplicación

Una vez que los contenedores estén ejecutándose:

- **API**: http://localhost:8080
- **Swagger UI**: http://localhost:8080/swagger
- **Base de Datos PostgreSQL**: localhost:5432

## 🗄️ Base de Datos

El proyecto incluye dos configuraciones de base de datos:

### 1. Base de Datos Remota (Render)
Por defecto, la aplicación usa la base de datos configurada en `appsettings.json`.

### 2. Base de Datos Local (Docker)
Si quieres usar una base de datos local:

1. Modifica el archivo `docker-compose.yml` para usar `appsettings.Docker.json`
2. La base de datos PostgreSQL se creará automáticamente en Docker

## 🏗️ Estructura de Archivos Docker

```
├── Dockerfile              # Imagen de la aplicación .NET
├── docker-compose.yml      # Orquestación de servicios
├── .dockerignore           # Archivos a ignorar
├── docker-start.sh         # Script de automatización
└── core.net_service/
    ├── appsettings.Docker.json  # Configuración para Docker
    └── ...
```

## 🔧 Personalización

### Cambiar Puerto

Edita el `docker-compose.yml`:

```yaml
ports:
  - "TU_PUERTO:8080"  # Cambia TU_PUERTO por el puerto deseado
```

### Variables de Entorno

Puedes crear un archivo `.env` en la raíz del proyecto:

```env
API_PORT=8080
POSTGRES_PASSWORD=tu_password
ASPNETCORE_ENVIRONMENT=Development
```

### Usar Base de Datos Remota

Si prefieres seguir usando la base de datos de Render, simplemente usa la configuración actual. La aplicación se conectará automáticamente.

## 🐛 Solución de Problemas

### Limpiar Todo y Empezar de Nuevo

```bash
./docker-start.sh clean
./docker-start.sh
```

### Ver Logs Detallados

```bash
docker-compose logs -f
```

### Acceder al Contenedor

```bash
docker-compose exec api bash
```

## 📝 Comandos Útiles

```bash
# Ver contenedores en ejecución
docker ps

# Ver imágenes
docker images

# Ejecutar migraciones (si es necesario)
docker-compose exec api dotnet ef database update

# Acceder a la base de datos PostgreSQL local
docker-compose exec postgres psql -U arturo_eg -d operaciones_aritmeticas
```

## ⚡ Desarrollo

Para desarrollo con hot-reload, puedes montar el código fuente:

```yaml
# Añadir en docker-compose.yml bajo el servicio api:
volumes:
  - ./core.net_service:/app/src
```

¡Tu proyecto .NET ahora está completamente dockerizado! 🎉
