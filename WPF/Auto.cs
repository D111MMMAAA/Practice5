using System;
namespace WPF
{
    //производный класс
    public class Auto : Transportvehicle
    {
        // поле для хранения
        int fuel;
        //конструктор
        public Auto(string firma = "Неизвестный", string model = "Неизвестный", int pow = 0, int speed = 0, int fuel = 0)
            : base(firma, model, pow, speed)
        {
            Fuel = fuel;
        }
        public override void PrintInfo()
        {
            // вызов базового метода для вывода общей информации
            base.PrintInfo();
            Console.WriteLine($"Средний расход топлива (л): {fuel}");
        }
        //использование блоков get и set
        public int Fuel
        {
            set
            {
                if (value > 0)
                {
                    // если значение в пределах допустимого диапазона, устанавливаем его
                    fuel = value;
                }
                else
                {
                    fuel = 0;
                    Console.WriteLine("Неккоректные данные.");
                }
            }
            get { return fuel; }
        }
    }
}
