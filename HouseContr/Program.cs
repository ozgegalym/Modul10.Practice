using System;
using System.Collections.Generic;


namespace HouseContr
{
    class Program
    {
        static int Check(int answer)
        {
            while (answer < 1 || answer > 3)
            {
                Console.WriteLine("Ваш выбор некорректен.");
                Console.WriteLine("Вы должны ввести 1 (один), 2 (два) или 3 (три).");
                Console.Write("Сделайте ваш выбор здесь - ");
                answer = Convert.ToInt32(Console.ReadLine());
            }
            return answer;
        }
        static int Menu()
        {
            int answer;
            Console.WriteLine("Какое действие вы хотите выполнить?");
            Console.WriteLine("1. Посмотреть отчет о процессах строительства.");
            Console.WriteLine("2. Что-то построить.");
            Console.WriteLine("3. Выйти из программы.");
            Console.Write("Введите корректный ответ здесь - ");
            answer = Convert.ToInt32(Console.ReadLine());
            return Check(answer);
        }
        static void Main(string[] args)
        {
            House house = new House();
            TeamLeader teamLeader = new TeamLeader("Бауыржан");
            Team team = new Team("Международная строительная бригада Galym");
            Worker worker = new Worker();  // нет информации о том, как использовать работника в программе
            Console.WriteLine("Давайте представим строительную бригаду.\n");
            teamLeader.ShowWorker();
            team.ShowWorker();
            do
            {
                switch (Menu())
                {
                    case 1:
                        teamLeader.BuildShow(house.GetList());
                        break;
                    case 2:
                        team.Build(house.GetList());
                        break;
                    case 3:
                        return;
                }
            } while (true);
        }
    }

}