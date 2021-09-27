using BlazorCRUDApp2.Shared;
using BlazorCRUDApp2.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUDApp2.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController:ControllerBase
    {
        private readonly AppDbContext dbContext;

        public CarController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<Car>>> Get()
        {
            return await dbContext.Cars.ToListAsync();
        }

        [HttpGet("{id}",Name = "GetCar")]
        public async Task<ActionResult<Car>> Get(int id)
        {
            return await dbContext.Cars.SingleOrDefaultAsync(x => x.id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Car car)
        {
            dbContext.Add(car);
            await dbContext.SaveChangesAsync();
            return new CreatedAtRouteResult("GetCar", new { id = car.id }, car);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Car car)
        {
            dbContext.Entry(car).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var car = new Car { id = id };
            dbContext.Remove(car);
            await dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
