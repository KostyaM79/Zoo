using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalsModel;
using AnimalsView;

namespace AnimalsPresenter
{
    /// <summary>
    /// Класс-оболочка для животного.
    /// Необходим, чтобы можно было использовать свойства животного в пользовательском интерфейсе, который не имеет доступа к классам животных.
    /// </summary>
    public class AnimalItem : IAnimalListItem
    {
        private AbstractAnimal animal;      //Экземпляр животного

        public AnimalItem(AbstractAnimal animal) => this.animal = animal;

        /// <summary>
        /// //Возвращает класс животного (в контексте классификации животных)
        /// </summary>
        public string AnimalClassName => animal.AnimalClassName;

        /// <summary>
        /// //Возвращает вид животного
        /// </summary>
        public string AnimalType => animal.AnimslType;

        public AbstractAnimal Animal => animal;
    }
}
