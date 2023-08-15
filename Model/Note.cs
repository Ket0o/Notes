using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Note
    {
        private string _title;
        private string _text;
        public bool IsEdit { get; set; } = false;
        private int _id;
        private static int _allNotesCount;

        public static int AllNotesCount
        {
            get => _allNotesCount;
        }

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
            }
        }

        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
            }
        }

        public int Id
        {
            get { return _id; }
        }

        public Note() 
        {
            _allNotesCount ++;
            _id = _allNotesCount;
        }

        public Note(string title, string text)
        {
            Title = title;
            Text = text;
            _allNotesCount++;
            _id = _allNotesCount;
        }
    }
}
