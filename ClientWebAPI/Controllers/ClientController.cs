using System;
using System.Collections.Generic;
using AutoMapper;
using ClientWebAPI.Attributes;
using ClientWebAPI.Model.Dto;
using ClientWebAPI.Models.Dto;
using Contracts;
using Entities.Extensions;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientWebAPI.Controllers
{
    [Route("api/client")]
    [ApiController]
    //[Authorize]
    public class ClientController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _autoMapper;

        public ClientController(ILoggerManager logger, IRepositoryWrapper repository, IMapper autoMapper)
        {
            _logger = logger;
            _repository = repository;
            _autoMapper = autoMapper;
        }

        [HttpGet]
        public IActionResult GetAllClients()
        {
            try
            {
                var clients = _repository.Client.GetAllClients();

                var clientsDto = _autoMapper.Map<IEnumerable<ClientDto>>(clients);

                _logger.LogInfo("${Returned all clients from database}");

                var response = ResponseHelper.GetSuccessResponse(clientsDto, HttpContext.Request.Path.Value, "Data fetched successfully");

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllClients action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetClientById(Guid id)
        {
            try
            {
                var client = _repository.Client.GetClientById(id);

                var clientDto = _autoMapper.Map<ClientDto>(client);

                if (client.IsEmptyObject())
                {
                    _logger.LogError($"Client with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned client for id: {id}");

                    var response = ResponseHelper.GetSuccessResponse(clientDto, HttpContext.Request.Path.Value, "Data fetched successfully");

                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetClientById action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult CreateClient([FromBody] ClientDtoForCreation clientDto)
        {
            try
            {
                var client = _autoMapper.Map<Client>(clientDto);

                _repository.Client.CreateClient(client);
                _repository.Save();

                var response = ResponseHelper.GetSuccessResponse(clientDto, HttpContext.Request.Path.Value,
                               $"Client with id {client.Id} created successfully");

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateClient action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult UpdateClient(Guid id, [FromBody]ClientDtoForUpdate clientDto)
        {
            try
            {
                var dbClient = _repository.Client.GetClientById(id);
                if(dbClient.IsEmptyObject())
                {
                    _logger.LogError($"Client with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                var client = _autoMapper.Map<Client>(clientDto);
                client.Id = id;

                _repository.Client.UpdateClient(client);
                _repository.Save();

                var response = ResponseHelper.GetSuccessResponse(clientDto, HttpContext.Request.Path.Value,
                               $"Client with id {client.Id} updated successfully");

                return Ok(response);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateClient action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClient(Guid id)
        {
            try
            {
                var client = _repository.Client.GetClientById(id);
                if(client.IsEmptyObject())
                {
                    _logger.LogError($"Client with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.Client.DeleteClient(client);
                _repository.Save();

                var response = ResponseHelper.GetSuccessResponse($"Client with {client.Id} deleted successfully", 
                               HttpContext.Request.Path.Value, "Data deleted successfully");

                return Ok(response);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteClient action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}