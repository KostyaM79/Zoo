﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsModel
{
    /// <summary>
    /// Базовый класс для животных
    /// </summary>
    public abstract class AbstractAnimal
    {
        /// <summary>
        /// Возвращает класс животного
        /// </summary>
        public abstract string AnimalClassName { get; }

        /// <summary>
        /// Возвращает вид животного
        /// </summary>
        public string AnimslType { get; protected set; }
    }
}