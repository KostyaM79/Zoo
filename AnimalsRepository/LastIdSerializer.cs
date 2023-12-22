using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using AnimalsModel;


namespace AnimalsRepository
{
    /// <summary>
    /// Сохраняет и загружает последнее значение Id
    /// </summary>
    public class LastIdSerializer : IIdSerialize
    {
        /// <summary>
        /// Сохраняет Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fileName"></param>
        public void Serialize(int id, string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(id);
            }
        }

        /// <summary>
        /// Загружает Id
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
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
