using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            string[] menu = new string[] {
                "Простая выборка элементов",
                "Выборка отдельного поля (проекция)",
                "Создание нового объекта анонимного типа",
                "Условия",
                "Сортировка с использованием расширяющих методов",
                "Декартовое произведение",
                "Inner Join",
                "Group Join",
                "Cross Join",
                "Outer Join",
                "Distinct",
                "Union - объединение без дубликатов",
                "Concat - объединение с дубликатами",
                "Intersect - пересечение",
                "Группирование с функциями агрегирования"
            };

            DataAsker asker = new DataAsker();
            Dictionary<DataNames, string> filenames = asker.CreateXmls();
            ConsoleNavigationMenu navMenu = new ConsoleNavigationMenu(menu);
            CommandList commandList = new CommandList(filenames);
            while (true)
            {
                int choice = navMenu.CreateMenu();
                Console.Clear();
                Console.WriteLine(menu[choice] + "\n");
                commandList[choice].Execute();
                Console.WriteLine("\n\nНажмите любую клавишу для возвращения в главное меню...");
                Console.ReadKey(true);
                Console.Clear();
            }
        }
    }
}
