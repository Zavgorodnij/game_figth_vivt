using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Wars_to_characters
{
    class Program
    {
        //Рандом
        static Random randint = new Random();
        static int Event_fronted;
        static int Event_backend;
        static int Event_figth;
        static int mode = 0;
        //Характеристика персонажа №1
        static float force1 = 0;
        static float agility1 = 0;
        static float stamina1 = 0;
        static float stamina1_limit=0;
        static float life1 = 50;
        static string name1 = "null";
        //Характеристика персонажа №2
        static float force2 = 0;
        static float agility2 = 0;
        static float stamina2 = 0;
        static float stamina2_limit=0;
        static float life2 = 50;
        static string name2 = "null";
        //Сама программа
        public static void Main()
        {
            input_character1();
            input_character2();
            game_mode();
            fight();
            end();

        }
        //Метод атаки первого бойца
        public static void hit1()
        {
            Event_fronted = randint.Next(1, 3);
            //Атакует
            if (Event_fronted == 1)
            {
                Event_backend = randint.Next(1, 3);
                //Атакует в полную силу
                if (Event_backend==1)
                {
                    if (stamina1<=0)
                    {
                        Console.WriteLine("Первый персонаж, отдыхает!");
                        inactivity1();
                    }
                    else
                    {
                        Console.WriteLine("Первый персонаж, бьёт в полную силу!");
                        life2 = life2 - force1;
                        stamina1 = stamina1 - 1;
                    }
                }
                //Атакует в половину силы
                if (Event_backend==2)
                {
                    if (stamina1 <= 0)
                    {
                        Console.WriteLine("Первый персонаж, отдыхает!");
                        inactivity1();
                    }
                    else
                    {
                        Console.WriteLine("Первый персонаж, бьёт в половину силы!");
                        life2 = life2 - (force1 / 2);
                        stamina1 = stamina1 - (1 / 2);
                    }
                    
                }
                //Промахивается
                else
                {
                    Console.WriteLine("Первый персонаж, промахивается!");
                    stamina1 = stamina1 - 1;
                }
            }
            //Блокирует
            if (Event_fronted == 2)
            {
                if (stamina1 <= 0)
                {
                    Console.WriteLine("Первый персонаж, отдыхает!");
                    inactivity1();
                }
                else
                {
                    block1();
                }
                
            }
            else
            {
                inactivity1();
            }
            status();
        }
        //Метод атаки второго бойца
        public static void hit2()
        {
            Event_fronted = randint.Next(1, 3);
            //Атакует
            if (Event_fronted==1)
            {
                Event_backend = randint.Next(1, 3);
                //Атакует в полную силу
                if (Event_backend==1)
                {
                    if (stamina2<=0)
                    {
                        
                        inactivity2();
                    }
                    else
                    {
                        Console.WriteLine("Второй персонаж, атакует в полную силу!");
                        life1 = life1 - force2;
                        stamina2 = stamina2 - 1;
                    }
                    
                }
                //Атакует в половину силы
                if (Event_backend==2)
                {
                    if (stamina2<=0)
                    {
                        inactivity2();
                    }
                    else
                    {
                        Console.WriteLine("Второй персонаж, атакует в полную силу!");
                        life1 = life1 - (force2 / 2);
                        stamina2 = stamina2 - (1 / 2);
                    }
                    
                }
                //Промахивается
                else
                {
                    if (stamina2<=0)
                    {
                        inactivity2();
                    }
                    else
                    {
                        Console.WriteLine("Второй персонаж, промахивается!");
                        stamina2 = stamina2 - 1;
                    }
                    
                }
                
            }
            //Блокирует
            if (Event_fronted==2)
            {
                if (stamina2<=0)
                {
                    inactivity2();
                }
                else
                {
                    block2();
                }
            }
            else
            {
                inactivity2();
            }
            status();
        }
        //Метод блокировки первого бойца(ТИПА РАБОТАЕТ)
        public static void block1()
        {
            stamina1 = stamina1 - (1 / 2);
            Console.WriteLine("Первый персонаж блокирует удар");
        }
        //Метод блокировки второго бойца(ТИПА РАБОТАЕТ)
        public static void block2()
        {
            stamina2 = stamina2 - (1 / 2);
            Console.WriteLine("Второй персонаж блокирует удар");
        }

        //Метод бездействия первого персонажа(ТИПА РАБОТАЕТ)
        public static void inactivity1()
        {
            if (stamina1_limit>=stamina1)
            {
                Console.WriteLine("Первый персонаж, отдыхает!");
                stamina1 = stamina1 + 1;
            }
        }
        //Метод бездействия первого персонажа(ТИПА РАБОТАЕТ)
        public static void inactivity2()
        {
            if (stamina2_limit>=stamina2)
            {
                Console.WriteLine("Второй персонаж, отдыхает!");
                stamina2 = stamina2 + 1;
            }
        }

        //Ввод переменных первого персонажа(ТИПА РАБОТАЕТ)
        public static void input_character1()
        {
            
            bool flagExcep;
            do
            {
                flagExcep = false;
                try
                {
                    Console.Write("Введите имя первого бойца=");
                    name1 = Console.ReadLine();
                    Console.Write("Введите значение силы первого персонажа=");
                    force1 = float.Parse(Console.ReadLine());
                    Console.Write("Введите значение ловкости первого персонажа=");
                    agility1 = float.Parse(Console.ReadLine());
                    Console.Write("Введите значение выносливости первого персонажа=");
                    stamina1 = float.Parse(Console.ReadLine());
                    if (force1 == 0 || agility1==0 || stamina1==0) throw new FormatException("Введенны не корректные данные");
                    stamina1_limit = stamina1;
                }

                
                catch (System.FormatException e)
                {
                    Console.WriteLine(e.Message);
                    flagExcep = true;
                    continue;
                }
                //stamina1 = stamina1_limit;
                if (force1 + agility1 + stamina1 == 8)
                {
                    Console.WriteLine("Условие выполнено");
                }
                else
                {
                    Console.WriteLine("Условие не выполнено,введите повторно!");
                }
                
                //Console.Clear();
            } while ((force1 + agility1 + stamina1 != 8)||flagExcep);
            

        }
        //Ввод переменных второго персонажа(ТИПА РАБОТАЕТ)
        public static void input_character2()
        {
            bool flagExcep;
            do
            {
                flagExcep = false;
                try
                {
                    Console.Write("Введите имя второго бойца=");
                    name2 = Console.ReadLine();
                    Console.Write("Введите значение силы второго персонажа=");
                    force2 = float.Parse(Console.ReadLine());
                    Console.Write("Введите значение ловкости второго персонажа=");
                    agility2 = float.Parse(Console.ReadLine());
                    Console.Write("Введите значение выносливости второго персонажа=");
                    stamina2 = float.Parse(Console.ReadLine());
                    if (force2 == 0 || agility2 == 0 || stamina2 == 0) throw new FormatException("Введенны не корректные данные");
                    stamina2_limit = stamina2;
                }
                catch (System.FormatException e)
                {
                    Console.WriteLine(e.Message);
                    flagExcep = true;
                    continue;
                }
                if (force2 + agility2 + stamina2 == 8)
                {
                    Console.WriteLine("Условие выполнено");
                }
                else
                {
                    Console.WriteLine("Условие не выполнено,введите повторно!");
                }
                
                //Console.Clear();
            } while (force2 + agility2 + stamina2 != 8 || flagExcep);


        }
        //Логика боя
        public static void fight()
        {
            if (agility1>agility2)
            {
                Console.WriteLine("Первый удар наносит первый персонаж!");
                do
                {
                    hit1();
                    hit2();
                    
                } while (life1 >= 0 & life2 >= 0);
            }
            
            //Если второй ловчее первого, то
            if (agility1<agility2)
            {
                Console.WriteLine("Первый удар наносит второй персонаж!");
                do
                {
                    hit2();
                    hit1();
                    
                } while (life1 >= 0 & life2 >= 0);
            }
            else
            {
                Event_figth = randint.Next(1, 100);
                do
                {
                    Console.WriteLine("Первый удар наносит святой рандом!");
                    if (Event_figth<=50)
                    {
                        hit1();
                        hit2();
                    }
                    else
                    {
                        hit2();
                        hit1();
                    }


                } while (life1 >= 0 & life2 >= 0);
            }
        }
        public static void end()
        {
            Console.WriteLine("//////////////////////////////////////////////////////////////////////////////////////////");
            if (life1<=0)
            {
                Console.Write(name1);
                Console.Write(" погиб в жесткой схватке с ");
                Console.WriteLine(name2);
            }
            else
            {
                Console.Write(name2);
                Console.Write(" погиб в жесткой схватке с ");
                Console.WriteLine(name1);
            }
        }
        public static void status()
        {
            if (mode==1)
            {
                System.Threading.Thread.Sleep(1000);
            }
            Console.Write("Персонаж "); Console.Write(name1); Console.Write(" / жизнь="); Console.Write(life1); Console.Write(" / выносливость="); Console.Write(stamina1);
            Console.Write(" / Персонаж "); Console.Write(name2); Console.Write(" / жизнь="); Console.Write(life2); Console.Write(" / выносливость="); Console.WriteLine(stamina2);
        }
        public static void game_mode()
        {
            try
            {
                Console.WriteLine("Введите 0, для автоматического режима/ введите 1, для ручного режима");
                Console.Write("Введите режим работы="); mode = int.Parse(Console.ReadLine());
            }
            catch (System.FormatException e)
            {
                Console.WriteLine("Ошибка");
            }
        }
    }
}

