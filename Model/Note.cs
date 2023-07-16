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

        public Note() {}

        public Note(string title, string text)
        {
            Title = title;
            Text = text;
        }
    }
}
