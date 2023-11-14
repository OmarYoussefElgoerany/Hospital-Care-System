using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCareSystem.DAL.Data.Models
{
    public class User:IdentityUser
    {
        public string? Department { get; set; }
    }
}
