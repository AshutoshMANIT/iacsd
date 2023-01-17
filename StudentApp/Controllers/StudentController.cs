using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StudentApp.Models;
using DAL;
namespace StudentApp.Controllers;


public class StudentController : Controller
{
    private readonly ILogger<StudentController> _logger;

    public StudentController(ILogger<StudentController> logger)
    {
        _logger = logger;
    }

    // public IActionResult StudentData()
    // {
    //     List<Student> student=DBManager.GetStudents();
    //     //return View();
    //     return student;
    // }

    [HttpGet]
    // public List<Student> StudentData()
    // {
    //     List<Student> students=DBManager.GetAllStudents();
    //     //return View();
    //     return students;
    

    // }

    // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    // public IActionResult Error()
    // {
    //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    // }


public void InsertStudent(Student student){
DBManager.Insert(student);

}

public Student StudentDataById(int id)
    {
        Student students=DBManager.GetStudent(id);
        //return View();
        return students;
    }

    public IActionResult Index()
    {
        List<Student> students=DBManager.GetAllStudents();
        ViewData["students"] = students;
        return View();
    }


// public void InsertStudent(int id,string name,string branch){

// DBManager.Update(id,name,branch);
// }






}