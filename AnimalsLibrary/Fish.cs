using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalsModel;

namespace AnimalsLibrary
{
    /// <summary>
    /// Класс рыбы
    /// </summary>
    public class Fish : AbstractAnimal
    {
        public override string Class => "Рыбы";

        public override string ClassDefinition => AnimalDefinitions.ResourceManager.GetString("FishDef");

        public Fish(int id, string animalType, string name) : base(id, animalType, name) { }
    }
}
