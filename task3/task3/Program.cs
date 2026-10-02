using System;
using System.IO;
using System.Collections.Generic;

namespace task3
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
                { age--; }
                return age;
            }
        }

        public Client(int id, string name, string surname, string patronymic, DateTime birthDate)
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
                goods[i] = new Good(int.Parse(data[0]), data[1], data[2]);
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

            clients[0] = new Client(1, "Arseniy", "Vasilev",  "Artyomovich", new DateTime(2004, 9, 22));
            clients[1] = new Client(2, "Artyom", "Portnov", "Sergeevich", new DateTime(2005, 7, 17));
            clients[2] = new Client(3, "Razil", "Minyazov",  "Renatovich", new DateTime(2000, 7, 14));            
            clients[3] = new Client(4,  "Dmitriy", "Hramov", "Aleksandrovich", new DateTime(2006, 12, 16));
            clients[4] = new Client(5,  "Alyona", "Kulakova", "Denisovna", new DateTime(1999, 2, 3));

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

                clients[i] = new Client(int.Parse(data[0]), data[1], data[2], data[3], DateTime.ParseExact(data[4], "dd.MM.yyyy", null)
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
            shops[1] = new Shop(2, "Metro", "002");
            shops[2] = new Shop(3, "7Eleven", "003");
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
                shops[i] = new Shop(int.Parse(data[0]), data[1], data[2]);
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
            Console.WriteLine("TASK1:");
            //GOODS
            Good[] goods = Repository.InitGoods();
            Repository.WriteGoods(goods);
            goods = Repository.ReadGoods();
            Repository.PrintGoods(goods);
            //CLIENTS
            Client[] clients = Repository.InitClients();
            Repository.WriteClients(clients);
            clients = Repository.ReadClients();
            Repository.PrintClients(clients);
            //SHOPS
            Shop[] shops = Repository.InitShops();
            Repository.WriteShops(shops);
            shops = Repository.ReadShops();
            Repository.PrintShops(shops);

            //ADDING GOODS
            Good[] newGoods = new Good[10];
            for (int i = 0; i < newGoods.Length; i++)
            {    newGoods[i] = new Good(goods.Length + i + 1, "new good" + (i + 1), (goods.Length + i + 1).ToString());}
            Good[] allGoods = new Good[goods.Length + newGoods.Length];
            Array.Copy(goods, allGoods, goods.Length);
            Array.Copy(newGoods, 0, allGoods, goods.Length, newGoods.Length);
            goods = allGoods;
            Repository.WriteGoods(goods);

            //ADDING CLIENTS
            Client[] newClients = new Client[3];
            newClients[0] = new Client(clients.Length + 1, "Morozova", "Anastasia", "Andreevna", new DateTime(2003, 3, 12));
            newClients[1] = new Client(clients.Length + 2, "Pavlovkiy", "Roman", "Vyacheslavovich", new DateTime(1999, 11, 29));
            newClients[2] = new Client(clients.Length + 3, "Ermolaeva", "Sofiya", "Pavlovna", new DateTime(2004, 7, 30));
            Client[] allClients = new Client[clients.Length + newClients.Length];
            Array.Copy(clients, allClients, clients.Length);
            Array.Copy(newClients, 0, allClients, clients.Length, newClients.Length);
            clients = allClients;
            Repository.WriteClients(clients);

            //ADDING SHOPS
            Shop[] newShops = new Shop[2];
            newShops[0] = new Shop(shops.Length + 1, "Gold Apple", "004");
            newShops[1] = new Shop(shops.Length + 2, "EuroSpar", "005");
            Shop[] allShops = new Shop[shops.Length + newShops.Length];
            Array.Copy(shops, allShops, shops.Length);
            Array.Copy(newShops, 0, allShops, shops.Length, newShops.Length);
            shops = allShops;
            Repository.WriteShops(shops);

            //AFTER ADDING
            Console.WriteLine();
            Console.WriteLine("AFTER ADDING:");
            goods = Repository.ReadGoods();
            Repository.PrintGoods(goods);
            clients = Repository.ReadClients();
            Repository.PrintClients(clients);
            shops = Repository.ReadShops();
            Repository.PrintShops(shops);

            Console.WriteLine();

            Console.WriteLine("TASK2:");

            ShopDaoFileRepository shop_rep = new ShopDaoFileRepository();
            ClientDaoFileRepository client_rep = new ClientDaoFileRepository();
            GoodDaoFileRepository good_rep = new GoodDaoFileRepository();

            ShopDao shop = new ShopDao();
            shop.Id = 6;
            shop.Name = "Costco";
            shop.Code = 1234;
            shop_rep.Create(shop);

            ClientDao client = new ClientDao();
            client.Id = 9;
            client.Name = "Azalia";
            client.Surname = "Vafina";
            client.Patronymic = "Airatovna";
            client.BirthDate = new DateTime(2007, 8, 24);
            client_rep.Create(client);

            GoodDao good = new GoodDao();
            good.Id = 31;
            good.Name = "Pasta";
            good.Code = 67;
            good_rep.Create(good);


            ShopDao shop1 = shop_rep.Read(6);
            Console.WriteLine($"{shop1.Id}, {shop1.Name}, {shop1.Code}");

            ClientDao client1 = client_rep.Read(9);
            Console.WriteLine($"{client1.Id}, {client1.Surname}, {client1.Name}, {client1.Age}");

            GoodDao good1 = good_rep.Read(31);
            Console.WriteLine($"{good1.Id}, {good1.Name}, {good1.Code}");


            Console.WriteLine();
            Console.WriteLine("SHOPS");
            List<ShopDao> shops1 = shop_rep.ReadAll();
            for (int i = 0; i < shops1.Count; i++)
            {
                Console.WriteLine($"{shops1[i].Id}, {shops1[i].Name}, {shops1[i].Code}");
            }
            Console.WriteLine();
            Console.WriteLine("CLIENTS");
            List<ClientDao> clients1 = client_rep.ReadAll();
            for (int i = 0; i < clients1.Count; i++)
            {
                Console.WriteLine($"{clients1[i].Id}, {clients1[i].Surname} {clients1[i].Name}  {clients1[i].Patronymic}, {clients1[i].Age}");
            }
            Console.WriteLine();
            Console.WriteLine("GOODS");
            List<GoodDao> goods1 = good_rep.ReadAll();
            for (int i = 0; i < goods1.Count; i++)
            {
                Console.WriteLine($"{goods1[i].Id}, {goods1[i].Name}, {goods1[i].Code}");
            }


            shop.Name = "Erewhon";
            shop_rep.Update(shop);

            client.Name = "Azalechka";
            client_rep.Update(client);

            good.Name = "Milk";
            good_rep.Update(good);

            Console.WriteLine();
            Console.WriteLine("SHOPS");
            List<ShopDao> shops2 = shop_rep.ReadAll();
            for (int i = 0; i < shops2.Count; i++)
            {
                Console.WriteLine($"{shops2[i].Id}, {shops2[i].Name}, {shops2[i].Code}");
            }
            Console.WriteLine();
            Console.WriteLine("CLIENTS");
            List<ClientDao> clients2 = client_rep.ReadAll();
            for (int i = 0; i < clients2.Count; i++)
            {
                Console.WriteLine($"{clients2[i].Id}, {clients2[i].Surname} {clients2[i].Name}  {clients2[i].Patronymic}, {clients2[i].Age}");
            }
            Console.WriteLine();
            Console.WriteLine("GOODS");
            List<GoodDao> goods2 = good_rep.ReadAll();
            for (int i = 0; i < goods2.Count; i++)
            {
                Console.WriteLine($"{goods2[i].Id}, {goods2[i].Name}, {goods2[i].Code}");
            }


            shop_rep.Delete(6);
            client_rep.Delete(9);
            good_rep.Delete(31);
        }
    }
}