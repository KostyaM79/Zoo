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
    /// Интерфейс для модели
    /// </summary>
    public interface IModel
    {
        void CreateAnimal(string className, string animalType, string name, IView viev, Presenter presenter);

        void LoadAnimals();

        void SaveRepository(RepositorySaver saver);

        List<IAnimal> GetAnimalItems();

        void DeleteAnimal(IAnimal animal);
    }
}
