﻿using System.ComponentModel.DataAnnotations;

namespace Notepad.Models
{
    public class NoteModel
    {
        public int Id { get; set; }
        
        //[Required]
        public string Name { get; set; }
        public string Content { get; set; }

        //public override string ToString()
        //{
        //    return $"{Id} - {Name}";
        //}

        public override bool Equals(object obj)
        {
            return base.Equals(obj) || (obj is NoteModel note && note.Id == Id);
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}