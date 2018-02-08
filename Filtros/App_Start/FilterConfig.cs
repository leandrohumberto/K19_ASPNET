﻿using Filtros.Filters;
using System.Web.Mvc;

namespace Filtros
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LoggingFilter());
        }
    }
}
