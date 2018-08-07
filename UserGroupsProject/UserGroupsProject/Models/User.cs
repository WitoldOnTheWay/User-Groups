using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UserGroupsProject.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        //[DataType](DataType.Date)]
        //[DisplayFormat(DataFormatString= "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayFormat(DataFormatString ="{0:d}")]
        public DateTime CreationDate { get; set; }
        public int Id { get; set; }
    }
}