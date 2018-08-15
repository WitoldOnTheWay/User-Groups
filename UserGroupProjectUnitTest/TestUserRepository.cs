using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserGroupsProject;
using UserGroupsProject.Models;

namespace UserGroupProjectUnitTest
{
    public class TestUserRepository:IUserRepository
    {
       
        public List<User> GetAll()
        {
            List<User> user = new List<User>();
            User testUser = new User();
            testUser.Name = "Mike";
            testUser.Email = "mike@gmail.com";
            testUser.CreationDate = DateTime.Parse("2018-08-10");
            testUser.Id = 1;
            user.Add(testUser);
            return user;
        }

        public User Details(int id)
        {
            
            User testUser = new User();
            testUser.Name = "Mike";
            testUser.Email = "mike@gmail.com";
            testUser.CreationDate = DateTime.Parse("2018 - 08 - 10");
            testUser.Id = 1;
            return testUser;

        }

        public User Edit(User user, int id)
        {
            User testUser = new User();
            testUser.Name = "Mike";
            testUser.Email = "mike@gmail.com";
            testUser.CreationDate = DateTime.Parse("2018 - 08 - 10");
            testUser.Id = 1;
            return testUser;

        }

        public void Create(User user)
        {
        }

        public void Delete(User user, int id)
        {
        }

        public List<Group> GetGroupNames(int id)
        {
            List<Group> group = new List<Group>();
            Group testGroup = new Group();
            testGroup.Name = "Sport Fans";
            testGroup.Id = 1;
            group.Add(testGroup);
            return group;
        }

        public void AddThisUserToGroup(int userID, int groupID)
        {
        }

        public void DeleteThisUserFromGroup(int userID, int groupID)
        {
        }

        public List<Group> GetNotAssignedGroups(int id)
        {
            List<Group> group = new List<Group>();
            Group testGroup = new Group();
            testGroup.Name = "Customers";
            testGroup.Id = 1;
            group.Add(testGroup);
            return group;
        }
    }
}
