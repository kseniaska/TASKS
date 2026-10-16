using Core;

namespace Shop.Bll;

public class ShopBlo : IPrimary
{
    public int Id { get; }

    private string name = string.Empty;
    private string code = string.Empty;

    public string Name
    {
        get => name;
        set => name = ValidateRequired(value, nameof(Name));
    }

    public string Code
    {
        get => code;
        set => code = ValidateRequired(value, nameof(Code));
    }

    public ShopBlo(int id, string name, string code)
    {
        Id = id;
        Name = name;
        Code = code;
    }

    private static string ValidateRequired(string value, string propertyName)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException($"{propertyName} must contain at least one character.", propertyName);

        return value;
    }
}
