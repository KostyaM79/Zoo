using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsView
{
    /// <summary>
    /// Интерфейс класса-оболочки для писателя
    /// </summary>
    public interface IWriterItemBase
    {
        /// <summary>
        /// Возвращает строку фильтра для конкретного писателя
        /// </summary>
        string FileFilter { get; }
    }
}
