using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Vinabook.Infrastructure;

namespace Vinabook.Models
{
    public class GioHang
    {
        [Key]
        public int MaGioHang { get; set; }
        public List<DongGioHang> dongGioHang { get; set; }
        
        [ForeignKey("NguoiDung")]
        public int MaNguoiDung { get; set; }
        public virtual NguoiDung? NguoiDung { get; set; }
    }

}
