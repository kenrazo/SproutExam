using Microsoft.AspNetCore.Mvc;
using SproutExam.Common.Enums;
using SproutExam.Service.Dtos;
using SproutExam.Service.LogicCollections;
using System;
using System.Threading.Tasks;

namespace SproutExam.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [Route("employee")]
        public async Task<IActionResult> Get()
        {
            return View(await _employeeService.Get());
        }

        [HttpGet]
        [Route("getbyid")]
        public async Task<IActionResult> GetById([FromQuery] Guid id)
        {
            return View(await _employeeService.GetById(id));
        }

        [HttpGet]
        [Route("create")]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(EmployeeInputDto employee)
        {
            await _employeeService.Add(employee);
            return RedirectToAction("Get");
        }

        [HttpGet]
        [Route("computesalary")]
        public async Task<IActionResult> ComputeSalary([FromQuery] EmployeeType employeeType)
        {
            ViewBag.EmployeeType = (int) employeeType;
            return View();
        }

        [HttpPost]
        [Route("computesalary")]
        public async Task<IActionResult> ComputeSalary([FromBody]ComputeSalaryInputDto input)
        {
            return Ok(await _employeeService.ComputeSalary(input.InputToCompute, input.EmployeeType));
        }
    }


}
