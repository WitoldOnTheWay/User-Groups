using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserGroupsProject.Models
{
    public class GetUserNamesViewModel
    {
        public List<User> user { get; set; }
        public List<User> userMember { get; set; }
        public Group group { get; set; }
    }
}