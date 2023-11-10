using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseContr
{
    class Team : IWorker
    {
        string name;
        public Team(string name) { this.name = name; }
        public int Check(int answer)
        {
            while (answer < 1 || answer > 5)
            {
                Console.WriteLine("Ваш выбор не верен.");
                Console.WriteLine("Вам нужно ввести 1(один), 2(два), 3(три), 4(четыре), 5(пять).");
                Console.Write("Сделайте свой выбор здесь - ");
                answer = Convert.ToInt32(Console.ReadLine());
            }
            return answer;
        }
        public int Menu()
        {
            int answer;
            Console.WriteLine("Какую часть вы хотите построить?");
            Console.WriteLine("1. Подвал, 2. Стена, 3. Дверь.");
            Console.WriteLine("4. Окно, 5. Крыша.");
            Console.Write("Введите правильный ответ здесь ");
            answer = Convert.ToInt32(Console.ReadLine());
            return Check(answer);
        }
        public void ShowWorker()
        {
            Console.WriteLine("Привет ребята. Мы строительная команда.");
            Console.WriteLine($"Наше имя - {name} и мы построим дом.");
            Console.WriteLine("Конечно, если это возможно.");
            Console.WriteLine("\r\nМы поможем Вам построить дом мечты.\n");
        }
        public void Build(List<IPart> obj)
        {
            bool check = false;
            int qtyWall = 1, qtyWindow = 1;
            Console.WriteLine();
            switch (Menu())
            {
                case 1:
                    foreach (var part in obj)
                    {
                        if (part is Basement)
                        {
                            if (part.Status == false)
                            {
                                part.Status = true;
                                Console.WriteLine($"\nКоманда построила {part.ShowPart()}.");
                                break;
                            }
                            else
                            {
                                Console.WriteLine($"\n {part.ShowPart()} Дом построить не удалось");
                                Console.WriteLine("Потому что он уже построен");
                                Console.WriteLine("Проверьте это в отчете.");
                                break;
                            }
                        }
                    }
                    break;
                case 2:
                    int wallsBuilt = 0;
                    foreach (var part in obj)
                    {
                        if (part is Basement && part.Status == true)
                            check = true;
                        else if (part is Basement && part.Status == false)
                        {
                            check = false;
                            break;
                        }
                        if (part is Wall && part.Status == true)
                            wallsBuilt++;
                    }
                    if (check && wallsBuilt < 4)
                    {
                        foreach (var part in obj)
                        {
                            if (part is Wall)
                            {
                                if (part.Status == false)
                                {
                                    part.Status = true;
                                    Console.WriteLine($"\nКоманда построила {part.ShowPart()} {qtyWall}.");
                                    break;
                                }
                                qtyWall++;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nСтену дома построить не удалось.");
                        Console.WriteLine("Потому что они уже построены или подвал отсутствует.");
                        Console.WriteLine("Проверьте это в отчете");
                        break;
                    }
                    break;
                case 3:
                    qtyWall = 0;
                    foreach (var part in obj)
                    {
                        if (part is Wall && part.Status == true)
                            qtyWall++;
                        if (part is Door && part.Status == false)
                            check = true;
                    }
                    if (check && qtyWall == 4)
                        foreach (var part in obj)
                        {
                            if (part is Door)
                            {
                                if (part.Status == false)
                                {
                                    part.Status = true;
                                    Console.WriteLine($"\nКоманда построила {part.ShowPart()}.");
                                    break;
                                }
                            }
                        }
                    else
                    {
                        Console.WriteLine("\nДверь дома построить не удалось.");
                        Console.WriteLine("Потому что он уже построен или нет, все стены присутствуют");
                        Console.WriteLine("Проверьте это в отчете.");
                        break;
                    }
                    break;
                case 4:
                    int windowsBuilt = 0;
                    foreach (var part in obj)
                    {
                        if (part is Door && part.Status == true)
                            check = true;
                        else if (part is Door && part.Status == false)
                        {
                            check = false;
                            break;
                        }
                        if (part is Window && part.Status == true)
                            windowsBuilt++;
                    }
                    if (check && windowsBuilt < 4)
                    {
                        foreach (var part in obj)
                        {
                            if (part is Window)
                            {
                                if (part.Status == false)
                                {
                                    part.Status = true;
                                    Console.WriteLine($"\nКоманда построила {part.ShowPart()} {qtyWindow}.");
                                    break;
                                }
                                qtyWindow++;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nОкно дома построить не удалось.");
                        Console.WriteLine("Потому что они уже построены или дверь отсутствует.");
                        Console.WriteLine("Проверьте это в отчете");
                        break;
                    }
                    break;
                case 5:
                    qtyWindow = 0;
                    foreach (var part in obj)
                    {
                        if (part is Window && part.Status == true)
                            qtyWindow++;
                        if (part is Roof && part.Status == false)
                            check = true;
                    }
                    if (check && qtyWindow == 4)
                        foreach (var part in obj)
                        {
                            if (part is Roof)
                            {
                                if (part.Status == false)
                                {
                                    part.Status = true;
                                    Console.WriteLine($"\nКоманда построила  {part.ShowPart()}.");
                                    Console.WriteLine("Дом закончен. Проверьте это в отчете.");
                                    break;
                                }
                            }
                        }
                    else
                    {
                        Console.WriteLine("\nКрышу дома построить не удалось.");
                        Console.WriteLine("Потому что он уже построен или нет, все окна присутствуют.");
                        Console.WriteLine("Проверьте это в отчете");
                        break;
                    }
                    break;
            }
            Console.WriteLine();
        }
    }
}
