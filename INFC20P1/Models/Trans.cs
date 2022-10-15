using System.ComponentModel.DataAnnotations;

namespace INFC20P1.Models
{
    public class Trans
    {
        [Key]
        public int tid { get; set; }
        public string tname { get; set; } = string.Empty;

        public int send_id { get; set; }
        public int recieve_id { get; set; }

        public decimal amount { get; set; }

        [DataType(DataType.Date)]
        public DateTime t_date { get; set; }

    }
}
