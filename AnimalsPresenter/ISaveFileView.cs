using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsView
{
    /// <summary>
    /// Интерфейс для объекта получения данных для сохранения файла
    /// </summary>
    public interface ISaveFileView
    {
        /// <summary>
        /// Возвращает путь для сохранения файла
        /// </summary>
        string FilePath { get; }

        /// <summary>
        /// Возаращает индекс выбранного пользователем формата
        /// </summary>
        int FilterIndex { get; }

        /// <summary>
        /// Возвращает значение, указывающее, были ли получены данные для сохранения файла - true, или нет - false
        /// </summary>
        bool DataReceived { get; }

        /// <summary>
        /// Открывает диалоговое окно для сохранения файла и инициализирует свойства полученными от пользователя данными
        /// </summary>
        /// <param name="filterStr"></param>
        void GetData(string filterStr);
    }
}
