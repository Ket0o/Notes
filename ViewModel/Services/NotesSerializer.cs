using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ViewModel;

namespace Model.Services
{
    public static class NotesSerializer
    {
        /// <summary>
        /// Путь к – «Мои документы\Notes\notes.json».
        /// </summary>
        public static string MyDocumentsPath { get; set; } =
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            + @"\Notes\notes.json";

        public static void Serialize(List<NoteDTO>? notes)
        {
            if (!Directory.Exists(Path.GetDirectoryName(MyDocumentsPath)))
                Directory.CreateDirectory(Path.GetDirectoryName(MyDocumentsPath));
            using (StreamWriter writer = new StreamWriter(MyDocumentsPath))
            {
                writer.Write(JsonConvert.SerializeObject(notes));
            }
        }

        public static ObservableCollection<NoteViewModel>? Deserialize()
        {
            if (!Directory.Exists(Path.GetDirectoryName(MyDocumentsPath)))
                Directory.CreateDirectory(Path.GetDirectoryName(MyDocumentsPath));
            ObservableCollection<NoteViewModel>? contacts = 
                new ObservableCollection<NoteViewModel>();
            try
            {
                using (StreamReader reader = new StreamReader(MyDocumentsPath))
                {
                    contacts = JsonConvert.
                        DeserializeObject<ObservableCollection<NoteViewModel>>(reader.ReadToEnd());
                }

                if (contacts == null) contacts = new ObservableCollection<NoteViewModel>();
            }
            catch (FileNotFoundException e)
            {
                return contacts;
            }

            return contacts;
        }
    }
}
