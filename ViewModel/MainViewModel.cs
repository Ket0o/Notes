using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Model.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Services;

namespace ViewModel
{
    public partial class MainViewModel: ObservableObject
    {
        private NoteViewModel _selectedNote;

        [ObservableProperty]
        private bool _isReadOnly = false;

        [RelayCommand]
        private void AddNote()
        {
            var note = new NoteViewModel();
            note.Title = "1";
            note.Text = "1";
            if (Notes.Contains(note))
            {
                NotesSerializer.Serialize(Transfers.TransferNoteVMToNoteDTO(Notes));
                if (SelectedNote != null)
                {
                    SelectedNote.IsEdit = false;
                }
            }
            else
            {
                Notes.Add(note);
                NotesSerializer.Serialize(Transfers.TransferNoteVMToNoteDTO(Notes));
                if (SelectedNote != null)
                {
                    SelectedNote.IsEdit = false;
                }
            }
            SelectedNote = Notes[Notes.Count - 1];
            IsReadOnly = true;
        }

        [RelayCommand]
        private void DeleteNote()
        {
            Notes.Remove(SelectedNote);
            IsReadOnly = false;
            NotesSerializer.Serialize(Transfers.TransferNoteVMToNoteDTO(Notes));
            if (SelectedNote != null)
            {
                SelectedNote.IsEdit = false;
            }
        }

        public ObservableCollection<NoteViewModel> Notes { get; } = NotesSerializer.Deserialize();

        public NoteViewModel SelectedNote
        {
            get => _selectedNote;
            set
            {   
                if (value == null)
                {
                    _selectedNote = null;
                    IsReadOnly = false;
                    OnPropertyChanged();
                    NotesSerializer.Serialize(Transfers.TransferNoteVMToNoteDTO(Notes));
                }
                else if (_selectedNote == null)
                {
                    _selectedNote = value;
                    _selectedNote.IsEdit = true;
                    IsReadOnly = true;
                }
                else if (_selectedNote.Id == value.Id)
                {
                    _selectedNote = value;
                    IsReadOnly = true;
                    _selectedNote.IsEdit = true;
                }
                else
                {
                    _selectedNote = value;
                    IsReadOnly = true;
                    _selectedNote.IsEdit = false;
                }               
                OnPropertyChanged();
                NotesSerializer.Serialize(Transfers.TransferNoteVMToNoteDTO(Notes));
                _selectedNote.IsEdit = false;
            }
        }
    }
}
