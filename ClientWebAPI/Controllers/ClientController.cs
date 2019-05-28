using System;
using System.Collections.Generic;
using AutoMapper;
using ClientWebAPI.Model.Dto;
using Contracts;
using Entities.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientWebAPI.Controllers
{
    [Route("api/client")]
    [ApiController]
    [Authorize]
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

                var response = ResponseHelper.GetSuccessResponse(clientsDto, HttpContext.Request.Path.Value);

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

                var clientDto = _autoMapper.Map<ClientDto>(client);

                if(client.IsEmptyObject())
                {
                    _logger.LogError($"Client with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned client for id: {id}");

                    var response = ResponseHelper.GetSuccessResponse(clientDto, HttpContext.Request.Path.Value);

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