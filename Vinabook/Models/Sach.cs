using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vinabook.Models
{
    public class Sach
    {
        [Key]
        public int MaSach { get; set; }
        public string Ten {  get; set; }

        public string TacGia { get; set; }

        public string MoTa { get; set; }

        public string URLAnh {  get; set; }

        public decimal Gia { get; set; }

        public int SoLuong { get; set; }

        [ForeignKey("DanhMuc")]
        public int MaDanhMuc { get; set; }

        public virtual DanhMuc? DanhMuc { get; set;}

    }
}
