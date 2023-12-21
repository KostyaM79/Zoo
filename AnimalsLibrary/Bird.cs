using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalsModel;

namespace AnimalsLibrary
{
    /// <summary>
    /// Класс Птицы
    /// </summary>
    public class Bird : AbstractAnimal
    {
        public Bird(int id, string animalType, string name) : base(id, animalType, name) { }

        public override string Class => "Птицы";

        public override string ClassDefinition => AnimalDefinitions.ResourceManager.GetString("BirdDef");
    }
}
