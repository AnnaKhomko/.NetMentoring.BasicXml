# .NetMentoring.BasicXml

Задание к модулю XML Basic

Общая формулировка задачи

У нас есть библиотечная система, которая хранит каталог всех единиц, представленных в библиотеке:

Описание хранимых объектов:

Книги

1. Название

2. Автор(ы)

3. Место издания (город)

4. Название издательства

5. Год издания

6. Количество страниц

7. Примечание

8. Международный стандартный номер книги (ISBN)

Газеты

1. Название

2. Место издания (город)

3. Название издательства

4. Год издания

5. Количество страниц

6. Примечание

7. Номер

8. Дата

9. Международный стандартный номер серийного издания (ISSN)

Патенты

1. Название

2. Изобретатель (и)

3. Страна

4. Регистрационный номер

5. Дата подачи заявки

6. Дата публикации

7. Количество страниц

8. Примечание

Система умеет делать массовую загрузку и выгрузку своих данных в XML файл. Структура файла очень проста:

* Общий корневой элемент, представляющий каталог (содержит информацию о времени выгрузки, библиотеке, …)

* Дочерние элементы – все, содержащиеся в системе объекты учета (см. выше), по одному элементу на объект. Элементы никак не упорядочены и не сгруппированы.
