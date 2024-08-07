﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Loyalify.Contracts.Store;

public class AddStoreRequest
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public decimal PointRation { get; set; }
    public string StoreManagerEmail { get; set; } = null!;
    public string StoreManagerPassword { get; set; } = null!;
    public int CategoryId { get; set; }
    public IFormFile? CoverImageFile { get; set; }
    public IFormFile? StoreImageFile { get; set; }
}
