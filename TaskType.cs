using System.ComponentModel.DataAnnotations;

namespace TaskManagerAPI
{
    public class TaskType
    {
        public int Id { get; set; }
        [StringLength(20)]

        public string NameTask { get; set; } = string.Empty;

    }
}
