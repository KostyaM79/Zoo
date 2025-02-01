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
        public void CreateAnimal(string className, string animalType, string name, IView view, Presenter presenter)
        {
            IFactory factory = GetFactory(className);
            AbstractAnimal animal = factory.CreateAnimal(animalType, name, Repository);
            animal.AddYourselfToList(new AnimalListDataSource(view));
        }

        /// <summary>
        /// Удаляет животное из репозитория
        /// </summary>
        /// <param name="animal"></param>
        public void DeleteAnimal(IAnimal animal)
        {
            Repository.Delete(animal as AbstractAnimal);
        }

        /// <summary>
        /// Возвращает фабрику, соответствующую переданному классу животного
        /// </summary>
        /// <param name="animalClass"></param>
        /// <returns></returns>
        private IFactory GetFactory(string animalClass)
        {
            IFactory factory = AnimalLibrary.GetNullFactory();
            IEnumerable<IFactory> factories = AnimalLibrary.GetFactoryCollection();
            foreach (IFactory f in factories)
                if (f.AnimalClassName == animalClass) factory = f;
            return factory;
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
            if (saver.GetDataForSave(filterStr))
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
    }
}
