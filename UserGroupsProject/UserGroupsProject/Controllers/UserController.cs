using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserGroupsProject.Models;
using UserGroupsProject.Repositories;


namespace UserGroupsProject.Controllers
{
    public class UserController : Controller
    {
        UserRepository userRepository = new UserRepository();
        public ActionResult GetAll()
        {
            return View(userRepository.GetAll());
        }
        public ActionResult Details(int Id)
        {
            return View(userRepository.Details(Id));
        }
        public ActionResult Edit(int Id)
        {
            return View(userRepository.Details(Id));
        }
        [HttpPost]
        public ActionResult Edit(User user,int Id)
        {
            if (ModelState.IsValid)
            {
                userRepository.Edit(user, Id);
                return RedirectToAction("GetAll");
            }
            else
            {
                return View(user);
            }
            
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                userRepository.Create(user);
                return RedirectToAction("GetAll");
            }
            else
            {
                return View(user);
            }
        }
        public ActionResult Delete(int Id)
        {
            return View(userRepository.Details(Id));
        }
        [HttpPost]
        public ActionResult Delete(User user,int Id)
        {
            if (ModelState.IsValid)
            {
                userRepository.Delete(user, Id);
                return RedirectToAction("GetAll");
            }
            else
            {
                return View(user);
            }
        }
        public ActionResult GetGroupNames(int Id)
        {
            GetGroupNamesViewModel getGroupNamesModelView = new GetGroupNamesViewModel();
            GroupRepository groupRepository = new GroupRepository();
            getGroupNamesModelView.Group = userRepository.GetGroupNames(Id);
            getGroupNamesModelView.User=userRepository.Details(Id);
            return View(getGroupNamesModelView);
        }

       
        [HttpPost]
        public ActionResult AddThisUserToGroup(int UserID, int GroupID)
        {
            userRepository.AddThisUserToGroup(UserID, GroupID);
            return RedirectToAction("GetGroupNames",new { @id = UserID });
        }
        [HttpPost]
            public ActionResult DeleteThisUserFromGroup(int UserID,int GroupID)
        {
            userRepository.DeleteThisUserFromGroup(UserID, GroupID);
            return RedirectToAction("GetGroupNames", new { @id = UserID });
        }
        [Route("User/UserToGroup/{Id}")]
        [HttpGet]
        public ActionResult UserToGroup(int ID)
        {
            GetGroupNamesViewModel getGroupNamesModelView = new GetGroupNamesViewModel();
            GroupRepository groupRepository = new GroupRepository();
            getGroupNamesModelView.Group = userRepository.GetNotAssignedGroups(ID);
            getGroupNamesModelView.GroupMember = userRepository.GetGroupNames(ID);
            getGroupNamesModelView.User = userRepository.Details(ID);
            return View(getGroupNamesModelView);
        }
    }
}