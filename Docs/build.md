# Команды

## Build проекта

```bash
dotnet build
```

## Добавление ссылки на проект

```bash
dotnet add ./Dinner.Application/ reference ./Dinner.Domain/
```

## Запуск web-приложения

```bash
dotnet run ./Dinner.Api/Dinner.Api.csproj
```

## Добавление NuGet-пакета

```bash
dotnet add ./Dinner.Api/ package MediatR
```

## Безопасное хранилище

### Инициализация

```bash
dotnet user-secrets init --project ./Dinner.Api/
```

### Сохранение значения

```bash
dotnet user-secrets set --project ./Dinner.Api/ "
JwtSettings:Secret" "super-secret-key-from-user-secrets"
```

### Список значений

```bash
dotnet user-secrets list --project ./Dinner.Api/
```
