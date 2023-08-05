using DotNetBank.Api.Core.Validation;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBank.Api.Controllers
{
    public class EndpointService : ControllerBase
    {
        public async Task<IActionResult> ResponseWrapper(Func<Task> callback)
        {
            try
            {
                await callback();
                return Ok();
            }
            catch (BadRequestException ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(400, new { error = ex.Message });
            }
            catch (NotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(404, new { error = ex.Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new { error = "INTERNAL_ERROR" });
            }
        }


        public async Task<IActionResult> ResponseWrapper(Func<Task<dynamic>> callback)
        {
            try
            {
                return Ok(new { data = await callback() });
            }
            catch (BadRequestException ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(400, new { error = ex.Message });
            }
            catch (NotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(404, new { error = ex.Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new { error = "INTERNAL_ERROR" });
            }
        }
    }
}
