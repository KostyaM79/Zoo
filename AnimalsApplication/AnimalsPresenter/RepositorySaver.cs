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

        /// <summary>
        /// Получает от пользователя данные для сохранения репозитория
        /// </summary>
        /// <param name="filterStr"></param>
        public bool GetDataForSave(string filterStr)
        {
            saveFileViewObject.GetData(filterStr);
            FilterIndex = saveFileViewObject.FilterIndex;
            FilePath = saveFileViewObject.FilePath;
            return saveFileViewObject.DataReceived;
        }

        /// <summary>
        /// Возвращает индекс формата файла, полученный от пользователя
        /// </summary>
        public int FilterIndex { get; private set; }

        /// <summary>
        /// Возвращает путь для сохранения
        /// </summary>
        public string FilePath { get; private set; }
    }
}
