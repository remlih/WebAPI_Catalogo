using Catalog.Application.Interfaces.Services;
using Catalog.Infrastructure.Contexts;
using Catalog.Infrastructure.Helpers;
using Catalog.Infrastructure.Models.Identity;
using Catalog.Shared.Constants.Permission;
using Catalog.Shared.Constants.Role;
using Catalog.Shared.Constants.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace Catalog.Infrastructure
{
    public class DatabaseSeeder : IDatabaseSeeder
    {
        private readonly ILogger<DatabaseSeeder> _logger;
        private readonly IStringLocalizer<DatabaseSeeder> _localizer;
        private readonly CatalogContext _db;
        private readonly UserManager<CatalogUser> _userManager;
        private readonly RoleManager<CatalogRole> _roleManager;

        public DatabaseSeeder(
            UserManager<CatalogUser> userManager,
            RoleManager<CatalogRole> roleManager,
            CatalogContext db,
            ILogger<DatabaseSeeder> logger,
            IStringLocalizer<DatabaseSeeder> localizer)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _db = db;
            _logger = logger;
            _localizer = localizer;
        }

        public void Initialize()
        {
            AddAdministrator();
            AddBasicUser();
            _db.SaveChanges();
        }
        private void AddAdministrator()
        {
            Task.Run(async () =>
            {
                //Check if Role Exists
                var adminRole = new CatalogRole(RoleConstants.AdministratorRole, _localizer["El rol administrador tiene todos los permisos"]);
                var adminRoleInDb = await _roleManager.FindByNameAsync(RoleConstants.AdministratorRole);
                if (adminRoleInDb == null)
                {
                    await _roleManager.CreateAsync(adminRole);
                    adminRoleInDb = await _roleManager.FindByNameAsync(RoleConstants.AdministratorRole);
                    _logger.LogInformation(_localizer["Rol de administrador predefinido."]);
                }
                //Check if User Exists
                var superUser = new CatalogUser
                {
                    Id = "158aac0f-24f3-41e5-a1a5-f42759d31d25",
                    FirstName = "Hilmer",
                    LastName = "Osorio",
                    Email = "hilmerosorio@gmail.com",
                    UserName = "hilmer",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    CreatedBy = "158aac0f-24f3-41e5-a1a5-f42759d31d25",
                    CreatedOn = DateTime.Now,
                    IsActive = true
                };
                var superUserInDb = await _userManager.FindByEmailAsync(superUser.Email);
                if (superUserInDb == null)
                {
                    await _userManager.CreateAsync(superUser, UserConstants.DefaultPassword);
                    var result = await _userManager.AddToRoleAsync(superUser, RoleConstants.AdministratorRole);
                    if (result.Succeeded)
                    {
                        _logger.LogInformation(_localizer["Usuario predeterminado SuperAdministrador."]);
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            _logger.LogError(error.Description);
                        }
                    }
                }
                foreach (var permission in Permissions.GetRegisteredPermissions())
                {
                    await _roleManager.AddPermissionClaim(adminRoleInDb, permission);
                }
            }).GetAwaiter().GetResult();
        }

        private void AddBasicUser()
        {
            Task.Run(async () =>
            {
                //Check if Role Exists
                var basicRole = new CatalogRole(RoleConstants.BasicRole, _localizer["Rol básico con permisos predeterminados"]);
                var basicRoleInDb = await _roleManager.FindByNameAsync(RoleConstants.BasicRole);
                if (basicRoleInDb == null)
                {
                    await _roleManager.CreateAsync(basicRole);
                    _logger.LogInformation(_localizer["Rol básico."]);
                }
                //Check if User Exists
                var basicUser = new CatalogUser
                {
                    Id = "d768034f-54b0-4115-a34b-cc7bf6b3cfc7",
                    FirstName = "Usuario",
                    LastName = "Demo",
                    Email = "hilmerosorio@yahoo.es",
                    UserName = "demo",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    CreatedBy = "158aac0f-24f3-41e5-a1a5-f42759d31d25",
                    CreatedOn = DateTime.Now,
                    IsActive = true
                };
                var basicUserInDb = await _userManager.FindByEmailAsync(basicUser.Email);
                if (basicUserInDb == null)
                {
                    await _userManager.CreateAsync(basicUser, UserConstants.DefaultPassword);
                    await _userManager.AddToRoleAsync(basicUser, RoleConstants.BasicRole);
                    _logger.LogInformation(_localizer["Usuario preseleccionado con rol básico."]);
                }
            }).GetAwaiter().GetResult();
        }
    }
}