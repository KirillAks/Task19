using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task19
{
    class Program
    {
        /* Модель  компьютера  характеризуется  кодом  и  названием  марки компьютера,  типом  процессора,  частотой  работы  процессора,
         * объемом оперативной памяти, объемом жесткого диска, объемом памяти видеокарты, стоимостью компьютера в условных единицах и количеством экземпляров, имеющихся в наличии.
         * Создать список, содержащий 6-10 записей с различным набором значений характеристик.
         Определить:
        - все компьютеры с указанным процессором. Название процессора запросить у пользователя;
        - все компьютеры с объемом ОЗУ не ниже, чем указано. Объем ОЗУ запросить у пользователя;
        - вывести весь список, отсортированный по увеличению стоимости;
        - вывести весь список, сгруппированный по типу процессора;
        - найти самый дорогой и самый бюджетный компьютер;
        - есть ли хотя бы один компьютер в количестве не менее 30 штук? */
        static void Main(string[] args)
        {
            List<Computer> computers = new List<Computer>()
            {
                new Computer(){Id=1, Name="Lenovo", Type="AMD", Frequency=2600, Ram=16, Hdd=512, Video=6, Cost=1750, Count=30},
                new Computer(){Id=2, Name="HP", Type="Corei5", Frequency=2600, Ram=8, Hdd=512, Video=4, Cost=1500, Count=25},
                new Computer(){Id=3, Name="Asus", Type="Pentium", Frequency=4000, Ram=4, Hdd=128, Video=2, Cost=400, Count=15},
                new Computer(){Id=4, Name="Lenovo", Type="AMD", Frequency=1350, Ram=4, Hdd=120, Video=2, Cost=500, Count=40},
                new Computer(){Id=5, Name="HP", Type="Corei5", Frequency=2600, Ram=8, Hdd=1024, Video=4, Cost=2100, Count=20},
                new Computer(){Id=6, Name="Asus", Type="Corei5", Frequency=2600, Ram=16, Hdd=512, Video=12, Cost=2200, Count=10},
                new Computer(){Id=7, Name="HP", Type="Corei7", Frequency=2900, Ram=16, Hdd=512, Video=4, Cost=3000, Count=15},
                new Computer(){Id=8, Name="iRU", Type="AMD", Frequency=3400, Ram=8, Hdd=500, Video=6, Cost=2000, Count=35},
                new Computer(){Id=9, Name="Dell", Type="Corei9", Frequency=2500, Ram=32, Hdd=1000, Video=24, Cost=6500, Count=3},
                new Computer(){Id=10, Name="Acer", Type="Corei7", Frequency=2500, Ram=16, Hdd=1000, Video=8, Cost=3500, Count=5}
            };
            Console.WriteLine("Введите название процессора");
            string type = Console.ReadLine();
            List<Computer> computers1 = computers.Where(t => t.Type == type).ToList();
            Print(computers1);

            Console.WriteLine("Введите минимальный объем ОЗУ");
            int ram = Convert.ToInt32(Console.ReadLine());
            List<Computer> computers2 = computers.Where(r => r.Ram >= ram).ToList();
            Print(computers2);

            Console.WriteLine("Cписок всех компьютеров, стоимость по возрастанию:");
            List<Computer> computers3 = computers.OrderBy(c => c.Cost).ToList();
            Print(computers3);

            Console.WriteLine("Cписок всех компьютеров, сгруппированный по типу процессора:");
            IEnumerable<IGrouping<string, Computer>> computers4 = computers.GroupBy(g => g.Type);
            foreach(IGrouping<string, Computer> gr in computers4)
            {
                Console.WriteLine(gr.Key);
                foreach (Computer c in gr)
                {
                    Console.WriteLine($"Номер:{c.Id} Марка:{c.Name} Процессор:{c.Type} Частота процессора:{c.Frequency} Гц ОЗУ:{c.Ram} Гб Жесткий диск:{c.Hdd} Гб Объем памяти видеокарты:{c.Video} Гб Стоимость:{c.Cost} у.е. Количество:{c.Count} шт.");
                }
            }
            Console.WriteLine();

            Console.WriteLine("Cамый дорогой компьютер:");
            Computer computer5 = computers.OrderByDescending(x => x.Cost).FirstOrDefault();
            Console.WriteLine($"Номер:{computer5.Id} Марка:{computer5.Name} Процессор:{computer5.Type} Частота процессора:{computer5.Frequency} Гц ОЗУ:{computer5.Ram} Гб Жесткий диск:{computer5.Hdd} Гб Объем памяти видеокарты:{computer5.Video} Гб Стоимость:{computer5.Cost} у.е. Количество:{computer5.Count} шт.");
            Console.WriteLine();

            Console.WriteLine("Cамый бюджетный компьютер:");
            Computer computer6 = computers.OrderBy(x => x.Cost).FirstOrDefault();
            Console.WriteLine($"Номер:{computer6.Id} Марка:{computer6.Name} Процессор:{computer6.Type} Частота процессора:{computer6.Frequency} Гц ОЗУ:{computer6.Ram} Гб Жесткий диск:{computer6.Hdd} Гб Объем памяти видеокарты:{computer6.Video} Гб Стоимость:{computer6.Cost} у.е. Количество:{computer6.Count} шт.");
            Console.WriteLine();

            Console.WriteLine("Есть ли хотя бы один компьютер в количестве не менее 30 штук?");
            if (computers.Any(x => x.Count > 30))
            {
                Console.WriteLine("Есть");
            }
            else
            {
                Console.WriteLine("Нет");
            }                

            Console.ReadKey();

        }
        static void Print(List<Computer> computers)
        {
            foreach(Computer c in computers)
            {
                Console.WriteLine($"Номер:{c.Id} Марка:{c.Name} Процессор:{c.Type} Частота процессора:{c.Frequency} Гц ОЗУ:{c.Ram} Гб Жесткий диск:{c.Hdd} Гб Объем памяти видеокарты:{c.Video} Гб Стоимость:{c.Cost} у.е. Количество:{c.Count} шт.");
            }
            Console.WriteLine();
        }
    }
}
