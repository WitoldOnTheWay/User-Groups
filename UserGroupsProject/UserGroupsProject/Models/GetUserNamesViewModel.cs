using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserGroupsProject.Models
{
    public class GetUserNamesViewModel
    {
        public List<User> User { get; set; }
        public List<User> UserMember { get; set; }
        public Group Group { get; set; }
    }
}