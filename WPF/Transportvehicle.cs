using System;
using System.Collections.Generic;
namespace WPF
{
    public class Transportvehicle
    {
        int pow, speed;
        //использование автоматических свойств
        public string Firma { get; set; }
        public string Model { get; set; }

        public Transportvehicle(string firma = "Неизвестный", string model = "Неизвестный", int pow = 0, int speed = 0)
        {
            Firma = firma;
            Model = model;
            Pow = pow;
            Speed = speed;
        }
        public virtual void PrintInfo()
        {
            Console.WriteLine($"Фирма: {Firma}");
            Console.WriteLine($"Модель: {Model}");
            Console.WriteLine($"Мощность: {Pow}");
            Console.WriteLine($"Максимальная скорость: {Speed}");
        }
        public int Pow
        {
            set
            {
                if (value > 0)
                {
                    // если значение в пределах допустимого диапазона, устанавливаем его
                    pow = value;
                }
                else
                {
                    pow = 0;
                    Console.WriteLine("Неккоректные данные.");
                }
            }
            get { return pow; }
        }
        public int Speed
        {
            set
            {
                if (value > 0)
                {
                    // если значение в пределах допустимого диапазона, устанавливаем его
                    speed = value;
                }
                else
                {
                    speed = 0;
                    Console.WriteLine("Неккоректные данные.");
                }
            }
            get { return speed; }
        }
    }
}
