using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDanhBa.DAL.Entity
{
    public class Nhom
    {
        public string MaNhom { get; set; }
        public string TenNhom { get; set; }

        public static Nhom Parse(string dataString)
        {
            var lsValue = dataString.Split(new char[] { '#' });
            var nhom = new Nhom
            {
                MaNhom = lsValue[0],
                TenNhom = lsValue[1]
            };
            return nhom;
        }

        public static List<Nhom> GetListFromFile(string pathData)
        {
            var arrayLines = File.ReadAllLines(pathData);
            List<Nhom> ketQua = new List<Nhom>();
            foreach (var line in arrayLines)
            {
                var nhom = Nhom.Parse(line);
                ketQua.Add(nhom);
            }
            return ketQua;
        }

        public static void Add(string pathData, Nhom nhom)
        {
            if (File.Exists(pathData))
            {
                List<string> rs = new List<string>();
                var lines = File.ReadAllLines(pathData);
                foreach (var line in lines)
                {
                    rs.Add(line);
                }
                rs.Add(Guid.NewGuid().ToString() + "#" + nhom.TenNhom);
                File.WriteAllLines(pathData, rs);
            }
            else
                throw new Exception("File dữ liệu không có tồn tại");
        }

        public static void Update(string pathData, Nhom nhom)
        {
            if (File.Exists(pathData))
            {
                List<string> rs = new List<string>();
                var lines = File.ReadAllLines(pathData);
                foreach (var line in lines)
                {
                    var data = Nhom.Parse(line);
                    if (data.MaNhom != nhom.MaNhom)
                        rs.Add(line);
                    else
                        rs.Add(nhom.MaNhom + "#" + nhom.TenNhom);
                }

                File.WriteAllLines(pathData, rs);
            }
            else
                throw new Exception("File dữ liệu không có tồn tại");

        }

        public static void Remove(string pathData, Nhom nhom)
        {
            if (File.Exists(pathData))
            {
                List<string> rs = new List<string>();
                var lines = File.ReadAllLines(pathData);
                foreach (var line in lines)
                {
                    var data = Nhom.Parse(line);
                    if (data.MaNhom != nhom.MaNhom)
                        rs.Add(line);
                }
                File.WriteAllLines(pathData, rs);
            }
            else
                throw new Exception("File dữ liệu không có tồn tại");

        }
    }
}
