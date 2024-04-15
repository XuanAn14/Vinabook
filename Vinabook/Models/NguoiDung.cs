using System.ComponentModel.DataAnnotations;

namespace Vinabook.Models
{
    public class NguoiDung
    {
        [Key]
        public int MaNguoiDung { get; set; }

        public string? TenNguoiDung { get; set; }

        public string? Email { get; set; }

        public DateTime? NgaySinh { get; set; }

        public string? MatKhau {  get; set; }

        public string? VaiTro {  get; set; }
    }
}
