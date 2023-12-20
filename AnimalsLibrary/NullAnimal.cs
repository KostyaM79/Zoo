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
        public override string AnimalClassName => "Несуществующий класс";

        public override void AddYourselfToList(List<string> list) { }
    }
}
