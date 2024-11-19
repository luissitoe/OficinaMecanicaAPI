using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OficinaMecanicaAPI.Data;
using OficinaMecanicaAPI.Models;
using OficinaMecanicaAPI.Models.DTO;

namespace OficinaMecanicaAPI.Controllers
{
    // localhost:7246/api/Clientes
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ApplicationDBContext dbContext;

        public ClientesController(ApplicationDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
         
        // Retorna todos os clientes registados na base de dados
        [HttpGet]
        public IActionResult GetAllClients()
        {
            var clientes = dbContext.Clientes.ToList();

            return Ok(clientes);
        }

     
        // Retorna um cliente pelo seu Id
        [HttpGet]
        //https://localhost:7246/api/Clientes/{id}
        [Route("{id:guid}")]
        public IActionResult GetClienteById(Guid id)
        {
            var cliente = dbContext.Clientes.Find(id);

            if (cliente is null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        // Adiciona um novo cliente à base de dados
        [HttpPost]
        public IActionResult AddCliente(ClienteDto clienteDto)
        {
            var cliente = new Cliente()
            {
                Nome = clienteDto.Nome,
                Apelido = clienteDto.Apelido,
                Email = clienteDto.Email,
                Telefone = clienteDto.Telefone
            };

            dbContext.Clientes.Add(cliente); 
            dbContext.SaveChanges();

            return Ok(cliente);

        }

        // Actualizar os dados de um determinado cliente 
        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateCliente(Guid id, UpdateClienteDto updateClienteDto)
        {
            var cliente = dbContext.Clientes.Find(id);

            if (cliente is null)
            {
                return NotFound();
            }

            cliente.Nome = updateClienteDto.Nome;
            cliente.Apelido = updateClienteDto.Apelido;
            cliente.Email = updateClienteDto.Email;
            cliente.Telefone = updateClienteDto.Telefone;

            dbContext.SaveChanges();
            return Ok(cliente);
        }

        // Eliminar um determinado cliente pelo seu id
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteCliente(Guid id) {
            var cliente = dbContext.Clientes.Find(id);

            if (cliente is null)
            {
                return NotFound();
            }

            dbContext.Clientes.Remove(cliente);
            dbContext.SaveChanges(); 

            return Ok(cliente); 
        }


    }
}
