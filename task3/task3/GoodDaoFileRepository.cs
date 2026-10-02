using System;
using System.Collections.Generic;
using System.IO;

namespace task3
{
    public class GoodDaoFileRepository : IRepository<GoodDao>
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
}