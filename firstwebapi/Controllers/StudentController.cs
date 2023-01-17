using Microsoft.AspNetCore.Mvc;
using poco;
namespace firstwebapi.Controllers;
using Microsoft.AspNetCore.Cors;
using DAL;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    

    private readonly ILogger<StudentController> _logger;

    public StudentController(ILogger<StudentController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetStudent")]
    [EnableCors()]
 
    public IEnumerable<uu> Get()
    {
        List<uu> allStudent=new List<uu>();
        allStudent=dal.GetAllStudents();

    return allStudent;
    
    }
}