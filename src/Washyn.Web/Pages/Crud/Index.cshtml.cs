﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Washyn.Domain.Identity;

namespace Washyn.Web.Pages.Crud
{
    [Authorize(Roles = RolConsts.User)]
    public class Index : PageModel
    {
        public void OnGet()
        {
            
        }
    }
}