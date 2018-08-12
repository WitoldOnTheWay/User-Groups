using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserGroupsProject.Models;
using UserGroupsProject.Repositories;

namespace UserGroupsProject.Controllers
{
    public class GroupController : Controller
    {
        GroupRepository groupRepository = new GroupRepository();
        // GET: Group/GetAll
        public ActionResult GetAll()
        {
            return View(groupRepository.GetAll());
        }
        //GET: Group/Details/Id
        public ActionResult Details(int Id)
        {
            return View(groupRepository.Details(Id));
        }
        //GET: Group/Delete/Id
        public ActionResult Delete(int Id)
        {
            return View(groupRepository.Details(Id));
        }
        [HttpPost]
        public ActionResult Delete(Group group,int Id)
        {
            if (ModelState.IsValid)
            {
                groupRepository.Delete(group,Id);
                return RedirectToAction("GetAll");
            }
            else
            {
                return View(group);
            }
        }
        //GET: Group/Edit/Id
        public ActionResult Edit(int Id)
        {
            return View(groupRepository.Details(Id));
        }
        [HttpPost]
        public ActionResult Edit(Group group,int Id)
        {
            if (ModelState.IsValid)
            {
                groupRepository.Edit(group, Id);
                return RedirectToAction("GetAll");
            }
            else
            {
                return View("group");
            }
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Group group)
        {
            if (ModelState.IsValid)
            {
                groupRepository.Create(group);
                return RedirectToAction("GetAll");
            }
            else
            {
                return View(group);
            }
        }
        public ActionResult GetUserNames(int Id)
        {
            GetUserNamesViewModel getUserNamesModelview = new GetUserNamesViewModel();
            UserRepository userRepository = new UserRepository();
            getUserNamesModelview.user = groupRepository.GetUserNames(Id);
            getUserNamesModelview.group = groupRepository.Details(Id);
            return View(getUserNamesModelview);
        }
        [Route("Group/AddGroupToUser/{Id}")]
        [HttpGet]
        public ActionResult AddGroupToUser(int ID)
        {
            GetUserNamesViewModel getUserNamesModelView = new GetUserNamesViewModel();
            UserRepository userRepository = new UserRepository();
            getUserNamesModelView.userMember = groupRepository.GetUserNames(ID);
            getUserNamesModelView.user = groupRepository.GetNotAssignedUsers(ID);
            getUserNamesModelView.group = groupRepository.Details(ID);
            return View(getUserNamesModelView);
        }
        [HttpPost]
        public ActionResult AddThisUserToGroup(int UserID, int GroupID)
        {
            UserRepository userRepository = new UserRepository();
            userRepository.AddThisUserToGroup(UserID, GroupID);
            return RedirectToAction("GetUserNames", new { @id = GroupID });
        }
       
    }

}