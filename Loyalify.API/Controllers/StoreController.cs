﻿using ErrorOr;
using Loyalify.Application.Common.Interfaces.Services;
using Loyalify.Application.Services.Store.Commands.AddStore;
using Loyalify.Contracts.Store;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Loyalify.API.Controllers;

[Route("Store")]
public class StoreController(
    IMapper mapper,
    ISender mediator,
    IPhotoService photoService) : ApiController
{
    private readonly IMapper _mapper = mapper;
    private readonly ISender _mediator = mediator;
    private readonly IPhotoService _photoService = photoService;

    [HttpPost]
    [Route("AddStore")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddStore([FromForm]AddStoreRequest request)
    {
        string coverImage = null!;
        if (request.CoverImageFile != null)
        {
            var fileResult = _photoService.SaveImage(request.CoverImageFile);
            coverImage = fileResult;
        }
        string storeImage = null!;
        if (request.StoreImageFile != null)
        {
            var fileResult = _photoService.SaveImage(request.StoreImageFile);
            storeImage = fileResult;
        }
        var command = new AddStoreCommand(
            request.Name,
            request.Description,
            request.Address,
            request.PhoneNumber,
            request.StoreManagerEmail,
            request.StoreManagerPassword,
            request.Category,
            coverImage,
            storeImage);
        //var command = _mapper.Map<AddStoreCommand>(request);
        ErrorOr<AddStoreResult> authResult = await _mediator.Send(command);

        return authResult.Match(
            authResult => Ok(_mapper.Map<AddStoreResponse>(authResult)),
            Problem);
    }
}