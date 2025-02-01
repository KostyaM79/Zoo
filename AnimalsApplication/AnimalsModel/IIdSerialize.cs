using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsModel
{
    public interface IIdSerialize
    {
        int Deserialize(string fileName);

        void Serialize(int value, string fileName);
    }
}
