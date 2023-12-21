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
        IAnimal CreateAnimal(IFactoryListItem factory, string animalType, string name, List<IAnimal>list, Presenter presenter);

        IEnumerable<IFactoryListItem> GetFactories();

        IFactoryListItem GetNullFactory();

        IFactoryListItem GetFactory(string animalClass);

        void LoadAnimals();

        void SaveRepository(RepositorySaver saver);

        List<IAnimal> GetAnimalItems();

        string GetAnimalClass(string animalType);

        string GetAnimalClassDefinition(string animalType);
    }
}
