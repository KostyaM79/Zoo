using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using AnimalsModel;

namespace AnimalsLibrary
{
    public class Library : IAnimalLibrary
    {
        /// <summary>
        /// Создаёт на основе метаданных сборки и возвращает коллекцию экземпляров фабрик
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IFactory> GetFactoryCollection()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();        //Получаем текущую сборку

            Type[] types = assembly.GetTypes();                         //Получаем все типы данной сборки

            List<Type> factoryTypes = GetFactories(types);              //Отбираем из полученных типов только фабрики

            List<IFactory> factories = new List<IFactory>();            //Создаём коллекцию для экземпляров фабрик

            //Заполняем коллекцию экземплярами фабрик
            foreach (Type temp in factoryTypes)
            {
                factories.Add(temp.GetConstructor(new Type[] { }).Invoke(new object[] { }) as IFactory);
            }

            return factories;                                           //Возвращаем коллекцию фабрик
        }

        public IFactory GetNullFactory()
        {
            return new NullFactory();
        }

        /// <summary>
        /// Отбирает из переданной коллекции типов, только типы фабрик
        /// </summary>
        /// <param name="types"></param>
        /// <returns></returns>
        private List<Type> GetFactories(Type[] types)
        {
            List<Type> resultTypes = new List<Type>();
            foreach (Type t in types)
            {
                if (IsFactory(t)) resultTypes.Add(t);
            }

            return resultTypes;
        }

        /// <summary>
        /// Возвращает true, если переданный тип является типом фабрики, в противном случае - false
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        private bool IsFactory(Type t)
        {
            IEnumerable<Type> interfaces = t.GetTypeInfo().ImplementedInterfaces;

            foreach (Type temp in interfaces)
            {
                if (temp.Equals(typeof(IFactory))) return true;
            }

            return false;
        }
    }
}
