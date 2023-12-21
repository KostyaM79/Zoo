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
        public AbstractAnimal CreateAnimal(string animalType, string name, IRepository repo)
        {
            Mammal mammal = new Mammal(-1, animalType, name);
            repo.AddAndGenerateId(mammal);
            repo.Save();
            return mammal;
        }

        public AbstractAnimal CreateAnimal(int id, string name, string animalType, IRepository repo)
        {
            Mammal mammal = new Mammal(id, animalType, name);
            repo.Add(mammal);
            repo.Save();
            return mammal;
        }
    }
}
