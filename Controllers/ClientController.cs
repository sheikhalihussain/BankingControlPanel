using BCP.Data.Models;
using BCP.Manager.Client;
using BCP.Model.Client;
using Microsoft.AspNetCore.Mvc;

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
        #region Client CRUD
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients([FromQuery] ClientQueryParameters parameters)
        {
            var result = await _clientManager.GetClients(parameters); //calling service            
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClientById(string id)
        {
            var result = await _clientManager.GetClientById(id);
            return Ok(result);            
        }

        [HttpPost]
        public async Task<ActionResult<Client>> CreateClient(Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _clientManager.CreateClient(client);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(string id, Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != client.Id)
            {
                return BadRequest();
            }
            var result = await _clientManager.UpdateClient(id,client);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(string id)
        {
            var result = await _clientManager.DeleteClient(id);
            return Ok(result);
        }
        #endregion
    }
}
