using System;
using System.Drawing;

namespace Lab9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int menu;
            do
            {
                Console.WriteLine();
                Console.WriteLine("1 - Работа с частью 1 ");
                Console.WriteLine("2 - Работа с частью 2");
                Console.WriteLine("3 - Работа с частью 3");
                Console.WriteLine("0 - Выход");
                Console.WriteLine();
                menu = int.Parse(Console.ReadLine());

                switch (menu)
                {
                    case 1:
                        Console.WriteLine("Точка 1, созданная конструктором без параметров:");
                        GeoCoordinates p1 = new GeoCoordinates();
                        Console.WriteLine(p1.ToString());
                        Console.WriteLine("Точка 2, созданная конструктором с параметрами:");
                        GeoCoordinates p2 = new GeoCoordinates(12.2365, -34.9848);
                        Console.WriteLine(p2.ToString());
                        Console.WriteLine("Точка 3, созданная конструктором копирования:");
                        GeoCoordinates p3 = new GeoCoordinates(p2);
                        Console.WriteLine(p3.ToString());
                        Console.WriteLine("Точка 4, инициализированная:");
                        GeoCoordinates p4 = new GeoCoordinates { Latitude = 34.3444, Longtitude = 56.4556 };
                        Console.WriteLine(p4.ToString());
                        Console.WriteLine($"Количество созданных объектов: {GeoCoordinates.GetCount()} ");

                        Console.WriteLine($"Расстояние между точками 1 и 2 (статическая функция): {GeoCoordinates.FindDistance(p1, p2)}");
                        Console.WriteLine($"Расстояние между точками 1 и 2 (метод класса): {p1.FindDistance(p2)}");
                        break;
                    case 2:
                        Console.WriteLine("Точка 5:");
                        GeoCoordinates p5 = new GeoCoordinates(56.8459, -31.0945);
                        Console.WriteLine(p5.ToString());
                        Console.WriteLine("Точка 5 после осуществления унарной операции:");
                        p5++;
                        Console.WriteLine(p5.ToString());

                        Console.WriteLine("Точка 6 = 5, но с обратными знаками:");
                        GeoCoordinates p6 = -p5;
                        Console.WriteLine(p6.ToString());

                        Console.WriteLine("Для точки 5:");
                        bool check = (bool)p5;
                        if (!check)
                        {
                            Console.WriteLine("Точка не располагается на экваторе");
                        }
                        else
                        {
                            Console.WriteLine("Точка располагается на экваторе");
                        }

                        string s = p5;
                        Console.WriteLine($"{s}");

                        if (p5 == p6)
                        {
                            Console.WriteLine("Точки 5 и 6 находятся на одной параллели");
                        }
                        else
                        {
                            Console.WriteLine("Точки 5 и 6 находятся на разных параллелях");
                        }

                        if (p5 != p6)
                        {
                            Console.WriteLine("Точки 5 и 6 находятся на разных меридианах");
                        }
                        else
                        {
                            Console.WriteLine("Точки 5 и 6 находятся на одном меридиане");
                        }
                        break;
                    case 3:
                        Console.WriteLine("1 точка, созданная конструктором без параметров:");
                        GeoCoordinatesArray a1 = new GeoCoordinatesArray();
                        a1.ShowArray();
                        Console.WriteLine("2 точки, созданные конструктором с параметрами (с рандомными значениями):");
                        GeoCoordinatesArray a2 = new(2, 2);
                        a2.ShowArray();
                        Console.WriteLine("Создание точек конструктором с параметрами (с клавиатуры):");
                        GeoCoordinatesArray a3 = new(3);
                        a3.ShowArray();
                        Console.WriteLine("Создание точек конструктором копирования:");
                        GeoCoordinatesArray a4 = new(a3);
                        a4.ShowArray();
                        try
                        {
                            a4.ShowGeoCoordinates((int)GeoCoordinatesArray.InputNumberFromKeyboard("Введите номер точки, которую хотите увидеть"));
                        }
                        catch (IndexOutOfRangeException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        Console.WriteLine($"Количество созданных объектов: {GeoCoordinatesArray.GetCountElementsInArray()} ");
                        Console.WriteLine($"Количество созданных массивов: {GeoCoordinatesArray.GetCountArrays()} ");
                        break;
                }

            } while (menu != 0);

        }
    }
}