using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using UserManagementMVCSample.Core.DataAccess;
using UserManagementMVCSample.Core.Models;
using UserManagementMVCSample.Extensions;
using PersonDto = UserManagementMVCSample.Core.Models.PersonModel;
using PersonViewModel = UserManagementMVCSample.Models.PersonModel;

namespace UserManagementMVCSample.Controllers
{
    public class GridController : Controller
    {
		readonly IDataAccess _dataAccess;
		public GridController(IDataAccess dataAccess)
		{
			_dataAccess = dataAccess;
		}
		public IActionResult Index()
        {
            return View();
        }
		public async Task<IActionResult> People_Read([DataSourceRequest] DataSourceRequest request)
		{
			List<PersonViewModel> people = new();
			var peopleFromDatabase = await _dataAccess.GetPeople();
			foreach (var person in peopleFromDatabase)
			{
				people.Add(person.ToPersonModel());
			}
			var dsResult = people.ToDataSourceResult(request);
			return Json(dsResult);
		}

	}
}
