using Core;
using System;
using System.IO;
using System.Collections.Generic;
using Shop.Dal;

namespace task4;

internal class Program
{
    static void Main()
    {
        using var context = new ShopEntityContext("shop.db");

        IRepository<ShopDao> shopRepository =
            new ShopDaoDataBaseRepository(context);

        IRepository<GoodDao> goodRepository =
            new GoodDaoDataBaseRepository(context);

        IRepository<ClientDao> clientRepository =
            new ClientDaoDataBaseRepository(context);


        var allShops = shopRepository.ReadAll();

        Console.WriteLine($"Всего магазинов: {allShops.Count}");

        foreach (var shop in allShops)
        {
            Console.WriteLine($"{shop.Id}: {shop.Name}, код {shop.Code}");
        }
        var shopToUpdate = shopRepository.Read(1000);

        if (shopToUpdate != null)
        {
            shopToUpdate.Name = "UpdatedShop";
            shopToUpdate.Code = 2000;

            shopRepository.Update(shopToUpdate);
            var updatedShop = shopRepository.Read(1000);
            Console.WriteLine(updatedShop == null ? "Update: ошибка" : $"Update: {updatedShop.Name}, код {updatedShop.Code}");
        }
        var allShops1 = shopRepository.ReadAll();

        Console.WriteLine($"Всего магазинов: {allShops1.Count}");

        foreach (var shop in allShops1)
        {
            Console.WriteLine($"{shop.Id}: {shop.Name}, код {shop.Code}");
        }

        var shopToUpdate1 = shopRepository.Read(1000);

        if (shopToUpdate1 != null)
        {
            shopToUpdate1.Name = "UpdatedShop";
            shopToUpdate1.Code = 2000;
            shopRepository.Update(shopToUpdate1);
            var updatedShop = shopRepository.Read(1000);
            Console.WriteLine(updatedShop == null ? "Update: ошибка" : $"Update: {updatedShop.Name}, код {updatedShop.Code}");
        }



        ShopDaoFileRepository shopFile = new ShopDaoFileRepository();
        ShopDaoXmlRepository shopXml = new ShopDaoXmlRepository();
        ShopDaoJsonRepository shopJson = new ShopDaoJsonRepository();

        ClientDaoFileRepository clientFile = new ClientDaoFileRepository();
        ClientDaoXmlRepository clientXml = new ClientDaoXmlRepository();
        ClientDaoJsonRepository clientJson = new ClientDaoJsonRepository();

        GoodDaoFileRepository goodFile = new GoodDaoFileRepository();
        GoodDaoXmlRepository goodXml = new GoodDaoXmlRepository();
        GoodDaoJsonRepository goodJson = new GoodDaoJsonRepository();

        List<ShopDao> shops = new List<ShopDao>
        {
            new ShopDao { Id = 1, Name = "EuroSpar", Code = 1001 },
            new ShopDao { Id = 2, Name = "7Eleven", Code = 1002 },
            new ShopDao { Id = 3, Name = "Costco", Code = 1003 }
        };

        List<ClientDao> clients = new List<ClientDao>
        {
            new ClientDao { Id = 1, Name = "Sofiya", Surname = "Jandarova", Patronymic = "Igorevna", BirthDay = new DateTime(2001, 3, 8) },
            new ClientDao { Id = 2, Name = "Azaliya", Surname = "Vafina", Patronymic = "Airatovna", BirthDay = new DateTime(2005, 8, 24) },
            new ClientDao { Id = 3, Name = "Arseniy", Surname = "Vasilev", Patronymic = "Artyomovich", BirthDay = new DateTime(2002, 9, 22) },
            new ClientDao { Id = 4, Name = "Dmitriy", Surname = "Hramov", Patronymic = "Aleksandrovich", BirthDay = new DateTime(2002, 12, 16) },
            new ClientDao { Id = 5, Name = "Alyona", Surname = "Kulakova", Patronymic = "Denisovna", BirthDay = new DateTime(2002, 2, 3) }
        };

        var goods = new List<GoodDao>
        {
            new GoodDao { Id = 1, Name = "Ноутбук Lenovo IdeaPad 3", Code = 2001 },
            new GoodDao { Id = 2, Name = "Ноутбук ASUS VivoBook 15", Code = 2002 },
            new GoodDao { Id = 3, Name = "Ноутбук HP Pavilion 15", Code = 2003 },
            new GoodDao { Id = 4, Name = "Смартфон Samsung Galaxy S24", Code = 2004 },
            new GoodDao { Id = 5, Name = "Смартфон Apple iPhone 15", Code = 2005 },
            new GoodDao { Id = 6, Name = "Смартфон Xiaomi Redmi Note 13", Code = 2006 },
            new GoodDao { Id = 7, Name = "Планшет Apple iPad Air", Code = 2007 },
            new GoodDao { Id = 8, Name = "Планшет Samsung Galaxy Tab S9", Code = 2008 },
            new GoodDao { Id = 9, Name = "Наушники JBL Tune 720BT", Code = 2009 },
            new GoodDao { Id = 10, Name = "Наушники Sony WH-1000XM5", Code = 2010 },
            new GoodDao { Id = 11, Name = "Клавиатура Logitech K380", Code = 2011 },
            new GoodDao { Id = 12, Name = "Клавиатура Redragon Kumara", Code = 2012 },
            new GoodDao { Id = 13, Name = "Мышь Logitech M185", Code = 2013 },
            new GoodDao { Id = 14, Name = "Мышь Razer DeathAdder V2", Code = 2014 },
            new GoodDao { Id = 15, Name = "Монитор Samsung Odyssey G5", Code = 2015 },
            new GoodDao { Id = 16, Name = "Монитор LG UltraGear 27GN800", Code = 2016 },
            new GoodDao { Id = 17, Name = "Веб-камера Logitech C920", Code = 2017 },
            new GoodDao { Id = 18, Name = "Микрофон HyperX SoloCast", Code = 2018 },
            new GoodDao { Id = 19, Name = "SSD Samsung 990 EVO 1TB", Code = 2019 },
            new GoodDao { Id = 20, Name = "Жёсткий диск Seagate BarraCuda 2TB", Code = 2020 },
            new GoodDao { Id = 21, Name = "Флешка Kingston DataTraveler 64GB", Code = 2021 },
            new GoodDao { Id = 22, Name = "Роутер TP-Link Archer AX55", Code = 2022 },
            new GoodDao { Id = 23, Name = "Принтер HP LaserJet Pro M404", Code = 2023 },
            new GoodDao { Id = 24, Name = "Портативная колонка JBL Flip 6", Code = 2024 },
            new GoodDao { Id = 25, Name = "Power Bank Xiaomi 20000 mAh", Code = 2025 },
            new GoodDao { Id = 26, Name = "Зарядное устройство Anker 735", Code = 2026 },
            new GoodDao { Id = 27, Name = "Кабель USB-C Baseus Cafule", Code = 2027 },
            new GoodDao { Id = 28, Name = "Игровой контроллер Xbox Wireless", Code = 2028 },
            new GoodDao { Id = 29, Name = "Игровая мышь Logitech G102 Lightsync", Code = 2029 },
            new GoodDao { Id = 30, Name = "Коврик для мыши HyperX Fury S", Code = 2030 }
        };

        foreach (ShopDao shop in shops)
        {
            shopFile.Create(shop);
            shopXml.Create(shop);
            shopJson.Create(shop);
            shopRepository.Create(shop);
        }

        foreach (ClientDao client in clients)
        {
            clientFile.Create(client);
            clientXml.Create(client);
            clientJson.Create(client);
            clientRepository.Create(client);    
        }

        foreach (GoodDao good in goods)
        {
            goodFile.Create(good);
            goodXml.Create(good);
            goodJson.Create(good);
            goodRepository.Create(good);
        }

        Console.WriteLine("created: shops.txt, shops.xml, shops.json, clients.txt, clients.xml, clients.json, goods.txt, goods.xml, goods.json.");



    }
}
