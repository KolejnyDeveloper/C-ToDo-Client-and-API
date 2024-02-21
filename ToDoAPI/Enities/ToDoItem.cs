using System.ComponentModel.DataAnnotations;

namespace ToDoAPI.Enities

{
    public class ToDoItem
    {
        [Key]
        public int Id { get; set; }
        public string TodoTask { get; set; }
        public DateTime? TodoTime { get; set; }
    }
}
