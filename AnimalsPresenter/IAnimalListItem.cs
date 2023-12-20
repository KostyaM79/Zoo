using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsView
{
    /// <summary>
    /// Интерфейс для класса-оболочки животного
    /// </summary>
    public interface IAnimalListItem
    {
        /// <summary>
        /// Возвращает класс животного
        /// </summary>
        string AnimalClassName { get; }

        /// <summary>
        /// Возаращает вид животного
        /// </summary>
        string AnimalType { get; }
    }
}
