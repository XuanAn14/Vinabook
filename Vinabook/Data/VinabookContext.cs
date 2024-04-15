using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vinabook.Models;

namespace Vinabook.Data
{
    public class VinabookContext : DbContext
    {
        public VinabookContext (DbContextOptions<VinabookContext> options)
            : base(options)
        {
        }

        public DbSet<Vinabook.Models.DanhMuc> DanhMuc { get; set; } = default!;
        public DbSet<Vinabook.Models.Sach> Sach { get; set; } = default!;
        public DbSet<Vinabook.Models.NguoiDung> NguoiDung { get; set; } = default!;
        public DbSet<Vinabook.Models.GioHang> GioHang { get; set; } = default!;
        public DbSet<Vinabook.Models.DongGioHang> DongGioHang { get; set; } = default!;
    }
}
