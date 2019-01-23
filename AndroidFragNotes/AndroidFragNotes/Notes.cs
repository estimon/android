using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace AndroidFragNotes
{ 
    class Notes
    {
        
        SQLiteConnection Db;

       

        public void CreateDataBase()
        {
            string dbpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Notes.db3");
            Db = new SQLiteConnection(dbpath);
            Db.CreateTable<NoteThings>();
        }
        public void AddNewNoteHeading(string noteheading)
        {
            var newNoteHeading = new NoteThings();
            newNoteHeading.noteheading = "pede";
            Db.Insert(newNoteHeading);
            
        }


        public void AddNewNoteContenxt(string note)
        {   
            var newNote = new NoteThings();
            newNote.notetext = note;
            Db.Insert(newNote);
        }

        public void CreateTable()
        {
            Db.CreateTable<NoteThings>();
        }

        public TableQuery<NoteThings> GetAllNotes()
        {
            var table = Db.Table<NoteThings>();
            return table;
        }
        

    }
}