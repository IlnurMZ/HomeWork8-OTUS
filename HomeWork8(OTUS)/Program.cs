using System;
using System.Collections.Generic;

namespace HomeWork8_OTUS_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Вариант с вводом данных дерева вручную
            while (true)
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Введите имя");
                string name = Console.ReadLine();
                int salary;
                bool isCorrectSalary;
                do
                {
                    Console.WriteLine("Введите зарплату");
                    isCorrectSalary = int.TryParse(Console.ReadLine(), out salary);
                } while (!isCorrectSalary);

                // создаем корень дерева (минимальное необходимое!)
                Node root = new Node()
                {
                    Name = name,
                    Salary = salary
                };

                // добавляем дочерние узлы
                while (true)
                {
                    Console.WriteLine("Введите имя");
                    name = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(name))
                        break;
                    do
                    {
                        Console.WriteLine("Введите зарплату");
                        isCorrectSalary = int.TryParse(Console.ReadLine(), out salary);
                    } while (!isCorrectSalary);
                    // вызываем метод добавления узла в дерево
                    AddNode(root, name, salary);
                }

                Console.WriteLine();
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
                    continue;
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
            } else if (salary == node.Salary)
            {
                return node.Name;
            } else if (salary > node.Salary)
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
