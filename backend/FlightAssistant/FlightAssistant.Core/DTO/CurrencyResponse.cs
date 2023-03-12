namespace FlightAssistant.Core.DTO
{
    public class CurrencyResponse
    {
        public int Id { get; set; }
        public string? AlphabeticCode { get; set; }
        public string? Name { get; set; }

        public CurrencyResponse(int id, string? alphabeticCode, string? name)
        {
            Id = id;
            AlphabeticCode = alphabeticCode;
            Name = name;
        }
    }
}
