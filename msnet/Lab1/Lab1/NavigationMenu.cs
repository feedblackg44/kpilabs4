using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class ConsoleNavigationMenu
    {
        private string[] _menuItems;
        private int _choice;
        private bool _toChoose;
        private bool _printAgain;

        public ConsoleNavigationMenu(string[] menuItems, int choice = 0)
        { 
            _menuItems = menuItems;
            _choice = choice;
            _toChoose = true;
            _printAgain = true;
        }
        public int CreateMenu()
        {
            while (_toChoose)
            {
                if (_printAgain)
                {
                    Console.Clear();
                    this.MenuPrint(_choice);
                }
                else
                    _printAgain = true;

                ConsoleKey key = Console.ReadKey(true).Key;
                this.KeyPressed(key);
            }
            _toChoose = true;
            return _choice;
        }
        public void MenuPrint(int highlited = 0)
        {
            Console.WriteLine("\n\n{0} Меню {0}\n\n", new String('-', 10));
            for (int i = 0; i < _menuItems.Length; i++)
            {
                if (i == highlited)
                    Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Запрос номер {0}: {1}.", i + 1, _menuItems[i]);
                Console.ResetColor();
            }
            Console.WriteLine("\nВыберите запрос стрелочками вверх и вниз." +
                              "\nНажмите Esc чтобы выйти.");
        }
        private void KeyPressed(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.Enter:
                    _toChoose = false;
                    break;
                case ConsoleKey.DownArrow:
                    _choice += 1;
                    if (_choice >= _menuItems.Length)
                        _choice = 0;
                    break;
                case ConsoleKey.UpArrow:
                    _choice -= 1;
                    if (_choice < 0)
                        _choice = _menuItems.Length - 1;
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
                default:
                    _printAgain = false;
                    break;
            }
        }
    }
}
