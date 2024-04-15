using System.ComponentModel.DataAnnotations;

namespace Vinabook.Models
{
    public class DanhMuc
    {
        [Key]
        public int MaDanhMuc { get; set; }

        public string? Ten { get; set; }
    }
}
