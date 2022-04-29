# Контроллер преподавателей

Реализует единственный на данный момент метод "Получить список преподавателей", возвращает контракт `TeacherListModel` при успехе.

```http
GET /v1/teachers/?name=имя_преподавателя
```

Параметр запроса `name` не является обязательным, однако благодаря ему можно реализовать, например, поиск по имени (точное совпадение с именем в базе не требуется, поиск ведется по всем именам, в которых содержится данная строка).

## Контракты

#### `TeacherListModel`

```apl
//	Список преподавателей
contract TeacherListModel
{
	//	Массив контрактов TeacherModel
	items = TeacherModel[];
	
	//	Число элементов в массиве
	total = int;
}
```

#### `TeacherModel`

```apl
//	Информация о преподавателе
contract TeacherModel
{
	// Идентификатор в базе
	id = int;
	
	//	Полное имя преподавателя
        name = string;
	
	//	Степень
        degree = string?;
	
	//	Кафедра
        chapter = string?;
    
        //	Должность
        position = string?;

        //	Номер телефона
        phoneNumber = string?;

        //	Электронная почта
        email = string?;

        //	Кафедра
        chapter = string?;

        //	Аудитория
        auditory = string?;

        //	URL изображения
        imageUrl = string?;

        //	Биография
        biography = string?;

        //	Кафедра
        chapter = string?;

        //	Курсы
        courses = string?;

        //	Исследования, публикации
        Science = string?;
}
```
