using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsModel
{
    /// <summary>
    /// Представляет генератор Id
    /// </summary>
    public class LastId
    {
        public event IdChangedEventHandler IdChanged;

        public LastId(IIdSerialize serializer) => id = serializer.Deserialize("lastId");

        private int id;

        /// <summary>
        /// Возвращает Id. При каждом обращении к данному свойству увеличивает Id на 1
        /// </summary>
        public int Id
        {
            get { id++; IdChanged(); return id; }
        }

        /// <summary>
        /// Сохраняет Id в файл
        /// </summary>
        /// <param name="serializer"></param>
        public void Serialize(IIdSerialize serializer)
        {
            serializer.Serialize(id, "lastId");
        }
    }
}
