using System.Text.Json.Serialization;
namespace ContosoPizza.Request;

public class PizzaRequest
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("is_gluten_free")]
    public bool IsGlutenFree { get; set; }
}