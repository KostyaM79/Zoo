using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalsModel;

namespace AnimalsPresenter
{
    public interface IAnimal
    {
        int Id { get; }
        string Name { get; }
        string Class { get; }
        string Type { get; }
        string ClassDefinition { get; }
    }
}
