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

       

        public Notes()
        {
            string dbpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Notes1.db1");
            Db = new SQLiteConnection(dbpath);
        }


        public void CreateDataBase()
        {
            Db.CreateTable<NoteThings>();
        }


        public void SampleData()
        {
            Db.CreateTable<NoteThings>();
            if (Db.Table<NoteThings>().Count() == 0)
            {
                var samepls = new NoteThings();
                samepls.Noteheading = "tere";
                samepls.Notetext = "hüvasti";
                Db.Insert(samepls);
            }
        }

        public void Addnote(string notecaption, string notetext)
        {
            var newnote = new NoteThings
            {
                Noteheading = notecaption,
                Notetext = notetext
            };

            Db.Insert(newnote);

        }


        public void DeleteNote(int id)
        {
            NoteThings noteToDelete = new NoteThings();
            noteToDelete.Id = id;
            Db.Delete(noteToDelete);
        }
      

        public TableQuery<NoteThings> GetAllNotes()
        {
            var table = Db.Table<NoteThings>();
            return table;
        }
        

        public void edit(int id, string content)
        {
            var getnotes = GetAllNotes();
            var query = from ord in getnotes
                        where ord.Id == id
                        select ord;
            foreach (NoteThings note in query)
            {
                note.Id = id;
               // note.Noteheading = title;
                note.Notetext = content;
                Db.Update(note);
            }
        }

    }
}