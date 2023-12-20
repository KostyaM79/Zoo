using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnimalsView;
using AnimalsPresenter;
using AnimalsRepository;
using AnimalsLibrary;

namespace AnimalsApplication
{
    public partial class MainForm : Form, IView
    {
        //Удалить потом
        IEnumerable<IFactoryListItem> f;

        private readonly Presenter presenter;
        private readonly List<IAnimalListItem> animalItems = new List<IAnimalListItem>();

        public event NeedToApplyFilterEventHandler NeedToApplyFilter;       //Событие вызывается при необходимости отфильтровать список

        public MainForm()
        {
            InitializeComponent();

            SetUpListBox(animalsListBox, animalItems);                                  //Настраиваем ListBox1
            SetUpListBox(filteredAnimalsListBox, new List<IAnimalListItem>());          //Настраиваем ListBox2
            presenter = AnimalsApp.BuildSystem(this, new Repository(), new Library());  //Собираем систему
            NeedToApplyFilter += e => presenter.ApplyFilterToList(e.AnimalList, e.AnimalClassName);
        }

        #region Свойства
        public IFactoryListItem SelectedAnimalFactory => classesComboBox.SelectedItem as IFactoryListItem;

        /// <summary>
        /// Возвращает коллекцию фабрик для создания животных
        /// </summary>
        //public IEnumerable<IFactoryListItem> Factories { set => classesComboBox.DataSource = value.ToList(); }
        public IEnumerable<IFactoryListItem> Factories { set => f = value; }

        /// <summary>
        /// Задаёт или возвращает коллекцию животных
        /// </summary>
        public List<IAnimalListItem> Animals
        {
            get => animalsListBox.DataSource as List<IAnimalListItem>; //Возвращаем коллекцию животных
            set => AddAnimalsToList(value);                     //Добавляем коллекцию животных в listBox
        }

        /// <summary>
        /// Возвращает вид животного, введённый пользователем
        /// </summary>
        public string AnimalType => typeTextBox.Text;

        public IEnumerable<IAnimalListItem> AnimalListItems
        {
            set => (filteredAnimalsListBox.DataSource as BindingSource).DataSource = value;
        }

        public ISaveFileView SaveFileObj => new SaveFileDataObject();
        #endregion

        #region Обработчики событий
        /// <summary>
        /// Обработчик события Shown формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Shown(object sender, EventArgs e)
        {
            //Инициируем фильтрацию
            //NeedToApplyFilter(new NeedToApplyFilterEventArgs((classesComboBox.SelectedItem as FactoryItem).AnimalClassName, animalItems));

            if (classesComboBox.SelectedItem != null)
                NeedToApplyFilter(new NeedToApplyFilterEventArgs(classesComboBox.SelectedItem.ToString(), animalItems));
        }

        /// <summary>
        /// Обработчик события нажатия кнопки "Добавить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddButton_Click(object sender, EventArgs e) => AddNewAnimal();


        /// <summary>
        /// Обработчик события выбора элемента в списке классов животных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClassesComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //При выборе пользователем какого-либо класса животного,
            //сообщаем об этом в Presenter, чтобы тот передал отфильтрованные данные в listBox2

            //NeedToApplyFilter(new NeedToApplyFilterEventArgs((classesComboBox.SelectedItem as FactoryItem).AnimalClassName, animalItems));

            NeedToApplyFilter(new NeedToApplyFilterEventArgs(classesComboBox.SelectedItem.ToString(), animalItems));
        }

        /// <summary>
        /// Закрывает форму
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Инициирует сохранение репозитория в одном из форматов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            presenter.SaveAs();
        }
        #endregion

        #region Открытые методы
        /// <summary>
        /// Добавляет животное в listBox
        /// </summary>
        /// <param name="item"></param>
        public void AddAnimalToList(IAnimalListItem item)
        {
            animalItems.Add(item);                                                  //Добавляем животное к коллекции
            (animalsListBox.DataSource as BindingSource).ResetBindings(false);      //Обновляем источник данных в listBox
        }
        #endregion

        #region Закрытые методы
        /// <summary>
        /// Добавляет в listBox коллекцию животных
        /// </summary>
        /// <param name="items"></param>
        private void AddAnimalsToList(IEnumerable<IAnimalListItem> items)
        {
            animalItems.Clear();                                            //Очищаем источник данных listBox
            animalsListBox.BeginUpdate();                                         //Предотвращаем перерисовку listBox
            foreach (IAnimalListItem item in items) AddAnimalToList(item);  //Добавляем всех животных из переданной коллекции в listBox
            animalsListBox.EndUpdate();                                           //Возобновляем перерисовку listBox
        }

        /// <summary>
        /// Настраивает источник данных в listBox
        /// </summary>
        /// <param name="lb"></param>
        /// <param name="bs"></param>
        /// <param name="list"></param>
        private void SetUpListBox(ListBox lb, List<IAnimalListItem> list)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = list;       //Устанавливаем переданную коллекцию животных в качестве источника данных в объекте привязки данных
            lb.DataSource = bs;         //Добавляем объект привязки данных в lixtBox
        }

        /// <summary>
        /// Добавляет новое животное
        /// </summary>
        private void AddNewAnimal()
        {
            //Если все необходимые данные введены пользователем, добавляем новое животное
            if (presenter.ValidateData(classesComboBox.SelectedItem, typeTextBox.Text))
            {
                presenter.AddNewAnimal();                       //Добавляем новое животное на основе введённых данных

                NeedToApplyFilter(                              //Вызываем событие инициирующее фильтрацию второго списка животных
                    new NeedToApplyFilterEventArgs(             //
                        SelectedAnimalFactory.AnimalClassName,  //
                        animalItems));                          //

                typeTextBox.Clear();                            //Очищаем поле ввода вида животного
            }

            //Если не все необходимые данные введены, выводим соответствующее сообщение
            else MessageBox.Show("Не все обязательные поля заполнены!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        #endregion
    }
}
