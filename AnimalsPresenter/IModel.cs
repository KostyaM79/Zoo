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
        void CreateAnimal(IFactoryListItem factory, string animalType, List<string>list);

        IEnumerable<IFactoryListItem> GetFactories();

        IFactoryListItem GetNullFactory();

        void LoadAnimals();

        void SaveRepository(RepositorySaver saver);

        List<string> GetAnimalItems();

        string GetAnimalClass(string animalType);
    }
}
