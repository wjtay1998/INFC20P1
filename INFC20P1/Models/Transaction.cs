using System.ComponentModel.DataAnnotations;

namespace INFC20P1.Models
{
    public class Transaction
    {
        [Key]
        public int tid { get; set; }
        public string tname { get; set; } = string.Empty;

        public int send_id { get; set; }
        public int recieve_id { get; set; }

        [DataType(DataType.Date)]
        public DateTime t_date { get; set; }

    }
}
