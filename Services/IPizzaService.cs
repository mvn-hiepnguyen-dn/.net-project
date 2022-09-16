using ContosoPizza.Models;
using ContosoPizza.Request;

namespace ContosoPizza.Services
{
    public interface IPizzaService
    {
        // Pizza? GetPizzaSingle(int id);
        Pizza? GetPizzaSingle(int id);
        List<Pizza> GetPizzas();
        bool AddPizza(PizzaRequest request);
        void UpdatePizza(Pizza pizza);
        void DeletePizza(int id);
    }
}