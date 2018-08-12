using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserGroupsProject.Models
{
    public class GetGroupNamesViewModel
    {
        public User user { get; set; }
        public List<Group> group { get; set; }
        public List<Group> groupMember { get; set; }
    }
}