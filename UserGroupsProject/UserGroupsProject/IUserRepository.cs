using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserGroupsProject.Models;

namespace UserGroupsProject
{
    public interface IUserRepository
    {
         List<User> GetAll();

         User Details(int Id);

        User Edit(User user, int Id);

        void Create(User user);

        void Delete(User user,int Id);

        List<Group> GetGroupNames(int Id);

        void AddThisUserToGroup(int UserID, int GroupID);

        void DeleteThisUserFromGroup(int UserID, int GroupID);

        List<Group> GetNotAssignedGroups(int ID);


    }
}
