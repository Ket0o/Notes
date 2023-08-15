using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ViewModel.Services
{
    public static class Transfers
    {
        public static List<NoteDTO> TransferNoteVMToNoteDTO(
            ObservableCollection<NoteViewModel> notesViewModel)
        {
            var notesDTO = new List<NoteDTO>();
            foreach(NoteViewModel note in notesViewModel)
            {
                var noteDTO = new NoteDTO();
                noteDTO.Title = note.Title;
                noteDTO.Text = note.Text;
                noteDTO.Id = note.Id;
                notesDTO.Add(noteDTO);
            }
            return notesDTO;
        }
    }
}
