using System.ComponentModel.DataAnnotations;

namespace INFC20P1.Models.Forms
{
    public class TransInput
    {
        [Key]
        public int tid { get; set; }
        public string tname { get; set; } = string.Empty;

        public string? send_pname { get; set; }
        public string? recieve_pname { get; set; }

        public decimal amount { get; set; }

        [DataType(DataType.Date)]
        public DateTime t_date { get; set; }

    }
}
