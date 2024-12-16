
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
            Request c = new Request(request);
            context.Requests.Add(c);
            context.SaveChanges();
            return base.Ok(m.retrieveMeal(c.requestUser));
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