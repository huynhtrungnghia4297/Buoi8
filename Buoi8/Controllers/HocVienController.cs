using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Buoi8.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Buoi8.Controllers
{
    public class HocVienController : Controller
    {
        /*static*/ List<HocVien> dsHV = new List<HocVien>();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DemoJson()
        {
            var hv = new HocVien
            {
                MaSo = 1,
                TenHocVien = "Hoa",
                Gioitinh = true,
                SDT = 0123456,
                DiemTB = 8.12
            };
            var data = new
            {
                HocVien = hv,
                TrungTam = "Nhất Nghệ",
                NgayTL = new DateTime(2003, 3, 10)
            };
            return Json(data);
        }
        [HttpPost]
        public IActionResult Index(HocVien hv,string Ghi)
        {
            if (Ghi == "Ghi File Text")
            {
                StreamWriter sw = new StreamWriter("HocVien.txt");
                sw.WriteLine(hv.MaSo);
                sw.WriteLine(hv.TenHocVien);
                sw.WriteLine(hv.SDT);
                sw.WriteLine(hv.DiemTB);
                sw.WriteLine(hv.Gioitinh);
                sw.Close();
            }  
            else if (Ghi == "Ghi File Json")
            {
                string chuoiJson = JsonConvert.SerializeObject(hv);
                System.IO.File.WriteAllText("HocVien.json", chuoiJson);
            }    
            return View();
        }
        public IActionResult DocFileJson()
        {
            var content = System.IO.File.ReadAllText("HocVien.json");
            var hocvien = JsonConvert.DeserializeObject<HocVien>(content);
            return View("Index", hocvien);
        }
        public IActionResult DocFileText()
        {
            var content = System.IO.File.ReadAllLines("HocVien.txt");
            var hocvien = new HocVien
            {
                MaSo = int.Parse(content[0]),
                TenHocVien = content[1],
                SDT = int.Parse(content[2]),
                DiemTB = double.Parse(content[3]),
                Gioitinh = content[4] == "true" ? true : false


            };
            return View("Index",hocvien);
        }
    }
}