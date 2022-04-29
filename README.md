# OrioksAPI.OrioksServer
Сервер хранения и обработки данных, полученных с OrioksAPI.OrioksDecorator

![workflow](https://github.com/stalinon/OrioksAPI.OrioksServer/workflows/.NET/badge.svg)

Цель проекта следующая - с использованием пакета `Quartz.NET` и разработанного ранее `OrioksAPI.OrioksDecorator` установить получение и хранение в БД `PostgresSQL` 
данных о преподавателях и расписании. Первый пакет непосредственно устанавливает периодичность получения данных, второй - средство их получения.
Написать контроллеры, которые обеспечат выдачу этих данных простыми GET-запросами:

Получение расписания
```http
GET /api/v1/schedule/
```

Получение информации о преподавателях
```http
GET /api/v1/teacher/
```

и подобными прочими.

Так же реализовать обработку хранимых данных и соответственно запросы сложнее

Получение списка пустых аудиторий
```http
GET /api/v1/schedule/empty-auditories
```
В основном реализация наворотов на запросах работает на параметрах запроса, вроде того:
```http
GET /api/v1/schedule?teacherName=Пупкин
```

Имплементация POST, UPDATE и DELETE запросов не предполагается.

---

- [Контроллер расписаний](docs/schedule.md)
- [Контроллер преподавателей](docs/teachers.md)

---

По окончании разработки деплой планируется с использованием Docker Swarm на нескольких узлах на `heroku` для обеспечения устойчивости сервера.
Из примеров использования сервера в голову приходит 
- создание tg-бота (практика базового C#)
- создание фронтенда веб-приложения (практика верстки и React)
- создание мобильного приложения (изучение и практика React Native)
