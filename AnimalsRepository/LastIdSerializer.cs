using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using AnimalsModel;


namespace AnimalsRepository
{
    public class LastIdSerializer : IIdSerialize
    {
        public void Serialize(int id, string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(id);
            }
        }

        public int Deserialize(string fileName)
        {
            if (File.Exists(fileName))
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Open))
                {
                    BinaryReader br = new BinaryReader(fs);
                    return br.ReadInt32();
                }
            }

            else return -1;
        }
    }
}
