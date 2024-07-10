namespace Alerium.Domain.Abstract
{
    public record Error(string Code, string Name)
    {
        public static Error None => new(string.Empty, string.Empty);
        public static Error Nullvalue => new("Error.NullValue", "Un valor Null fue ingresado");
    }
}
