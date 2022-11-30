using AutoMapper;
using EmployeeAPI.DTOs;
using EmployeeAPI.Services.Contract;
using EmployeeAPI.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentServcie;
        private readonly IMapper _mapper;

        public DepartmentController(IDepartmentService departmentServcie, IMapper mapper)
        {
            this._departmentServcie = departmentServcie;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            ResponseApi<List<DepartmentDTO>> _response = new ResponseApi<List<DepartmentDTO>>();
            try
            {
                var departmantList = await _departmentServcie.GetList();

                if (departmantList.Count > 0)
                {
                    var dtoList = _mapper.Map<List<DepartmentDTO>>(departmantList);

                    _response = new ResponseApi<List<DepartmentDTO>>() { Status = true, Msg = "Ok", Value = dtoList };
                }
                else
                {
                    _response = new ResponseApi<List<DepartmentDTO>>() { Status = true, Msg = "No Data" };
                }

                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new ResponseApi<List<DepartmentDTO>>() { Status = false, Msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
    }
}
