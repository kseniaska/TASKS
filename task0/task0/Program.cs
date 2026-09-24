using System;
using System.IO;
using System.Diagnostics;

namespace ConsoleApp
{
    class Creature
    {
        string type;
        string name;
        string surname;
        int age;
        string area;

        public Creature()
        {
            type = "";
            name = "";
            surname = "";
            age = 0;
            area = "";
        }
        public Creature(string t, string n, string s, int ag, string ar)
        {
            type = t;
            name = n;
            surname = s;
            age = ag;   
            area = ar;
        }

        public string Type
        {
            get => type;
            set => type = value;
        }
        public string Name
        {
            get => name;
            set => name = value;
        }
        public string Surname
        {
            get => surname;
            set => surname = value;
        }
        public int Age
        {
            get => age;
            set => age = value;
        }
        public string Area
        {
            get => area;
            set => area = value;
        }
        public void Print()
        {
            Console.WriteLine($"{type}: {name} {surname}, age: {age}, area: {area}");
        }
    }
    class Program
    {
        private static Creature[] Generate_Creatures(int n)
        {
            Creature[] a = new Creature[n];
            
            string[] types = new string[5] { "cat", "person", "dog", "rabbit", "horse" };

            string[] persons_names = new string[10] { "Josh", "Sean", "Arseniy", "Alex", "Olivia", "Anna", "Eve", "Leon", "Dmitriy", "Rob" };
            string[] animals_names = new string[10] { "Archie", "Tulip", "Pirate", "Baby", "Candy", "Tom", "Berry", "AppleJack", "Sydney", "Bravie" };
            string[] surnames = new string[10] {"Smith", "Tucson", "Ivanov", "Elordi", "Kennedy", "Vasiliev", "Carpenter", "Taylor", "Hudson", "Jackson" };

            string[] areas = new string[5] { "city", "village", "farm", "forest", "island" };

            Random r = new Random();
            for (int i = 0; i < n; i++)
            {
                a[i] = new Creature();
                int w = r.Next(types.Length);
                a[i].Type = types[w];
                if (a[i].Type == "person")
                { a[i].Name = persons_names[r.Next(persons_names.Length)]; }
                else
                { a[i].Name = animals_names[r.Next(animals_names.Length)]; }
                a[i].Surname = surnames[r.Next(surnames.Length)];
                a[i].Age = r.Next(100);
                a[i].Area = areas[r.Next(areas.Length)]; 
            }
            return a;
        }
        private static void ToText(int n, Creature[] a)
        {
            using (StreamWriter sw = new StreamWriter(@"task0.txt"))
            {
                for (int i = 0; i < n; i++)
                {
                    sw.WriteLine($"{a[i].Type},{a[i].Name},{a[i].Surname},{a[i].Age},{a[i].Area}");
                }
            }
        }
        private static Creature[] FromText(int n)
        {
            Creature[] a = new Creature[n];
            using (StreamReader sr = new StreamReader(@"task0.txt", System.Text.Encoding.UTF8))
            {
                for (int i = 0; i < n; i++)
                {
                    string s = sr.ReadLine();
                    if (s == null)
                        break;
                    a[i] = new Creature();
                    string[] data = s.Split(',');

                    a[i].Type = data[0];
                    a[i].Name = data[1];
                    a[i].Surname = data[2];
                    a[i].Age = int.Parse(data[3]);
                    a[i].Area = data[4];
                }
            }
            return a;
        }
        private static void ToBin(int n, Creature[] a)
        {
            using (BinaryWriter bw = new BinaryWriter(new FileStream("C:\\TM\\task0.bin", FileMode.Create)))
            {
                for (int i = 0; i < n; i++)
                {
                    bw.Write(a[i].Type);
                    bw.Write(a[i].Name);
                    bw.Write(a[i].Surname);
                    bw.Write(a[i].Age);
                    bw.Write(a[i].Area);
                }
            }            
        }
        private static Creature[] FromBin(int n)
        {
            Creature[] a = new Creature[n];
            using (BinaryReader br = new BinaryReader(new FileStream("C:\\TM\\task0.bin", FileMode.Open)))
            {
                for (int i = 0; i < n; i++)
                {
                    a[i] = new Creature();
                    a[i].Type = br.ReadString();
                    a[i].Name = br.ReadString();
                    a[i].Surname = br.ReadString();
                    a[i].Age = br.ReadInt32();
                    a[i].Area = br.ReadString();
                }
            }
            return a;
        }

        private static long MeasureTextReading(int n)
        {
            Stopwatch sw = Stopwatch.StartNew();
            Creature[] a = FromText(n);
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }
        private static long MeasureBinaryReading(int n)
        {
            Stopwatch sw = Stopwatch.StartNew();
            Creature[] a = FromBin(n);
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        static void Main()
        {
            int[] amounts = { 10, 1000, 100000, 1000000, 10000000 };

            for (int i = 0; i < amounts.Length; i++)
            {
                int n = amounts[i];
                Creature[] a = Generate_Creatures(n);
                ToText(n, a);
                ToBin(n, a);
                long texttime = MeasureTextReading(n);
                long bintime = MeasureBinaryReading(n);
                Console.WriteLine($"amount: {n}, text reading: {texttime}, bin reading: {bintime}");
            }            
        }
    }
}