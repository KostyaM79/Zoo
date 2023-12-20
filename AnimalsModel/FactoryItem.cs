using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalsView;
using AnimalsModel;

namespace AnimalsPresenter
{
    /// <summary>
    /// Класс-оболочка для фабрики.
    /// Необходим, чтобы можно было использовать свойства фабрики в пользовательском интерфейсе, который не имеет доступа к классам фабрик.
    /// </summary>
    public class FactoryItem : IFactoryListItem
    {
        private readonly IFactory factory;                                      //Экземпляр фабрики

        public FactoryItem(IFactory factory)
        {
            this.factory = factory;
        }

        /// <summary>
        /// Возаращает класс животных, экземпляры которых создаёт данная фабрика
        /// </summary>
        public string AnimalClassName => factory.AnimalClassName;

        /// <summary>
        /// Возвращает интерфейс фабрики
        /// </summary>
        public IFactory Factory => factory;
    }
}
