using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalsModel;

namespace AnimalsLibrary
{
    public class Reptile : AbstractAnimal
    {
        public Reptile(int id, string animalType, string name) : base(id, animalType, name) { }

        public override string Class => "Пресмыкающиеся";

        public override string ClassDefinition => AnimalDefinitions.ResourceManager.GetString("ReptileDef");
    }
}
