using Microsoft.AspNetCore.Mvc;
using ContosoPizza.Models;
using ContosoPizza.Services;
using ContosoPizza.Request;
using ContosoPizza.Response;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Produces("application/json")]
public class PizzaController : ControllerBase
{
    private readonly IPizzaService _pizzaService;  
  
    public PizzaController(IPizzaService pizzaService)  
    {  
        _pizzaService = pizzaService;  
    }  

    // GET all action
    [HttpGet]
    // [Route("[controller]")]
    public ActionResult<List<PizzaReponse>> GetAll()
    {
        List<PizzaReponse> responses = new List<PizzaReponse>();
        _pizzaService.GetPizzas().ForEach(pizza => responses.Add(new PizzaReponse(pizza)));

        string json = JsonConvert.SerializeObject(responses.OrderBy(o => o.Id).ToList(), new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            },
            Formatting = Formatting.Indented
        });

        // List<PizzaReponse>? responses1 = JsonSerializer.Deserialize<List<PizzaReponse>>(json);
        
        return Ok(responses);
    }

    // GET by Id action
    [HttpGet("{id}")]
    // [Route("[controller]")]
    public ActionResult<Pizza> GetById(int id)
    {
        var pizza = _pizzaService.GetPizzaSingle(id);

        if(pizza is null)
            return NotFound();

        return Ok(new PizzaReponse(pizza));
    }

    // POST action
    [HttpPost]
    public IActionResult Create([FromBody] PizzaRequest request)
    {            
        if (!_pizzaService.AddPizza(request))
            return BadRequest();

        return CreatedAtAction(nameof(Create), "Created successfully!");
    }

    // PUT action
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] PizzaRequest request)
    {
        if (id != request.Id)
            return BadRequest();
           
        var existingPizza = _pizzaService.GetPizzaSingle(id);
        if(existingPizza is null)
            return NotFound();

        existingPizza.toUpdate(request.Name, request.IsGlutenFree);
        
        _pizzaService.UpdatePizza(existingPizza);           
   
        return CreatedAtAction(nameof(Update), "Updated successfully!");
    }

    // DELETE action
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var pizza = _pizzaService.GetPizzaSingle(id);
   
        if (pizza is null)
            return NotFound();
       
        _pizzaService.DeletePizza(id);
   
        return NoContent();
    }
}