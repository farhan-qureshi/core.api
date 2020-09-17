using System;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using core.api.commerce.Data.Interfaces;
using core.api.commerce.Models;

namespace core.api.commerce.Controllers
{
    [ApiController]
    [Route("api/v1")]
    [Produces(MediaTypeNames.Application.Json)]
    public class CommerceController : ControllerBase
    {
        private readonly ILogger<CommerceController> _logger;
        private readonly ICommerceRepository _evalRepository;

        public CommerceController(ILogger<CommerceController> logger, ICommerceRepository evalRepository)
        {
            _logger = logger;
            _evalRepository = evalRepository;
        }

        [HttpGet]
        [Route("products")]
        public async Task<ActionResult> GetAllProducts()
        {
            _logger.LogInformation("Calling GetAllProducts on the repository");
            var error = new ErrorResponse { RequestId = HttpContext?.TraceIdentifier ?? Guid.NewGuid().ToString() };

            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _evalRepository.GetAllProductsAsync();
                    if(result != null)
                    {
                        return new JsonResult(result);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
            catch (Exception e)
            {
                error.Errors.Add(ErrorModel.FromApiErrorCode(ApiErrorCode.FailToGetData));
                _logger.LogError($"Fail to retrieve prescribing information {e.Message}", e);
                return StatusCode((int)HttpStatusCode.InternalServerError, error);
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("subproducts")]
        public async Task<ActionResult> GetAllSubProducts()
        {
            _logger.LogInformation("Calling GetAllSubProducts on the repository");
            var error = new ErrorResponse { RequestId = HttpContext?.TraceIdentifier ?? Guid.NewGuid().ToString() };

            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _evalRepository.GetAllSubProductsAsync();
                    if (result != null)
                    {
                        return new JsonResult(result);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
            catch (Exception e)
            {
                error.Errors.Add(ErrorModel.FromApiErrorCode(ApiErrorCode.FailToGetData));
                _logger.LogError($"Fail to retrieve prescribing information {e.Message}", e);
                return StatusCode((int)HttpStatusCode.InternalServerError, error);
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("product/{id:int}")]
        public async Task<ActionResult> GetProductByIdAsync([FromRoute]int id)
        {
            _logger.LogInformation("Calling GetProductById on the repository");
            var error = new ErrorResponse { RequestId = HttpContext?.TraceIdentifier ?? Guid.NewGuid().ToString() };

            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _evalRepository.GetProductByIdAsync(id);

                    if (result != null)
                    {
                        return new JsonResult(result);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
            catch (Exception e)
            {
                error.Errors.Add(ErrorModel.FromApiErrorCode(ApiErrorCode.FailToGetData));
                _logger.LogError($"Fail to retrieve prescribing information {e.Message}", e);
                return StatusCode((int)HttpStatusCode.InternalServerError, error);
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("subproduct/{id:int}")]
        public async Task<ActionResult> GetSubProductById([FromRoute]int id)
        {
            _logger.LogInformation("Calling GetSubProductById on the repository");
            var error = new ErrorResponse { RequestId = HttpContext?.TraceIdentifier ?? Guid.NewGuid().ToString() };

            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _evalRepository.GetSubProductByIdAsync(id);

                    if (result != null)
                    {
                        return new JsonResult(result);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
            catch (Exception e)
            {
                error.Errors.Add(ErrorModel.FromApiErrorCode(ApiErrorCode.FailToGetData));
                _logger.LogError($"Fail to retrieve sub product {e.Message}", e);
                return StatusCode((int)HttpStatusCode.InternalServerError, error);
            }

            return BadRequest();
        }

        [HttpPost]
        [Route("CreateProduct")]
        public async Task<ActionResult<SuccessResponse>> CreateProduct([FromBody]Product Product)
        {
            _logger.LogInformation("Calling CreateProduct on the repository");

            var error = new ErrorResponse { RequestId = HttpContext?.TraceIdentifier ?? Guid.NewGuid().ToString() };

            try
            {
                if (ModelState.IsValid)
                {
                    await _evalRepository.CreateProductAsync(Product);
                    return Ok();
                }
            }
            catch (Exception e)
            {
                error.Errors.Add(ErrorModel.FromApiErrorCode(ApiErrorCode.FailToGetData));
                _logger.LogError($"Fail to retrieve prescribing information {e.Message}", e);
                return StatusCode((int)HttpStatusCode.InternalServerError, error);
            }

            return BadRequest();
        }

        [HttpPost]
        [Route("CreateSubProduct")]
        public async Task<ActionResult<SuccessResponse>> CreateSubProduct([FromBody]SubProduct Product)
        {
            _logger.LogInformation("Calling CreateProduct on the repository");

            var error = new ErrorResponse { RequestId = HttpContext?.TraceIdentifier ?? Guid.NewGuid().ToString() };

            try
            {
                if (ModelState.IsValid)
                {
                    await _evalRepository.CreateSubProductAsync(Product);
                    return Ok();
                }
            }
            catch (Exception e)
            {
                error.Errors.Add(ErrorModel.FromApiErrorCode(ApiErrorCode.FailToGetData));
                _logger.LogError($"Fail to retrieve prescribing information {e.Message}", e);
                return StatusCode((int)HttpStatusCode.InternalServerError, error);
            }

            return BadRequest();
        }

        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<ActionResult<SuccessResponse>> UpdateProduct([FromBody]Product product)
        {
            _logger.LogInformation("Calling UpdateProduct on the repository");
            var error = new ErrorResponse { RequestId = HttpContext?.TraceIdentifier ?? Guid.NewGuid().ToString() };

            try
            {
                if (ModelState.IsValid)
                {
                    _evalRepository.UpdateProductAsync(product);
                    return Ok();
                }
            }
            catch(Exception e)
            {
                error.Errors.Add(ErrorModel.FromApiErrorCode(ApiErrorCode.UnknownReason));
                _logger.LogError($"Fail to update record {e.Message}", e);
                return StatusCode((int)HttpStatusCode.InternalServerError, error);
            }

            return BadRequest();
        }

        [HttpPut]
        [Route("UpdateSubProduct")]
        public async Task<ActionResult<SuccessResponse>> UpdateSubProduct([FromBody]SubProduct product)
        {
            _logger.LogInformation("Calling UpdateSubProduct on the repository");
            var error = new ErrorResponse { RequestId = HttpContext?.TraceIdentifier ?? Guid.NewGuid().ToString() };

            try
            {
                if (ModelState.IsValid)
                {
                    _evalRepository.UpdateSubProductAsync(product);
                    return Ok();
                }
            }
            catch (Exception e)
            {
                error.Errors.Add(ErrorModel.FromApiErrorCode(ApiErrorCode.UnknownReason));
                _logger.LogError($"Fail to update record {e.Message}", e);
                return StatusCode((int)HttpStatusCode.InternalServerError, error);
            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("DeleteProduct/{id:int}")]
        public async Task<ActionResult<SuccessResponse>> DeleteProduct([FromRoute]int id)
        {
            _logger.LogInformation("Calling DeleteProduct on the repository");
            var error = new ErrorResponse { RequestId = HttpContext?.TraceIdentifier ?? Guid.NewGuid().ToString() };

            try
            {
                if (ModelState.IsValid)
                {
                    _evalRepository.DeleteProductAsync(id);
                    return Ok();
                }
            }
            catch (Exception e)
            {
                error.Errors.Add(ErrorModel.FromApiErrorCode(ApiErrorCode.UnknownReason));
                _logger.LogError($"Fail to delete record {e.Message}", e);
                return StatusCode((int)HttpStatusCode.InternalServerError, error);
            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("DeleteSubProduct/{id:int}")]
        public async Task<ActionResult<SuccessResponse>> DeleteSubProduct([FromRoute]int id)
        {
            _logger.LogInformation("Calling DeleteSubProduct on the repository");
            var error = new ErrorResponse { RequestId = HttpContext?.TraceIdentifier ?? Guid.NewGuid().ToString() };

            try
            {
                if (ModelState.IsValid)
                {
                    _evalRepository.DeleteSubProductAsync(id);
                    return Ok();
                }
            }
            catch (Exception e)
            {
                error.Errors.Add(ErrorModel.FromApiErrorCode(ApiErrorCode.UnknownReason));
                _logger.LogError($"Fail to delete record {e.Message}", e);
                return StatusCode((int)HttpStatusCode.InternalServerError, error);
            }

            return BadRequest();
        }
    }
}
