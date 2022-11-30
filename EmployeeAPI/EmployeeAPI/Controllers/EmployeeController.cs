using AutoMapper;
using EmployeeAPI.DTOs;
using EmployeeAPI.Models;
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
                var employeeList = await _employeeServcie.GetList();

                if (employeeList.Count > 0)
                {
                    var dtoList = _mapper.Map<List<EmployeeDTO>>(employeeList);

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

        [HttpPost]
        public async Task<IActionResult> Post(EmployeeDTO request)
        {
            ResponseApi<EmployeeDTO> _response = new ResponseApi<EmployeeDTO>();
            try
            {
                Employee _model = _mapper.Map<Employee>(request);

                Employee _employeeCreated = await this._employeeServcie.Add(_model);

                if (_employeeCreated.Id != 0)
                {
                    _response = new ResponseApi<EmployeeDTO>() { Status = true, Msg = "Ok", Value = _mapper.Map<EmployeeDTO>(_employeeCreated) };
                }
                else
                {
                    _response = new ResponseApi<EmployeeDTO>() { Status = false, Msg = "Can not create" };
                }
                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new ResponseApi<EmployeeDTO>() { Status = false, Msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(EmployeeDTO request)
        {
            ResponseApi<EmployeeDTO> _response = new ResponseApi<EmployeeDTO>();
            try
            {
                Employee _model = _mapper.Map<Employee>(request);

                Employee _employeeEdited = await this._employeeServcie.Update(_model);
                _response = new ResponseApi<EmployeeDTO>() { Status = true, Msg = "Ok", Value = _mapper.Map<EmployeeDTO>(_employeeEdited) };

                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new ResponseApi<EmployeeDTO>() { Status = false, Msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ResponseApi<bool> _response = new ResponseApi<bool>();
            try
            {
                Employee _employeeFound = await this._employeeServcie.Get(id);
                bool deleted = await this._employeeServcie.Delete(_employeeFound);

                if(deleted)
                {
                    _response = new ResponseApi<bool>() { Status = true, Msg = "Ok" };
                }
                else
                {
                    _response = new ResponseApi<bool>() { Status = false, Msg = "No deleted"};
                }

                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new ResponseApi<bool>() { Status = false, Msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
    }
}
