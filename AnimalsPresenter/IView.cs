using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalsPresenter;

namespace AnimalsView
{
    /// <summary>
    /// Интерфейс для View MVP
    /// </summary>
    public interface IView
    {
        //event NeedToApplyFilterEventHandler NeedToApplyFilter;

        /// <summary>
        /// Возвращает фабрику
        /// </summary>
        //IFactoryListItem SelectedAnimalFactory { get; }
        string SelectedAnimalClass { get; }

        /// <summary>
        /// Возвращает вид животного, введённый пользователем
        /// </summary>
        string AnimalType { get; }

        /// <summary>
        /// Возвращает или задаёт источник данных для списка животных
        /// </summary>
        List<IAnimal> Animals { get; set; }

        /// <summary>
        /// Добавляет животное в список
        /// </summary>
        /// <param name="item"></param>
        void AddAnimalToList(string item);

        void AddAnimalToList(IAnimal animal);

        /// <summary>
        /// Задаёт источник данных для списка
        /// </summary>
        List<IAnimal> AnimalListItems { set; }

        /// <summary>
        /// Возвращает объект для сохранения файла
        /// </summary>
        ISaveFileView SaveFileObj { get; }

        /// <summary>
        /// Обновляет список животных
        /// </summary>
        void UpdateAnimalList();

        /// <summary>
        /// Выводит сообщение
        /// </summary>
        /// <param name="message"></param>
        void ShowMessage(string message);

        string ClassDefinition { get; set; }

        IAnimal SelectedAnimal { get; }

        string AnimalName { get; }
    }
}
