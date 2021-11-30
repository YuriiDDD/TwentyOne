using System;

namespace Employee
{
    class Program
    {
        public static void Print(string[] points, int choose)
        {
            Console.Clear();
            for (int i = 0; i < points.Length; i++)
                Console.WriteLine("{0} {1}", points[i], i == choose ? "<<--" : "");
        }
        public static int Menu(string[] points)
        {
            Console.CursorVisible = false; // Чтобы не было мигающего курсора.
            int choose = 0;
            while (true) // Бесконечный цикл.
            {
                Print(points, choose);
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow: choose--; break;
                    case ConsoleKey.DownArrow: choose++; break;
                    case ConsoleKey.D: Console.CursorVisible = true; return -1;
                    case ConsoleKey.Enter: Console.CursorVisible = true; return choose;
                }
                choose = (choose + points.Length) % points.Length; // Зацикливаем выбор.
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            //Adding employees
            Company MyCompany = new Company();
            Employee rabotnik1 = new Employee("Sergey", "Petrov", 5, RankType.Worker);
            MyCompany += rabotnik1;
            rabotnik1 = new Employee("Andrey", "Ivanov", 13, RankType.Director);
            MyCompany += rabotnik1;
            rabotnik1 = new Employee("Ivan", "Dolgiy", 7, RankType.Foreman);
            MyCompany += rabotnik1;
            rabotnik1 = new Employee("Petr", "Khmelevskiy", 4, RankType.Manager);
            MyCompany += rabotnik1;
            rabotnik1 = new Employee("Konstantin", "Pavlenko", 9, RankType.Worker);
            MyCompany += rabotnik1;
            rabotnik1 = new Employee("Maxim", "Vasiuta", 2, RankType.Worker);
            MyCompany += rabotnik1;

           //
            
            string[] points = { "1) Добавить сотрудника", "2) Удалить сотрудника", "3) Распечатать список сотрудников", "4) Сравнить по должности", "5) Выход" };
            int choose = -1;
            while (choose!=4)
            {
                choose = Menu(points);

                Console.WriteLine($"Выбран пункт № { choose + 1}");

                switch (choose)
                {
                    // Add
                    case 0:
                        Console.WriteLine("Введите имя, фамилию, стаж, должность (0-4) сотрудника:");
                        rabotnik1 = new Employee(Console.ReadLine(), Console.ReadLine(), Convert.ToInt32(Console.ReadLine()), (RankType)Convert.ToInt32(Console.ReadLine()));
                        MyCompany += rabotnik1;
                        MyCompany.PrintEmployees();
                        break;
                    //Delete
                    case 1:
                        MyCompany.PrintEmployees();
                        Console.WriteLine("Введите номер сотрудника, которого необходимо удалить:");
                        int number = Convert.ToInt32(Console.ReadLine());
                        rabotnik1 = MyCompany.Employees[number];
                        MyCompany -= rabotnik1;
                        break;
                    //Print
                    case 2:
                        MyCompany.PrintEmployees();
                        break;
                    //Compare
                    case 3:
                        MyCompany.PrintEmployees();
                        Console.WriteLine("Введите номера сравниваемых сотрудников");
                        int x = MyCompany.CompareRankType(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()));
                        if (x == -1) Console.WriteLine("Должности сравниваемых сотрудников равноценны");
                        else
                        {
                            Console.WriteLine("Старше по должности сотрудник: ");
                            MyCompany.PrintEmployees(x);
                        }
                        break;
                    //Exit
                    default:

                        break;
                }

            }
            }
           

           // Console.ReadKey();
        }
    }

