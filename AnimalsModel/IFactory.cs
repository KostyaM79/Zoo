using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsModel
{
    /// <summary>
    /// Абстрактная фабрика
    /// </summary>
    public interface IFactory
    {
        AbstractAnimal CreateAnimal(string animalType);

        string AnimalClassName { get; }
    }
}
