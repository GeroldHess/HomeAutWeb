using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HomeAutWeb.Models;
using System.Data;
using System.Security.AccessControl;
using MySql.Data;
using HomeAutWeb.Models;
using MySql.Data.MySqlClient;

namespace HomeAutWeb.Controllers;

public class HomeController : Controller
{
    public string connectin = "server=192.168.178.43;uid=gerold;pwd=nirak2403;database=homeaut";
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<TempValue> werte = new List<TempValue>();
        MySql.Data.MySqlClient.MySqlConnection con = new MySqlConnection(connectin);
        con.Open();
        MySqlCommand command;
        command = new MySqlCommand("select * from homeaut.vw_TempTop");
        command.Connection = con;
        MySqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                TempValue tv = new TempValue(reader);
                werte.Add(tv);
            }
        }

        ViewBag.Werte = werte;
        return View();
    }

    public IActionResult DelItems()
    {
        MySql.Data.MySqlClient.MySqlConnection con = new MySqlConnection(connectin);
        con.Open();
        MySqlCommand command;
        
        command = new MySqlCommand("homeaut.prc_TempValue_OldItems");
        command.CommandType = CommandType.StoredProcedure;
        command.Connection = con;
        command.ExecuteNonQuery();
        return Content("ok");
    }
    
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}