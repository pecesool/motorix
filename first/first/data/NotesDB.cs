using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using first.models;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Essentials;

namespace first.data
{
    public class NotesDB
    {
        readonly SQLiteAsyncConnection db;
        public NotesDB(string connectionString)
        {
            db = new SQLiteAsyncConnection(connectionString);
            db.CreateTableAsync<Note>().Wait();
        }
        public Task<int> Addsas(Note note)
        {
            if (note.ID != 0)
            {
                return db.UpdateAsync(note);
            }
            else
            {
                return db.InsertAsync(note);
            }
        }
        public Task<List<Note>> GetNotesAsync()
        {
            return db.Table<Note>().ToListAsync();
        }
        public Task<int> Deletee(Note note)
        {
            return db.DeleteAsync(note);
        }
        public Task<Note> GetNoteAsync(int id)
        {
            return db.Table<Note>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

    }
}
