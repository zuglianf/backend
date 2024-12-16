
using System.Text.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

[Route("api/[controller]")]
[ApiController]

public class MealController : ControllerBase
{
    static AddDbContext context = new AddDbContext();
    static MealServices m = new MealServices();

    static Meal meal = new Meal();

    [HttpGet("{request}")]
    public ActionResult<Meal> Get(string request)
    {
        var re = context.Requests.FirstOrDefault(t => t.requestUser == request);
        if (re == null)
        {
            //Richiesta se la richiesta assente allora inserisce nel db
            //Se non presente nell'api non lo scrive nelle richieste
            Request c = new Request(request);
            Meal temp = m.retrieveMeal(c.requestUser);

            if(!(temp.meals == null)){
                context.Requests.Add(c);
                context.SaveChanges();
                // invia la richiesta api 
                // NON ricerco nel database la richiesta
                return base.Ok(temp);}
            else
            {
                return BadRequest("Richiesta non presente");
            }
        }
        else
        {
            if (m.retrieveMeal(re.requestUser) != null)
            {
                return base.Ok(m.retrieveMeal(re.requestUser));
            }
            else
            {
                return NotFound("AHIA");
            }

        }
    }


}