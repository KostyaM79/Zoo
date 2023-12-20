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
        IAnimalListItem CreateAnimal(IFactoryListItem factory, string animalType);

        IEnumerable<IFactoryListItem> GetFactories();

        void AddAnimal(IAnimalListItem animal);

        void LoadAnimals();

        void SaveRepository(RepositorySaver saver);

        IEnumerable<IAnimalListItem> GetAnimalItems();
    }
}
