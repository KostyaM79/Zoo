using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalsPresenter;

namespace AnimalsModel
{
    /// <summary>
    /// Базовый класс для животных
    /// </summary>
    public abstract class AbstractAnimal : IAnimal
    {
        public AbstractAnimal(string name) => Name = name;

        public AbstractAnimal(int id, string animalType, string name)
        {
            Id = id;
            Type = animalType;
            Name = name;
        }

        /// <summary>
        /// Возвращает Id животного
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Возвращает имя животного
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Возвращает класс животного
        /// </summary>
        public abstract string Class { get; }

        /// <summary>
        /// Возвращает определение класса животного
        /// </summary>
        public abstract string ClassDefinition { get; }

        /// <summary>
        /// Возвращает вид животного
        /// </summary>
        public string Type { get; private set; }

        /// <summary>
        /// Добавляет данный экземпляр к коллекции
        /// </summary>
        /// <param name="list"></param>
        public virtual void AddYourselfToList(AnimalListDataSource dataSource)
        {
            dataSource.Add(this);
        }

        /// <summary>
        /// Устанавливает Id
        /// </summary>
        /// <param name="lastId"></param>
        public void SetId(LastId lastId) => Id = lastId.Id;

        public override string ToString() => $"{Class}: {Type}, {Name}";
    }
}
