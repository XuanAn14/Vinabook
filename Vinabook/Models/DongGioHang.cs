using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vinabook.Models
{
    public class DongGioHang
    {
        [Key]
        public int MaDong { set; get; }
        public string? Ten { get; set; }
        public string? URLAnh { get; set; }
        public decimal? Gia { get; set; }
        public int? SoLuong { get; set; }
        public decimal? ThanhTien => SoLuong * Gia;
        [ForeignKey("Sach")]
        public int MaSach { get; set; }
        public virtual Sach? Sach { get; set; }
    }
}
