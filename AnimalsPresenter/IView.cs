﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsView
{
    /// <summary>
    /// Интерфейс для View MVP
    /// </summary>
    public interface IView
    {
        //event NeedToApplyFilterEventHandler NeedToApplyFilter;

        /// <summary>
        /// Возвращает фабрику
        /// </summary>
        IFactoryListItem SelectedAnimalFactory { get; }

        /// <summary>
        /// Задаёт источник данных для списка фабрик
        /// </summary>
        IEnumerable<IFactoryListItem> Factories { set; }

        /// <summary>
        /// Возвращает вид животного, введённый пользователем
        /// </summary>
        string AnimalType { get; }

        /// <summary>
        /// Возвращает или задаёт источник данных для списка животных
        /// </summary>
        List<IAnimalListItem> Animals { get; set; }

        /// <summary>
        /// Добавляет животное в список
        /// </summary>
        /// <param name="item"></param>
        void AddAnimalToList(IAnimalListItem item);

        IEnumerable<IAnimalListItem> AnimalListItems { set; }

        ISaveFileView SaveFileObj { get; }
    }
}