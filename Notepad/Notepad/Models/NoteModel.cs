namespace Notepad.Models
{
    public class NoteModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }

        //public override string ToString()
        //{
        //    return $"{Id} - {Name}";
        //}

        protected bool Equals(NoteModel note)
        {
            return Id == note.Id;
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}