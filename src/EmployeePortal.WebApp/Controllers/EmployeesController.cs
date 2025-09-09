using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace EmployeePortal.WebApp.Controllers
{
    public sealed class EmployeesController(IHttpClientFactory http) : Controller
    {
        public async Task<IActionResult> Index(string? q, int page = 1)
        {
            var client = http.CreateClient("Api");
            var data = await client.GetFromJsonAsync<object>($"api/v1/employees?q ={ q} &page ={ page}");
            return View(data);
        }
    }
}
