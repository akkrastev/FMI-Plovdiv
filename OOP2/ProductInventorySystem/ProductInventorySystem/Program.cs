using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductInventorySystem.Products;


namespace ProductInventorySystem
{
    class Program
    {
       
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Inventory techShop = new Inventory();


            Laptop lenovo = new Laptop("Лаптоп Gaming Lenovo Legion Y520-15IKBN", "Най-новото в гейминг производителността ", 1815m);
            Laptop hp = new Laptop("Лаптоп HP 250 G5", "Много добро съотношение цена-спецификации-качество", 996m);
            Laptop apple = new Laptop("Лаптоп Apple MacBook Air 13", "Характеристики, на които можете да разчитате всеки ден", 3219m);
            SmartPhone j5 = new SmartPhone("Смартфон Samsung Galaxy J5 (2017)", "Елегантен по природа", 350m);
            SmartPhone huawei = new SmartPhone("Смартфон Huawei Y5II, Dual Sim", "Никога не изпускай възможност да се насладиш на мига",  450m);
            SmartPhone s8 = new SmartPhone("Смартфон Samsung Galaxy S8", "Открийте впечатляващите възможности на Galaxy S8", 1149m);
            TV ledStar = new TV("Телевизор LED Star-Light", "Открийте магията на ярките цветове с LED TV", 2499m);
            TV philips = new TV("Телевизор Smart Android Philips", "Ambilight променя завинаги начина ви на гледане на телевизия ", 1799m);
            TV samsungled = new  TV ("Телевизор LED Smart Samsung", "Истинският 4K UHD телевизор UHD резолюция ", 999m);
            TV lg = new TV("LG 49UK6300MLB", "Висока разделителна способност за ясно изображение.", 1252m);
            

            // Няма значение в какъв ред се добавят продуктите
            techShop.AddProduct(j5);
            techShop.AddProduct(lenovo);
            techShop.AddProduct(huawei);
            techShop.AddProduct(ledStar);
            techShop.AddProduct(hp);
            techShop.AddProduct(s8);
            techShop.AddProduct(apple);
            techShop.AddProduct(philips);
            techShop.AddProduct(samsungled);
            techShop.AddProduct(lg);
            techShop.AddProduct(philips); // Ще го направи 2 броя, тъй като е същия продукт

            techShop.AddStock(ledStar, 7);
            techShop.AddStock(s8, 14);
            techShop.AddStock(hp, 9);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(50, 0);
            Console.WriteLine("----TechShop----");
            Console.WriteLine();
            Console.WriteLine();
            Console.ResetColor();

            techShop.PrintShop();

            Console.WriteLine(techShop.calculateTotalOfProduct(s8));
            Console.WriteLine(techShop.calculateTotalOfProduct(lg));
            Console.WriteLine(techShop.calculateTotalOfProduct(hp));

            Console.WriteLine("Общата цена на всички продукти е: " + techShop.calculateTotal() + " лв.");


        }
            }
        }
    

