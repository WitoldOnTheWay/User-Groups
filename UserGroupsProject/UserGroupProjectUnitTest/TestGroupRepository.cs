using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserGroupsProject;
using UserGroupsProject.Models;

namespace UserGroupProjectUnitTest
{
    class TestGroupRepository : IGroupRepository
    {
        public List<Group> GetAll()
        {
            List<Group> group = new List<Group>();
            Group testGroup = new Group();
            testGroup.Name = "Milk drinkers";
            testGroup.Id = 1;
            group.Add(testGroup);

            return group;
        }
        public Group Details(int id)
        {
           
            Group testGroup = new Group();
            testGroup.Name = "Sport Fans";
            testGroup.Id = 1;
            return testGroup;
        }
       public void Delete(Group group, int id)
        {

        }
        public Group Edit(Group group, int id)
        {
            Group testGroup = new Group();
            testGroup.Name = "Sport Fans";
            testGroup.Id = 1;
            return testGroup;

        }

        public void Create(Group group)
        {

        }
        public List<User> GetUserNames(int id)
        {
            List<User> user = new List<User>();
            User testUser = new User();
            testUser.Name = "Mike";
            testUser.Email = "mike@gmail.com";
            testUser.CreationDate = DateTime.Parse("2018 - 08 - 10");
            testUser.Id = 1;
            user.Add(testUser);
            return user;
        }
        public List<User> GetNotAssignedUsers(int id)
        {
            List<User> user = new List<User>();
            User testUser = new User();
            testUser.Name = "Mike";
            testUser.Email = "mike@gmail.com";
            testUser.CreationDate = DateTime.Parse("2018 - 08 - 10");
            testUser.Id = 1;
            user.Add(testUser);
            return user;
        }




    }
}
