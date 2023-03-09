using Microsoft.EntityFrameworkCore;
using System.Text;

namespace TaskManagerAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Task> Tasks { get; set; } //apontando as classes para poder trabalhar com elas

        public DbSet<TaskType> TaskTypes { get; set; }

        public DbSet<Status> Status { get; set; }



        public Stream ExportCsv()
        {
            var csv = new StringBuilder();

            var task = Tasks;

            var columns = "ID;TÍTULO;PRIORIDADE;STATUS;CRIADA EM";
            csv.AppendLine(columns);

            foreach (var item in task)
            {
                csv.AppendLine($"{item.Id};" +
                    $"{item.TaskType?.NameTask};" +
                    $"{item.Comments};" +
                    $"{item.Status};" +
                    $"{item.InitialDate};" +
                    $"{item.EndDate}");
            }

            var randomString = Guid.NewGuid().ToString();

            string filePath = $"C:\\teste\\{randomString}.csv";

            File.WriteAllText(filePath, csv.ToString(), Encoding.UTF8);

            Stream file = new FileStream(filePath, FileMode.Open, FileAccess.Read);

            return file;
        }

    }


}
