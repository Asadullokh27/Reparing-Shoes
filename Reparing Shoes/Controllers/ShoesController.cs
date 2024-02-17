using Microsoft.AspNetCore.Mvc;
using Reparing_Shoes.DTOModels;
using Reparing_Shoes.Models;
using Reparing_Shoes.Pattern;
using Reparing_Shoes.Servise;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Reparing_Shoes.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShoesController : ControllerBase
    {
        private readonly IShoesRepository _shoesRepository;
        private readonly IShoescs _shoescs;

        public ShoesController(IShoesRepository shoesRepository)
        {
            _shoesRepository = shoesRepository;
        }
        [HttpGet]
        public IActionResult GetAllShoes()
        {
            try
            {
                var response = _shoesRepository.GetAllShoes();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            try
            {
                var response = _shoescs.GetByID(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public IActionResult Post(ShoesDTO shoes)
        {
            try
            {
                var response = _shoesRepository.Post(shoes);
                return Ok(response);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        public IActionResult Put(ShoesDTO shoes,int id)
        {
            try
            {
                var response = _shoesRepository.UpdateShoes(shoes);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

       
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var response = _shoesRepository.DeleteShoes(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
