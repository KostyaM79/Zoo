# Зоопарк

Инструиенты: MS Visual Studio 2019 Professional.

Стэк технологий: .NET Framework, WinForm.

Разработчик: Константин Махнутин.

Запуск приложения:
	1. Собрать проект.
	2. Запустить файл AnimalsApplication.exe.

Программа позволяет добавлять животных, указывая их класс, вид и имя. Данные сохраняются в формате XML.
Есть возможность выгрузить данные в форматах: XML, TXT и JSON. В программе уже имеются несколько классов животных (Млекопитающие, Птицы, Рыбы и т.д.).
Чтобы добавить новый класс животных, нужно создать новый класс, наследующий от класса AbstractAnimal и клас фабрики для него, реализующий интерфейс IFactory.
Система автоматически находит все классы фабрик и создаёт их экземпляры. Управление простое. Вверху формы есть 3 поля: "Класс", "Вид" и "Имя", ниже - поле
для отображения подробной информации о классе животного, далее два списка: 1-й отображает всех животных, 2-й - животных, отфильтрованых по классу. В самом
низу формы расположены 4 кнопки: "Закрыть", "Сохранить репозиторий как...", "Удалить" и "Добавить". Соответственно кнопка "Закрыть" закрывает программу,
кнопка "Сохранить репозиторий как..." открывает диалог для сохранения списка животных, где можно выбрать формат и путь для сохранения, кнопка "Удалить"
удаляет выбранное животное, ну и кнопка "Добавить" добавляет новое животное, если введены все необходимые данные.