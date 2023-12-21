using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using AnimalsModel;

namespace AnimalsRepository
{
    /// <summary>
    /// XML-загрузчик
    /// </summary>
    public class XmlReader : IReader
    {
        /// <summary>
        /// Загружает данные в коллекцию из XML-файла
        /// </summary>
        /// <param name="animals"></param>
        /// <param name="model"></param>
        public void Read(IRepository animals, Model model, string fileName)
        {
            animals.Animals.Clear();                                                                //Очищаем коллекцию
            XmlDocument doc = new XmlDocument();                                                    //Создаём Xml-документ

            //Если файл существует, загружаем из него данные
            if (File.Exists(fileName))
            {
                doc.Load(fileName);                                                                 //Загружаем данные в Xml-документ
                IEnumerable<IFactory> factories = model.AnimalLibrary.GetFactoryCollection();       //Получаем коллекцию фабрик из model
                CreateAllAnimals(doc, factories, animals);                                          //Создаём животных
            }
        }

        /// <summary>
        /// Создаёт животных и добавляет их в репозиторий
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="factories"></param>
        /// <param name="animals"></param>
        private void CreateAllAnimals(XmlDocument doc, IEnumerable<IFactory> factories, IRepository animals)
        {
            //В цикле перебираем все узлы Xml-документа, соответствующие классам животных
            foreach (XmlElement el in doc.DocumentElement.ChildNodes)
            {
                IFactory factory = factories.First(e => e.AnimalClassName == el.Name);          //Для каждого животного находим соответствующую фабрику
                CreateAnimalsOfClass(animals, el, factory);                                     //Создаём животного соответствующего класса
            }
        }

        /// <summary>
        /// Создаёт животных определённого класса
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="el"></param>
        /// <param name="factory"></param>
        private void CreateAnimalsOfClass(IRepository repo, XmlElement el, IFactory factory)
        {
            //В цикле перебираем всех животных данного класса
            foreach (XmlElement e in el.ChildNodes)
            {
                //По каждой записи создаём экземпляр животного
                factory.CreateAnimal(
                    int.Parse(e.Attributes["Id"].Value),
                    e.Attributes["Name"].Value,
                    e.Attributes["AnimalType"].Value,
                    repo);
            }
        }
    }
}
