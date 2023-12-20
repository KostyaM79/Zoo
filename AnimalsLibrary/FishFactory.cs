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
        public AbstractAnimal CreateAnimal(string animalType, IRepository repo)
        {
            Fish fish = new Fish(animalType);
            repo.Add(fish);
            repo.Save();
            return fish;
        }
    }
}
