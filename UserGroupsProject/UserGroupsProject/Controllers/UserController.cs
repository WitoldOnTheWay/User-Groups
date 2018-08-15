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
        public ActionResult Details(int id)
        {
            
            return View(_userRepository.Details(id));

        }
        public ActionResult Edit(int id)
        {
            return View(_userRepository.Details(id));
        }
        [HttpPost]
        public ActionResult Edit(User user,int id)
        {
            if (ModelState.IsValid)
            {
                _userRepository.Edit(user, id);
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
        public ActionResult Delete(int id)
        {
            return View(_userRepository.Details(id));
        }
        [HttpPost]
        public ActionResult Delete(User user,int id)
        {
            if (ModelState.IsValid)
            {
                _userRepository.Delete(user, id);
                return RedirectToAction("GetAll");
            }
            else
            {
                return View(user);
            }
        }
        public ActionResult GetGroupNames(int id)
        {
            GetGroupNamesViewModel getGroupNamesViewModel = new GetGroupNamesViewModel();
            getGroupNamesViewModel.Group = _userRepository.GetGroupNames(id);
            getGroupNamesViewModel.User=_userRepository.Details(id);
            return View(getGroupNamesViewModel);
        }

   
        [HttpPost]
        public ActionResult AddThisUserToGroup(int userID, int groupID)
        {
            _userRepository.AddThisUserToGroup(userID, groupID);
            return RedirectToAction("GetGroupNames",new { @id = userID });
        }
        [HttpPost]
            public ActionResult DeleteThisUserFromGroup(int userID,int groupID)
        {
            _userRepository.DeleteThisUserFromGroup(userID, groupID);
            return RedirectToAction("GetGroupNames", new { @id = userID });
        }
        [Route("User/UserToGroup/{Id}")]
        [HttpGet]
        public ActionResult UserToGroup(int id)
        {
            GetGroupNamesViewModel getGroupNamesModelView = new GetGroupNamesViewModel();
            getGroupNamesModelView.Group = _userRepository.GetNotAssignedGroups(id);
            getGroupNamesModelView.GroupMember = _userRepository.GetGroupNames(id);
            getGroupNamesModelView.User = _userRepository.Details(id);
            return View(getGroupNamesModelView);
        }
    }
}