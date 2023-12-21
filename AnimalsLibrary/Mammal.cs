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
        public Mammal(int id, string animalType, string name) : base(id, animalType, name) { }

        public override string Class => "Млекопитающие";

        public override string ClassDefinition => AnimalDefinitions.ResourceManager.GetString("MammalDef");
    }
}
