using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Server.Models
{
    public class User : IdentityUser
    {
        /// <summary>Имя</summary>
        public string FirstName { get; set; }

        /// <summary>Фамилия</summary>
        public string LastName { get; set; }

        /// <summary>Отчество</summary>
        public string Patronymic { get; set; }

        /// <summary>Возраст</summary>
        public int Age { get; set; }

    }
}
