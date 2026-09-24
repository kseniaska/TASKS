using System;
using System.IO;

namespace ConsoleApp
{
    public interface IPrimary
    {
        int Id { get; }
    }

    public class Shop : IPrimary
    {
        private int id;
        private string name;
        private string code;

        public int Id
        {
            get { return id; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        public Shop(int id, string name, string code)
        {
            this.id = id;
            this.name = name;
            this.code = code;
        }

        public void Print()
        {
            Console.WriteLine("ID: " + Id + ", name: " + Name + ", code: " + Code);
        }
    }

    public class Client : IPrimary
    {
        private int id;
        private string name;
        private string surname;
        private string patronymic;
        private DateTime birthDate;

        public int Id
        {
            get { return id; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public string Patronymic
        {
            get { return patronymic; }
            set { patronymic = value; }
        }

        public DateTime BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }

        public int Age
        {
            get
            {
                DateTime today = DateTime.Today;
                int age = today.Year - birthDate.Year;
                if (birthDate.Date > today.AddYears(-age))
                {   age--;}
                return age;
            }
        }

        public Client( int id, string name, string surname, string patronymic, DateTime birthDate)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.patronymic = patronymic;
            this.birthDate = birthDate;
        }

        public void Print()
        {
            Console.WriteLine("ID: " + Id + ", " + Surname + " " + Name + " " + Patronymic + ", birth date: " + BirthDate.ToString("dd.MM.yyyy") + ", age: " + Age);
        }
    }

    public class Good : IPrimary
    {
        private int id;
        private string name;
        private string code;

        public int Id
        {
            get { return id; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Code
        {
            get { return code; }
            set { code = value; }
        }
        public Good(int id, string name, string code)
        {
            this.id = id;
            this.name = name;
            this.code = code;
        }
        public void Print()
        {
            Console.WriteLine("ID: " + Id + ", Name: " + Name + ", Code: " + Code);
        }
    }

    public static class Repository
    {
        public static Good[] InitGoods()
        {
            Good[] goods = new Good[20];
            for (int i = 0; i < goods.Length; i++)
            {
                goods[i] = new Good(i + 1, "good" + (i + 1), (i + 1).ToString());
            }
            return goods;
        }

        public static void WriteGoods(Good[] goods)
        {
            using (StreamWriter wr = new StreamWriter("goods.txt"))
            {
                foreach (Good good in goods)
                {
                    wr.WriteLine(good.Id + "," + good.Name + "," + good.Code);
                }
            }
        }

        public static Good[] ReadGoods()
        {
            string[] lines = File.ReadAllLines("goods.txt");

            Good[] goods = new Good[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                string[] data = lines[i].Split(',');
                goods[i] = new Good(int.Parse(data[0]), data[1],data[2]);
            }
            return goods;
        }

        public static void PrintGoods(Good[] goods)
        {
            Console.WriteLine("GOODS:");

            foreach (Good good in goods)
            {
                good.Print();
            }
        }
        

        public static Client[] InitClients()
        {
            Client[] clients = new Client[5];

            clients[0] = new Client(1, "Arefiev", "Oleg", "Yurievich", new DateTime(2000, 3, 8));
            clients[1] = new Client(2, "Vafina", "Azaliya", "Airatovna", new DateTime(2005, 8, 24));
            clients[2] = new Client(3, "Arseniy", "Vasilev", "Artyomovich", new DateTime(2004, 9, 22));
            clients[3] = new Client(4, "Hramov", "Dmitriy", "Aleksandrovich", new DateTime(2006, 12, 16));
            clients[4] = new Client(5, "Kulakova", "Alyona", "Denisovna", new DateTime(1999, 2, 3));

            return clients;
        }

        public static void WriteClients(Client[] clients)
        {
            using (StreamWriter wr = new StreamWriter("clients.txt"))
            {
                foreach (Client client in clients)
                {
                    wr.WriteLine(client.Id + "," + client.Name + "," + client.Surname + "," + client.Patronymic + "," + client.BirthDate.ToString("dd.MM.yyyy"));
                }
            }
        }

        public static Client[] ReadClients()
        {
            string[] lines = File.ReadAllLines("clients.txt");

            Client[] clients = new Client[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                string[] data = lines[i].Split(',');

                clients[i] = new Client(int.Parse(data[0]), data[1], data[2], data[3],DateTime.ParseExact(data[4],"dd.MM.yyyy",null)
                );
            }
            return clients;
        }

        public static void PrintClients(Client[] clients)
        {
            Console.WriteLine();
            Console.WriteLine("CLIENTS:");

            foreach (Client client in clients)
            {
                client.Print();
            }
        }

        public static Shop[] InitShops()
        {
            Shop[] shops = new Shop[3];

            shops[0] = new Shop(1, "SportMaster", "001");
            shops[1] = new Shop(2, "Metro","002");
            shops[2] = new Shop(3, "7Eleven","003");
            return shops;
        }

        public static void WriteShops(Shop[] shops)
        {
            using (StreamWriter wr = new StreamWriter("shops.txt"))
            {
                foreach (Shop shop in shops)
                {
                    wr.WriteLine(shop.Id + "," + shop.Name + "," + shop.Code);
                }
            }
        }

        public static Shop[] ReadShops()
        {
            string[] lines = File.ReadAllLines("shops.txt");

            Shop[] shops = new Shop[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                string[] data = lines[i].Split(',');
                shops[i] = new Shop(int.Parse(data[0]),data[1],data[2]);
            }

            return shops;
        }

        public static void PrintShops(Shop[] shops)
        {
            Console.WriteLine();
            Console.WriteLine("SHOPS:");

            foreach (Shop shop in shops)
            {
                shop.Print();
            }
        }
    }
    class Program
    {
        static void Main()
        {

            Good[] goods = Repository.InitGoods();
            Repository.WriteGoods(goods);
            goods = Repository.ReadGoods();
            Repository.PrintGoods(goods);

            Client[] clients = Repository.InitClients();
            Repository.WriteClients(clients);
            clients = Repository.ReadClients();
            Repository.PrintClients(clients);

            Shop[] shops = Repository.InitShops();
            Repository.WriteShops(shops);
            shops = Repository.ReadShops();
            Repository.PrintShops(shops);


            Good[] newGoods = new Good[10];
            for (int i = 0; i < newGoods.Length; i++)
            {
                newGoods[i] = new Good(goods.Length + i + 1,"new good" + (i + 1), (goods.Length + i + 1).ToString());
            }
            Good[] allGoods = new Good[goods.Length + newGoods.Length];
            Array.Copy(goods,allGoods,goods.Length);
            Array.Copy(newGoods, 0, allGoods,goods.Length,newGoods.Length);
            goods = allGoods;
            Repository.WriteGoods(goods);


            Client[] newClients = new Client[3];
            newClients[0] = new Client(clients.Length + 1, "Morozova", "Anastasia", "Andreevna",new DateTime(2003, 3, 12));
            newClients[1] = new Client(clients.Length + 2, "Pavlovkiy", "Roman", "Vyacheslavovich",new DateTime(1999, 11, 29));
            newClients[2] = new Client(clients.Length + 3, "Ermolaeva", "Sofiya", "Pavlovna", new DateTime(2004, 7, 30));
            Client[] allClients = new Client[clients.Length + newClients.Length];
            Array.Copy(clients,allClients, clients.Length);
            Array.Copy(newClients,0,allClients,clients.Length,newClients.Length);
            clients = allClients;
            Repository.WriteClients(clients);


            Shop[] newShops = new Shop[2];
            newShops[0] = new Shop(shops.Length + 1,"Gold Apple","004");
            newShops[1] = new Shop(shops.Length + 2,"EuroSpar","005");
            Shop[] allShops = new Shop[shops.Length + newShops.Length];
            Array.Copy(shops,allShops,shops.Length);
            Array.Copy(newShops,0,allShops,shops.Length, newShops.Length);
            shops = allShops;
            Repository.WriteShops(shops);


            Console.WriteLine();
            Console.WriteLine("AFTER ADDING:");
            goods = Repository.ReadGoods();
            Repository.PrintGoods(goods);
            clients = Repository.ReadClients();
            Repository.PrintClients(clients);
            shops = Repository.ReadShops();
            Repository.PrintShops(shops);

            Console.WriteLine();
        }
    }
}