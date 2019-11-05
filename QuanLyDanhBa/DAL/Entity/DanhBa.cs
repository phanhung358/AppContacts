using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDanhBa.DAL.Entity
{
    public class DanhBa
    {
        public string MaDanhBa { get; set; }
        public string TenDanhBa { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
        public string TenNhom { get; set; }

        public static DanhBa Parse(string dataString)
        {
            var lsValue = dataString.Split(new char[] { '#' });
            var danhBa = new DanhBa
            {
                MaDanhBa = lsValue[0],
                TenDanhBa = lsValue[1],
                DiaChi = lsValue[2],
                Email = lsValue[3],
                SoDienThoai = lsValue[4],
                TenNhom = lsValue[5]
            };
            return danhBa;
        }
        public static List<DanhBa> GetListFromFile(string pathData, string tenNhom)
        {
            var arrayLines = File.ReadAllLines(pathData);
            List<DanhBa> ketQua = new List<DanhBa>();
            foreach (var line in arrayLines)
            {
                var danhBa = DanhBa.Parse(line);
                if (danhBa.TenNhom == tenNhom)
                    ketQua.Add(danhBa);
            }
            return ketQua;
        }

        public static void Add(string pathData, DanhBa danhBa)
        {
            if (File.Exists(pathData))
            {
                List<string> rs = new List<string>();
                var lines = File.ReadAllLines(pathData);
                foreach(var line in lines)
                {
                    rs.Add(line);
                }
                rs.Add(Guid.NewGuid().ToString() + "#" + danhBa.TenDanhBa + "#" + danhBa.DiaChi + "#" + danhBa.Email + "#" + danhBa.SoDienThoai + "#" + danhBa.TenNhom);
                File.WriteAllLines(pathData, rs);
            }
            else
                throw new Exception("File dữ liệu không có tồn tại");
        
        }

        public static void Update(string pathData, DanhBa danhBa)
        {
            if (File.Exists(pathData))
            {
                List<string> rs = new List<string>();
                var lines = File.ReadAllLines(pathData);
                foreach (var line in lines)
                {
                    var data = DanhBa.Parse(line);
                    if(data.MaDanhBa != danhBa.MaDanhBa)
                        rs.Add(line);
                    else
                        rs.Add(danhBa.MaDanhBa + "#" + danhBa.TenDanhBa + "#" + danhBa.DiaChi + "#" + danhBa.Email + "#" + danhBa.SoDienThoai + "#" + danhBa.TenNhom);
                }
                
                File.WriteAllLines(pathData, rs);
            }
            else
                throw new Exception("File dữ liệu không có tồn tại");

        }

        public static void Remove(string pathData, DanhBa danhBa)
        {
            if (File.Exists(pathData))
            {
                List<string> rs = new List<string>();
                var lines = File.ReadAllLines(pathData);
                foreach (var line in lines)
                {
                    var data = DanhBa.Parse(line);
                    if (data.MaDanhBa != danhBa.MaDanhBa)
                        rs.Add(line);
                }
                File.WriteAllLines(pathData, rs);
            }
            else
                throw new Exception("File dữ liệu không có tồn tại");

        }

        internal static List<DanhBa> GetListFromFile(string pathDataDanhBa, Func<string> toString)
        {
            throw new NotImplementedException();
        }
    }
}
