using AnimalsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace AnimalsRepository
{
    /// <summary>
    /// Сохраняет репозиторий в формате xml
    /// </summary>
    internal class XmlWriter : IWriter
    {
        public string FileFilter => "Xml|*.xml";

        /// <summary>
        /// Сохраняет репозиторий в XML-файл
        /// </summary>
        /// <param name="animals"></param>
        public void Write(List<AbstractAnimal> animals, string fileName)
        {
            XmlDocument doc = new XmlDocument();                                //Создаём XML-документ
            doc.AppendChild(doc.CreateElement("Animals"));                      //Добавляем корневой элемент Animals

            //В цикле перебираем животных
            foreach (AbstractAnimal a in animals)
            {
                XmlElement element = GetNode(doc.DocumentElement, a.Class);     //Ищем узел, соответствующий классу животного

                //Если узел не найден, создаём новый и добавляем его в XML-документ
                if (element == null)
                {
                    element = doc.CreateElement(a.Class);                       //Если узел не найден, создаём новый
                    doc.DocumentElement.AppendChild(element);                   //Добавляем созданный узел в XML-документ
                }

                XmlElement animalElement = doc.CreateElement("Animal");         //Создаём узел Animal
                XmlAttribute idAttr = doc.CreateAttribute("Id");                //Создаём атрибут Id
                XmlAttribute nameAttr = doc.CreateAttribute("Name");            //Создаём атрибут Name
                XmlAttribute typeAttr = doc.CreateAttribute("AnimalType");      //Создаём атрибут AnimalType

                idAttr.Value = a.Id.ToString();                                 //Присваиваем атрибуту Id значение
                nameAttr.Value = a.Name;                                        //Присваиваем атрибуту Name значение
                typeAttr.Value = a.Type;                                        //Присваиваем атрибуту AnimalType значение

                animalElement.Attributes.Append(idAttr);                        //Добавляем атрибут Id к узлу Animal
                animalElement.Attributes.Append(nameAttr);                      //Добавляем атрибут Name к узлу Animal
                animalElement.Attributes.Append(typeAttr);                      //Добавляем атрибут AnimalClass к узлу Animal
                element.AppendChild(animalElement);                             //Добавляем узел Animal в XML-документ
            }

            doc.Save(fileName);                                                 //Сохраняем XML-документ
        }

        /// <summary>
        /// Получает и возвращает узел XML-документа по имени. Если узел не нейден, возвращает null.
        /// </summary>
        /// <param name="rootElement"></param>
        /// <param name="nodeName"></param>
        /// <returns></returns>
        private XmlElement GetNode(XmlElement rootElement, string nodeName)
        {
            //Перебираем все узлы в корневом элементе XML-документа
            foreach(XmlElement element in rootElement.ChildNodes)
            {
                if (element.Name == nodeName) return element;   //Если узел найден, возвращаем его
            }
            return null;                                        //Если цикл закончился, а искомый узел не найден, возвращаем null
        }
    }
}
