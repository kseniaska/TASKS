using Core;

namespace Shop.Dal;

public class ClientDao : IPrimary
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string Patronymic { get; set; } = string.Empty;
    public DateTime BirthDay { get; set; } = new DateTime(1900, 1, 1);

    public int Age
    {
        get
        {
            int age = DateTime.Today.Year - BirthDay.Year;
            if (BirthDay.Date > DateTime.Today.AddYears(-age))
                age--;
            return age;
        }
    }
}
