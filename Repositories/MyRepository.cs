using _1907FirstWebAppAtempt.Data;
using _1907FirstWebAppAtempt.Models;
using _1907FirstWebAppAtempt.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace _1907FirstWebAppAtempt.Repositories
{
    public class MyRepository : IRepository
    {
        private ZooContext context;

        public MyRepository(ZooContext context)
        {
            this.context = context;   
        }

<<<<<<< HEAD
=======
        public void InsertUser(MyUser user)
        {
            context.AllUsers.Add(user);
            context.SaveChanges();
        }
        public void DeleteUser(int id)
        {
            var user = context.AllUsers!.Single(u => u.UserId == id);
            context.AllUsers.Remove(user);
            context.SaveChanges();
        }

        public IEnumerable<MyUser> GetUsers()
        {
            return context.AllUsers;
        }


        public void UpdateUserName(int id, string UserName)
        {
            var user = context.AllUsers!.Single(u => u.UserId == id);
            user.UserName = UserName;
            context.SaveChanges();
        }

>>>>>>> 26281e4ca54093c2eef448ab8311b83ba2c3019b
        public Animal GetAnimalById(int id)
        {
            // explicite Loading 
            var animal = 
                context.Animals!.Single(a => a.AnimalId == id);
                //context.Entry(animal).Collection(a => a.Comments!).Load();
                //context.Entry(animal).Reference(a => a.Category).Load();


            //lazy loading
            return animal;
        }

        public Category GetCategoryById(int id)
        {
			var categories = context.Categories!.ToList();
			return categories.FirstOrDefault(c => c.CategoryId == id);
        }

        public List<Category> GetCategorys()
        {
            // Eagar Loading 
            var categories =
                context.Categories!//.
                                   //Include(c => c.Animals!)
                                   //.ThenInclude(a => a.Comments)
                .ToList();

            //if (category == null)
                return categories;
            
            //return categories.Where(c => c.CategoryId == category.CategoryId).ToList();
        }

        public List<Animal> GetAnimalsByCommentsAmount(int topAnimals)
        {
            return context.Animals.OrderByDescending(a => a.Comments!.Count).Take(topAnimals).ToList();
        }

        public void SaveComment(Animal animal, Comment comment)
        {
            animal.Comments!.Add(comment);
            context.SaveChanges();
        }

        public void DeleteAnimal(int id)
        {
            context.Animals.Remove(GetAnimalById(id));
            context.SaveChanges();
        }

        public void SaveAnimalChanges(Animal animal)
        {
            Animal OriginalAnimal = GetAnimalById(animal.AnimalId);
            UpdateAnimalParams(animal, OriginalAnimal);
            context.SaveChanges();
        }

        
        public AnimalViewModel AnimalToAnimalVM(Animal animal)
        {
            AnimalViewModel animalViewModel = new AnimalViewModel();
            UpdateAnimalParams(animal, animalViewModel);

            return animalViewModel;
        }

        public List<SelectListItem> CategorysToSelectListItem(List<Category> categorys)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (Category category in categorys) 
            {
                SelectListItem item = new SelectListItem { Value = category.CategoryId.ToString(), Text = category.CategoryName };
                items.Add(item);
            }
            return items;
        }

        public void InsertNewAnimal(Animal animal)
        {
            context.Animals.Add(animal);
            context.SaveChanges();
        }

        private static void UpdateAnimalParams(Animal animal, Animal OriginalAnimal)
        {
            foreach (PropertyInfo property in typeof(Animal).GetProperties())
            {
                if (property.GetValue(animal) != null)
                    property.SetValue(OriginalAnimal, property.GetValue(animal));
            }
            //מחיקת תוכן שדה ללא השמה של תוכן חלופי לא תתאפשר
        }

    }


}
