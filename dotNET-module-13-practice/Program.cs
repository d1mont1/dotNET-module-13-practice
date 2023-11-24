using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using System.IO;
using System.Linq;

namespace dotNET_module_13_practice
{
    class Program
    {
        static void ex1()
        {
            List<int> numbers = new List<int> { 3, 7, 2, 9, 8, 5, 10, 6 };

            // Находим второе максимальное значение
            int max1 = numbers.Max();
            numbers.Remove(max1);
            int max2 = numbers.Max();

            Console.WriteLine($"Позиция второго максимального значения: {numbers.IndexOf(max2)}");
            Console.WriteLine($"Значение второго максимального значения: {max2}");

            // Удаляем все нечетные элементы
            numbers.RemoveAll(n => n % 2 != 0);

            Console.WriteLine("Список после удаления нечетных элементов:");
            foreach (var num in numbers)
            {
                Console.WriteLine(num);
            }
        }

        static void ex2()
        {
            List<double> doubles = new List<double> { 1.5, 2.3, 4.8, 3.1, 5.6 };

            double average = doubles.Average();

            Console.WriteLine("Элементы списка больше среднего арифметического:");
            foreach (var num in doubles)
            {
                if (num > average)
                {
                    Console.WriteLine(num);
                }
            }
        }

        static void ex3()
        {
            // Чтение чисел из файла
            string[] lines = File.ReadAllLines("input.txt");
            List<int> numbers = new List<int>();

            foreach (var line in lines)
            {
                if (int.TryParse(line, out int number))
                {
                    numbers.Add(number);
                }
            }

            // Перепись в другой файл в обратном порядке
            numbers.Reverse();
            File.WriteAllLines("output.txt", numbers.Select(n => n.ToString()));
            //ВАЖНОЕ СООБЩЕНИЕ: ПУТЬ К output.txt: dotNET-module-13-practice\dotNET-module-13-practice\bin\Debug\output.txt
        }

        static void ex4()
        {
            List<Employee> employees = new List<Employee>();
            // Загрузка данных о сотрудниках из файла
            string[] lines = File.ReadAllLines("employees.txt");
            foreach (var line in lines)
            {
                string[] data = line.Split(',');
                List<int> Salaries = new List<int>();
                int temp = 0;
                if (int.TryParse(data[1], out int IntSalary))
                {
                    temp = IntSalary;
                }
                Employee emp = new Employee
                {
                    LastName = data[0],
                    Salary = temp
                };

                employees.Add(emp);
            }

            // Вывод сотрудников с зарплатой < 10000 и остальных сотрудников сохраняя порядок
            var filteredEmployees = employees.Where(e => e.Salary < 10000).ToList();
            filteredEmployees.ForEach(Console.WriteLine);

            var remainingEmployees = employees.Except(filteredEmployees).ToList();
            remainingEmployees.ForEach(Console.WriteLine);
        }

        static void Main(string[] args)
        {
            ex3();
            ex4();
        }
    }
}
