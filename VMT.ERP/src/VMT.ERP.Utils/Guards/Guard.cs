namespace VMT.ERP.Utils.Guards
{
    public static class Guard
    {
        public static T NotNull<T>(T? value, string? message)
        {
            var result = message ?? $"{typeof(T).Name} no puede ser nulo";

            return value ?? throw new InvalidOperationException(result);
        }

        public static string NotNullOrEmpty(string? value, string? message)
        {
            var result = message ?? "El valor de la cadena no puede ser nula o vacia";

            return string.IsNullOrWhiteSpace(value)
                ? throw new InvalidOperationException(result)
                : value;
        }
    }
}