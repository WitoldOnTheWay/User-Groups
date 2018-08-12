using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserGroupsProject.Models
{
    public class GetGroupNamesViewModel
    {
        public User User { get; set; }
        public List<Group> Group { get; set; }
        public List<Group> GroupMember { get; set; }
    }
}