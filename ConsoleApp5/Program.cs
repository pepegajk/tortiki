using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;

namespace CakeShop
{
    class Program
    {
    

        static void Main(string[] args)
        {
            bool repeat = true;
            while (repeat)
            {
                CakeOrder order = new CakeOrder();
                order.ChooseCake();

                Console.WriteLine("ХАТИТЕ СДЛЕАТЬ ЗАКАЗ?(ДА/НЕТ)");
                string choice = Console.ReadLine().ToUpper();
                if (choice != "ДА")
                    repeat = false;
            }
        }
    }

    public class Cake
    {
        public string Form;
        public string Size;
        public string Flavor;
        public int Quantity;
        public string Glaze;
        public string Decor;
        public decimal Price;
    }
    public abstract class Menu
    {
        protected List<string> options;

        public string Show()
        {
            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i]}");
            }

            int choice;
            do
            {
                Console.Write("ВаШ выбОр: ");
            } while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > options.Count);

            return options[choice - 1];
        }
    }
    public class MenuForm
    {
        private List<string> forms = new List<string> { "круглая", "квадратная" };

        public string Show()
        {
            int input;
            for (int i = 0; i < forms.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + forms[i]);
            }
            Console.WriteLine("Выберите форму:");
            while (!int.TryParse(Console.ReadLine(), out input) || input < 1 || input > forms.Count)
            {
                Console.WriteLine("Неверный ввод. Выберите форму:");
            }
            return forms[input - 1];
        }
    }

    public class MenuSize : Menu
    {
        public MenuSize()
        {
            options = new List<string> { "маленький", "средний", "большой" };
        }
    }

    public class MenuFlavor : Menu
    {
        public MenuFlavor()
        {
            options = new List<string> { "ваниль", "шоколад", "клубника" };
        }
    }

    public class MenuGlaze : Menu
    {
        public MenuGlaze()
        {
            options = new List<string> { "шоколад", "молочная" };
        }
    }

    public class MenuDecor : Menu
    {
        public MenuDecor()
        {
            options = new List<string> { "посыпка", "фрукты" };
        }
    }


    public class CakeOrder
    {
        private static MenuForm formMenu;
        private static MenuSize sizeMenu;
        private static MenuFlavor flavorMenu;
        private static MenuGlaze glazeMenu;
        private static MenuDecor decorMenu;

        private Cake cake;

        public CakeOrder()
        {
            formMenu = new MenuForm();
            sizeMenu = new MenuSize();
            flavorMenu = new MenuFlavor();
            glazeMenu = new MenuGlaze();
            decorMenu = new MenuDecor();

            cake = new Cake();
        }

        public void ChooseCake()
        {
            Console.Clear();
            Console.WriteLine("ДАБРО ПАЖАЛОВАТЬ В ПЕКАРНЮ ТУДА-СЮДА КЛУБНИЧНЫЙ МАХИТО!!!!");

            Console.WriteLine("ФОРМУ тортА выбери");
            cake.Form = formMenu.Show();

            Console.WriteLine("РАЗМЕР ВЫБЕРИ ");
            cake.Size = sizeMenu.Show();

            Console.WriteLine("ВКУС ТУДА-СЮДА ОФОРМИ");
            cake.Flavor = flavorMenu.Show();

            Console.WriteLine("КОЛЛИЧЕСТВО ТОРТОВ");
            int quantity;
            while (!int.TryParse(Console.ReadLine(), out quantity))
            {
                Console.WriteLine("Invalid input. Please enter a valid quantity:");
            }
            cake.Quantity = quantity;

            Console.WriteLine("ГЛАЗУРЬ ВЫБЕРИ ");
            cake.Glaze = glazeMenu.Show();

            Console.WriteLine("ДЕКОР К ТОРТУ ОФОРМИ ДА");
            cake.Decor = decorMenu.Show();

            cake.Price = CalculatePrice();

            Console.WriteLine("КАКОЙ ХАЙП ЗАКАЗ ТЫ СОСТАВИЛ ");
            Console.WriteLine("ФОРМА " + cake.Form);
            Console.WriteLine("РАЗМЕР " + cake.Size);
            Console.WriteLine("ВКУС " + cake.Flavor);
            Console.WriteLine("КОЛЛИЧЕСТВО " + cake.Quantity);
            Console.WriteLine("ГЛАЗУРЬ" + cake.Glaze);
            Console.WriteLine("ДЕКОР " + cake.Decor);
            Console.WriteLine("ТВОЙ ДОЛГ США $" + cake.Price);
        }

        private decimal CalculatePrice()
        {
            
            decimal price = 0;

           
            switch (cake.Size)
            {
                case "маленький":
                    price += 10;
                    break;
                case "средний":
                    price += 15;
                    break;
                case "большой":
                    price += 20;
                    break;
            }

           
            switch (cake.Form)
            {
                case "круглая":
                    price += 5;
                    break;
                case "квадратная":
                    price += 7;
                    break;
            }

            switch (cake.Flavor)
            {
                case "ваниль":
                    price += 3;
                    break;
                case "шоколад":
                    price += 4;
                    break;
                case "клубника":
                    price += 5;
                    break;
            }

            switch (cake.Glaze)
            {
                case "шоколад":
                    price += 2;
                    break;
                case "молочная":
                    price += 1;
                    break;
            }

            switch (cake.Decor)
            {
                case "посыпка":
                    price += 1;
                    break;
                case "фрукты":
                    price += 2;
                    break;
            }

            return price * cake.Quantity;
        }
    }
}