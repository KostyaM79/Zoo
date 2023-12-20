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
        public Bird(string animalType) => AnimslType = animalType;

        public override string AnimalClassName => "Птицы";
    }
}
