using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Server.Models
{
    public class User : IdentityUser
    {
        private string pathAvatar;
        /// <summary>Имя</summary>
        public string FirstName { get; set; }

        /// <summary>Фамилия</summary>
        public string LastName { get; set; }

        /// <summary>Отчество</summary>
        public string Patronymic { get; set; }

        /// <summary>Возраст</summary>
        public int Age { get; set; }

        /// <summary>Путь к аватару пользователя</summary>
        public string PathAvatar
        {
            get
            {
                if (pathAvatar == null || !File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot") + pathAvatar))
                    return @"/Files/noAvatar.png";
                return pathAvatar;
            }
            set => pathAvatar = value;
        }

    }
}
