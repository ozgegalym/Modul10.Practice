using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseContr
{
    class TeamLeader : IWorker
    {
        string name;
        public TeamLeader(string name) { this.name = name; }
        string checkStatus(bool status)
        {
            return status == true ? "завершено" : "не построено";
        }
        public void ShowWorker()
        {
            Console.WriteLine("Привет, парни. Я лидер строительной бригады.");
            Console.WriteLine($"Меня зовут {name}, и я покажу вам отчет о процессе строительства.\n");
        }
        public void DisplayHouseImage()
        {
            Console.WriteLine("   ______");
            Console.WriteLine("  /      \\");
            Console.WriteLine(" /        \\");
            Console.WriteLine("|    __    |");
            Console.WriteLine("|[] |  | []|");
            Console.WriteLine("|   |__|   |");
            Console.WriteLine("|          |");
            Console.WriteLine("|__________|");
            Console.WriteLine();
        }
        public void BuildShow(List<IPart> list)
        {
            bool check = false;
            int wall = 1, window = 1;
            Console.WriteLine();
            foreach (var obj in list)
            {
                if (obj is Basement)
                    Console.WriteLine($"{obj.ShowPart()} - {checkStatus(obj.Status)}.");
                if (obj is Wall)
                    Console.WriteLine($"{obj.ShowPart()}{wall++} - {checkStatus(obj.Status)}.");
                if (obj is Door)
                    Console.WriteLine($"{obj.ShowPart()} - {checkStatus(obj.Status)}.");
                if (obj is Window)
                    Console.WriteLine($"{obj.ShowPart()}{window++} - {checkStatus(obj.Status)}.");
                if (obj is Roof)
                    Console.WriteLine($"{obj.ShowPart()} - {checkStatus(obj.Status)}.");
                if (obj is Roof && obj.Status == true)
                    check = true;
            }
            if (check)
            {
                Console.WriteLine("\nДом завершен. Поздравляю!");
                DisplayHouseImage(); // Используйте метод экземпляра, а не статический
            }

            Console.WriteLine();
        }
    }
}
