using AutoMapper;
using EmployeeAPI.DTOs;
using EmployeeAPI.Services.Contract;
using EmployeeAPI.Services.Implementation;
using EmployeeAPI.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeServcie;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeServcie, IMapper mapper)
        {
            this._employeeServcie = employeeServcie;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            ResponseApi<List<EmployeeDTO>> _response = new ResponseApi<List<EmployeeDTO>>();
            try
            {
                var departmantList = await _employeeServcie.GetList();

                if (departmantList.Count > 0)
                {
                    var dtoList = _mapper.Map<List<EmployeeDTO>>(departmantList);

                    _response = new ResponseApi<List<EmployeeDTO>>() { Status = true, Msg = "Ok", Value = dtoList };
                }
                else
                {
                    _response = new ResponseApi<List<EmployeeDTO>>() { Status = true, Msg = "No Data" };
                }

                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new ResponseApi<List<EmployeeDTO>>() { Status = false, Msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }


        }
    }
}
