using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Employee
    {
        public string LastName { get; set; }
        public int Salary { get; set; }
        // Другие свойства сотрудника

        public override string ToString()
        {
            return $"Имя: {LastName} Зарплата: {Salary}"; // Здесь выводите нужные данные о сотруднике
        }
    }
}
