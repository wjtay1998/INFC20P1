using System.ComponentModel.DataAnnotations;

namespace INFC20P1.Models
{
    public class Person
    {
        [Key]
        public int pid { get; set; }
        public string pname { get; set; } = string.Empty;

        public decimal sent { get; set; }

        public decimal recieved { get; set; }
    }
}
