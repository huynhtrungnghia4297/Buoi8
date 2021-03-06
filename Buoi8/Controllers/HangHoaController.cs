﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Buoi8.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Buoi8.Controllers
{
    public class HangHoaController : Controller
    {
        static List<HangHoa> dsHangHoa = new List<HangHoa>();
        public IActionResult Index()
        {
            return View(dsHangHoa);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(HangHoa hh, IFormFile Hinh)
        {
            if(Hinh != null)
            {
                var filename = $"{DateTime.Now.Ticks}_{Hinh.FileName}";
                var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "hanghoa", filename);
                hh.Hinh = filename;
                using (var file = new FileStream(fullPath, FileMode.Create))
                {
                    Hinh.CopyTo(file);
                    dsHangHoa.Add(hh);
                    return Redirect("/HangHoa");
                }
            }
            return View();
        }

    }
}