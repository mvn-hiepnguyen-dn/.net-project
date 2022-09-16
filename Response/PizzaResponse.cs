using System.Text.Json.Serialization;
using ContosoPizza.Models;

namespace ContosoPizza.Response;

public class PizzaReponse
{
    public PizzaReponse(Pizza pizza)
    {
        this.Id = pizza.Id;
        this.Name = pizza.Name;
        this.IsGlutenFree = pizza.IsGlutenFree;
    }

    // [JsonPropertyName("id")]
    public int Id { get; set; }
    // [JsonPropertyName("name")]
    public string? Name { get; set; }
    // [JsonPropertyName("is_gluten_free")]
    public bool IsGlutenFree { get; set; }
}