using System;
using linkManagerApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace linkManagerApp.Controllers {

    public class AdminController : Controller {

        private LinkManager linkManager;

        public AdminController(LinkManager myManager){
            // originally we have to construct the object, now we don't need it becuz we have services handling that for us
            linkManager = myManager;
        }

        [Route("Admin")]
        public IActionResult Admin() {

            if (HttpContext.Session.GetString("auth") != "true"){
                return RedirectToAction("Login", "Admin");
            }

            return View(linkManager);            
        }

        [Route("Admin/Add/{categoryID}")]
        public IActionResult Add(string categoryID) {
            if (HttpContext.Session.GetString("auth") != "true"){
                return RedirectToAction("Login", "Admin");
            }
            Category category = new Category();
            category = linkManager.getCategory(categoryID);
            // Console.WriteLine(category.categoryID);
            linkManager.SyncCategoryID(categoryID);
            // pass it into the view for populating
            return View(linkManager);
        }

        [HttpPost]
        public IActionResult AddSubmit(LinkManager linkManager) {
            if (!ModelState.IsValid) return RedirectToAction("admin");

            Link link = new Link();
            link = linkManager.link;

            linkManager.Add(link);
            linkManager.SaveChanges();
            // following PRG pattern
            return RedirectToAction("admin");
        }

        [Route("Admin/Delete/{linkID}")]
        public IActionResult Delete(string linkID) {
            if (HttpContext.Session.GetString("auth") != "true"){
                return RedirectToAction("Login", "Admin");
            }
            Link link = new Link();
            link = linkManager.getLink(linkID);
            //Console.WriteLine(link.linkID);
            //link.linkID = Convert.ToInt32(linkID);
            return View(link);
        }

        public IActionResult DeleteSubmit(Link link) {
            Console.WriteLine(link.linkID);
            linkManager.Remove(link);      
            linkManager.SaveChanges();

            return RedirectToAction("admin");
        }

        [Route("Admin/Edit/{linkID}")]
        public IActionResult Edit(string linkID) {
            if (HttpContext.Session.GetString("auth") != "true"){
                return RedirectToAction("Login", "Admin");
            }
            ViewBag.selectList = linkManager.getCategoryList();

            Link link = new Link();
            link = linkManager.getLink(linkID);

            Category category = new Category();
            category = linkManager.getCategory(link.categoryRefID.ToString());
    
            //Console.WriteLine(link.linkID);

            return View(linkManager);
        }

        public IActionResult EditSubmit(Link link) {
            if (!ModelState.IsValid) return RedirectToAction("admin");
            //Console.WriteLine(link.linkID);

            linkManager.Update(link);      
            linkManager.SaveChanges();

            return RedirectToAction("admin");
        }


        [Route("Admin/Update/{categoryID}")]
        public IActionResult Update(string categoryID) {
            if (HttpContext.Session.GetString("auth") != "true"){
                return RedirectToAction("Login", "Admin");
            }
            Category category = new Category();
            category = linkManager.getCategory(categoryID);
            return View(category);
        }

        public IActionResult UpdateSubmit(Category category) {
            if (!ModelState.IsValid) return RedirectToAction("admin");
            //Console.WriteLine (category.categoryID);

            linkManager.Update(category);      
            linkManager.SaveChanges();

            return RedirectToAction("admin");
        }
        [Route("Login")]
        public IActionResult Login() {
            return View();
        }

        public IActionResult Submit(string myUsername, string myPassword) {

            WebLogin webLogin = new WebLogin(Connection.CONNECTION_STRING, HttpContext);

            // update properties
            webLogin.username = myUsername;
            webLogin.password = myPassword;

            // attempt unlock
            if (webLogin.unlock()){
                return RedirectToAction("Admin", "Admin");
            } else {
                ViewData["feedback"] = "Incorrect login. Please try again....";
            }
            
            return View("Login");
        }

        public IActionResult Logout() {
            WebLogin webLogin = new WebLogin(Connection.CONNECTION_STRING, HttpContext);

            webLogin.logout();

            return RedirectToAction("Index","Home");
        }

    }
}
