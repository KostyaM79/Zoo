using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalsRepository;

namespace AnimalsModel
{
    /// <summary>
    /// Интерфейс для репозитория
    /// </summary>
    public interface IRepository
    {
        void Add(AbstractAnimal animal);

        List<AbstractAnimal> Animals { get; }

        void Save();

        void Load(Model model);

        IEnumerable<IWriter> GetWriters();
    }
}
