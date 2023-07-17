using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Base;

namespace ViewModel
{
    public class MainViewModel: BaseViewModel
    {
        private NoteViewModel _selectedNote;

        public ObservableCollection<NoteViewModel> Notes { get; } =
            new ObservableCollection<NoteViewModel>();

        public NoteViewModel SelectedNote 
        { 
            get { return _selectedNote;} 
            set
            {
                _selectedNote = value;
                OnPropertyChanged();
            }
        }
    }
}
