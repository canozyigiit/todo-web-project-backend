using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagementsController : ControllerBase
    {

        private IManagementService _managementService;

        public ManagementsController(IManagementService managementService)
        {
            _managementService = managementService;
        }

        [HttpOptions("todoappointe")]
        public IActionResult ToDoAppointe(int toDoId, int employeeId)
        {
            var result = _managementService.ToDoAppointe(toDoId, employeeId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("makeuseremployee")]
        public IActionResult MakeUserEmployee(string mail, string position)
        {
            var result = _managementService.MakeUserEmployee(mail, position);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("makeusermanager")]
        public IActionResult MakeUserManager(string mail)
        {
            var result = _managementService.MakeUserManager(mail);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("makeuserdirector")]
        public IActionResult MakeUserDirector(string mail)
        {
            var result = _managementService.MakeUserDirector(mail);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
