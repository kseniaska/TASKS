using Core;

namespace Shop.Bll;

public class ClientBlo : IPrimary
{
    public int Id { get; }

    private string firstName = string.Empty;
    private string lastName = string.Empty;
    private string patronymic = string.Empty;

    public string FirstName
    {
        get => firstName;
        set => firstName = ValidateRequired(value, nameof(FirstName));
    }

    public string LastName
    {
        get => lastName;
        set => lastName = ValidateRequired(value, nameof(LastName));
    }

    public string Patronymic
    {
        get => patronymic;
        set => patronymic = value ?? string.Empty;
    }

    public DateTime Birthday { get; set; }

    public ClientBlo(int id, string firstName, string lastName, string patronymic = "", DateTime? birthday = null)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Patronymic = patronymic;
        Birthday = birthday ?? new DateTime(1900, 1, 1);
    }

    private static string ValidateRequired(string value, string propertyName)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException($"{propertyName} must contain at least one character.", propertyName);

        return value;
    }
}
