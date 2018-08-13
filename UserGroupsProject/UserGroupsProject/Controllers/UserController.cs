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
        private readonly IUserRepository _userRepository;
        private readonly IGroupRepository _groupRepository;

        public UserController(IUserRepository userRepository, IGroupRepository groupRepository)
        {
            _userRepository = userRepository;
            _groupRepository = groupRepository;
        }
        public UserController() :this(new UserRepository(),new GroupRepository())
        {

        }


        public ActionResult GetAll()
        {
            return View(_userRepository.GetAll());
        }
        public ActionResult Details(int Id)
        {
            return View(_userRepository.Details(Id));
        }
        public ActionResult Edit(int Id)
        {
            return View(_userRepository.Details(Id));
        }
        [HttpPost]
        public ActionResult Edit(User user,int Id)
        {
            if (ModelState.IsValid)
            {
                _userRepository.Edit(user, Id);
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
                _userRepository.Create(user);
                return RedirectToAction("GetAll");
            }
            else
            {
                return View(user);
            }
        }
        public ActionResult Delete(int Id)
        {
            return View(_userRepository.Details(Id));
        }
        [HttpPost]
        public ActionResult Delete(User user,int Id)
        {
            if (ModelState.IsValid)
            {
                _userRepository.Delete(user, Id);
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
            getGroupNamesModelView.Group = _userRepository.GetGroupNames(Id);
            getGroupNamesModelView.User=_userRepository.Details(Id);
            return View(getGroupNamesModelView);
        }

       
        [HttpPost]
        public ActionResult AddThisUserToGroup(int UserID, int GroupID)
        {
            _userRepository.AddThisUserToGroup(UserID, GroupID);
            return RedirectToAction("GetGroupNames",new { @id = UserID });
        }
        [HttpPost]
            public ActionResult DeleteThisUserFromGroup(int UserID,int GroupID)
        {
            _userRepository.DeleteThisUserFromGroup(UserID, GroupID);
            return RedirectToAction("GetGroupNames", new { @id = UserID });
        }
        [Route("User/UserToGroup/{Id}")]
        [HttpGet]
        public ActionResult UserToGroup(int ID)
        {
            GetGroupNamesViewModel getGroupNamesModelView = new GetGroupNamesViewModel();
            getGroupNamesModelView.Group = _userRepository.GetNotAssignedGroups(ID);
            getGroupNamesModelView.GroupMember = _userRepository.GetGroupNames(ID);
            getGroupNamesModelView.User = _userRepository.Details(ID);
            return View(getGroupNamesModelView);
        }
    }
}