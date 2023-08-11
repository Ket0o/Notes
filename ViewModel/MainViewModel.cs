using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Model.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Services;

namespace ViewModel
{
    public partial class MainViewModel: ObservableObject
    {
        private NoteViewModel _selectedNote;

        [RelayCommand]
        private void AddNote()
        {
            var note = new NoteViewModel();
            note.Title = "1";
            note.Text = "1";
            if (Notes.Contains(note))
            {
                NotesSerializer.Serialize(Notes);
            }
            else
            {
                Notes.Add(note);
                NotesSerializer.Serialize(Notes);
            }
            SelectedNote = Notes[Notes.Count - 1];
        }

        [RelayCommand]
        private void DeleteNote()
        {
            Notes.Remove(SelectedNote);
            NotesSerializer.Serialize(Notes);
        }

        public ObservableCollection<NoteViewModel> Notes { get; } = NotesSerializer.Deserialize();

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
