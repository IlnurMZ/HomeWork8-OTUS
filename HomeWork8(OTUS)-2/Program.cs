using System;
using System.Collections.Generic;

namespace HomeWork8_OTUS_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Вариант с "зашитыми" данными с именами и зп в листе
            // Надеюсь, что кроме этих данных больше зашивать ничего не нужно
            
            List<Employee> employees = new List<Employee>() {
                new Employee("Евгений", 100),
                new Employee("Кирилл", 90),
                new Employee("Алена", 135),
                new Employee("Костя", 70),
                new Employee("Слава", 95),
                new Employee("Макс",120),
                new Employee("Дима", 140),
                new Employee("Лена", 92),
                new Employee("Степан", 97)
            };

            while (true)
            {
                // создаем корень дерева (минимальное необходимое!)
                Node root = new Node()
                {
                    Name = employees[0].Name,
                    Salary = employees[0].Salary
                };

                for (int i = 1; i < employees.Count; i++)                
                    AddNode(root, employees[i].Name, employees[i].Salary);                
                
                // Обходим дерево
                Traverse(root);
                Console.WriteLine();

                int choiseUser;
                do
                {
                    Console.Write("Введите искомый уровень заработный платы:  ");
                    int salarySeach = int.Parse(Console.ReadLine());

                    // Поиск человека по введенному значению зп
                    Console.WriteLine(SeachEmploeyr(root, salarySeach));
                    Console.WriteLine();

                    Console.WriteLine("Введите:\n0 - для ввода нового списка сотрудников," +
                        "\n1 - для нового поиска сотрудника," +
                        "\n<0 или >1 - для выхода из программы");
                    choiseUser = int.Parse(Console.ReadLine());
                } while (choiseUser == 1);

                if (choiseUser == 0)
                {                   
                    employees.Clear();

                    // добавляем данные в листы для корня
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine("Введите имя");
                    string name = Console.ReadLine();                    
                    
                    Console.WriteLine("Введите зарплату");
                    int salary = int.Parse(Console.ReadLine());

                    employees.Add(new Employee(name, salary));

                    // добавляем данные в листы по дочерним узлам
                    while (true)
                    {
                        Console.WriteLine("Введите имя");
                        name = Console.ReadLine();                        
                        if (String.IsNullOrWhiteSpace(name))
                            break;
                        
                        bool isCorrectSalary;
                        do
                        {
                            Console.WriteLine("Введите зарплату");
                            isCorrectSalary = int.TryParse(Console.ReadLine(), out salary);
                        } while (!isCorrectSalary);

                        employees.Add(new Employee(name, salary));                  
                    }
                }                
                else
                    break;
            }
        }

        // Метод добавления узла в бинарное дерево поиска
        static void AddNode(Node node, string name, int salary)
        {
            if (salary < node.Salary)
            {
                if (node.Left != null)
                    AddNode(node.Left, name, salary);
                else
                {
                    node.Left = new Node()
                    {
                        Name = name,
                        Salary = salary,
                    };
                }
            }
            else
            {
                if (node.Right != null)
                    AddNode(node.Right, name, salary);
                else
                {
                    node.Right = new Node()
                    {
                        Name = name,
                        Salary = salary,
                    };
                }
            }
        }

        // Поиск сотрудника по уровню зарплаты
        static string SeachEmploeyr(Node node, int salary)
        {
            string name = "такой сотрудник не найден";
            if (salary < node.Salary)
            {
                if (node.Left != null)
                    name = SeachEmploeyr(node.Left, salary);
            }

            else if (salary == node.Salary)
            {
                return node.Name;
            }

            else if (salary > node.Salary)
            {
                if (node.Right != null)
                    name = SeachEmploeyr(node.Right, salary);
            }
            return name;
        }

        // Вывод информации из узлов дерева путем симметричного обхода
        static void Traverse(Node node)
        {
            if (node.Left != null)
            {
                Traverse(node.Left);
            }

            Console.WriteLine($"{node.Name} - {node.Salary}");

            if (node.Right != null)
            {
                Traverse(node.Right);
            }
        }
    }
}
