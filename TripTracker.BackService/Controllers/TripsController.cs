using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripTracker.BackService.Data;
using TripTracker.BackService.Models;

namespace TripTracker.BackService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        //private Repository _repository;

        TripContext _tripContext;
        public TripsController(TripContext  context)
        {
            _tripContext = context;
           // _tripContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        // GET api/trips

        //[HttpGet]
        //public ActionResult<IEnumerable<Trip>> Get()
        //{
        //    return _tripContext.Trips.ToList();
        //}

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var trips = await _tripContext.Trips
                .AsNoTracking()
                .Include(t=> t.Segments)
                .Select(t => new TripWithSegments
                {
                    Id = t.Id,
                    Name = t.Name,
                    StartDate = t.StartDate,
                    EndDate = t.EndDate,
                    Segments = t.Segments
                })
                .ToListAsync();
                
            return Ok(trips);
        }
        // GET api/trips/5
        [HttpGet("{id}")]
        public ActionResult<TripWithSegments> Get(int id)
        {
            return _tripContext.Trips
                .Select(t => new TripWithSegments
                {
                    Id = t.Id,
                    Name = t.Name,
                    StartDate = t.StartDate,
                    EndDate = t.EndDate,
                    Segments = t.Segments
                })
                .SingleOrDefault(t => t.Id == id);
        }

        // POST api/trips
        [HttpPost]
        public IActionResult Post([FromBody] Trip value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _tripContext.Trips.Add(value);
            _tripContext.SaveChanges();

            return Ok();
            //_repository.Add(value);
        }

        // PUT api/trips/5
        [HttpPut("{id}")]
        public async Task <IActionResult> PutAsync(int id, [FromBody] Trip value)
        {
            if (!_tripContext.Trips.Any(t => t.Id ==id))
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            _tripContext.Trips.Update(value);
            await _tripContext.SaveChangesAsync();

            return Ok();
        }

        // DELETE api/trips/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var myTrip = _tripContext.Trips.Find(id);

            if (myTrip == null)
            {
                return NotFound();
            }

            _tripContext.Trips.Remove(myTrip);
            _tripContext.SaveChanges();

            return NoContent();
        }
    }
}
