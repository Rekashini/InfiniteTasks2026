using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;
using CodeChallenge11_Ques2.Models;

public class OrdersMvcController : Controller
{
    public async Task<ActionResult> Index()
    {
        List<OrderViewModel> orders = new List<OrderViewModel>();

        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new System.Uri("https://localhost:44337/");

            var response = await client.GetAsync("api/orders/buchanan");

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                orders = JsonConvert.DeserializeObject<List<OrderViewModel>>(data);
            }
        }

        return View(orders);
    }
}