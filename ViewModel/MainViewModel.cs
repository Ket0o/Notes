using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Base;

namespace ViewModel
{
    public partial class MainViewModel: BaseViewModel
    {
        private NoteViewModel? _selectedNote;

        [RelayCommand]
        private void AddNote()
        {
            SelectedNote = null;
            NoteViewModel note = new NoteViewModel();
            note.Title = "Note";
            SelectedNote = note;
            Notes.Add(SelectedNote);
        }

        [RelayCommand]
        private void DeleteNote()
        {
            Notes.Remove(SelectedNote);
        }

        public ObservableCollection<NoteViewModel> Notes { get; } =
            new ObservableCollection<NoteViewModel>();

        public NoteViewModel SelectedNote
        {
            get => _selectedNote;
            set
            {
                _selectedNote = value;
                OnPropertyChanged();
            }
        }
    }
}
