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
        public IAnimal CreateAnimal(IFactoryListItem factoryItem, string animalType, string name, List<IAnimal> list, Presenter presenter)
        {
            return (factoryItem as FactoryItem).Factory.CreateAnimal(animalType, name, Repository);
        }

        /// <summary>
        /// Возвращает коллекцию фабрик для создания животных
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IFactoryListItem> GetFactories() => AnimalLibrary.GetFactoryCollection().Select(e => new FactoryItem(e));

        /// <summary>
        /// Возвращает нулевую фабрику
        /// </summary>
        /// <returns></returns>
        public IFactoryListItem GetNullFactory() => new FactoryItem(AnimalLibrary.GetNullFactory());

        public IFactoryListItem GetFactory(string animalClass)
        {
            IFactory factory = AnimalLibrary.GetNullFactory();
            IEnumerable<IFactory> factories = AnimalLibrary.GetFactoryCollection();
            foreach (IFactory f in factories)
                if (f.AnimalClassName == animalClass) factory = f;
            return new FactoryItem(factory);
        }

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

        /// <summary>
        /// Возвращает список животных, созданный на основе репозитория
        /// </summary>
        /// <returns></returns>
        public List<IAnimal> GetAnimalItems()
        {
            //return Repository.Animals.Select(e => e.Type).ToList();
            return Repository.Animals.Select(e => e as IAnimal).ToList();
        }

        /// <summary>
        /// Создаёт и возвращает строку фильтра для диалога сохранения файла
        /// </summary>
        /// <param name="writers"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Определяет класс животного по его виду
        /// </summary>
        /// <param name="animalType"></param>
        /// <returns></returns>
        public string GetAnimalClass(string animalType)
        {
            foreach (AbstractAnimal a in Repository.Animals)
                if (a.Type == animalType) return a.Class;

            return "";
        }

        public string GetAnimalClassDefinition(string animalType)
        {
            return Repository.GetAnimal(animalType).ClassDefinition;
        }
    }
}
