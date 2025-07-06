# BilogChallenge
## 🩺 Gestión de Especialidades – WebAPI (.NET 8)

Este proyecto es parte de un desafío técnico que consiste en desarrollar una API REST para gestionar especialidades médicas. Se implementan principios de Clean Architecture, validaciones de entrada, control de concurrencia con `rowVersion`, documentación interactiva y configuración segura mediante User Secrets.

---

## 🛠 Tecnologías

- ASP.NET Core 8
- Entity Framework Core
- SQL Server
- AutoMapper
- Swagger (Swashbuckle)
- Postman
- Middlewares personalizados
- User Secrets

---

## 🔐 Configuración segura

Usamos User Secrets para evitar exponer claves o contraseñas en el código fuente:

```bash
dotnet user-secrets init
dotnet user-secrets set "Application:ConnectionString" "Server=...;Database=...;User Id=...;Password=...;"
