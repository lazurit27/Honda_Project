# 🏎️ Honda Project — E-Commerce Platform

Полнофункциональное веб-приложение для просмотра каталога автомобильной продукции и управления заказами, разработанное на **ASP.NET Core MVC (.NET 8)**.

---

## 🚀 Основные возможности

### 👤 Клиентская часть (User Dashboard)
* **Каталог товаров**: Просмотр брендов, моделей и автомобильной продукции с подробным описанием.
* **Личный кабинет**: Просмотр собственной истории заказов.
* **Безопасность**: Защищённый доступ с отображением заказов только текущего авторизованного пользователя.
* **Интерактивный UI**: Динамическая цветовая индикация статусов заказов (`Completed`, `Pending`, `InProgress`, `Canceled`).

### 🛠️ Панель администратора (Admin Area)
* **Управление заказами**: Мониторинг всех оформленных заказов в системе с возможностью просмотра данных покупателя.
* **Изменение статусов**: Удобное редактирование и обновление текущего статуса любого заказа.
* **Разграничение прав (RBAC)**: Доступ к админ-панели строго ограничен ролью `Admin`.

---

## 🛠️ Технологический стек

* **Backend**: C# 12, .NET 8 (ASP.NET Core MVC)
* **Database & ORM**: Entity Framework Core, SQL Server
* **Authentication & Security**: ASP.NET Core Identity (Пользователи и Роли, Cookie-авторизация)
* **Frontend**: Razor Views (CSHTML), Bootstrap 5, Bootstrap Icons, CSS3
* **Architecture**: Repository Pattern, DTOs / ViewModels, Area Separation (`Admin` / `Main`)

---

## 📁 Структура проекта

```text
Honda_Project/
├── Areas/
│   └── Admin/                 # Админ-панель
│       ├── Controllers/       # Контроллеры админки (OrdersController, etc.)
│       └── Views/             # Представления управления заказами и каталогом
├── Controllers/               # Пользовательские контроллеры (OrderController, CarProducts, etc.)
├── Models/                    # Сущности базы данных и основные доменные модели
├── Repositories/              # Реализация паттерна Repository для работы с БД
├── ViewModels/                # DTO и модели отображения (OrderRow, OrderEdit)
├── Views/                     # Пользовательские Razor-представления
└── Program.cs                 # Конфигурация DI-контейнера, Identity и Middleware
