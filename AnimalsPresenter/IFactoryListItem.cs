using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsView
{
    /// <summary>
    /// Интерфейс для класса-оболочки фабрики
    /// </summary>
    public interface IFactoryListItem
    {
        /// <summary>
        /// Возвращает класс животного, которое создаётся фабрикой
        /// </summary>
        string AnimalClassName { get; }
    }
}
