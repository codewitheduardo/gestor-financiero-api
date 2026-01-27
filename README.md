# 📊 Gestor Financiero API

API REST para la gestión de finanzas, desarrollada en **C# con .NET**, pensada como backend para administrar información financiera como ingresos y gastos.

Este proyecto forma parte de un desarrollo personal orientado al aprendizaje y al portfolio, aplicando buenas prácticas de backend y arquitectura de Web APIs.

---

## 🧰 Tecnologías utilizadas

- C#
- .NET Web API
- REST
- Arquitectura por capas
- Controladores HTTP
- BCrypt (hash de contraseñas)
- JWT (JSON Web Tokens)
- Consumo de APIs externas

---

## 🚀 Funcionalidades

- Exposición de endpoints REST  
- Operaciones CRUD sobre entidades financieras  
- Separación de responsabilidades (controladores, lógica de negocio y datos)  
- Gestión de usuarios con **contraseñas hasheadas mediante BCrypt**
- Autenticación y autorización mediante JWT
- Consumo de una **API externa para obtener el tipo de cambio de moneda**  
- Integración con aplicaciones frontend o clientes HTTP  

---

## 📥 Instalación y ejecución

1. Clonar el repositorio:

```bash
git clone https://github.com/codewitheduardo/gestor-financiero-api.git
```

2. Entrar al proyecto:

```bash
cd gestor-financiero-api
```

3. Restaurar dependencias:

```bash
dotnet restore
```

4. Ejecutar la API:

```bash
dotnet run
```

> Es necesario tener instalado el **.NET SDK**.

---

## 🛠️ Uso

Con la API en ejecución, los endpoints pueden consumirse utilizando herramientas como **Postman**, **Insomnia** o **curl**.

Ejemplo de request:

```bash
GET http://localhost:5000/api/TipoGasto/GetAll
```

---

## 🧪 Endpoints (ejemplo)

| Método  | Ruta              | Descripción    |
|--------|-------------------|----------------|
| GET    | /api/TipoGasto/GetAll      | Obtener todos  |
| POST   | /api/TipoGasto/Create    | Crear nuevo    |
| GET    | /api/TipoGasto/Get/{id} | Obtener por ID |
| PATCH    | /api/TipoGasto/Edit/ | Actualizar     |
| DELETE | /api/TipoGasto/Delete/{id} | Eliminar       |

---

## 🔐 Seguridad

- Las contraseñas de los usuarios **no se almacenan en texto plano**.
- Se utiliza **BCrypt** para el hash seguro de contraseñas antes de persistirlas.
- La API implementa autenticación y autorización con JWT para proteger los endpoints.

---

## 💱 Tipo de cambio de moneda

La API consume un **servicio externo de cambio de moneda** para obtener valores actualizados y permitir conversiones dentro del sistema financiero.

---

## 📌 Estado del proyecto

🟡 En desarrollo / mejoras continuas

---

## ✍️ Autor

**Eduardo Monzón**  
GitHub: https://github.com/codewitheduardo

---

## ✨ Mejoras futuras

- Roles y permisos más granulares
- Tests unitarios
- Persistencia avanzada con base de datos
