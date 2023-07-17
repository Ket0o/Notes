using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Base
{
    /// <summary>
    /// Представляет базовую реализацию интерфейса <see cref="INotifyPropertyChanged"/>.
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Событие на изменение свойст.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Зажигает событие <see cref="OnPropertyChanged"/>.
        /// </summary>
        /// <param name="propertyName">Имя свойства.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
