#!/bin/bash

# CPCC Campus App - Docker Database Helper Script
# Provides easy commands for managing PostgreSQL in Docker

set -e

# Colors for output
GREEN='\033[0;32m'
YELLOW='\033[1;33m'
RED='\033[0;31m'
NC='\033[0m' # No Color

# Function to print colored messages
success() {
    echo -e "${GREEN}✓${NC} $1"
}

warning() {
    echo -e "${YELLOW}⚠${NC} $1"
}

error() {
    echo -e "${RED}✗${NC} $1"
}

# Check if docker-compose is available
if ! command -v docker-compose &> /dev/null; then
    error "docker-compose is not installed. Please install Docker Desktop."
    exit 1
fi

# Main menu
case "${1:-help}" in
    start)
        echo "Starting PostgreSQL database..."
        docker-compose up -d postgres
        success "PostgreSQL is starting. Waiting for health check..."
        sleep 3
        docker-compose ps postgres
        success "Database is ready at localhost:5432"
        ;;
    
    stop)
        echo "Stopping all services..."
        docker-compose down
        success "Services stopped"
        ;;
    
    restart)
        echo "Restarting PostgreSQL..."
        docker-compose restart postgres
        success "PostgreSQL restarted"
        ;;
    
    logs)
        docker-compose logs -f postgres
        ;;
    
    status)
        docker-compose ps
        ;;
    
    psql)
        echo "Connecting to PostgreSQL CLI..."
        docker exec -it cpcc_postgres psql -U postgres -d cpcc_campus_app_dev
        ;;
    
    tables)
        echo "Listing all database tables..."
        docker exec cpcc_postgres psql -U postgres -d cpcc_campus_app_dev -c "\dt"
        ;;
    
    count)
        echo "Counting records in key tables..."
        docker exec cpcc_postgres psql -U postgres -d cpcc_campus_app_dev -c "
            SELECT 
                'UserProfiles' as table_name, COUNT(*) as records FROM \"UserProfiles\"
            UNION ALL
            SELECT 'CompanyProfiles', COUNT(*) FROM \"CompanyProfiles\"
            UNION ALL
            SELECT 'Schools', COUNT(*) FROM \"Schools\"
            UNION ALL
            SELECT 'JobPosts', COUNT(*) FROM \"JobPosts\"
            UNION ALL
            SELECT 'SmartTypes', COUNT(*) FROM \"SmartTypes\"
            UNION ALL
            SELECT 'SmartCodes', COUNT(*) FROM \"SmartCodes\";
        "
        ;;
    
    seed)
        echo "Running API to trigger seeding..."
        cd Portal.Api
        dotnet run
        ;;
    
    migrate)
        echo "Applying migrations..."
        cd Portal.Api
        dotnet ef database update
        success "Migrations applied"
        ;;
    
    reset)
        warning "This will DELETE ALL DATA and recreate the database!"
        read -p "Are you sure? (yes/no): " confirm
        if [ "$confirm" = "yes" ]; then
            echo "Stopping services and removing volumes..."
            docker-compose down -v
            success "Volumes removed"
            
            echo "Starting PostgreSQL..."
            docker-compose up -d postgres
            sleep 3
            
            echo "Applying migrations..."
            cd Portal.Api
            dotnet ef database update
            
            success "Database reset complete. Run './db.sh seed' to load reference data."
        else
            warning "Reset cancelled"
        fi
        ;;
    
    backup)
        BACKUP_FILE="backup_$(date +%Y%m%d_%H%M%S).sql"
        echo "Creating backup: $BACKUP_FILE"
        docker exec cpcc_postgres pg_dump -U postgres cpcc_campus_app_dev > "$BACKUP_FILE"
        success "Backup created: $BACKUP_FILE"
        ;;
    
    restore)
        if [ -z "$2" ]; then
            error "Usage: ./db.sh restore <backup-file.sql>"
            exit 1
        fi
        echo "Restoring from: $2"
        docker exec -i cpcc_postgres psql -U postgres -d cpcc_campus_app_dev < "$2"
        success "Database restored from $2"
        ;;
    
    clean)
        warning "This will remove ALL Docker containers and volumes!"
        read -p "Are you sure? (yes/no): " confirm
        if [ "$confirm" = "yes" ]; then
            docker-compose down -v --remove-orphans
            success "All Docker resources cleaned"
        else
            warning "Clean cancelled"
        fi
        ;;
    
    help|*)
        echo "CPCC Campus App - Docker Database Helper"
        echo ""
        echo "Usage: ./db.sh [command]"
        echo ""
        echo "Commands:"
        echo "  start       - Start PostgreSQL in Docker"
        echo "  stop        - Stop all services"
        echo "  restart     - Restart PostgreSQL"
        echo "  logs        - View PostgreSQL logs (Ctrl+C to exit)"
        echo "  status      - Show status of all services"
        echo "  psql        - Connect to PostgreSQL CLI"
        echo "  tables      - List all database tables"
        echo "  count       - Count records in key tables"
        echo "  seed        - Run API to trigger data seeding"
        echo "  migrate     - Apply pending EF Core migrations"
        echo "  reset       - Reset database (deletes all data)"
        echo "  backup      - Create database backup"
        echo "  restore     - Restore from backup file"
        echo "  clean       - Remove all Docker resources"
        echo "  help        - Show this help message"
        echo ""
        echo "Examples:"
        echo "  ./db.sh start              # Start database"
        echo "  ./db.sh psql               # Connect to database"
        echo "  ./db.sh backup             # Create backup"
        echo "  ./db.sh restore backup.sql # Restore from backup"
        ;;
esac
