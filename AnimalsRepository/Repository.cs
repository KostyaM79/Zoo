using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using AnimalsModel;

namespace AnimalsRepository
{
    /// <summary>
    /// Класс репозитория
    /// </summary>
    public class Repository : IRepository
    {
        private readonly List<AbstractAnimal> animals = new List<AbstractAnimal>();     //Коллекция животных
        private readonly IWriter saver = new XmlWriter();                               //Экземпляр писателя
        private readonly IReader loader = new XmlReader();                              //Экземпляр загрузчика
        private readonly LastId lastId;

        public Repository()
        {
            LastIdSerializer lastIdSerializer = new LastIdSerializer();
            lastId = new LastId(new LastIdSerializer());                            //Загружаем значение lastId, если оно сохранено, иначе будет создан новый lastId
            lastId.IdChanged += () => lastId.Serialize(new LastIdSerializer());     //При каждом изменении счётчика, lastId будет сохранён
        }

        /// <summary>
        /// Возвращает коллекцию животных
        /// </summary>
        public List<AbstractAnimal> Animals => animals;

        /// <summary>
        /// Добавляет животное в коллекцию и генерирует ему новый Id
        /// </summary>
        /// <param name="animal"></param>
        public void AddAndGenerateId(AbstractAnimal animal)
        {
            animal.SetId(lastId);       //Добавляем Id
            animals.Add(animal);        //Добавляем животное в репозиторий
        }

        /// <summary>
        /// Добавляет животное в коллекцию
        /// </summary>
        /// <param name="animal"></param>
        public void Add(AbstractAnimal animal)
        {
            animals.Add(animal);        //Добавляем животное в репозиторий
        }

        /// <summary>
        /// Удаляет животное
        /// </summary>
        /// <param name="animal"></param>
        public void Delete(AbstractAnimal animal)
        {
            animals.Remove(animal);
            Save();
        }

        /// <summary>
        /// Сохраняет коллекцию животных.
        /// Источник данных определяется конкретным писателем.
        /// </summary>
        public void Save() => saver.Write(animals, "FileAnimals.xml");

        /// <summary>
        /// Загружает животных.
        /// Источник данных определяется конкретным загрузчиком.
        /// </summary>
        /// <param name="model"></param>
        public void Load(Model model) => loader.Read(this, model, "FileAnimals.xml");

        /// <summary>
        /// Создаёт и возвращает коллекцию писателей
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IWriter> GetWriters()
        {
            List<IWriter> writers = new List<IWriter>();
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type[] types = assembly.GetTypes();
            IEnumerable<Type> resultTypes = types.Where(e => e.GetInterface("IWriter") != null);
            foreach (Type t in resultTypes)
            {
                writers.Add(t.GetConstructor(new Type[] { }).Invoke(new object[] { }) as IWriter);
            }
            return writers;
        }
    }
}
