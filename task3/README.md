# Task 3 — Shop

Структура решения:

- `Core` — общие контракты `IPrimary` и `IRepository<T>`.
- `Shop.Dal` — DAO и репозитории XML/JSON (а также репозитории старого txt-формата).
- `Shop.Bll` — бизнес-сущности `ShopBlo`, `ClientBlo`, `GoodBlo`.
- `task3` — единственный консольный проект, содержит только `Program.cs`.

Зависимости:

`task3 -> Shop.Dal -> Core`
`Shop.Bll -> Core`

`Shop.Bll` НЕ зависит от `Shop.Dal`, что соответствует требованию независимости бизнес-логики от хранения данных.

После запуска `task3` в рабочей папке приложения создаются:
`shops.xml`, `shops.json`, `clients.xml`, `clients.json`, `goods.xml`, `goods.json`.
