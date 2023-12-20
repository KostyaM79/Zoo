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
        public string AnimalClassName => "Отсутствующий класс животного";

        public AbstractAnimal CreateAnimal(string animalType, IRepository repo)
        {
            return null;
        }
    }
}
