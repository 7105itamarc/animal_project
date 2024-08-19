using _1907FirstWebAppAtempt.Models;
using _1907FirstWebAppAtempt.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _1907FirstWebAppAtempt.Repositories
{
    public interface IRepository
    {
        Animal GetAnimalById(int id);
        Category GetCategoryById(int id);

        List<Animal> GetAnimalsByCommentsAmount(int topAnimals);
        List<Category> GetCategorys();
        void SaveComment(Animal animal, Comment comment);
        void DeleteAnimal(int id);
        void SaveAnimalChanges(Animal animal);
        AnimalViewModel AnimalToAnimalVM(Animal animal);
        List<SelectListItem> CategorysToSelectListItem(List<Category> categorys);
        void InsertNewAnimal(Animal animal);

    }
}
