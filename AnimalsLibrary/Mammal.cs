using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalsModel;

namespace AnimalsLibrary
{
    /// <summary>
    /// Класс Млекопитающие
    /// </summary>
    public class Mammal : AbstractAnimal
    {
        public Mammal(string animalType) => AnimslType = animalType;

        public override string AnimalClassName => "Млекопитающие";
    }
}
