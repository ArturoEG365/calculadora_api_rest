# 🚀 Instrucciones de Despliegue - Puerto 10000

## Para Servicios de Despliegue (Render, Railway, etc.)

Tu proyecto está configurado para correr en el **puerto 10000** por defecto.

### 📋 Archivos Importantes

- `Dockerfile` - Para desarrollo local
- `Dockerfile.production` - Para despliegue en servicios cloud
- `docker-compose.yml` - Para desarrollo local completo

### 🌐 URLs de Acceso

- **API**: http://localhost:10000
- **Swagger**: http://localhost:10000/swagger  
- **Health Check**: http://localhost:10000/health

### 🛠️ Comandos de Despliegue

#### Para desarrollo local:
```bash
./docker-start.sh
```

#### Para build de producción:
```bash
docker build -f Dockerfile.production -t core-net-service .
docker run -p 10000:10000 core-net-service
```

#### Para servicios de despliegue automático:
La mayoría de servicios detectarán automáticamente el `Dockerfile.production` y el puerto 10000.

### ⚙️ Variables de Entorno Necesarias

Para el despliegue, asegúrate de configurar:

```env
ASPNETCORE_ENVIRONMENT=Production
ASPNETCORE_URLS=http://+:10000
ConnectionStrings__DefaultConnection=tu_connection_string_de_produccion
```

### 🔍 Health Check

El endpoint `/health` está disponible para que los servicios de despliegue puedan verificar que la aplicación está funcionando correctamente.

### 📊 Base de Datos

Tu aplicación usa PostgreSQL. Asegúrate de que la conexión string en `appsettings.json` sea accesible desde el entorno de despliegue.

¡Tu aplicación está lista para despliegue en el puerto 10000! 🎉
