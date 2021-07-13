using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserImagesController : ControllerBase
    {

        IUserImageService _userImageService;

        public UserImagesController(IUserImageService userImageService)
        {
            _userImageService = userImageService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = "Image")] IFormFile file, [FromForm] UserImage userImage)
        {
            var result = _userImageService.Add(file, userImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update([FromForm(Name = "Image")] IFormFile file, [FromForm(Name = ("Id"))] int Id)
        {
            var userImages = _userImageService.GetById(Id).Data;
            var result = _userImageService.Update(file, userImages);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpDelete("delete")]
        public IActionResult Delete([FromForm(Name = "Id")] int Id)
        {
            var forDelete = _userImageService.GetById(Id).Data;
            var result = _userImageService.Delete(forDelete);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _userImageService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getbyuser")]
        public IActionResult GetByUser(int id)
        {
            var result = _userImageService.GetAll(I => I.UserId == id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("profileimageadd")]
        public IActionResult ProfileImageAdd([FromForm(Name = "Image")] IFormFile file, [FromForm] UserImage userImage)
        {
            var result = _userImageService.ProfileImageAdd(file, userImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("profileimagedelete")]
        public IActionResult ProfileImageDelete([FromForm(Name = "Id")] int Id)
        {
            var forDelete = _userImageService.GetById(Id).Data;
            var result = _userImageService.ProfileImageDelete(forDelete);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



    }
}