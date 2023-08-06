using Microsoft.AspNetCore.Mvc;
using UserManagementMVCSample.Core.DataAccess;
using UserManagementMVCSample.Extensions;
using UserManagementMVCSample.Models;

namespace UserManagementMVCSample.Controllers
{
    public class PersonController : Controller
    {
        readonly IDataAccess _dataAccess;
        public PersonController(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public IActionResult People()
        {
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var person = _dataAccess.GetPerson(id);
            return View((await person)?.ToPersonModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(PersonModel person)
        {
            if (ModelState.IsValid)
            {
                await _dataAccess.UpdatePerson(person.ToPersonDto());
            }
            return RedirectToAction("People");
        }
    }
}
