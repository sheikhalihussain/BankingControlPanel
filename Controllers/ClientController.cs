using BCP.Data.Models;
using BCP.Manager.Client;
using BCP.Model.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankingControlPanel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        public readonly IClientManager _clientManager;
        public ClientController(IClientManager clientManager)
        {
            _clientManager = clientManager;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients([FromQuery] ClientQueryParameters parameters)
        {
            var result = await _clientManager.GetClients(parameters);            
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClientById(string id)
        {
            var result = await _clientManager.GetClientById(id);
            return Ok(result);            
        }

    }
}
