using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab9
{
    public class GeoCoordinatesArray
    {
        GeoCoordinates[] geoCoordinatesArray;
        private static int countArrays;
        private static int countElements;
        public int Length
        {
            get => geoCoordinatesArray.Length;
        }

        //конструктор без параметров
        public GeoCoordinatesArray()
        {
            geoCoordinatesArray = new GeoCoordinates[1];
            geoCoordinatesArray[0] = new GeoCoordinates();
            countElements++;
            countArrays++;
        }

        //конструктор с параметром(случайные элементы)
        public GeoCoordinatesArray(int length, double min)
        {
            geoCoordinatesArray = new GeoCoordinates[length];
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                geoCoordinatesArray[i] = new GeoCoordinates(random.Next(-100, 100) + (Math.Round(random.NextDouble(), 4)),
                    random.Next(-100, 100) + (Math.Round(random.NextDouble(), 4)));
                countElements++;
            }
            countArrays++;
        }

        //конструктор с параметром(элементы с клавиатуры)
        public GeoCoordinatesArray(int length)
        {
            geoCoordinatesArray = new GeoCoordinates[length];
            for (int i = 0; i < length; i++)
            {
                geoCoordinatesArray[i] = new GeoCoordinates(InputNumberFromKeyboard($"Введите широту точки {i + 1}"),
                    InputNumberFromKeyboard($"Введите долготу точки {i + 1} "));
                countElements++;
            }
            countArrays++;
        }

        //конструктор копирования
        public GeoCoordinatesArray(GeoCoordinatesArray other)
        {
            this.geoCoordinatesArray = new GeoCoordinates[other.Length];
            for (int i = 0; i < other.Length; i++)
            {
                this.geoCoordinatesArray[i] = new GeoCoordinates(other.geoCoordinatesArray[i]);
                countElements++;
            }
            countArrays++;
        }

        //Вывод массива
        public void ShowArray()
        {
            for (int i = 0; i < geoCoordinatesArray.Length; i++)
            {
                Console.WriteLine(geoCoordinatesArray[i].ToString());
            }
        }

        //Вывод объекта массива
        public void ShowGeoCoordinates(int index)
        {
            Console.WriteLine(this.geoCoordinatesArray[index - 1].ToString);
        }

        //Счетчик массивов
        public static int GetCountArrays()
        {
            return countArrays;
        }

        //Счетчик объектов в массивах
        public static int GetCountElementsInArray()
        {
            return countElements;
        }

        //индексатор
        public GeoCoordinates this[int index]
        {
            get
            {
                if (index >= 0 && index < geoCoordinatesArray.Length)
                    return geoCoordinatesArray[index];
                throw new IndexOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < geoCoordinatesArray.Length)
                    geoCoordinatesArray[index] = value;
                throw new IndexOutOfRangeException();
            }
        }

        //Ввод данных
        static public double InputNumberFromKeyboard(string message)
        {
            bool isNumber;
            double number;
            string errorMessage = "Неверные данные, введите число";
            do
            {
                Console.WriteLine(message);
                isNumber = double.TryParse(Console.ReadLine(), out number);
                if (isNumber && Math.Round(number, 4) != number)
                {
                    isNumber = false;
                    Console.WriteLine(errorMessage);
                }
            }
            while (!isNumber);
            return number;
        }
    }
}



