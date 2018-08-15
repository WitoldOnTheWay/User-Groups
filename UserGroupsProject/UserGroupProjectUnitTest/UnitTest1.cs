using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserGroupsProject;
using UserGroupsProject.Controllers;
using UserGroupsProject.Models;



namespace UserGroupProjectUnitTest
{
    [TestClass]
    public class UnitTest1 //Methods from UserController
    {
        IUserRepository testUserRepository = new TestUserRepository();
        IGroupRepository testGroupRepository = new TestGroupRepository();

        [TestMethod]
        public void TestGetAll()
        {
            var userController= new UserController(testUserRepository, testGroupRepository);
            var result = userController.GetAll() as ViewResult;
            var users = (List<User>)result.ViewData.Model;
            Assert.AreEqual("Mike", users[0].Name);
            Assert.AreEqual("mike@gmail.com", users[0].Email);
            Assert.AreEqual(DateTime.Parse("2018-08-10"), users[0].CreationDate);
            Assert.AreEqual(1, users[0].Id);

        }

        [TestMethod]
        public void TestDetails()
        {
            var userController = new UserController(testUserRepository, testGroupRepository);
            var result = userController.Details(1) as ViewResult;
            var user = (User)result.ViewData.Model;
            Assert.AreEqual("Mike", user.Name);
            Assert.AreEqual("mike@gmail.com", user.Email);
            Assert.AreEqual(DateTime.Parse("2018 - 08 - 10"), user.CreationDate);
            Assert.AreEqual(1, user.Id);
        }
        [TestMethod]
        public void TestEdit()
        {
            var userController = new UserController(testUserRepository, testGroupRepository);
            var result = userController.Edit(1) as ViewResult;
            var user = (User)result.ViewData.Model;
            Assert.AreEqual("Mike", user.Name);
            Assert.AreEqual("mike@gmail.com", user.Email);
            Assert.AreEqual(DateTime.Parse("2018 - 08 - 10"), user.CreationDate);
            Assert.AreEqual(1, user.Id);
        }


        [TestMethod]
        public void TestEditWith2Parameters()
        {
            var userController = new UserController(testUserRepository, testGroupRepository);
            User userToEdit = new User();
            userToEdit.Name = "Mike";
            userToEdit.Email = "mike@gmail.com";
            userToEdit.CreationDate = DateTime.Parse("2018 - 08 - 10");
            userToEdit.Id = 1;
            var result = userController.Edit(userToEdit, 1) as RedirectToRouteResult;
            Assert.AreEqual("GetAll", result.RouteValues["action"]);
        }
        [TestMethod]
        public void TestCreate()
        {
            var userController = new UserController(testUserRepository, testGroupRepository);
            User userNewOne = new User();
            userNewOne.Name = "Mike";
            userNewOne.Email = "mike@gmail.com";
            userNewOne.CreationDate = DateTime.Parse("2018 - 08 - 10");
            userNewOne.Id = 1;
            var result = userController.Create(userNewOne) as RedirectToRouteResult;
            Assert.AreEqual("GetAll", result.RouteValues["action"]);
        }



        [TestMethod]
        public void TestGetGroupNames()
        {
            var userController = new UserController(testUserRepository, testGroupRepository);
            var result = userController.GetGroupNames(1) as ViewResult;
            var group = (GetGroupNamesViewModel)result.ViewData.Model;
            Assert.AreEqual("Sport Fans", group.Group[0].Name);
        }

    }
}
