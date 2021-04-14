namespace MyProject.Domain.Entities
{
    public class Employee 
    {
        /// <summary>Идентификатор</summary>
        public int Id { get; set; }

        /// <summary>Имя</summary>
        public string FirstName { get; set; }

        /// <summary>Фамилия</summary>
        public string LastName { get; set; }

        /// <summary>Отчество</summary>
        public string Patronymic { get; set; }

        /// <summary>Возраст</summary>
        public int Age { get; set; }

        /// <summary>Адрес почты</summary>
        public string Email { get; set; }
    }
}
