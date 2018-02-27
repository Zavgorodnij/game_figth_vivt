using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Wars_to_characters
{
    class Program
    {
        //Рандом & нужные переменные
        /// <summary>
        /// Класс рандома
        /// </summary>
        static Random randint = new Random();
        /// <summary>
        /// Переменная используемая для внешних событий первого персонажа в рандомном алгоритме
        /// </summary>
        static int Event_fronted1;
        /// <summary>
        /// Переменная используемая для внутренних событий первого персонажа в рандомном алгоритме
        /// </summary>
        static int Event_backend1;
        /// <summary>
        /// Переменная используемая для внутренних событий второго персонажа в рандомном алгоритме
        /// </summary>
        static int Event_fronted2;
        /// <summary>
        /// Переменная используемая для внешних событий второго персонажа в рандомном алгоритме
        /// </summary>
        static int Event_backend2;
        /// <summary>
        /// Переменная используемая для определения блокировки первого персонажа
        /// </summary>
        static bool block_character1;
        /// <summary>
        /// Переменная используемая для определения блокировки второго персонажа
        /// </summary>
        static bool block_character2;
        /// <summary>
        /// Переменная для рандома первого хода персонажа (Рандом)(Если выносливость одинаковая)
        /// </summary>
        static int Event_figth;
        /// <summary>
        /// Переменная для определения режима работы(Авто/Ручной)
        /// </summary>
        static int mode = 0;
        /// <summary>
        /// Переменная для запуска адаптивного режима
        /// </summary>
        static int adaptiv_mode = 0;
        /// <summary>
        /// Переменная для запуска повторного сражения
        /// </summary>
        static int repeat;
        /// <summary>
        /// Зарезервированная переменная для уменьшения выносливости
        /// </summary>
        static float stamina_edit = 1;
        /// <summary>
        /// Лимит для жизни
        /// </summary>
        static float life1_limit;
        /// <summary>
        /// Лимит для жизни
        /// </summary>
        static float life2_limit;
        /// <summary>
        /// Переменная в которой лежит найденная сила первого персонажа
        /// </summary>
        static float search_force1 = 0;
        /// <summary>
        /// Переменная в которой лежит найденная сила второго персонажа
        /// </summary>
        static float search_force2 = 0;
        //Характеристика персонажа №1
        /// <summary>
        /// Сила первого
        /// </summary>
        static float force1 = 0;
        /// <summary>
        /// Ловкость первого
        /// </summary>
        static float agility1 = 0;
        /// <summary>
        /// Выносливость первого
        /// </summary>
        static float stamina1 = 0;
        /// <summary>
        /// Лимит выносливости первого
        /// </summary>
        static float stamina1_limit = 0;
        /// <summary>
        /// Жизнь первого
        /// </summary>
        static float life1 = 50;
        /// <summary>
        /// Имя первого
        /// </summary>
        static string name1 = "null";
        //Характеристика персонажа №2
        /// <summary>
        /// Сила первого
        /// </summary>
        static float force2 = 0;
        /// <summary>
        /// Ловкость второго
        /// </summary>
        static float agility2 = 0;
        /// <summary>
        /// Виносливость второго
        /// </summary>
        static float stamina2 = 0;
        /// <summary>
        /// Лимит выносливости второго
        /// </summary>
        static float stamina2_limit = 0;
        /// <summary>
        /// Жизнь второго
        /// </summary>
        static float life2 = 50;
        /// <summary>
        /// Имя второго
        /// </summary>
        static string name2 = "null";
        //Сама программа
        public static void Main()
        {
            input_character1();
            input_character2();
            adaptive_mode();
            game_mode();
            if (adaptiv_mode==1)
            {
                adaptive_fight();
            }
            if (adaptiv_mode==0)
            {
                fight();
            }
            end();

        }
        //Метод атаки первого бойца
        /// <summary>
        /// Метод атаки первого бойца(Рандом)
        /// </summary>
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
        /// <summary>
        /// Метод атаки второго бойца(Рандом)
        /// </summary>
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
        /// <summary>
        /// Метод блокировки первого бойца
        /// </summary>
        public static void block1()
        {
            block_character1 = true;
            stamina1 = stamina1 - (stamina_edit / 2);
            Console.WriteLine(name1 + " блокирует удар");
            
        }
        //Метод блокировки второго бойца(ТИПА РАБОТАЕТ)
        /// <summary>
        /// Метод блокировки второго бойца
        /// </summary>
        public static void block2()
        {
            block_character2 = true;
            stamina2 = stamina2 - (stamina_edit / 2);
            Console.WriteLine(name2 + " блокирует удар");
        }

        //Метод бездействия первого персонажа(ТИПА РАБОТАЕТ)
        /// <summary>
        /// Метод бездействия первого бойца
        /// </summary>
        public static void inactivity1()
        {
            if (stamina1_limit >= stamina1)
            {
                Console.WriteLine(name1 + " прилёг отдохнуть во время боя!");
                stamina1 = stamina1 + stamina_edit;
            }
        }
        //Метод бездействия первого персонажа(ТИПА РАБОТАЕТ)
        /// <summary>
        /// Метод бездействия второго бойца
        /// </summary>
        public static void inactivity2()
        {
            if (stamina2_limit >= stamina2)
            {
                Console.WriteLine(name2 + " прилёг отдохнуть во время боя!");
                stamina2 = stamina2 + stamina_edit;
            }
        }

        /// <summary>
        /// Ввод переменных первого персонажа
        /// </summary>
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
                    Console.WriteLine("При вводе данных вы не должны забывать о том, что сумма:Силы, ловкости и выносливости должна быть равна 8");
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
                catch(System.OverflowException)
                {
                    Console.WriteLine("Ошибка:введено слишком большое число");
                    flagExcep = true;
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
        /// <summary>
        /// Ввод переменных второго персонажа
        /// </summary>
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
                    Console.WriteLine("При вводе данных вы не должны забывать о том, что сумма:Силы, ловкости и выносливости должна быть равна 8");
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
                catch (System.OverflowException)
                {
                    Console.WriteLine("Ошибка:введено слишком большое число");
                    flagExcep = true;
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
        /// <summary>
        /// Метод логики боя(Рандом)
        /// </summary>
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
        /// <summary>
        /// Метод завершения боя
        /// </summary>
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
        /// <summary>
        /// Метод статуса персонажей после раунда
        /// </summary>
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
        /// <summary>
        /// Метод режима игры(Ручной/Авто)
        /// </summary>
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
                catch (System.OverflowException e)
                {
                    Console.WriteLine("Ошибка:введено слишком большое число");
                    flagExcep = true;
                }
                catch(System.ArgumentNullException e)
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
        /// <summary>
        /// Метод повтора игры
        /// </summary>
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
                catch (System.OverflowException e)
                {
                    Console.WriteLine("Ошибка:введено слишком большое число");
                    flagExcep = true;
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
        /// <summary>
        /// Метод восстановления здоровья при блокировке
        /// </summary>
        public static void global_block_repeat_life()
        {
            if (block_character1 == true || block_character2 == true)
            {
                life1 = life1_limit;
                life2 = life2_limit;
            }
        }
        /// <summary>
        /// Метод работы адаптивного режима
        /// </summary>
        public static void adaptive_mode()
        {
            bool flagExcep;
            Console.WriteLine("Желаете ли вы использовать аддаптивный алгоритм поведения персонажей?");
            Console.WriteLine("1=Включить/0=Выключить");
            do
            {
                flagExcep = false;
                try
                {
                    Console.Write("Введите режим="); adaptiv_mode = int.Parse(Console.ReadLine());
                    if (adaptiv_mode < 0 || adaptiv_mode > 1) throw new FormatException("Мне больно;( Не вводи отрицательное число");
                }
                catch (System.OverflowException e)
                {
                    flagExcep = true;
                    Console.WriteLine("Мне больно, вы пихаете слишком большое число");
                }
                catch (System.FormatException e)
                {
                    flagExcep = true;
                    Console.WriteLine("Ошибка! Введите число");
                }
            } while (flagExcep);
            {
                if (adaptiv_mode==1)
                {
                    Console.WriteLine("Адаптивный режим включен!");
                }
                if (adaptiv_mode==0)
                {
                    Console.WriteLine("Адаптивный режим не включен, бой расчитывается через рандомные методы");
                }
            }

        }
        /// <summary>
        /// Метод тренировки бойцов перед боем
        /// </summary>
        public static void warm_up_fight()
        {
            Console.WriteLine("Сейчас наши бойцы поиграют мышцами, для того что бы не получить травму(Тренировка)");
            Event_figth = randint.Next(1, 100);
            int round = 0;
            do
            {
                round++;
                Console.WriteLine("Раунд="+round);
                if (Event_figth <= 50)
                {
                    life1_limit = life1;
                    life2_limit = life2;
                    warm_up_hit1();
                    warm_up_hit2();
                    search_force_characters();
                    Console.ReadKey();
                    if (life1 == 0)
                    {
                        break;
                    }
                    if (life2 == 0)
                    {
                        break;
                    }
                    if (round==5)
                    {
                        break;
                    }
                }
                if (Event_figth > 50)
                {
                    life1_limit = life1;
                    life2_limit = life2;
                    warm_up_hit2();
                    warm_up_hit1();
                    search_force_characters();
                    Console.ReadKey();
                    if (life1 == 0)
                    {
                        break;
                    }
                    if (life2 == 0)
                    {
                        break;
                    }
                    if(round==5)
                    {
                        break;
                    }
                }


            } while (life1 >= 0 & life2 >= 0 || life1 == 0 || life2 == 0);
            stamina1 = stamina1_limit;
            stamina2 = stamina2_limit;
            life1 = 50;
            life2 = 50;
            Console.WriteLine("Сила "+name1+"=" + search_force1 + " Сила "+name2+"=" + search_force2);
            Console.WriteLine("Тренировка закончилась,сейчас начнётся Мясо");
            Console.WriteLine("/////////////////////////////////////////////////////////");
            Console.ReadKey();
        }
        /// <summary>
        /// Метод поиска силы (адаптивный алгоритм)
        /// </summary>
        public static void search_force_characters()
        {
            int temp_search_force1=0;
            int temp_search_force2=0;
            int Counter = 0;
            Counter++;
            search_force1 = life1_limit - life1;
            search_force2 = life2_limit - life2;
            if (Counter > 2)
            {
                if (search_force1<temp_search_force1)
                {
                    search_force1 = temp_search_force1;
                }
                if (search_force2<temp_search_force2)
                {
                    search_force2 = temp_search_force2;
                }
            }


        }
        /// <summary>
        /// Метод адаптивного боя
        /// </summary>
        public static void adaptive_fight()
        {
            warm_up_fight();
            do
            {
                if (search_force1 > search_force2)
                {
                    do
                    {
                        life1_limit = life1;
                        life2_limit = life2;
                        if (agility1>agility2)
                        {
                            adaptive_hit1_hard();
                            adaptive_hit2_cunning();
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
                        if (agility1<agility2)
                        {
                            adaptive_hit2_cunning();
                            adaptive_hit1_hard();
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
                        if (agility1==agility2)
                        {
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
                if (search_force1 < search_force2)
                {
                    do
                    {
                        life1_limit = life1;
                        life2_limit = life2;
                        if (agility1>agility2)
                        {
                            
                            adaptive_hit1_cunning();
                            adaptive_hit2_hard();
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
                        if (agility1<agility2)
                        {
                            adaptive_hit2_cunning();
                            adaptive_hit1_hard();
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
                        if (agility1==agility2)
                        {
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
                if (search_force1 == search_force2)
                {
                    fight();
                }
            } while (life1 >= 0 & life2 >= 0 || life1 == 0 || life2 == 0);

        }
        //В этой тактике персонаж должен любой ценой совершить удар
        /// <summary>
        /// Метод агресивного поведения первого бойца
        /// </summary>
        public static void adaptive_hit1_hard()
        {
            block_character1 = false;
            Event_backend1 = randint.Next(1, 3);
            if (Event_backend1==1)
            {
                if (stamina1 <= 0.5)
                {
                    inactivity1();
                    block_character1 = true;
                }
                else
                {
                    Console.WriteLine(name1 + " пинает в полную силу " + name2);
                    life2 = life2 - force1;
                    stamina1 = stamina1 - 1;
                }
            }
            
            if (Event_backend1==2)
            {
                if (stamina1<=0)
                {
                    inactivity1();
                    block_character1 = true;
                }
                else
                {
                    Console.WriteLine(name1 + " пинает ногами " + name2);
                    life2 = life2 - (force1 / 2);
                    stamina1 = stamina1 - (stamina_edit / 2);
                }
                
            }
        }
        //В этой тактике персонаж должен любой ценой совершить удар
        /// <summary>
        /// Метод агресивного поведения второго бойца
        /// </summary>
        public static void adaptive_hit2_hard()
        {
            block_character2 = false;
            Event_backend2 = randint.Next(1, 2);
            if (Event_backend2==1)
            {
                if (stamina2 <= 0.5)
                {
                    inactivity2();
                    block_character2 = true;
                }
                else
                {
                    Console.WriteLine(name2 + " пинает в полную силу " + name1);
                    life1 = life1 - force2;
                    stamina2 = stamina2 - 1;
                }
            }
            
            if (Event_backend2 == 2)
            {
                if (stamina2 <= 0)
                {
                    inactivity2();
                    block_character2 = true;
                }
                else
                {
                    Console.WriteLine(name2 + " пинает ногами " + name1);
                    life1 = life1 - (force2 / 2);
                    stamina2 = stamina2 - (stamina_edit / 2);
                }

            }
        }
        /// <summary>
        /// Метод хитрого поведения первого бойца
        /// </summary>
        public static void adaptive_hit1_cunning()
        {
            Event_backend1 = randint.Next(1, 3);
            if (block_character2==true)
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
            }
            else
            {
                //Пока что пусть будет так
                block1();
            }
        }
        /// <summary>
        /// Метод хитрого поведения второго бойца
        /// </summary>
        public static void adaptive_hit2_cunning()
        {
            Event_backend2 = randint.Next(1, 3);
            if (block_character1==true)
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
                        block_character2 = true;
                    }
                    else
                    {
                        Console.WriteLine(name2 + " даёт в половину силы урона " + name1);
                        life1 = life1 - (force2 / 2);
                        stamina2 = stamina2 - (stamina_edit / 2);
                    }
                }
            }
            else
            {
                //Пока пусть живёт тут
                block2();
            }
        }
        /// <summary>
        /// Метод поведения первого бойца при тренировке
        /// </summary>
        public static void warm_up_hit1()
        {
            Event_fronted1 = randint.Next(1, 3);
            if (Event_fronted1==1)
            {
                life2 = life2 - force1;
            }
            if (Event_fronted1==2)
            {
                life2 = life2 - (force1 / 2);
                
            }
        }
        /// <summary>
        /// Метод поведения второго бойца при тренировке
        /// </summary>
        public static void warm_up_hit2()
        {
            Event_fronted2 = randint.Next(1, 3);
            if (Event_fronted2==1)
            {
                life1 = life1 - force2;
            }
            if (Event_fronted2==2)
            {
                life1 = life1 - (force2 / 2);
            }
        }
        //Это типа действия первого бойца в адаптивном режиме
    }

}
