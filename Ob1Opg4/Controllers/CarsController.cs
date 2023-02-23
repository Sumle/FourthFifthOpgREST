using Microsoft.AspNetCore.Mvc;
using Ob1Opg4.Repositories;
using FirstObOpgUnit;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ob1Opg4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private CarsRepository _repo;

        public CarsController(CarsRepository repo)
        {
            _repo = repo;
        }

        // GET: api/<CarsController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public ActionResult<IEnumerable<Car>> Get()
        {
            List<Car> result = _repo.GetAll();
            if(result.Count <  1) 
            {
                return NotFound();
            }
            return Ok(result);
        }

        // GET api/<CarsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<Car?> Get(int id)
        {
            Car? carFound = _repo.GetById(id);
            if(carFound == null)
            {
                return NotFound();
            }
            return Ok(carFound);
        }

        // POST api/<CarsController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<Car> Post([FromBody] Car newCar)
        {
            try
            {
                Car carCreated = _repo.AddCar(newCar);
                return Created($"api/cars/{carCreated.Id}", newCar);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CarsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public ActionResult<Car> Put(int id, [FromBody] Car update)
        {
            try
            {
                Car? carUpdate = _repo.UpdateCar(id, update);
                if(carUpdate == null)
                {
                    return NotFound();
                }
                return Ok(carUpdate);
            }
            catch(ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            } 
        }

        // DELETE api/<CarsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<Car> Delete(int id)
        {
            Car? carDelete = _repo.DeleteCar(id);
            if (carDelete == null)
            {
                return NotFound();
            }
            return Ok(carDelete);
        }
    }
}