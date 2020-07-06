using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APICore.Data;
using APICore.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly DataContext _dbContext;
        public FuncionarioController(DataContext dbContext)
        {
            this._dbContext = dbContext;
        }

        // GET: api/<FuncionarioController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = _dbContext.Funcionarios.Where(_ => _.Enable == true).ToList();
                return Ok(result);
            }
            catch (Exception errGetAll)
            {
                return BadRequest($"Error: {errGetAll.Message}");
            }
            
        }

        // GET api/<FuncionarioController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                if (id < 1)
                    return NotFound();
                else
                {
                    var result = _dbContext.Funcionarios.Where(_ => _.Id == id);
                    return Ok(result);
                }
            }
            catch (Exception errGet)
            {
                return BadRequest($"Error: {errGet.Message}");
            }
        }

        // POST api/<FuncionarioController>
        [HttpPost]
        public IActionResult Post([FromBody] FuncionarioModel funcionarioModel)
        {
            try
            {
                FuncionarioModel f = new FuncionarioModel();

                f.Id = funcionarioModel.Id;
                f.Name = funcionarioModel.Name;
                f.Email = funcionarioModel.Email;
                f.Position = funcionarioModel.Position;
                f.Salary = funcionarioModel.Salary;
                f.CreatedOn = f.ModifiedOn = DateTime.Now;
                f.Enable = true;

                _dbContext.Funcionarios.Add(f);
                _dbContext.SaveChanges();
                return Ok();
            }
            catch (Exception errPost)
            {
                return BadRequest($"Error: {errPost.Message}");
            }   
        }

        // PUT api/<FuncionarioController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] FuncionarioModel funcionarioModel)
        {
            try
            {
                if (id > 0)
                {
                    FuncionarioModel f = _dbContext.Funcionarios.First(_ => _.Id == id);

                    f.Name = funcionarioModel.Name;
                    f.Email = funcionarioModel.Email;
                    f.Position = funcionarioModel.Position;
                    f.Salary = funcionarioModel.Salary;
                    f.ModifiedOn = DateTime.Now;

                    _dbContext.SaveChanges();
                    return Ok();
                }
                else
                {
                    Response.StatusCode = 406;
                    return new ObjectResult($"Error : Id não pode ser igual ou menor que zero");
                }
                
            }
            catch (Exception errPut)
            {
                return BadRequest($"Error: {errPut.Message}");
            }
        }

        // DELETE api/<FuncionarioController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    FuncionarioModel f = _dbContext.Funcionarios.First(_ => _.Id == id);

                    f.Enable = false;
                    f.DeletedOn = DateTime.Now;

                    _dbContext.SaveChanges();
                    return Ok();
                }
                else
                {
                    Response.StatusCode = 406;
                    return new ObjectResult($"Error : Id não pode ser igual ou menor que zero");
                }
            }
            catch (Exception errDel)
            {
                return BadRequest($"Error: {errDel.Message}");
            }
        }

    }
}
