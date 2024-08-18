using _1907FirstWebAppAtempt.Data;
using _1907FirstWebAppAtempt.Models;
using _1907FirstWebAppAtempt.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace _1907FirstWebAppAtempt.Controllers
{
    public class OtherController : Controller
    {
        private IRepository repository;

        public IPrimeService IprimeS { get; set; }


        public OtherController(IPrimeService IprimeS, IRepository repository)
        {
            this.repository = repository;
            this.IprimeS = IprimeS;
        }
        public IActionResult Registration()
        {
            return View("Registration");
        }

        public IActionResult ShowUserDetails(MyUser user)
        {
            if (ModelState.IsValid)
            {
                MyUser IdLessUser = new MyUser { password = user.password, UserName = user.UserName };
                repository.InsertUser(IdLessUser); // can't get a user with id (id is pk)
                ViewBag.primeUserId = IprimeS.IsPrime(user.UserId);
                return View("ShowUserDetails", user);
            }
            return View("Registration");
        }

        //public IActionResult ShowAllUsers() 
        //{
        //    ViewBag.UsersContext = UserContext.Users;
        //    return View("ShowAllUsers", UserContext.Users);
        //}

        public IActionResult ShowDbUsers()
        {
            ViewBag.UsersContext = repository.GetUsers();
            return View("ShowAllUsers", repository.GetUsers());
        }

        public IActionResult Insert()
        {
            repository.InsertUser(new MyUser { UserName = "itamar248", password = "itamar2001" }); // can't put PrimeryKey - id 
            return RedirectToAction("ShowDbUsers");
        }

        public IActionResult Edit(int id)
        {
            var user = new MyUser { UserId = 10, password = "itamar54321", UserName = "itamarV2" };
            repository.UpdateUserName(id, user.UserName);
            return RedirectToAction("ShowDbUsers");
        }

        public IActionResult Delete(int id)
        {
            repository.DeleteUser(id);
            return RedirectToAction("ShowDbUsers");
        }

        public IActionResult ShowAnimalDetails()
        {
            return View(repository.GetAnimalById(1));
        }

        public IActionResult ShowAnimalsDetails()
        {
            return View(repository.GetAnimalsByCommentsAmount(1));
        }


        public IActionResult ShowAllZooDetails()
        {
            Category? category = null;
            return View(repository.GetCategorys());
        }

        public IActionResult AnimalDetails()
        {
            return View();
        }

        //create actions to see all  category + animals + message 
        //use explicit loading, egor loading and lazy loadoing
    }
}
