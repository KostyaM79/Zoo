using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalsModel;

namespace AnimalsLibrary
{
    /// <summary>
    /// Фабрика для создания птиц
    /// </summary>
    public class BirdFactory : IFactory
    {
        public string AnimalClassName => "Птицы";

        /// <summary>
        /// Создаёт новый экземпляр птицы
        /// </summary>
        /// <param name="animalType"></param>
        /// <returns></returns>
        public AbstractAnimal CreateAnimal(string animalType, string name, IRepository repo)
        {
            Bird bird = new Bird(-1, animalType, name);
            repo.AddAndGenerateId(bird);
            repo.Save();
            return bird;
        }

        public AbstractAnimal CreateAnimal(int id, string name, string animalType, IRepository repo)
        {
            Bird bird = new Bird(id, animalType, name);
            repo.Add(bird);
            repo.Save();
            return bird;
        }
    }
}
