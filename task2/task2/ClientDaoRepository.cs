using System;
using System.Collections.Generic;
using System.IO;

namespace task2
{
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
}