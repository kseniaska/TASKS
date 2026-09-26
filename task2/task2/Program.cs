using System;
using System.IO;
using System.Collections.Generic;

namespace ConsoleApp
{
    public interface IRepository<T>
    {
        void Create(T item);
        T Read(int id);
        List<T> ReadAll();
        void Update(T item);
        void Delete(int id);
    }

    public class ShopDao
    {
        int id;
        string name;
        int code;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Code
        {
            get { return code; }
            set { code = value; }
        }
    }
    public class ClientDao
    {
        int id;
        string name;
        string surname;
        string patronymic;

        public int Id
        {
            get { return id; }
            set { id = value; }
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
            get; set;
        }
        public int Age
        {
            get
            {
                int age = DateTime.Today.Year - BirthDate.Year;
                if (BirthDate.Date > DateTime.Today.AddYears(-age))
                    age--;
                return age;
            }
        }
    }
    public class GoodDao
    {
        int id;
        string name;
        int code;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Code
        {
            get { return code; }
            set { code = value; }
        }
    }

    public class ShopDaoRepository : IRepository<ShopDao>
    {
        string path = "shops.txt";
        public void Create(ShopDao item)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine($"{item.Id},{item.Name},{item.Code}");
            }
        }
        public ShopDao Read(int id)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] data = line.Split(',');
                    if (int.Parse(data[0]) == id)
                    {
                        ShopDao shop = new ShopDao();
                        shop.Id = int.Parse(data[0]);
                        shop.Name = data[1];
                        shop.Code = int.Parse(data[2]);
                        return shop;
                    }
                }
            }
            return null;
        }
        public List<ShopDao> ReadAll()
        {
            List <ShopDao> shops = new List<ShopDao>();

            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] data = line.Split(',');
                    ShopDao shop = new ShopDao();
                    shop.Id = int.Parse(data[0]);
                    shop.Name = data[1];
                    shop.Code = int.Parse(data[2]);
                    
                    shops.Add(shop);
                }
            }
            return shops;
        }
        public void Update(ShopDao item)
        {
            List<ShopDao> shops = ReadAll();
            for (int i = 0; i < shops.Count; i++)
            {
                if (shops[i].Id == item.Id)
                {
                    shops[i] = item;
                    break;
                }
            }

            using (StreamWriter sw = new StreamWriter(path))
            {
                for (int i = 0; i < shops.Count; i++)
                {
                    sw.WriteLine($"{shops[i].Id},{shops[i].Name},{shops[i].Code}");
                }
            }
        }
        public void Delete(int id)
        {
            List<ShopDao> shops = ReadAll();
            for (int i = 0; i < shops.Count; i++)
            {
                if (shops[i].Id == id)
                {
                    shops.RemoveAt(i);
                    break;
                }
            }

            using (StreamWriter sw = new StreamWriter(path))
            {
                for (int i = 0; i < shops.Count; i++)
                {
                    sw.WriteLine($"{shops[i].Id},{shops[i].Name},{shops[i].Code}");
                }
            }
        }
    }
    public class ClientDaoRepository : IRepository<ClientDao>
    {
        string path = "clients.txt";
        public void Create(ClientDao item)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine($"{item.Id},{item.Name},{item.Surname},{item.Patronymic},{item.BirthDate}");
            }
        }
        public ClientDao Read(int id)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] data = line.Split(',');
                    if (int.Parse(data[0]) == id)
                    {
                        ClientDao client = new ClientDao();
                        client.Id = int.Parse(data[0]);
                        client.Name = data[1];
                        client.Surname = data[2];
                        client.Patronymic = data[3];
                        client.BirthDate = DateTime.Parse(data[4]);
                        return client;
                    }
                }
            }
            return null;
        }
        public List<ClientDao> ReadAll()
        {
            List<ClientDao> clients = new List<ClientDao>();

            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] data = line.Split(',');
                    ClientDao client = new ClientDao();
                    client.Id = int.Parse(data[0]);
                    client.Name = data[1];
                    client.Surname = data[2];
                    client.Patronymic = data[3];
                    client.BirthDate = DateTime.Parse(data[4]);

                    clients.Add(client);
                }
            }
            return clients;
        }
        public void Update(ClientDao item)
        {
            List<ClientDao> clients = ReadAll();
            for (int i = 0; i < clients.Count; i++)
            {
                if (clients[i].Id == item.Id)
                {
                    clients[i] = item;
                    break;
                }
            }

            using (StreamWriter sw = new StreamWriter(path))
            {
                for (int i = 0; i < clients.Count; i++)
                {
                    sw.WriteLine($"{clients[i].Id},{clients[i].Name},{clients[i].Surname},{clients[i].Patronymic},{clients[i].BirthDate}");
                }
            }
        }
        public void Delete(int id)
        {
            List<ClientDao> clients = ReadAll();
            for (int i = 0; i < clients.Count; i++)
            {
                if (clients[i].Id == id)
                {
                    clients.RemoveAt(i);
                    break;
                }
            }

            using (StreamWriter sw = new StreamWriter(path))
            {
                for (int i = 0; i < clients.Count; i++)
                {
                    sw.WriteLine($"{clients[i].Id},{clients[i].Name},{clients[i].Surname},{clients[i].Patronymic},{clients[i].BirthDate}");
                }
            }
        }
    }
    public class GoodDaoRepository : IRepository<GoodDao>
    {
        string path = "goods.txt";
        public void Create(GoodDao item)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine($"{item.Id},{item.Name},{item.Code}");
            }
        }
        public GoodDao Read(int id)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] data = line.Split(',');
                    if (int.Parse(data[0]) == id)
                    {
                        GoodDao good = new GoodDao();
                        good.Id = int.Parse(data[0]);
                        good.Name = data[1];
                        good.Code = int.Parse(data[2]);

                        return good;
                    }
                }
            }
            return null;
        }
        public List<GoodDao> ReadAll()
        {
            List<GoodDao> goods = new List<GoodDao>();

            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] data = line.Split(',');
                    GoodDao good = new GoodDao();
                    good.Id = int.Parse(data[0]);
                    good.Name = data[1];
                    good.Code = int.Parse(data[2]);

                    goods.Add(good);
                }
            }
            return goods;
        }
        public void Update(GoodDao item)
        {
            List<GoodDao> goods = ReadAll();
            for (int i = 0; i < goods.Count; i++)
            {
                if (goods[i].Id == item.Id)
                {
                    goods[i] = item;
                    break;
                }
            }

            using (StreamWriter sw = new StreamWriter(path))
            {
                for (int i = 0; i < goods.Count; i++)
                {
                    sw.WriteLine($"{goods[i].Id},{goods[i].Name},{goods[i].Code}");
                }
            }
        }
        public void Delete(int id)
        {
            List<GoodDao> goods = ReadAll();
            for (int i = 0; i < goods.Count; i++)
            {
                if (goods[i].Id == id)
                {
                    goods.RemoveAt(i);
                    break;
                }
            }

            using (StreamWriter sw = new StreamWriter(path))
            {
                for (int i = 0; i < goods.Count; i++)
                {
                    sw.WriteLine($"{goods[i].Id},{goods[i].Name},{goods[i].Code}");
                }
            }
        }
    }

    public abstract class FileRepository<T>: IRepository<T>
    {
        string path;
        public FileRepository(string path)
        {
            this.path = path;
        }
        protected abstract T FromString(string line);
        protected abstract string ToString(T item);

        public void Create(T item)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine(ToString(item));
            }
        }
        public T Read(int id)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    T item = FromString(line);
                    string[] data = line.Split(',');

                    if (int.Parse(data[0]) == id)
                    {
                        return item;
                    }
                }
            }
            return default(T);
        }
        
        public List<T> ReadAll()
        {
            List<T> items = new List<T>();

            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    items.Add(FromString(line));
                }
            }
            return items;
        }
        public void Update(T item)
        {
            List<T> items = ReadAll();

            string item_line = ToString(item);
            string[] item_data = item_line.Split(",");
            int item_id = int.Parse(item_data[0]);
            for (int i = 0; i < items.Count; i++)
            {
                string current_line = ToString(items[i]);
                string[] current_data = current_line.Split(",");
                if (int.Parse(current_data[0]) == item_id)
                {
                    items[i] = item;
                    break;
                }
            }

            using (StreamWriter sw = new StreamWriter(path))
            {
                for (int i = 0; i < items.Count; i++)
                {
                    sw.WriteLine(ToString(items[i]));
                }
            }
        }
        public void Delete(int id)
        {
            List<T> items = ReadAll();

            for (int i = 0; i < items.Count; i++)
            {
                string current_line = ToString(items[i]);
                string[] current_data = current_line.Split(",");
                if (int.Parse(current_data[0]) == id)
                {
                    items.RemoveAt(i);
                    break;
                }
            }
            using (StreamWriter sw = new StreamWriter(path))
            {
                for (int i = 0; i < items.Count; i++)
                {
                    sw.WriteLine(ToString(items[i]));
                }
            }
        }
    }

    class Program
    {
        static void Main()
        {
            ShopDaoRepository shop_rep = new ShopDaoRepository();
            ClientDaoRepository client_rep = new ClientDaoRepository();
            GoodDaoRepository good_rep = new GoodDaoRepository();

            ShopDao shop = new ShopDao();
            shop.Id = 1;
            shop.Name = "EuroSpar";
            shop.Code = 1234;
            shop_rep.Create(shop);

            ClientDao client = new ClientDao();
            client.Id = 1;
            client.Name = "Azalia";
            client.Surname = "Vafina";
            client.Patronymic = "Airatovna";
            client.BirthDate = new DateTime(2007, 8, 24);
            client_rep.Create(client);

            GoodDao good = new GoodDao();
            good.Id = 1;
            good.Name = "Pasta";
            good.Code = 67;
            good_rep.Create(good);


            ShopDao shop1 = shop_rep.Read(1);
            Console.WriteLine(shop1.Name);

            ClientDao client1 = client_rep.Read(1);
            Console.WriteLine($"{client1.Name},{client1.Age}");

            GoodDao good1 = good_rep.Read(1);
            Console.WriteLine(good1.Name);


            List<ShopDao> shops = shop_rep.ReadAll();
            for (int i = 0; i < shops.Count; i++)
            {
                Console.WriteLine($"{shops[i].Id}, {shops[i].Name}, {shops[i].Code}");
            }
            List<ClientDao> clients = client_rep.ReadAll();
            for (int i = 0; i < clients.Count; i++)
            {
                Console.WriteLine($"{clients[i].Id}, {clients[i].Surname} {clients[i].Name}  {clients[i].Patronymic}, {clients[i].Age}");
            }
            List<GoodDao> goods = good_rep.ReadAll();
            for (int i = 0; i < goods.Count; i++)
            {
                Console.WriteLine($"{goods[i].Id}, {goods[i].Name}, {goods[i].Code}");
            }


            shop.Name = "Spar";
            shop_rep.Update(shop);

            client.Name = "Azalechka";
            client_rep.Update(client);

            good.Name = "Milk";
            good_rep.Update(good);

            List<ShopDao> shops1 = shop_rep.ReadAll();
            for (int i = 0; i < shops1.Count; i++)
            {
                Console.WriteLine($"{shops1[i].Id}, {shops1[i].Name}, {shops1[i].Code}");
            }
            List<ClientDao> clients1 = client_rep.ReadAll();
            for (int i = 0; i < clients1.Count; i++)
            {
                Console.WriteLine($"{clients1[i].Id}, {clients1[i].Surname} {clients1[i].Name}  {clients[i].Patronymic}, {clients1[i].Age}");
            }
            List<GoodDao> goods1 = good_rep.ReadAll();
            for (int i = 0; i < goods1.Count; i++)
            {
                Console.WriteLine($"{goods1[i].Id}, {goods1[i].Name}, {goods1[i].Code}");
            }


            shop_rep.Delete(1);
            client_rep.Delete(1);
            good_rep.Delete(1);
        }
    }
}