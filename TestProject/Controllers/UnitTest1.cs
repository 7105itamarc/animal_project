using _1907FirstWebAppAtempt.Controllers;
using _1907FirstWebAppAtempt.Data;
using _1907FirstWebAppAtempt.Models;
using _1907FirstWebAppAtempt.Repositories;
using Microsoft.AspNetCore.Mvc;
using TestProject.FakeRepository;

namespace TestProject.Controllers

{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            var Rep = new MyFakeRepository();
            var controller = new MainController(Rep.IprimeS,Rep);

            // Act
            var result = controller.HomePage() as ViewResult;

            // Assert
            Assert.AreEqual(typeof(List<Animal>), result!.Model!.GetType());


            //ZooContext zooContext = new ZooContext();
            //MyRepository myRepository = new MyRepository();

        }
    }
}