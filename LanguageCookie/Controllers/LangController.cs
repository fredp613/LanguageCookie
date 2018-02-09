using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LanguageCookie.Models;
using Microsoft.AspNetCore.Http;

namespace LanguageCookie.Controllers
{
    public class LangController : Controller
    {
        public IActionResult Index(string lang = "")
        {
            if (lang != "") {
                Response.Cookies.Append("_gc_lang", lang, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    Domain = ".fjgc-gccf.gc.ca"
                });
            } else
            {
                lang = Request.Cookies["_gc_lang"] == null ? "eng" : Request.Cookies["_gc_lang"];
                
                //Response.Cookies.Append("_gc_lang", lang, new CookieOptions
                //{
                //    HttpOnly = true,
                //    Secure = true,
                //    Domain = ".fjgc-gccf.gc.ca"
                //});
            }
            
            ViewBag.Message = lang;
            return View();
        }

     
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
