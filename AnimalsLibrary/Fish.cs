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
        public override string AnimalClassName => "Рыбы";

        public Fish(string animalType) => AnimslType = animalType;
    }
}
