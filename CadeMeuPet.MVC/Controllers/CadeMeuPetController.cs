using CadeMeuPet.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace CadeMeuPet.MVC.Controllers
{
    public class CadeMeuPetController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        
    }
}