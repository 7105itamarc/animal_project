using _1907FirstWebAppAtempt.Data;
using _1907FirstWebAppAtempt.Models;
using _1907FirstWebAppAtempt.Repositories;
using _1907FirstWebAppAtempt.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
namespace _1907FirstWebAppAtempt.Controllers
{

    [Authorize]
    public class MainController : Controller
    {
        private IRepository repository;
        private IHostingEnvironment hostingEnvironment;

        public MainController(IRepository repository, IHostingEnvironment hostingEnvironment)
        {
            this.repository = repository;
            this.hostingEnvironment = hostingEnvironment;
        }
        public IActionResult HomePage()
        {
            return View(repository.GetAnimalsByCommentsAmount(2));
        }

        public IActionResult Catalog(int CategoryId)
        {
            Category category = repository.GetCategoryById(CategoryId);
            ViewBag.category = category;

            return View(repository.GetCategorys());
        }

        public IActionResult AnimalDetails(int id)
        {
            Animal animal = repository.GetAnimalById(id);
            ViewBag.animal = animal;

            return View();
        }

        public IActionResult AddComment(Comment comment)
        {
            Animal animal = repository.GetAnimalById(comment.AnimalId);
            comment.CategoryId = (int)animal.CategoryId!;
            repository.SaveComment(animal, comment);
            ViewBag.animal = animal;

            return View("AnimalDetails");
        }

        [Authorize(Roles = "Administrators")]
        public IActionResult Administrator(int CategoryId)
        {
            Category category = repository.GetCategoryById(CategoryId);
            ViewBag.category = category;

            return View(repository.GetCategorys());
        }

        public IActionResult DeleteAnimal(int CategoryId, int AnimalId)
        {
            Category category = repository.GetCategoryById(CategoryId);
            ViewBag.category = category;
            repository.DeleteAnimal(AnimalId);

            return View("Administrator", repository.GetCategorys());
        }

        public IActionResult EditAnimalInput()
        {
            int.TryParse(Request.Query["AnimalId"], out int AnimalId) ;
            Animal animalStrat = repository.GetAnimalById(AnimalId);
            AnimalViewModel animalVM = repository.AnimalToAnimalVM(animalStrat);
            animalVM.CategoryOptions = repository.CategorysToSelectListItem(repository.GetCategorys());
            return View(animalVM);
        }

        public IActionResult EditAnimal(AnimalViewModel animal)
        {
            if (ModelState.IsValid)
            {
                if (animal.photo != null) 
                {
                    string UploadsFolder =  Path.Combine(hostingEnvironment.WebRootPath, "AnimalsPic");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + animal.photo.FileName;
                    string FilePath = Path.Combine(UploadsFolder, uniqueFileName);
                    animal.photo.CopyTo(new FileStream(FilePath, FileMode.Create));
                    animal.PictureName = "\\AnimalsPic\\" + uniqueFileName;
                }

                repository.SaveAnimalChanges(animal);
                return View("Administrator", repository.GetCategorys());

            }
            return View("EditAnimalInput", animal);
        }
        //BackToEdit 
        //////
        public IActionResult newAnimalInput(AnimalViewModel animal)
        {
            AnimalViewModel animalVM = new AnimalViewModel();

            if (animal != null)
            {
                animalVM = repository.AnimalToAnimalVM(animal);
            }
            
            animalVM.CategoryOptions = repository.CategorysToSelectListItem(repository.GetCategorys());
            return View(animalVM);
        }


        public IActionResult CreateNewAnimal(AnimalViewModel animal)
        {
            if (ModelState.IsValid)
            {
                if (animal.photo != null)
                {
                    string UploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "AnimalsPic");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + animal.photo.FileName;
                    string FilePath = Path.Combine(UploadsFolder, uniqueFileName);
                    animal.photo.CopyTo(new FileStream(FilePath, FileMode.Create));
                    animal.PictureName = "\\AnimalsPic\\" + uniqueFileName;
                }

                Category category = repository.GetCategoryById(animal.SelectedCategoryId);
                animal.CategoryId = animal.SelectedCategoryId;
                animal.Category = category;

                repository.InsertNewAnimal(animal);
                
                return View("Administrator", repository.GetCategorys());
            }
            return RedirectToAction("newAnimalInput", animal);
        }

        public IActionResult ChatForum(/*AnimalViewModel animal*/)
        {
            return View();
        }

    }
}
