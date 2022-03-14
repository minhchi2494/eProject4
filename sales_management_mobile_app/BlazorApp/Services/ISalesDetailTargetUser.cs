﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp.Models;

namespace BlazorApp.Services
{
    public interface ISalesDetailTargetUser
    {
        Task<List<vSalesDetailTargetUser>> getSalesDetailTargetUsers(DateTime? fromDate, DateTime? toDate);
    }
}