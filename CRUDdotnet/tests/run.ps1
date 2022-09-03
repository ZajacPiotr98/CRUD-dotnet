$env:COMPOSE_PROJECT_NAME = New-Guid
docker-compose up -d postgres
Start-Sleep -Seconds 2
Read-Host -Prompt 'Press Enter to exit...'
docker-compose down --remove-orphans --rmi local