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
        private List<IAnimal> animalList;
        private IView view;

        public AnimalListDataSource(List<IAnimal> list) => animalList = list;

        public AnimalListDataSource(IView view) => this.view = view;

        public void Add(AbstractAnimal animal)
        {
            view.Animals.Add(animal);
            view.UpdateAnimalList();
        }

        public void ShowNotAddedMessage() => view.ShowMessage("Животное не было добавлено, так как обработка выбранного класса животных ещё не реализована!");
    }
}
