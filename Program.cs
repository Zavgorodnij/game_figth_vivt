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
        static int Event_fronted1;
        static int Event_backend1;
        static int Event_fronted2;
        static int Event_backend2;
        static bool block_character1;
        static bool block_character2;
        static int Event_figth;
        static int mode = 0;
        static int repeat;
        static float stamina_edit = 1;
        static float life1_limit;
        static float life2_limit;
        static float search_force1 = 0;
        static float search_force2 = 0;
        //Характеристика персонажа №1
        static float force1 = 0;
        static float agility1 = 0;
        static float stamina1 = 0;
        static float stamina1_limit = 0;
        static float life1 = 50;
        static string name1 = "null";
        //Характеристика персонажа №2
        static float force2 = 0;
        static float agility2 = 0;
        static float stamina2 = 0;
        static float stamina2_limit = 0;
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
            block_character1 = false;
            Event_fronted1 = randint.Next(1, 3);
            Event_backend1 = randint.Next(1, 3);
            
            //Атакует общая ветка
            if (Event_fronted1 == 1)
            {

                //Атакует в полную силу
                if (Event_backend1 == 1)
                {
                    if (stamina1 <= 0.5)
                    {
                        inactivity1();
                    }
                    else
                    {
                        Console.WriteLine(name1 + " пинает в полную силу " + name2);
                        life2 = life2 - force1;
                        stamina1 = stamina1 - 1;
                    }

                }
                //Атакует в половину силы
                if (Event_backend1 == 2)
                {
                    if (stamina1 <= 0)
                    {
                        inactivity1();
                    }
                    else
                    {
                        Console.WriteLine(name1 + " пинает ногами " + name2);
                        life2 = life2 - (force1 / 2);
                        stamina1 = stamina1 - (stamina_edit / 2);
                    }
                }
                //Промахивается
                if (Event_backend1 == 3)
                {
                    Console.WriteLine(name1 + " не пинает ногами, так как промахнулся " + name2);
                    stamina1 = stamina1 + stamina_edit;
                }
            }
            //Блокирует
            if (Event_fronted1 == 2)
            {
                if (stamina1 <= 0)
                {
                    inactivity1();
                }
                else
                {
                    block1();
                }

            }
            //Не активен
            if (Event_fronted1 == 3)
            {
                inactivity1();
            }
            

        }

        //Метод атаки второго бойца
        public static void hit2()
        {
            block_character2 = false;
            Event_fronted2 = randint.Next(1, 3);
            Event_backend2 = randint.Next(1, 3);
            
            //Атакует общая ветка
            if (Event_fronted2 == 1)
            {

                //Атакует в полную силу
                if (Event_backend2 == 1)
                {
                    if (stamina2 <= 0.5)
                    {
                        inactivity2();
                    }
                    else
                    {
                        Console.WriteLine(name2 + " даёт по полной по звездюлей " + name1);
                        life1 = life1 - force2;
                        stamina2 = stamina2 - stamina_edit;
                    }

                }
                //Атакует в половину силы
                if (Event_backend2 == 2)
                {
                    if (stamina2 <= 0)
                    {
                        inactivity2();
                    }
                    else
                    {
                        Console.WriteLine(name2 + " даёт в половину силы урона " + name1);
                        life1 = life1 - (force2 / 2);
                        stamina2 = stamina2 - (stamina_edit / 2);
                    }
                }
                //Промахивается
                if (Event_backend2 == 3)
                {
                    Console.WriteLine(name2 + " не даёт звездюлей, так как промахнулся " + name1);
                    stamina2 = stamina2 + stamina_edit;
                }
            }
            //Блокирует
            if (Event_fronted2 == 2)
            {
                if (stamina2 <= 0)
                {
                    inactivity2();
                }
                else
                {
                    block2();
                }

            }
            //Не активен
            if (Event_fronted2 == 3)
            {
                inactivity2();
            }
        }
        //Метод блокировки первого бойца(ТИПА РАБОТАЕТ)
        public static void block1()
        {
            block_character1 = true;
            stamina1 = stamina1 - (stamina_edit / 2);
            Console.WriteLine(name1 + " блокирует удар");
            
        }
        //Метод блокировки второго бойца(ТИПА РАБОТАЕТ)
        public static void block2()
        {
            block_character2 = true;
            stamina2 = stamina2 - (stamina_edit / 2);
            Console.WriteLine(name2 + " блокирует удар");
        }

        //Метод бездействия первого персонажа(ТИПА РАБОТАЕТ)
        public static void inactivity1()
        {
            if (stamina1_limit >= stamina1)
            {
                Console.WriteLine(name1 + " прилёг отдохнуть во время боя!");
                stamina1 = stamina1 + stamina_edit;
            }
        }
        //Метод бездействия первого персонажа(ТИПА РАБОТАЕТ)
        public static void inactivity2()
        {
            if (stamina2_limit >= stamina2)
            {
                Console.WriteLine(name2 + " прилёг отдохнуть во время боя!");
                stamina2 = stamina2 + stamina_edit;
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
                    if (name1 == "") throw new FormatException("Мне больно;( Введите хоть что то в имя персонажа...");
                    if (force1 <= 0 || agility1 <= 0 || stamina1 <= 0) throw new FormatException("Введенны не корректные данные");
                    stamina1_limit = stamina1;
                }

                catch (System.ArgumentNullException)
                {
                    Console.WriteLine("Ошибка");
                    flagExcep = true;
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
            } while ((force1 + agility1 + stamina1 != 8) || flagExcep);


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
                    if (name2 == "") throw new FormatException("Мне больно;( Введите хоть что то в имя персонажа");
                    if (force2 <= 0 || agility2 <= 0 || stamina2 <= 0) throw new FormatException("Введенны не корректные данные");
                    stamina2_limit = stamina2;
                }
                catch (System.ArgumentNullException)
                {
                    Console.WriteLine("Ошибка");
                    flagExcep = true;
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
            if (agility1 > agility2)
            {
                Console.WriteLine("Первый удар наносит первый персонаж!");
                do
                {
                    life1_limit = life1;
                    life2_limit = life2;
                    hit1();
                    hit2();
                    global_block_repeat_life();
                    status();
                    if (life1 == 0)
                    {
                        break;
                    }
                    if (life2 == 0)
                    {
                        break;
                    }

                } while (life1 >= 0 & life2 >= 0 || life1 == 0 || life2 == 0);
            }

            //Если второй ловчее первого, то
            if (agility1 < agility2)
            {
                int mass = 0;
                Console.WriteLine("Первый удар наносит второй персонаж!");
                do
                {
                    life1_limit = life1;
                    life2_limit = life2;
                    hit2();
                    hit1();
                    global_block_repeat_life();
                    status();
                    if (life1 == 0)
                    {
                        break;
                    }
                    if (life2 == 0)
                    {
                        break;
                    }

                } while (life1 >= 0 & life2 >= 0 || life1 == 0 || life2 == 0);
            }
            if (agility1 == agility2)
            {
                Console.WriteLine("Первый удар наносит святой рандом!");
                Event_figth = randint.Next(1, 100);
                do
                {

                    if (Event_figth <= 50)
                    {
                        life1_limit = life1;
                        life2_limit = life2;
                        hit1();
                        hit2();
                        global_block_repeat_life();
                        status();
                        if (life1 == 0)
                        {
                            break;
                        }
                        if (life2 == 0)
                        {
                            break;
                        }
                    }
                    if (Event_figth > 50)
                    {
                        life1_limit = life1;
                        life2_limit = life2;
                        hit2();
                        hit1();
                        global_block_repeat_life();
                        status();
                        if (life1 == 0)
                        {
                            break;
                        }
                        if (life2 == 0)
                        {
                            break;
                        }
                    }


                } while (life1 >= 0 & life2 >= 0 || life1 == 0 || life2 == 0);
            }
        }
        public static void end()
        {
            Console.WriteLine("//////////////////////////////////////////////////////////////////////////////////////////");
            if (life1 <= 0)
            {
                Console.Write(name1);
                Console.Write(" погиб в жесткой схватке с ");
                Console.WriteLine(name2);
            }
            if (life1 == 0 & life2 == 0)
            {
                Console.WriteLine("Герои умерли смертью храбрых! Земля им пухом");
            }
            if (life2 <= 0)
            {
                Console.Write(name2);
                Console.Write(" погиб в жесткой схватке с ");
                Console.WriteLine(name1);
            }
            repeat_game();
        }
        public static void status()
        {
            
            if (life1 < 0)
            {
                life1 = 0;
            }
            if (life2 < 0)
            {
                life2 = 0;
            }
            Console.Write("Персонаж "); Console.Write(name1); Console.Write(" / жизнь=");
            Console.Write(life1); Console.Write(" / выносливость="); Console.Write(stamina1);
            Console.Write(" / Персонаж "); Console.Write(name2); Console.Write(" / жизнь="); Console.Write(life2); Console.Write(" / выносливость="); Console.WriteLine(stamina2);
            if (mode == 1)
            {
                Console.ReadKey();
            }
        }
        public static void game_mode()
        {
            bool flagExcep;
            do
            {
                flagExcep = false;
                try
                {
                    Console.WriteLine("Введите 0, для автоматического режима/ введите 1, для ручного режима");
                    Console.Write("Введите режим работы="); mode = int.Parse(Console.ReadLine());
                    if (mode < 0 || mode > 1) throw new FormatException("Мне больно;( Не вводи отрицательное число");
                }
                catch(System.ArgumentNullException)
                {
                    Console.WriteLine("Ошибка");
                    flagExcep = true;
                }
                catch (System.FormatException e)
                {
                    Console.WriteLine("Ошибка");
                    flagExcep = true;
                }
            } while (flagExcep);
        }
        public static void repeat_game()
        {
            Console.WriteLine("Хотите повторить? нажмите 1 для повтора/ нажмите 0, для завершения");
            bool flagExcep;
            life1 = 50;
            life2 = 50;
            do
            {
                flagExcep = false;
                Console.Write("Введите команду=");
                try
                {
                    repeat = int.Parse(Console.ReadLine());
                }

                catch (System.FormatException e)
                {
                    Console.WriteLine("Да мне же больно, введи нормально!");
                    flagExcep = true;
                    continue;
                }
            } while (flagExcep);
            if (repeat == 1)
            {
                Console.Clear();
                Main();
            }
            if (repeat == 0)
            {
                Console.WriteLine("При нажатии на любую клавишу клавиатуры, приложение закроется");
                Console.ReadKey();
            }
            else
            {
                repeat_game();
            }
        }
        public static void global_block_repeat_life()
        {
            if (block_character1 == true || block_character2 == true)
            {
                life1 = life1_limit;
                life2 = life2_limit;
            }
        }
        /*public static void search_force_characters1()
        {
            search_force1 = life1_limit - life1;
        }
        public static void search_force_character2()
        {
            search_force2 = life2_limit - life2;
        }
        public static void adaptive_fight()
        {
            if (agility1 > agility2)
            {
                Console.WriteLine("Первый удар наносит первый персонаж");
                do
                {
                    adaptive_hit1();
                    adaptive_hit2();
                    status();
                    if (life1 == 0)
                    {
                        break;
                    }
                    if (life2 == 0)
                    {

                    }
                } while (life1 >= 0 & life2 >= 0 || life1 == 0 || life2 == 0);
            }
            if (agility1 < agility2)
            {
                Console.WriteLine("Первый удар наносит второй персонаж");
                do
                {
                    adaptive_hit2();
                    adaptive_hit1();
                    status();
                    if (life1 == 0)
                    {
                        break;
                    }
                    if (life2 == 0)
                    {
                        break;
                    }
                } while (life1 >= 0 & life2 >= 0 || life1 == 0 || life2 == 0);
            }
            if (agility1 == agility2)
            {
                Console.WriteLine("Первый удар наносит святой рандом");
                Event_figth = randint.Next(1, 100);
                do
                {
                    if (Event_figth < 50)
                    {
                        adaptive_hit1();
                        adaptive_hit2();
                        status();
                        if (life1 == 0)
                        {
                            break;
                        }
                        if (life2 == 0)
                        {
                            break;
                        }
                    }
                    if (Event_figth >= 50)
                    {
                        adaptive_hit2();
                        adaptive_hit1();
                        status();
                        if (life1 == 0)
                        {
                            break;
                        }
                        if (life2 == 0)
                        {
                            break;
                        }
                    }
                } while (life2 >= 0 & life2 >= 0 || life1 == 0 || life2 == 0);
            }
        }
        public static void adaptive_hit1()
        {
            life1_limit = life1;
            Event_backend1 = randint.Next(1, 3);
            //Если первый сильнее второго
            if (search_force1>search_force2)
            {

            }
            //Если второй сильнее первого
            if (search_force1<search_force2)
            {

            }
            if (search_force1==search_force2)
            {
                fight();
            }
            //Атакует впринципе
        }
        public static void adaptive_hit2()
        {
            life2_limit = life2;
            Event_backend2 = randint.Next(1, 3);
            //Если второй


        }
        public static void search_stamina_character1()
        {

        }
        public static void search_stamina_character2()
        {

        }*/

    }

}
