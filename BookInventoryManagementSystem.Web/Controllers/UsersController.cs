using BookInventoryManagementSystem.Application.Services.Users;

namespace BookInventoryManagementSystem.Web.Controllers;

[Authorize(Roles = Roles.Administrator)]
public class UsersController(IUserService _userService) : Controller
{
    // GET: UsersController
    public async Task<ActionResult> Index(string sortOrder)
    {
        ViewData["FirstNameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "FirstName_desc" : "";
        ViewData["LastNameSortParm"] = sortOrder == "LastName" ? "LastName_desc" : "LastName";
        ViewData["RoleSortParm"] = sortOrder == "Role" ? "Role_desc" : "Role";

        var users = from user in await _userService.GetUsersAsync()
                    select user;

        switch (sortOrder)
        {
            case "FirstName_desc":
                users = users.OrderByDescending(b => b.FirstName);
                break;
            case "LastName":
                users = users.OrderBy(b => b.LastName);
                break;
            case "LastName_desc":
                users = users.OrderByDescending(b => b.LastName);
                break;
            case "Role":
                users = users.OrderBy(b => b.Role);
                break;
            case "Role_desc":
                users = users.OrderByDescending(b => b.Role);
                break;
            default:
                users = users.OrderBy(b => b.FirstName);
                break;
        }

        return View(users.ToList());
    }

    // GET: UsersController/Details/5
    public async Task<ActionResult> Details(int id)
    {
        // TODO
        return View();
    }

    // GET: UsersController/Create
    public async Task<ActionResult> Create()
    {
        // TODO
        return View();
    }

    // POST: UsersController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(IFormCollection collection)
    {
        // TODO
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: UsersController/Edit/5
    public async Task<ActionResult> Edit(int id)
    {
        // TODO
        return View();
    }

    // POST: UsersController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(int id, IFormCollection collection)
    {
        // TODO
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: UsersController/Delete/5
    public async Task<ActionResult> Delete(int id)
    {
        // TODO
        return View();
    }

    // POST: UsersController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete(int id, IFormCollection collection)
    {
        // TODO
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
