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
                view.Animals = LoadAnimals().ToList<IAnimalListItem>();     //Передаём в view загруженную коллекцию животных
            }
        }

        /// <summary>
        /// Добавляет новое животное
        /// </summary>
        public void AddNewAnimal()
        {
            IEnumerable<IFactoryListItem> factories = model.GetFactories();
            IFactoryListItem concreteFactory = model.GetNullFactory();
            
            foreach (IFactoryListItem fac in factories)
                if (fac.AnimalClassName == view.SelectedAnimalClass) concreteFactory = fac;

            IAnimalListItem animal = model.CreateAnimal(concreteFactory, view.AnimalType);
            view.AddAnimalToList(animal);
        }

        /// <summary>
        /// Возвращает коллекцию фабрик, обёрнутых в FactoryItem, чтобы её можно было использовать в пользовательском интерфейсе,
        /// т.к. он не имеет доступа к классам фабрик
        /// </summary>
        /// <returns></returns>
        private IEnumerable<IFactoryListItem> GetListItems()
        {
            IEnumerable<IFactoryListItem> factories = Model.GetFactories();                         //Получаем коллекцию фабрик из Model
            return factories;                                                                   //Возвращаем коллекцию экземпляров FactoryItem
        }

        /// <summary>
        /// Загружает животных в репозиторий и возвращает коллекцию животных, обёрнутых в AnimalItem, чтобы её можно было использовать в пользовательском интерфейсе,
        /// т.к. он не имеет доступа к классам животных
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IAnimalListItem> LoadAnimals()
        {
            Model.LoadAnimals();                                                                        //Загружаем животных
            IEnumerable<IAnimalListItem> items = model.GetAnimalItems();
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
        public bool ValidateData(object selectedItem, string animalType)
        {
            return dataValidator.Validate(selectedItem, animalType);
        }

        public void ApplyFilterToList(List<IAnimalListItem>list, string animalClassName)
        {
            IEnumerable<IAnimalListItem> items = from item in list                                  //Отбираем животных выбранного пользователем класса
                                                 where (item.AnimalClassName == animalClassName)    //
                                                 select item;                                       //

            view.AnimalListItems = items.Count() > 0 ? items : null;
        }
    }
}
