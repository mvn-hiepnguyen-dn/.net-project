using ContosoPizza.Models;
using ContosoPizza.Data;
using ContosoPizza.Request;
using System.Linq;

namespace ContosoPizza.Services;

public class PizzaService : IPizzaService
{
    private readonly ContosoPizza.Data.ApplicationDbContext _context;

    public PizzaService(ApplicationDbContext context)
    {
        _context = context;
    }

    // public Pizza? GetPizzaSingle(int id) => _context.Pizzas.FirstOrDefault(t => t.Id == id);
    public Pizza? GetPizzaSingle(int id) => _context.Pizzas.Where(t => t.Id == id).FirstOrDefault();

    public List<Pizza> GetPizzas() => _context.Pizzas.ToList();

    public bool AddPizza(PizzaRequest request)
    {
        _context.Pizzas.Add(new Pizza(request.Name, request.IsGlutenFree));
        int result = _context.SaveChanges();
        return result == 1 ? true : false;
    }

    public void UpdatePizza(Pizza pizza)
    {
        _context.Pizzas.Update(pizza);
        _context.SaveChanges();
    }

    public void DeletePizza(int id)
    {
        var entity = _context.Pizzas.FirstOrDefault(t => t.Id == id);
        if (entity != null)
        {
            _context.Pizzas.Remove(entity);
            _context.SaveChanges();
        }
    }
   
    // static List<Pizza> Pizzas { get; }

    // public PizzaService(ContosoPizza.Data.PizzaContext context)
    // {
    //         _context = context;
    // }
    // static int nextId = 3;
    // static PizzaService()
    // {
    //     Pizzas = new List<Pizza>
    //     {
    //         new Pizza { Id = 1, Name = "Classic Italian", IsGlutenFree = false },
    //         new Pizza { Id = 2, Name = "Veggie", IsGlutenFree = true }
    //     };
    // }

    // public List<Pizza> GetAll()
    // {
    //     List<Pizza> pizzas = new List<Pizza>(new PizzaContext());

    //     pizzas = _context.Pizzas.ToList<Pizza>();

    //     return pizzas;
    // }

    // public Pizza? Get(int id) => _context.Pizzas.FirstOrDefault(p => p.Id == id);

    // public void Add(Pizza pizza)
    // {
    //     pizza.Id = nextId++;
    //     _context.Pizzas.
    //     Pizzas.Add(pizza);
    // }

    // public static void Delete(int id)
    // {
    //     var pizza = Get(id);
    //     if(pizza is null)
    //         return;

    //     Pizzas.Remove(pizza);
    // }

    // public static void Update(Pizza pizza)
    // {
    //     var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
    //     if(index == -1)
    //         return;

    //     Pizzas[index] = pizza;
    // }
}