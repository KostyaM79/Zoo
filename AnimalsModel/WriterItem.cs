using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalsRepository;
using AnimalsView;

namespace AnimalsPresenter
{
    /// <summary>
    /// Элемент списка писателей для отображения в списке
    /// </summary>
    public class WriterItem : IWriterItemBase
    {
        private readonly IWriter writer;

        public WriterItem(IWriter writer) => this.writer = writer;

        public string FileFilter => writer.FileFilter;

        public IWriter Writer => writer;
    }
}
