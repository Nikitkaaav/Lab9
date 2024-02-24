using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab9
{
    public class GeoCoordinates
    {
        //Поля
        private double latitude;
        private double longtitude;
        private static int count;

        //Свойства
        public double Latitude
        {
            get
            {
                return this.latitude;
            }
            set
            {
                if (Math.Round(value, 4) == value)
                {
                    this.latitude = value;
                }
                else
                {
                    throw new ArgumentException("В значении широты должно быть ровно 4 знака после запятой.");
                }
            }
        }

        public double Longtitude
        {
            get
            {
                return this.longtitude;
            }
            set
            {
                if (Math.Round(value, 4) == value)
                {
                    this.longtitude = value;
                }
                else
                {
                    throw new ArgumentException("В значении долготы должно быть ровно 4 знака после запятой.");
                }
            }
        }

        //Конструктор без параметров
        public GeoCoordinates()
        {
            Latitude = -78.4875;
            Longtitude = 45.4945;
            count++;
        }

        //Конструктор с параметрами
        public GeoCoordinates(double latitude, double longtitude)
        {
            this.Latitude = latitude;
            this.Longtitude = longtitude;
            count++;
        }

        //Конструктор копирования
        public GeoCoordinates(GeoCoordinates a)
        {
            this.Latitude = a.latitude;
            this.Longtitude = a.longtitude;
            count++;
        }

        //Преобразование в строку
        public override string ToString()
        {
            return $"Широта: {Latitude} Долгота: {Longtitude}";
        }

        //Статическая функция
        public static double FindDistance(GeoCoordinates gc1, GeoCoordinates gc2)
        {
            double radLat1 = DegreesToRadians(gc1.latitude);
            double radLon1 = DegreesToRadians(gc1.longtitude);
            double radLat2 = DegreesToRadians(gc2.latitude);
            double radLon2 = DegreesToRadians(gc2.longtitude);

            double dLat = radLat2 - radLat1;
            double dLon = radLon2 - radLon1;

            double a = Math.Pow(Math.Sin(dLat / 2), 2) + Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(dLon / 2), 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            double distance = 6371 * c;

            distance = Math.Round(distance, 3);

            return distance;
        }

        //Метод класса
        public double FindDistance(GeoCoordinates gc)
        {
            double radLat1 = DegreesToRadians(Latitude);
            double radLon1 = DegreesToRadians(Longtitude);
            double radLat2 = DegreesToRadians(gc.Latitude);
            double radLon2 = DegreesToRadians(gc.Longtitude);

            double dLat = radLat2 - radLat1;
            double dLon = radLon2 - radLon1;

            double a = Math.Pow(Math.Sin(dLat / 2), 2) + Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(dLon / 2), 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            double distance = 6371 * c;

            distance = Math.Round(distance, 3);

            return distance;
        }

        public static double DegreesToRadians(double degrees)
        {
            return degrees * (Math.PI / 180);
        }

        //Счетчик объектов
        public static int GetCount()
        {
            return count;
        }

        // Унарные операции
        public static GeoCoordinates operator ++(GeoCoordinates gc)
        {
            gc.latitude += 0.01;
            gc.longtitude += 0.01;
            return gc;
        }

        public static GeoCoordinates operator -(GeoCoordinates gc)
        {
            return new GeoCoordinates(-gc.latitude, -gc.longtitude);
        }

        // Операции приведения типов
        public static explicit operator bool(GeoCoordinates gc)
        {
            return gc.latitude == 0;
        }

        public static implicit operator string(GeoCoordinates gc)
        {
            if (gc.longtitude > 0)
            {
                return "Восточная долгота";
            }
            else if (gc.longtitude < 0)
            {
                return "Западная долгота";
            }
            else
            {
                return "Нулевой меридиан";
            }
        }

        // Бинарные операции
        public static bool operator ==(GeoCoordinates gc1, GeoCoordinates gc2)
        {
            return gc1.latitude == gc2.latitude;
        }

        public static bool operator !=(GeoCoordinates gc1, GeoCoordinates gc2)
        {
            return gc1.longtitude != gc2.longtitude;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is not GeoCoordinates) return false;
            return ((GeoCoordinates)obj).Latitude == this.Latitude && ((GeoCoordinates)obj).Longtitude == this.Longtitude;
        }
    }

}

