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
    /// Класс Presentera для MVP
    /// </summary>
    public class Presenter
    {
        private IView view;                     //Экземпляр View
        private IModel model;                   //Экземпляр Model

        private readonly DataValidator dataValidator = new DataValidator();

        //Возвращает или задаёт Model
        public IModel Model
        {
            get => model;                               //Возвращаем model
            set
            {
                model = value;                          //Сохраняем model в закрытое поле
            }
        }

        /// <summary>
        /// Возвращает или задаёт view
        /// </summary>
        public IView View
        {
            get => view;                                                    //Возаращаем view
            set
            {
                view = value;                                               //Сохраняем view в закрытое поле
                view.Animals = LoadAnimals();                               //Передаём в view загруженную коллекцию животных
            }
        }

        /// <summary>
        /// Добавляет новое животное
        /// </summary>
        public void CreateNewAnimal()
        {
            model.CreateAnimal(view.SelectedAnimalClass, view.AnimalType, view.AnimalName, view, this);          //Создаём новое животное, используя фабрику
            view.UpdateAnimalList();
        }

        /// <summary>
        /// Загружает животных в репозиторий и возвращает коллекцию животных, обёрнутых в AnimalItem, чтобы её можно было использовать в пользовательском интерфейсе,
        /// т.к. он не имеет доступа к классам животных
        /// </summary>
        /// <returns></returns>
        public List<IAnimal> LoadAnimals()
        {
            Model.LoadAnimals();                                                                        //Загружаем животных
            List<IAnimal> items = model.GetAnimalItems();
            return items;                                                                               //Возвращаем коллекцию экземпляров AnimalItem
        }

        /// <summary>
        /// Сохраняет репозиторий в нужном формате
        /// </summary>
        public void SaveAs()
        {
            ISaveFileView saveFileViewObj = view.SaveFileObj;
            RepositorySaver saver = new RepositorySaver(saveFileViewObj);
            model.SaveRepository(saver);
        }

        /// <summary>
        /// Проверяет, все ли необходимые данные введены пользователем
        /// </summary>
        /// <param name="selectedItem"></param>
        /// <param name="animalType"></param>
        /// <returns></returns>
        public bool ValidateData(object selectedItem, string animalType, string name)
        {
            return dataValidator.Validate(selectedItem, animalType, name);
        }

        /// <summary>
        /// Применяет фильтр к списку
        /// </summary>
        /// <param name="list"></param>
        /// <param name="animalClassName"></param>
        public void ApplyFilterToList(List<IAnimal> list, string animalClassName)
        {
            List<IAnimal> items = (from item in list                                                    //Отбираем животных выбранного пользователем класса
                                   where (animalClassName == item.Class) select item).ToList();         //

            view.AnimalListItems = items.Count() > 0 ? items : null;
        }

        /// <summary>
        /// Получает определение класса животного
        /// </summary>
        public void GetClassDefinition() => view.ClassDefinition = view.SelectedAnimal.ClassDefinition;

        /// <summary>
        /// Удаляет животное
        /// </summary>
        public void DeleteAnimal()
        {
            view.DeleteAnimalFromList(view.SelectedAnimal);
            model.DeleteAnimal(view.SelectedAnimal);
        }
    }
}
