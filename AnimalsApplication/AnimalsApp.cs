using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalsPresenter;
using AnimalsModel;
using AnimalsView;

namespace AnimalsApplication
{
    /// <summary>
    /// Содержит статический метод для создания Presenter
    /// </summary>
    internal static class AnimalsApp
    {
        /// <summary>
        /// Возвращает инициализированный объект Presenter
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        internal static Presenter BuildSystem(IView form, IRepository repo, IAnimalLibrary lib)
        {
            return new Presenter()
            {
                Model = new Model(repo, lib),
                View = form
            };
        }
    }
}
