﻿using System.Web;
using System.Web.Mvc;

namespace Patient_CRUD_System
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
