#!/bin/bash

echo "🐳 Dockerizando proyecto .NET..."

# Función para mostrar ayuda
show_help() {
    echo "Uso: ./docker-start.sh [OPCIÓN]"
    echo ""
    echo "Opciones:"
    echo "  build     Construir las imágenes Docker"
    echo "  up        Iniciar los contenedores"
    echo "  down      Detener los contenedores"
    echo "  logs      Mostrar logs de la aplicación"
    echo "  clean     Limpiar imágenes y contenedores"
    echo "  help      Mostrar esta ayuda"
    echo ""
}

# Función para construir
build_containers() {
    echo "🔨 Construyendo contenedores..."
    docker-compose build
}

# Función para iniciar
start_containers() {
    echo "🚀 Iniciando contenedores..."
    docker-compose up -d
    echo "✅ Aplicación disponible en: http://localhost:8080"
    echo "📊 Swagger UI: http://localhost:8080/swagger"
}

# Función para detener
stop_containers() {
    echo "🛑 Deteniendo contenedores..."
    docker-compose down
}

# Función para mostrar logs
show_logs() {
    echo "📝 Mostrando logs..."
    docker-compose logs -f api
}

# Función para limpiar
clean_containers() {
    echo "🧹 Limpiando contenedores e imágenes..."
    docker-compose down --volumes --rmi all
    docker system prune -f
}

# Verificar que Docker esté instalado
if ! command -v docker &> /dev/null; then
    echo "❌ Docker no está instalado. Por favor, instala Docker primero."
    exit 1
fi

if ! command -v docker-compose &> /dev/null; then
    echo "❌ Docker Compose no está instalado. Por favor, instala Docker Compose primero."
    exit 1
fi

# Procesar argumentos
case "$1" in
    build)
        build_containers
        ;;
    up)
        start_containers
        ;;
    down)
        stop_containers
        ;;
    logs)
        show_logs
        ;;
    clean)
        clean_containers
        ;;
    help|--help|-h)
        show_help
        ;;
    "")
        echo "🐳 Iniciando proyecto completo..."
        build_containers
        start_containers
        ;;
    *)
        echo "❌ Opción no válida: $1"
        show_help
        exit 1
        ;;
esac
