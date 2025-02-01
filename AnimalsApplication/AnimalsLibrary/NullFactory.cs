using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalsModel;

namespace AnimalsLibrary
{
    public class NullFactory : IFactory
    {
        /// <summary>
        /// Возвращает класс животного, экземпляры которого создаются фабрикой
        /// </summary>
        public string AnimalClassName => "Отсутствующий класс животного";

        /// <summary>
        /// Возвращает нулевой объект животного
        /// </summary>
        /// <param name="animalType"></param>
        /// <param name="repo"></param>
        /// <returns></returns>
        public AbstractAnimal CreateAnimal(string animalType,string name, IRepository repo)
        {
            return new NullAnimal();
        }

        public AbstractAnimal CreateAnimal(int id, string name, string animalType, IRepository repo)
        {
            return new NullAnimal();
        }
    }
}
