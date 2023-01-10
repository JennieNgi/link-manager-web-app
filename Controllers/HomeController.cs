using System;
using linkManagerApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace linkManagerApp.Controllers {

    public class HomeController : Controller {

        private LinkManager linkManager;

        public HomeController(LinkManager myManager){
            // originally we have to construct the object, now we don't need it becuz we have services handling that for us
            linkManager = myManager;
        }

        public IActionResult Index() {
            return View(linkManager);            
        }

    }
}
