using System;
using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientWebAPI.Controllers
{
    [Route("api/client")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;

        public ClientController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllClients()
        {
            try
            {
                var clients = _repository.Client.GetAllClients();

                _logger.LogInfo("${Returned all clients from database}");

                var response = ResponseHelper.GetSuccessResponse(clients, HttpContext.Request.Path.Value);

                return Ok(response);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllClients action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetClientById(Guid id)
        {
            try
            {
                var client = _repository.Client.GetClientById(id);

                if(client.Id.Equals(Guid.Empty))
                {
                    _logger.LogError($"Client with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned client for id: {id}");

                    var response = ResponseHelper.GetSuccessResponse(client, HttpContext.Request.Path.Value);

                    return Ok(response);
                }
            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetClientById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}