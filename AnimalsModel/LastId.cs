using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsModel
{
    public class LastId
    {
        public event IdChangedEventHandler IdChanged;

        public LastId(IIdSerialize serializer) => id = serializer.Deserialize("lastId");

        private int id;

        public int Id
        {
            get { id++; IdChanged(); return id; }
        }

        public void Serialize(IIdSerialize serializer)
        {
            serializer.Serialize(id, "lastId");
        }
    }
}
