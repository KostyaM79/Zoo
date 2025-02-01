using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsPresenter
{
    /// <summary>
    /// Содержит метод для проверки введённых данных
    /// </summary>
    public class DataValidator
    {
        /// <summary>
        /// Возвращает true, если все необходимые данные введены. Иначе возвращает false
        /// </summary>
        /// <param name="selectedItem"></param>
        /// <param name="animalType"></param>
        /// <returns></returns>
        public bool Validate(object selectedItem, string animalType, string name)
        {
            return selectedItem != null && !string.IsNullOrEmpty(animalType) && !string.IsNullOrEmpty(name);
        }
    }
}
