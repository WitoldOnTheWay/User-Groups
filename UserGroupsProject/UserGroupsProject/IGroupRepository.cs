using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserGroupsProject.Models;

namespace UserGroupsProject
{
    public interface IGroupRepository
    {
        List<Group> GetAll();
        Group Details(int Id);
        void Delete(Group group, int Id);
        Group Edit(Group group, int Id);
        void Create(Group group);
        List<User> GetUserNames(int Id);
        List<User> GetNotAssignedUsers(int ID);


    }
}
