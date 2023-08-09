using EmployeeManagement.DataAccess;
using EmployeMangement.Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMangement.Business
{
    public class NotesBusiness
    {
        public static List<NotesModel> GetUserNotes(int userId,bool isAdmin)
        {
            return NotesData.GetUserNotes(userId, isAdmin);
        }

        public static void DeleteNotes(int noteId)
        {
            NotesData.DeleteNotes(noteId);
        }

        public static void EditNotes(NotesModel notes)
        {
            NotesData.EditNotes(notes);
        }

        public static void AddNotes(NotesModel notes)
        {
            NotesData.AddNotes(notes);  
        }
    }
}
