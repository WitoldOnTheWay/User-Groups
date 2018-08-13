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
        private readonly IUserRepository _userRepository;
        private readonly IGroupRepository _groupRepository;

        public GroupController(IUserRepository userRepository, IGroupRepository groupRepository)
        {
            _userRepository = userRepository;
            _groupRepository = groupRepository;
        }
        public GroupController() :this(new UserRepository(),new GroupRepository())
        {
            
        }
       
        public ActionResult GetAll()
        {
            return View(_groupRepository.GetAll());
        }
        
        public ActionResult Details(int Id)
        {
            return View(_groupRepository.Details(Id));
        }
        
        public ActionResult Delete(int Id)
        {
            return View(_groupRepository.Details(Id));
        }
        [HttpPost]
        public ActionResult Delete(Group group,int Id)
        {
            if (ModelState.IsValid)
            {
                _groupRepository.Delete(group,Id);
                return RedirectToAction("GetAll");
            }
            else
            {
                return View(group);
            }
        }
        
        public ActionResult Edit(int Id)
        {
            return View(_groupRepository.Details(Id));
        }
        [HttpPost]
        public ActionResult Edit(Group group,int Id)
        {
            if (ModelState.IsValid)
            {
                _groupRepository.Edit(group, Id);
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
                _groupRepository.Create(group);
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
            getUserNamesModelview.User = _groupRepository.GetUserNames(Id);
            getUserNamesModelview.Group = _groupRepository.Details(Id);
            return View(getUserNamesModelview);
        }
        [Route("Group/AddGroupToUser/{Id}")]
        [HttpGet]
        public ActionResult AddGroupToUser(int ID)
        {
            GetUserNamesViewModel getUserNamesModelView = new GetUserNamesViewModel();
            getUserNamesModelView.UserMember = _groupRepository.GetUserNames(ID);
            getUserNamesModelView.User = _groupRepository.GetNotAssignedUsers(ID);
            getUserNamesModelView.Group = _groupRepository.Details(ID);
            return View(getUserNamesModelView);
        }
        [HttpPost]
        public ActionResult AddThisUserToGroup(int UserID, int GroupID)
        {
            _userRepository.AddThisUserToGroup(UserID, GroupID);
            return RedirectToAction("GetUserNames", new { @id = GroupID });
        }
       
    }

}