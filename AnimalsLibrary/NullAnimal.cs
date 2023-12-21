using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalsModel;

namespace AnimalsLibrary
{
    public class NullAnimal : AbstractAnimal
    {
        public NullAnimal() : base("Нет имени") { }

        /// <summary>
        /// Возвращает класс животного
        /// </summary>
        public override string Class => "Несуществующий класс";

        public override string ClassDefinition => "Определение отсутствует";

        /// <summary>
        /// Вызывает метод обратного вызова, дла обработки нулевого объекта
        /// </summary>
        /// <param name="list"></param>
        public override void AddYourselfToList(AnimalListDataSource dataSource) => dataSource.ShowNotAddedMessage();
    }
}
