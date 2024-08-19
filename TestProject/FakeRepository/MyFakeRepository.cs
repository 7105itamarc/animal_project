using _1907FirstWebAppAtempt;
using _1907FirstWebAppAtempt.Models;
using _1907FirstWebAppAtempt.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.FakeRepository
{
    internal class MyFakeRepository : IRepository
    {
        private IEnumerable<Animal> Animals;

        public IPrimeService IprimeS { get; set; }

        public MyFakeRepository()
        {
            Animals = new List<Animal>() { new Animal() { AnimalId = 1, Name = "Eli", Age = 1, PictureName = "pic", Description = "Elephent", CategoryId = 1 },
                new Animal() { AnimalId = 2, Name = "catly", Age = 2, PictureName = "pic", Description = "cat", CategoryId = 1 }
        };
    }
        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetCategorys()
        {
            throw new NotImplementedException();
        }

        public Animal GetAnimalById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Animal> GetAnimalsByCommentsAmount(int topAnimals)
        {
            return this.Animals.ToList();
        }

        public IEnumerable<LoginDetials> GetUsers()
        {
            throw new NotImplementedException();
        }

        public void InsertUser(LoginDetials user)
        {
            throw new NotImplementedException();
        }

        public void UpdateUserName(int id, string UserName)
        {
            throw new NotImplementedException();
        }
    }
}
