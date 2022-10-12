﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryReportProject.Entities
{
    public class Laborant : IEntity, IPerson
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string SurName { get; set; } 
        public string IdentityNumber { get; set; }  
        public DateTime BirthDate { get; set; }  
        public int RoleId { get; set; } 
        public string UserName { get; set; }    
        public string Password { get; set; }    
    }
}
