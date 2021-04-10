using System;
using System.Collections.Generic;
using System.Net;
using MyProject.Domain.Models;

namespace MyProject.Interfaces.API
{
    public interface IEmployeeServices
    {
        /// <summary>
        /// Возвращает перечисление строк
        /// </summary>
        /// <returns></returns>
        IEnumerable<Employee> Get();

        /// <summary>
        /// Возвращает одну строку
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Employee Get(int id);

        /// <summary>
        /// Создавать новую строку и возващать ссылку на эту созданную строку
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        Uri Post(string value);

        /// <summary>
        /// Обновить строку и вернуть код результата
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        HttpStatusCode Update(int id, string value);

        /// <summary>
        /// Удалить строку по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        HttpStatusCode Delete(int id);
    }
}
