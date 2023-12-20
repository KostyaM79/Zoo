using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalsRepository;
using AnimalsPresenter;
using AnimalsView;

namespace AnimalsModel
{
    /// <summary>
    /// Модель
    /// </summary>
    public class Model : IModel
    {
        public Model(IRepository repo, IAnimalLibrary lib)
        {
            Repository = repo;
            AnimalLibrary = lib;
        }

        /// <summary>
        /// Возвращает или задаёт репозиторий
        /// </summary>
        public IRepository Repository { get; set; }

        /// <summary>
        /// Возвращает или задаёт библиотеку животных
        /// </summary>
        public IAnimalLibrary AnimalLibrary { get; set; }

        /// <summary>
        /// Возвращает конкретное животное
        /// </summary>
        /// <param name="factoryItem"></param>
        /// <param name="animalType"></param>
        /// <returns></returns>
        public IAnimalListItem CreateAnimal(IFactoryListItem factoryItem, string animalType)
        {
            AbstractAnimal animal = (factoryItem as FactoryItem).Factory.CreateAnimal(animalType, Repository);
            return new AnimalItem(animal);
        }

        /// <summary>
        /// Возвращает коллекцию фабрик для создания животных
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IFactoryListItem> GetFactories() => AnimalLibrary.GetFactoryCollection().Select(e => new FactoryItem(e));

        public IFactoryListItem GetNullFactory() => new FactoryItem(AnimalLibrary.GetNullFactory());

        /// <summary>
        /// Загружает всех животных в репозиторий
        /// </summary>
        public void LoadAnimals() => Repository.Load(this);

        /// <summary>
        /// Сохраняет репозиторий, используя переданного писателя
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="filePath"></param>
        public void SaveRepository(RepositorySaver saver)
        {
            IEnumerable<IWriter> writers = Repository.GetWriters();
            string filterStr = GetFilterString(writers);
            saver.GetDataForSave(filterStr);
            writers.ElementAt(saver.FilterIndex - 1).Write(Repository.Animals, saver.FilePath);
        }

        public IEnumerable<IAnimalListItem> GetAnimalItems()
        {
            return Repository.Animals.Select(e => new AnimalItem(e));
        }

        private string GetFilterString(IEnumerable<IWriter> writers)
        {
            StringBuilder sb = new StringBuilder();
            int count = writers.Count();

            for (int i = 0; i < count; i++)
            {
                sb.Append(writers.ElementAt(i).FileFilter);
                if (i < count - 1) sb.Append("|");
            }

            return sb.ToString();
        }
    }
}
