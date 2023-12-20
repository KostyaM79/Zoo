using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalsModel;

namespace AnimalsLibrary
{
    /// <summary>
    /// Фабрика для создания экземпляров млекопитающих
    /// </summary>
    public class MammalFactory : IFactory
    {
        public string AnimalClassName => "Млекопитающие";

        /// <summary>
        /// Создаёт новый экземпляр млекопитающего
        /// </summary>
        /// <param name="animalType"></param>
        /// <returns></returns>
        public AbstractAnimal CreateAnimal(string animalType)
        {
            return new Mammal(animalType);
        }
    }
}
