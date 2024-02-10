using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static RealEstateSystem.Areas.Admin.AdminConstants;
namespace RealEstateSystem.Areas.Admin.Controllers
{
    [Area(AreaName)]
    [Authorize(Roles =AdminRoleName)]
    public class BaseAdminController:Controller
    {

    }
}
