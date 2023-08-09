using EmployeMangement.Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.DataAccess
{
    public class NotesData
    {
        public static List<NotesModel> GetUserNotes(int userId,bool isAdmin)
        {
            List<NotesModel> notes = new List<NotesModel>();
            var privateText = isAdmin ? "YES" : "NO";
            if (isAdmin)
            {
                using (var dbContext = new UserRegistrationEntities())
                {
                    var items = dbContext.UserNotes.Where(i => i.ObjectId == userId && i.ObjectType == "User");
                    foreach (var item in items)
                    {
                        NotesModel obj = new NotesModel();
                        obj.Notes = item.Notes.Trim();
                        obj.NoteId = item.NoteId;
                        obj.IsPrivate = item.IsPrivate.Trim();
                        obj.CreatedId = item.CreatedId;
                        obj.CreatedBy = dbContext.User.Where(i => i.UserId == item.CreatedId).Select(i => i.Firstname).FirstOrDefault().Trim();
                        obj.CreatedOn=item.CreatedOn.Trim();
                        notes.Add(obj);
                    }
                }
            }
            else
            {
                using (var dbContext = new UserRegistrationEntities())
                {
                    var items = dbContext.UserNotes.Where(i => i.ObjectId == userId && i.ObjectType == "User" && i.IsPrivate=="NO");
                    foreach (var item in items)
                    {
                        NotesModel obj = new NotesModel();
                        obj.Notes = item.Notes.Trim();
                        obj.NoteId = item.NoteId;
                        obj.IsPrivate = item.IsPrivate.Trim();
                        obj.CreatedId = item.CreatedId;
                        obj.CreatedBy = dbContext.User.Where(i => i.UserId == item.CreatedId).Select(i => i.Firstname).FirstOrDefault().Trim();
                        obj.CreatedOn = item.CreatedOn.Trim();
                        notes.Add(obj);
                    }
                }
            }
            return notes;
        }


        public static void DeleteNotes(int noteId)
        {
            using (var dbContext = new UserRegistrationEntities())
            {
                UserNotes obj = dbContext.UserNotes.Where(i => i.NoteId == noteId).Single();
                dbContext.UserNotes.Remove(obj);
                dbContext.SaveChanges();
            }
        }

        public static void EditNotes(NotesModel note)
        {
           
            using (var dbContext = new UserRegistrationEntities())
            {
                UserNotes obj = dbContext.UserNotes.Where(i => i.NoteId == note.NoteId).Single();
                obj.Notes = note.Notes;
                dbContext.SaveChanges();
            }
        }

        public static void AddNotes(NotesModel note)
        {
            using (var dbContext = new UserRegistrationEntities())
            {
                UserNotes obj = new UserNotes();
                obj.Notes = note.Notes;
                obj.IsPrivate = note.IsPrivate;
                obj.ObjectId = note.ObjectId;
                obj.ObjectType = "User";
                obj.CreatedId= note.CreatedId;
                obj.CreatedOn = DateTime.Now.ToString("dddd, dd MMMM yyyy");
                dbContext.UserNotes.Add(obj);
                dbContext.SaveChanges();
            }
        }
    }
}
