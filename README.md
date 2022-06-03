# OrioksAPI.OrioksServer

Сервер хранения и обработки данных, полученных с [OrioksAPI.OrioksDecorator](https://github.com/stalinon/OrioksAPI.OrioksDecorator)

![workflow](https://github.com/stalinon/OrioksAPI.OrioksServer/workflows/.NET/badge.svg)

![workflow](https://github.com/stalinon/OrioksAPI.OrioksServer/workflows/Docker%20Image%20Builder/badge.svg)

![workflow](https://github.com/stalinon/OrioksAPI.OrioksServer/workflows/Deploy/badge.svg)

Разработано с использованием пакета `Quartz.NET` и разработанного ранее `OrioksAPI.OrioksDecorator`. Получение и хранение в БД `PostgresSQL`
данных о преподавателях и расписании. Первый пакет непосредственно устанавливает периодичность получения данных, второй - средство их получения.

---

-   [Инструкции по развертке](docs/instuction.md)
-   [Контроллер расписаний](docs/schedule.md)
-   [Контроллер преподавателей](docs/teachers.md)

---

-   [создание tg-бота (практика базового C#)](https://github.com/stalinon/OrioksAPI.TelegramService)
-   создание фронтенда веб-приложения (практика верстки и React)
