using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalsModel;

namespace AnimalsRepository
{
    /// <summary>
    /// Интерфейс писателя
    /// </summary>
    public interface IWriter
    {
        string FileFilter { get; }

        void Write(List<AbstractAnimal> animals, string fileName);
    }
}
