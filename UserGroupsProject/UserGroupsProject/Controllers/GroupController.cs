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
        
        public ActionResult Details(int id)
        {
            return View(_groupRepository.Details(id));
        }
        
        public ActionResult Delete(int id)
        {
            return View(_groupRepository.Details(id));
        }
        [HttpPost]
        public ActionResult Delete(Group group,int id)
        {
            if (ModelState.IsValid)
            {
                _groupRepository.Delete(group,id);
                return RedirectToAction("GetAll");
            }
            else
            {
                return View(group);
            }
        }
        
        public ActionResult Edit(int id)
        {
            return View(_groupRepository.Details(id));
        }
        [HttpPost]
        public ActionResult Edit(Group group,int id)
        {
            if (ModelState.IsValid)
            {
                _groupRepository.Edit(group, id);
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
        public ActionResult GetUserNames(int id)
        {
            GetUserNamesViewModel getUserNamesModelview = new GetUserNamesViewModel();
            getUserNamesModelview.User = _groupRepository.GetUserNames(id);
            getUserNamesModelview.Group = _groupRepository.Details(id);
            return View(getUserNamesModelview);
        }
        [Route("Group/AddGroupToUser/{Id}")]
        [HttpGet]
        public ActionResult AddGroupToUser(int id)
        {
            GetUserNamesViewModel getUserNamesModelView = new GetUserNamesViewModel();
            getUserNamesModelView.UserMember = _groupRepository.GetUserNames(id);
            getUserNamesModelView.User = _groupRepository.GetNotAssignedUsers(id);
            getUserNamesModelView.Group = _groupRepository.Details(id);
            return View(getUserNamesModelView);
        }
        [HttpPost]
        public ActionResult AddThisUserToGroup(int userID, int groupID)
        {
            _userRepository.AddThisUserToGroup(userID, groupID);
            return RedirectToAction("GetUserNames", new { @id = groupID });
        }
       
    }

}