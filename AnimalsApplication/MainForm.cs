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
        private readonly Presenter presenter;
        private readonly List<IAnimal> animalListItems = new List<IAnimal>();
        private IAnimal selectedAnimal;

        public event NeedToApplyFilterEventHandler NeedToApplyFilter;           //Событие вызывается при необходимости отфильтровать список

        public MainForm()
        {
            InitializeComponent();

            SetUpListBox(animalsListBox, animalListItems);                                              //Настраиваем ListBox1

            SetUpListBox(filteredListBox, new List<IAnimal>());                                         //Настраиваем ListBox2
            presenter = AnimalsApp.BuildSystem(this, new Repository(), new Library());                  //Собираем систему
            NeedToApplyFilter += e => presenter.ApplyFilterToList(e.AnimalList, e.AnimalClassName);
        }

        //--------------------------------------------------------------------------------------------------------------
        #region Свойства
        public string SelectedAnimalClass => classesComboBox.SelectedItem.ToString();

        /// <summary>
        /// Задаёт или возвращает коллекцию животных
        /// </summary>
        public List<IAnimal> Animals
        {
            get => animalListItems;                     //Возвращаем коллекцию животных
            set => AddAnimalsToList(value);         //Добавляем коллекцию животных в listBox
        }

        /// <summary>
        /// Возвращает вид животного, введённый пользователем
        /// </summary>
        public string AnimalType => typeTextBox.Text;

        public List<IAnimal> AnimalListItems
        {
            set => (filteredListBox.DataSource as BindingSource).DataSource = value;
        }

        public ISaveFileView SaveFileObj => new SaveFileDataObject();

        public string ClassDefinition
        {
            get => label3.Text;
            set => label3.Text = value;
        }

        public IAnimal SelectedAnimal => selectedAnimal;

        public string AnimalName => nameTextBox.Text;
        #endregion

        //--------------------------------------------------------------------------------------------------------------
        #region Обработчики событий
        /// <summary>
        /// Обработчик события Shown формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Shown(object sender, EventArgs e)
        {
            //Инициируем фильтрацию
            if (classesComboBox.SelectedItem != null)
                NeedToApplyFilter(new NeedToApplyFilterEventArgs(classesComboBox.SelectedItem.ToString(), animalListItems));
        }

        /// <summary>
        /// Обработчик события нажатия кнопки "Добавить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddButton_Click(object sender, EventArgs e) => CreateNewAnimal();

        /// <summary>
        /// Обрабатывает нажатие кнопки "Удалить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            presenter.DeleteAnimal();
            if (classesComboBox.SelectedItem != null)
                NeedToApplyFilter(new NeedToApplyFilterEventArgs(classesComboBox.SelectedItem.ToString(), animalListItems));
        }


        /// <summary>
        /// Обработчик события выбора элемента в списке классов животных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClassesComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //При выборе пользователем какого-либо класса животного,
            //сообщаем об этом в Presenter, чтобы тот передал отфильтрованные данные в listBox2
            NeedToApplyFilter(new NeedToApplyFilterEventArgs(classesComboBox.SelectedItem.ToString(), animalListItems));
        }

        /// <summary>
        /// Закрывает форму
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, EventArgs e) => Close();

        /// <summary>
        /// Инициирует сохранение репозитория в одном из форматов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, EventArgs e) => presenter.SaveAs();

        /// <summary>
        /// Обрабатывает выбор животного в любом из списков
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void animalsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox lb = sender as ListBox;
            GetClassDefinition(lb);
        }
        #endregion

        //--------------------------------------------------------------------------------------------------------------
        #region Открытые методы
        public void AddAnimalToList(IAnimal animal)
        {
            animalListItems.Add(animal);                                            //Добавляем животное к коллекции
            (animalsListBox.DataSource as BindingSource).ResetBindings(false);      //Обновляем источник данных в listBox
        }

        public void DeleteAnimalFromList(IAnimal animal)
        {
            animalListItems.Remove(animal);
            (animalsListBox.DataSource as BindingSource).ResetBindings(false);
        }

        public void UpdateAnimalList() => (animalsListBox.DataSource as BindingSource).ResetBindings(false);

        public void ShowMessage(string message) => MessageBox.Show(message);
        #endregion

        //--------------------------------------------------------------------------------------------------------------
        #region Закрытые методы
        /// <summary>
        /// Добавляет в listBox коллекцию животных
        /// </summary>
        /// <param name="items"></param>
        private void AddAnimalsToList(IEnumerable<IAnimal> items)
        {
            animalListItems.Clear();                                    //Очищаем источник данных listBox
            animalsListBox.BeginUpdate();                           //Предотвращаем перерисовку listBox
            foreach (IAnimal item in items) AddAnimalToList(item);  //Добавляем всех животных из переданной коллекции в listBox
            animalsListBox.EndUpdate();                             //Возобновляем перерисовку listBox
        }

        /// <summary>
        /// Настраивает источник данных в listBox
        /// </summary>
        /// <param name="lb"></param>
        /// <param name="bs"></param>
        /// <param name="list"></param>
        private void SetUpListBox(ListBox lb, List<IAnimal> list)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = list;       //Устанавливаем переданную коллекцию животных в качестве источника данных в объекте привязки данных
            lb.DataSource = bs;         //Добавляем объект привязки данных в lixtBox
        }

        /// <summary>
        /// Добавляет новое животное
        /// </summary>
        private void CreateNewAnimal()
        {
            //Если все необходимые данные введены пользователем, добавляем новое животное
            if (presenter.ValidateData(classesComboBox.SelectedItem, typeTextBox.Text, nameTextBox.Text))
            {
                presenter.CreateNewAnimal();                    //Добавляем новое животное на основе введённых данных

                NeedToApplyFilter(                              //Вызываем событие инициирующее фильтрацию второго списка животных
                    new NeedToApplyFilterEventArgs(             //
                        SelectedAnimalClass,                    //
                        animalListItems));                      //

                typeTextBox.Clear();                            //Очищаем поле ввода вида животного
                nameTextBox.Clear();
                typeTextBox.Focus();
            }

            //Если не все необходимые данные введены, выводим соответствующее сообщение
            else MessageBox.Show("Не все обязательные поля заполнены!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        /// <summary>
        /// Возыращает определение класса животного
        /// </summary>
        /// <param name="lb"></param>
        private void GetClassDefinition(ListBox lb)
        {
            if (lb != null && presenter != null)
            {
                if (lb.SelectedItem != null)
                {
                    selectedAnimal = lb.SelectedItem as IAnimal;
                    presenter.GetClassDefinition();
                }
            }
        }
        #endregion
    }
}
