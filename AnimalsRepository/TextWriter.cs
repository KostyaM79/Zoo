using AnimalsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AnimalsRepository
{
    /// <summary>
    /// Сохраняет репозиторий в формате txt
    /// </summary>
    public class TextWriter : IWriter
    {
        public string FileFilter => "Txt|*.txt";

        public void Write(List<AbstractAnimal> animals, string fileName)
        {
            List<string> strings = new List<string>();
            foreach (AbstractAnimal animal in animals)
            {
                strings.Add($"Класс: {animal.AnimalClassName} | Вид: {animal.AnimslType}");
            }

            File.WriteAllLines(fileName, strings);
        }
    }
}
