using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalsModel;

namespace AnimalsLibrary
{
    public class ReptileFactory : IFactory
    {
        public string AnimalClassName => "Пресмыкающиеся";

        public AbstractAnimal CreateAnimal(string animalType, string name, IRepository repo)
        {
            Reptile reptile = new Reptile(-1, animalType, name);
            repo.AddAndGenerateId(reptile);
            repo.Save();
            return reptile;
        }

        public AbstractAnimal CreateAnimal(int id, string name, string animalType, IRepository repo)
        {
            Reptile reptile = new Reptile(id, animalType, name);
            repo.Add(reptile);
            repo.Save();
            return reptile;
        }
    }
}
