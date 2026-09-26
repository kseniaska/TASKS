using System;
using System.Collections.Generic;
using System.IO;

namespace task2
{
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
            List<ShopDao> shops = new List<ShopDao>();

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
}