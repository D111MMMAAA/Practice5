using System;
using System.Security.Cryptography.X509Certificates;
namespace WPF
{
    //производный класс
    public class Electricscooter : Transportvehicle
    {
        // поле для хранения
        int weight;
        //конструктор
        public Electricscooter(string firma = "Неизвестный", string model = "Неизвестный", int pow = 0, int speed = 0, int weight = 0)
            : base(firma, model, pow, speed)
        {
            Weight = weight;
        }
        public override void PrintInfo()
        {
            // вызов базового метода для вывода общей информации
            base.PrintInfo();
            Console.WriteLine($"Вес (кг): {weight}");
        }
        //использование блоков get и set
        public int Weight
        {
            set
            {
                if (value > 0)
                {
                    // если значение в пределах допустимого диапазона, устанавливаем его
                    weight = value;
                }
                else
                {
                    weight = 0;
                    Console.WriteLine("Неккоректные данные.");
                }
            }
            get { return weight; }
        }
    }
}
