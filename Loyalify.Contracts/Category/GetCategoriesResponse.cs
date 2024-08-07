﻿using System.Net;

namespace Loyalify.Contracts.Category;

public class GetCategoriesResponse
{
    public HttpStatusCode Status { get; set; }
    public List<object> Items { get; set; } = [];
}
