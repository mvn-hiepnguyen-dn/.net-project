namespace ContosoPizza.Models;

public class Pizza
{
    public Pizza(string Name, bool IsGlutenFree)
    {
        this.Name = Name;
        this.IsGlutenFree = IsGlutenFree;
    }

    public void toUpdate(string Name, bool IsGlutenFree) {
        this.Name = Name;
        this.IsGlutenFree = IsGlutenFree;
    }

    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsGlutenFree { get; set; }
}