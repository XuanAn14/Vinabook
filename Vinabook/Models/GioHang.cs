using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Vinabook.Infrastructure;

namespace Vinabook.Models
{
    public class GioHang
    {
        public List<DongGioHang> dongGioHang;
        public decimal TongTien() => dongGioHang.Sum(e => e.SoLuong * e.Gia);
        public class DongGioHang
        {
            public int MaSach { get; set; }
            public string Ten { get; set; }
            public string URLAnh {  get; set; }
            public decimal Gia { get; set; }
            public int SoLuong { get; set; }
            public decimal ThanhTien => SoLuong * Gia;
        }
    }

}
