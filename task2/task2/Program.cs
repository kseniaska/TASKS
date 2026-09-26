using System;
using System.IO;
using System.Collections.Generic;

namespace task2
{
            
    //public abstract class FileRepository<T>: IRepository<T>
    //{
    //    string path;
    //    public FileRepository(string path)
    //    {
    //        this.path = path;
    //    }
    //    protected abstract T FromString(string line);
    //    protected abstract string ToString(T item);

    //    public void Create(T item)
    //    {
    //        using (StreamWriter sw = new StreamWriter(path, true))
    //        {
    //            sw.WriteLine(ToString(item));
    //        }
    //    }
    //    public T Read(int id)
    //    {
    //        using (StreamReader sr = new StreamReader(path))
    //        {
    //            string line;
    //            while ((line = sr.ReadLine()) != null)
    //            {
    //                T item = FromString(line);
    //                string[] data = line.Split(',');

    //                if (int.Parse(data[0]) == id)
    //                {
    //                    return item;
    //                }
    //            }
    //        }
    //        return default(T);
    //    }
        
    //    public List<T> ReadAll()
    //    {
    //        List<T> items = new List<T>();

    //        using (StreamReader sr = new StreamReader(path))
    //        {
    //            string line;
    //            while ((line = sr.ReadLine()) != null)
    //            {
    //                items.Add(FromString(line));
    //            }
    //        }
    //        return items;
    //    }
    //    public void Update(T item)
    //    {
    //        List<T> items = ReadAll();

    //        string item_line = ToString(item);
    //        string[] item_data = item_line.Split(",");
    //        int item_id = int.Parse(item_data[0]);
    //        for (int i = 0; i < items.Count; i++)
    //        {
    //            string current_line = ToString(items[i]);
    //            string[] current_data = current_line.Split(",");
    //            if (int.Parse(current_data[0]) == item_id)
    //            {
    //                items[i] = item;
    //                break;
    //            }
    //        }

    //        using (StreamWriter sw = new StreamWriter(path))
    //        {
    //            for (int i = 0; i < items.Count; i++)
    //            {
    //                sw.WriteLine(ToString(items[i]));
    //            }
    //        }
    //    }
    //    public void Delete(int id)
    //    {
    //        List<T> items = ReadAll();

    //        for (int i = 0; i < items.Count; i++)
    //        {
    //            string current_line = ToString(items[i]);
    //            string[] current_data = current_line.Split(",");
    //            if (int.Parse(current_data[0]) == id)
    //            {
    //                items.RemoveAt(i);
    //                break;
    //            }
    //        }
    //        using (StreamWriter sw = new StreamWriter(path))
    //        {
    //            for (int i = 0; i < items.Count; i++)
    //            {
    //                sw.WriteLine(ToString(items[i]));
    //            }
    //        }
    //    }
    //}

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