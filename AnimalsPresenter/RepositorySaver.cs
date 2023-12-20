using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalsView;

namespace AnimalsPresenter
{
    public class RepositorySaver
    {
        private ISaveFileView saveFileViewObject;

        public RepositorySaver(ISaveFileView saveFileViewObject) => this.saveFileViewObject = saveFileViewObject;

        public void GetDataForSave(string filterStr)
        {
            saveFileViewObject.GetData(filterStr);
            FilterIndex = saveFileViewObject.FilterIndex;
            FilePath = saveFileViewObject.FilePath;
        }

        public int FilterIndex { get; private set; }
        public string FilePath { get; private set; }
    }
}
