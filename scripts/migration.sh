#!/bin/bash

set -e

MIGRATION_NAME="$1"

if [ -z "$MIGRATION_NAME" ]; then
    echo "Usage: ./scripts/migration.sh <MigrationName>"
    exit 1
fi

export ConnectionStrings__DefaultConnection="Host=localhost;Port=5432;Database=worklist;Username=worklist;Password=worklist"

export Jwt__Secret="$(docker compose -f docker-compose.dev.yml exec -T api printenv Jwt__Secret)"

export Jwt__Issuer="$(docker compose -f docker-compose.dev.yml exec -T api printenv Jwt__Issuer)"

export Jwt__Audience="$(docker compose -f docker-compose.dev.yml exec -T api printenv Jwt__Audience)"

export Jwt__ExpirationMinutes="$(docker compose -f docker-compose.dev.yml exec -T api printenv Jwt__ExpirationMinutes)"

cd backend/WorkList.Api

dotnet ef migrations add "$MIGRATION_NAME"

dotnet ef database update
