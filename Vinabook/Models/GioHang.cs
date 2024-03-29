namespace Vinabook.Models
{
    public class GioHang
    {
        public List<DongSanPham> DongGioHang { get; set; } = new List<DongSanPham>();
        public void ThemMuc(Sach sach, int soluong)
        {
            DongSanPham? dong = DongGioHang
                .Where(p => p.Sach.MaSach == sach.MaSach)
                .FirstOrDefault();
            if(dong == null)
            {
                DongGioHang.Add(new DongSanPham
                {
                    Sach = sach,
                    SoLuong = soluong
                });
            }
            else
            {
                dong.SoLuong += soluong;
            }
        }
        public void XoaMuc(Sach sach) => DongGioHang.RemoveAll(l => l.Sach.MaSach == sach.MaSach);
        public decimal TongTien() => (decimal)DongGioHang.Sum(e => e.Sach.Gia * e.SoLuong);
        public void Xoa() => DongGioHang.Clear();
    }

    public class DongSanPham
    {
        public int MaDong {  get; set; }
        public Sach Sach { get; set; } = new();
        public int SoLuong { get; set; }
    }
}
