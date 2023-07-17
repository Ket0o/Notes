using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Base;
using Model;

namespace ViewModel
{
    public class NoteViewModel: BaseViewModel
    {
        public Note Note { get; } = new Note();

        public string Titile
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

        public NoteViewModel()
        {

        }
    }
}
