using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalsPresenter;

namespace AnimalsView
{
    /// <summary>
    /// Аргументы для события, возникающего при необходимости фильтрации списка
    /// </summary>
    public class NeedToApplyFilterEventArgs : EventArgs
    {
        public NeedToApplyFilterEventArgs(string animalClassName, List<IAnimal> items)
        {
            AnimalClassName = animalClassName;
            AnimalList = items;
        }

        /// <summary>
        /// Возвращает коллекцию животных
        /// </summary>
        public List<IAnimal> AnimalList { get; private set; }

        /// <summary>
        /// Возвращает название класса животного
        /// </summary>
        public string AnimalClassName { get; private set; }
    }
}
