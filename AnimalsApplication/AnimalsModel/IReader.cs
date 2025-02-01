using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalsModel;

namespace AnimalsRepository
{
    /// <summary>
    /// Интерфейс загрузчика данных
    /// </summary>
    public interface IReader
    {
        void Read(IRepository animals, Model model, string fileName);
    }
}
