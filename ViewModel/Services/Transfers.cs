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
        public static List<NoteDTO> TransferNoteVMToNoteDTO(ObservableCollection<NoteViewModel> notesViewModel)
        {
            var notesDTO = new List<NoteDTO>();
            var noteDTO = new NoteDTO();

            foreach(NoteViewModel note in notesViewModel)
            {
                noteDTO.Title = note.Title;
                noteDTO.Text = note.Text;
                notesDTO.Add(noteDTO);
            }

            return notesDTO;
        }

        public static ObservableCollection<NoteViewModel> TransferNoteDTOToNoteViewModel(List<NoteDTO> notesDTO)
        {
            var notesViewModel = new ObservableCollection<NoteViewModel>();
            var noteViewModel = new NoteViewModel();

            foreach (NoteDTO note in notesDTO)
            {
                noteViewModel.Title = note.Title;
                noteViewModel.Text = note.Text;
                notesViewModel.Add(noteViewModel);
            }

            return notesViewModel;
        }
    }
}
