using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;   
using Model;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ViewModel
{
    public class NoteViewModel: ObservableObject
    {
        public Note Note { get; } = new Note();

        public string Title
        {
            get => Note.Title;
            set
            {
                Note.Title = value;
                OnPropertyChanged();
            }
        }

        public string Text
        {
            get => Note.Text;
            set
            {
                Note.Text = value;
                OnPropertyChanged();
            }
        }

        public bool IsEdit
        {
            get => Note.IsEdit;
            set
            {
                Note.IsEdit = value;
                OnPropertyChanged();
            }
        }

        public int Id
        {
            get => Note.Id;
        }

        public int AllNotesCount
        {
            get => Note.AllNotesCount;
        }

        public NoteViewModel()
        {

        }
    }
}
