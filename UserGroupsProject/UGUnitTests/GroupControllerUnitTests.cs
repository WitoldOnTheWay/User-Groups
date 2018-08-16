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
    public class GroupControllerUnitTests
    {
        IUserRepository testUserRepository = new TestUserRepository();
        IGroupRepository testGroupRepository = new TestGroupRepository();

        [TestMethod]
        public void TestGetAll()
        {
            var groupController = new GroupController(testUserRepository, testGroupRepository);
            var result = groupController.GetAll() as ViewResult;
            var groups = (List<Group>)result.ViewData.Model;
            Assert.AreEqual("Milk drinkers", groups[0].Name);
            Assert.AreEqual(1, groups[0].Id);
        }

        [TestMethod]
        public void TestDetails()
        {
            var groupController = new GroupController(testUserRepository, testGroupRepository);
            var result = groupController.Details(1) as ViewResult;
            var group = (Group)result.ViewData.Model;
            Assert.AreEqual("Sport Fans", group.Name);
            Assert.AreEqual(1, group.Id);
        }
        [TestMethod]
        public void TestEdit()
        {
            var groupController = new GroupController(testUserRepository, testGroupRepository);
            var result = groupController.Edit(1) as ViewResult;
            var group = (Group)result.ViewData.Model;
            Assert.AreEqual("Sport Fans", group.Name);
            Assert.AreEqual(1, group.Id);
        }
        [TestMethod]
        public void TestEditWith2Parameters()
        {
            var groupController = new GroupController(testUserRepository, testGroupRepository);
            Group groupToEdit = new Group();
            groupToEdit.Name = "Sport Fans";
            groupToEdit.Id = 1;
            var result = groupController.Edit(groupToEdit, 1) as RedirectToRouteResult;
            Assert.AreEqual("GetAll", result.RouteValues["action"]);
        }
        [TestMethod]
        public void TestCreate()
        {
            var groupController = new GroupController(testUserRepository, testGroupRepository);
            Group groupNewOne = new Group();
            groupNewOne.Name = "Mike";
            groupNewOne.Id = 1;
            var result = groupController.Create(groupNewOne) as RedirectToRouteResult;
            Assert.AreEqual("GetAll", result.RouteValues["action"]);
        }
        [TestMethod]
        public void TestGetUserNames()
        {
            var groupController = new GroupController(testUserRepository, testGroupRepository);
            var result = groupController.GetUserNames(1) as ViewResult;
            var user = (GetUserNamesViewModel)result.ViewData.Model;
            Assert.AreEqual("Mike", user.User[0].Name);
        }
    }
}
