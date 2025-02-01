using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsModel
{
    /// <summary>
    /// Интерфейс для библиотеки классов животных
    /// </summary>
    public interface IAnimalLibrary
    {
        IEnumerable<IFactory> GetFactoryCollection();

        IFactory GetNullFactory();
    }
}
