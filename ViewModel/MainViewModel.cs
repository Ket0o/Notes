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
        private bool _isEnabled = false;

        [RelayCommand]
        private void AddNote()
        {
            var note = new NoteViewModel();
            note.Title = "1";
            note.Text = "1";
            if (SelectedNote != null)
            {
                SelectedNote.IsEdit = true;
            }
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
            SelectedNote = Notes.Last();
            IsEnabled = true;
        }

        [RelayCommand]
        private void DeleteNote()
        {
            if (Notes.Count > 0)
            {
                if (SelectedNote == Notes.Last())
                {
                    Notes.Remove(SelectedNote);
                    if (Notes.Count >= 1)
                    {
                        SelectedNote = Notes.Last();
                        IsEnabled = true;
                    }
                    else
                    {
                        SelectedNote = null;
                        IsEnabled = false;
                    }
                }
                else
                {
                    foreach (var note in Notes)
                    {
                        if (SelectedNote == note)
                        {
                            Notes.Remove(SelectedNote);
                            SelectedNote = note;
                            IsEnabled = true;
                            break;
                        }
                    }
                }
            }
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
                if (value != null)
                {
                    var keepId = value.Id;
                    if (_selectedNote != null)
                    {
                        if (_selectedNote.Id != keepId)
                        {
                            _selectedNote.IsEdit = false;
                        }
                    }
                }
                _selectedNote = value;
                IsEnabled = true;
                OnPropertyChanged();
                NotesSerializer.Serialize(Transfers.TransferNoteVMToNoteDTO(Notes));
            }
        }
    }
}
