using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimalsView
{
    /// <summary>
    /// Получает данные от пользователя для сохранения файла
    /// </summary>
    public class SaveFileDataObject : ISaveFileView
    {
        private int index = 0;
        private string path = null;
        private bool dataReceived = false;

        /// <summary>
        /// Возвращает путь для сохранения файла
        /// </summary>
        public string FilePath => path;

        /// <summary>
        /// Возвращает индекс выбранного пользователем формата файла
        /// </summary>
        public int FilterIndex => index;

        public bool DataReceived => dataReceived;

        /// <summary>
        /// Получает данные от пользователя с использованием диалогового окна SaveFileDialog
        /// </summary>
        /// <param name="filterStr"></param>
        public void GetData(string filterStr)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = filterStr;
            sfd.FileName = "Repository";
            sfd.FileOk += (s, e) => SetProperties(sfd.FileName, sfd.FilterIndex);
            sfd.ShowDialog();
        }

        /// <summary>
        /// Инициализирует свойства полученными от пользователя данными
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="filterIndex"></param>
        private void SetProperties(string filePath, int filterIndex)
        {
            index = filterIndex;
            path = filePath;
            dataReceived = true;
        }
    }
}
