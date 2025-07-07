# 🩺 Bilog Challenge – Gestión de Especialidades Médicas

Este proyecto es parte de un desafío técnico propuesto por Bilog. Consiste en desarrollar una API RESTful robusta para gestionar especialidades médicas, con foco en mantener la integridad de datos, buenas prácticas arquitectónicas y manejo de concurrencia.

---

## 🛠 Tecnologías utilizadas

- ASP.NET Core 8  
- Entity Framework Core  
- SQL Server  
- AutoMapper  
- Swagger (Swashbuckle)  
- Middlewares personalizados  
- FluentValidation  
- User Secrets  

---

## 📐 Arquitectura

La solución está basada en principios de Clean Architecture, separando claramente las capas de:

- Controladores (WebAPI)  
- Servicios de aplicación  
- Repositorios (acceso a datos)  
- Entidades del dominio y DTOs  

---

## ▶️ Endpoints disponibles

- GET /especialidades → Listar todas las especialidades  
- POST /especialidades → Crear una nueva especialidad  
- PUT /especialidades/{id} → Actualizar una especialidad existente  
- DELETE /especialidades/{id} → Eliminar una especialidad  

---

## 🔒 Validaciones y reglas de negocio

- `cod_especialidad` y `descripcion` deben ser únicos.  
- Se implementa control de concurrencia optimista utilizando el campo `rowVersion`.  
- Se retorna el código HTTP adecuado: 200, 201, 204, 400, 404, 409, etc.  
- Se valida entrada con FluentValidation.  

---

# 🚀 Bilog Challenge – Postman Collection

Esta colección de Postman permite probar funcionalmente los endpoints de la API.

Enlace de descarga:  
📄 [Bilog-Challenge.postman_collection.json](https://globant-enterprise-ai.postman.co/workspace/My-Workspace~b9fbbd6e-805c-4cb7-9c0d-726bc609e326/collection/24340576-95ac1702-734a-4eee-afe3-2341613ecada?action=share&creator=24340576)

---

## 🔧 Requisitos para usar la colección

- Tener Postman instalado  
- Tener la API corriendo localmente (por defecto en: `https://localhost:7191`)  

---
## 🚀 Next steps for production-readiness

| Mejora                   | Justificación                                                                 |
|--------------------------|-------------------------------------------------------------------------------- 
| 🔒 JWT Authentication    | Proteger los endpoints y gestionar control de acceso a recursos sensibles     |
| 💥 Retry Policies        | Reintentos ante errores transitorios de base de datos o servicios externos    |
| 🧪 Entorno QA            | validar nuevos desarrollados aplicando test unitarios, integradores y E2E     |
| 🔍 Health Checks         | Exponer endpoint `/health` para verificar disponibilidad en producción        |



