using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Timers;
using System.Threading;

namespace Tamagocha
{
    ////test recommit
    /// <summary>
    public class StateAnimal
    {

        public int hp;
        public int sleep;
        public int eat;
        public int choise;
        string name;
        string status = "";


        public StateAnimal()
        {

        }
        public StateAnimal(string _name)
        {
            name = _name;
            hp = 100;
            sleep = 100;
            eat = 100;
            choise = 10;
        }



        public void States()
        {
            
            Console.WriteLine(name + "\t" + status);
            Console.WriteLine("Здоровье {0}", hp);
            Console.WriteLine("Сон      {0}", sleep);
            Console.WriteLine("Еда      {0}", eat);
        }
        public int DinamicProgress()
        {
            Random ran = new Random();
            switch (ran.Next(1, 3))
            {
                case 1: hp = hp - ran.Next(5, 15); break;
                case 2: sleep = sleep - ran.Next(7, 19); break;
                case 3: eat = eat - ran.Next(6, 25); break;
            }
            if (hp < 50) status = "-need for heal"; if (eat < 50) status = "-need for eat"; if (sleep < 50) status = "-need for sleep";
            if (hp > 50 && eat > 50 && sleep > 50) status = "Full hp;3";
            if (hp <= 0 || sleep <= 0 || eat <= 0)
            {
                hp = 0; sleep = 0; eat = 0;
                return 666;
            }
            return 0;

        }

        public void Undead()
        {
            hp = 100;
            sleep = 100;
            eat = 100;
        }


    }

    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string taked_name = "";
            Stopwatch sw = new Stopwatch();
            Console.Write("Take animal:\n1.Dog\t2.Cat\t3.Pony"); Console.Write("\nYou take is : ");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1: { taked_name = "Dog"; break; }
                case 2: { taked_name = "Cat"; break; }
                case 3: { taked_name = "Pony"; break; }
            }

           StateAnimal ob1 = new StateAnimal(taked_name);
            Thread MyTr = new Thread(new ThreadStart(new Action(() => progress111(ob1))));

            MyTr.Start();
            int swt;
            for(int i = 0; i < 1000; i++)
            {
                swt=Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                ob1.States();
                Console.WriteLine("\n1.For give eat\t2.for send sleep\t3.for healing him\t4. for attack this animal\nEnter:");
                
                switch (swt)
                {
                    case 1: { for (int j = 23; j>= 0; j--) { if (ob1.eat + j <= 100) { ob1.eat = ob1.eat + j; } } break; }
                    case 2: { for (int j = 23; j >= 0; j--) { if (ob1.sleep + j <= 100) { ob1.sleep = ob1.sleep + 25; } } break; }
                    case 3: { for (int j = 23; j >= 0; j--) { if (ob1.hp + j <= 100) { ob1.hp = ob1.hp + 17; } } break; }
                    case 4: { ob1.hp = ob1.hp - 20; break; }
                    default: break;
                }
            }
            Console.ReadKey();
        }
        
        /// /////////////////
       
        public static void progress111(object o)
        {


            var pb = (StateAnimal)o;
            for (bool i = true; i ==true; )
            {

                Console.Clear();
                int test = pb.DinamicProgress();
                pb.States();
                Console.WriteLine("\n1.For give eat\t2.for send sleep\t3.for healing him\t4. for attack this animal\nEnter:");

                if (test == 666)
                {
                    ManualResetEvent mre = new ManualResetEvent(true);
                    Console.Clear();
                   mre.WaitOne();
                    
                    Console.WriteLine("Your friend is dead, press '5' for restart animal or any bind for exit to menu");
                    switch (Convert.ToInt32(Console.ReadLine()))
                    {
                        case 5: { pb.hp = 100;pb.sleep = 100;pb.eat = 100; mre.Set();test = 0; break; }
                        default:mre.Reset(); break;//Обход кода
                    }


                }
                Thread.Sleep(1500);
            }


        }
    }
}
