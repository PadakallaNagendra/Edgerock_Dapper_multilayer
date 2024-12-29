using EdgeRock_Dapper_BusinessLogic.Interface;
using EdgeRock_Dapper_BusinessLogic.ModelDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Edgerock_Dapper_multilayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public IEmployeeServices _services;
        public EmployeeController(IEmployeeServices services)
        {
            _services = services;
            
        }

        [HttpPost]
        [Route("AddEmployee")]
        public async Task<IActionResult> Post([FromBody] EmployeeDTO employeeDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {
                    await _services.Addemployee(employeeDTO);
                    return StatusCode(StatusCodes.Status200OK, "inserted successfully");
                }
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "internal server error");
            }
        }
        [HttpGet]
        [Route("GetAllEmployee")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var a = await _services.GetAllemployee();
                if (a == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest,"bad request");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, a);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "internal server");
            }
        }
        [HttpGet]
        [Route("GetEmployeeById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "error");

            }
            try
            {
               var a= await _services.GetemployeeById(id);
                if(a== null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "page not found");
                }
                else
                {

                    return StatusCode(StatusCodes.Status200OK, a);
                }
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server error");
            }
        }
        [HttpPut]
        [Route("UpdateEmployee")]
        public async Task<IActionResult> Put(EmployeeDTO dTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "server error");

                }
                else
                {
                    await _services.Updateemployee(dTO);
                    return StatusCode(StatusCodes.Status201Created, "Updated sucessfully");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

    }
}
