using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalsPresenter;
using AnimalsView;

namespace AnimalsModel
{
    /// <summary>
    /// Класс-оболочка для источника данных списка животных формы
    /// </summary>
    public class AnimalListDataSource
    {
        private IView view;

        public AnimalListDataSource(IView view) => this.view = view;

        /// <summary>
        /// Добавляет животное в список на форме
        /// </summary>
        /// <param name="animal"></param>
        public void Add(AbstractAnimal animal)
        {
            view.Animals.Add(animal);
            view.UpdateAnimalList();
        }

        /// <summary>
        /// Выводит сообщение о невозможности добавить животное
        /// </summary>
        public void ShowNotAddedMessage() => view.ShowMessage("Животное не было добавлено, так как обработка выбранного класса животных ещё не реализована!");
    }
}
