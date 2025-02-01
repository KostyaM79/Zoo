using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsView
{
    /// <summary>
    /// Делегат для обработчика события, возникающего при необходимости фильтрации списка
    /// </summary>
    /// <param name="e"></param>
    public delegate void NeedToApplyFilterEventHandler(NeedToApplyFilterEventArgs e);
}
