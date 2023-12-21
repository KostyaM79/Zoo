using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalsModel;

namespace AnimalsLibrary
{
    /// <summary>
    /// Фабрика для создания рыб
    /// </summary>
    public class FishFactory : IFactory
    {
        public string AnimalClassName => "Рыбы";

        /// <summary>
        /// Создаёт новый экземпляр рыбы
        /// </summary>
        /// <param name="animalType"></param>
        /// <returns></returns>
        public AbstractAnimal CreateAnimal(string animalType, string name, IRepository repo)
        {
            Fish fish = new Fish(-1, animalType, name);
            repo.AddAndGenerateId(fish);
            repo.Save();
            return fish;
        }

        public AbstractAnimal CreateAnimal(int id, string name, string animalType, IRepository repo)
        {
            Fish fish = new Fish(id, animalType, name);
            repo.Add(fish);
            repo.Save();
            return fish;
        }
    }
}
