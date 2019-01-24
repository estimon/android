﻿using System;
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
            string dbpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Notes1.db3");
            Db = new SQLiteConnection(dbpath);
        }


        public void AddNewNoteHeading(string notecaption)
        {
            var newNoteHeading = new NoteThings();
            newNoteHeading.Noteheading = notecaption;
            Db.Insert(newNoteHeading);


        }

        public void AddNewNoteContenxt(string note)
        {
            var newNote = new NoteThings();
            newNote.Notetext = note;
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