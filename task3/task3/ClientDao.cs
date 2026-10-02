using System;

namespace task3
{
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
}
