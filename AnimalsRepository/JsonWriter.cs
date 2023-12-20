using AnimalsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace AnimalsRepository
{
    /// <summary>
    /// Сохраняет репозиторий в формате json
    /// </summary>
    public class JsonWriter : IWriter
    {
        public string FileFilter => "Json|*.json";

        public void Write(List<AbstractAnimal> animals, string fileName)
        {
            string json = JsonConvert.SerializeObject(animals);
            using (FileStream fs = File.Create(fileName))
            {
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(json);
                sw.Close();
            }
        }
    }
}
