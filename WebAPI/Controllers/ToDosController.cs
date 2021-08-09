using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDosController : ControllerBase
    {
        private IToDoService _toDoService;

        public ToDosController(IToDoService toDoService)
        {
            this._toDoService = toDoService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = this._toDoService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getalldetails")]
        public IActionResult GetAllDetails()
        {
            var result = this._toDoService.GetAllToDoDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetAllIsEndedFalse")]
        public IActionResult GetAllIsEndedFalse()
        {
            var result = this._toDoService.GetAllIsEndedFalse();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetAllIsEndedTrue")]
        public IActionResult GetAllIsEndedTrue()
        {
            var result = this._toDoService.GetAllIsEndedTrue();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetAllIsAppointedFalse")]
        public IActionResult GetAllIsAppointedFalse()
        {
            var result = this._toDoService.GetAllIsAppointedFalse();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetAllIsAppointedTrue")]
        public IActionResult GetAllIsAppointedTrue()
        {
            var result = this._toDoService.GetAllIsAppointedTrue();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetAllByManagerId")]
        public IActionResult GetAllByManagerId(int id)
        {
            var result = this._toDoService.GetAllByManagerId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("GetAllByEmployeeId")]
        public IActionResult GetAllByEmployeeId(int id)
        {
            var result = this._toDoService.GetAllByEmployeeId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Todo todo)
        {
            var result = _toDoService.Add(todo);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _toDoService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


    }
}
