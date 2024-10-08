﻿using ErrorOr;
using Loyalify.Application.Common.DTOs;
using Loyalify.Application.Common.Interfaces.Services;
using Loyalify.Application.Services.Store.Commands.AddStore;
using Loyalify.Application.Services.StoreServices.Commands.UpdateStore;
using Loyalify.Application.Services.StoreServices.Queries.DeactivateStore;
using Loyalify.Application.Services.StoreServices.Queries.GetAllStoresAdmin;
using Loyalify.Application.Services.StoreServices.Queries.GetAllStoresUser;
using Loyalify.Application.Services.StoreServices.Queries.GetPopularStores;
using Loyalify.Application.Services.StoreServices.Queries.GetStoreInfo;
using Loyalify.Contracts.Offer;
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
    //[Authorize(Roles = "Admin")]
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
            request.PointRation,
            request.StoreManagerEmail,
            request.StoreManagerPassword,
            request.CategoryId,
            coverImage,
            storeImage);
        //var command = _mapper.Map<AddStoreCommand>(request);
        ErrorOr<AddStoreResult> authResult = await _mediator.Send(command);

        return authResult.Match(
            authResult => Ok(_mapper.Map<AddStoreResponse>(authResult)),
            Problem);
    }
    [HttpGet]
    [Route("GetAllStoresUser")]
    public async Task<IActionResult> GetAllStoresUser([FromQuery]SeeStoresListRequest request)
    {
        var query = _mapper.Map<GetAllStoresUserQuery>(request);
        var authResult = await _mediator.Send(query);
        return authResult.Match(
            authResult => Ok(_mapper.Map<SeeStoresListResponse>(authResult)),
            Problem);
    }
    [HttpGet]
    [Route("GetAllStoresAdmin")]
    public async Task<IActionResult> GetAllStoresAdmin([FromQuery]SeeStoresListRequest request)
    {
        var query = _mapper.Map<GetAllStoresAdminQuery>(request);
        var authResult = await _mediator.Send(query);
        return authResult.Match(
            authResult => Ok(_mapper.Map<SeeStoresListResponse>(authResult)),
            Problem);
    }
    [HttpPost]
    [Route("ChangeStoreState")]
   // [Authorize(Roles = "Admin")]
    public async Task<IActionResult> ChangeStoreState([FromBody]DeactivateStoreRequest request)
    {
        var command = _mapper.Map<DeactivateStoreCommand>(request);
        var authResult = await _mediator.Send(command);
        return authResult.Match(
            authResult => Ok(_mapper.Map<DeactivateStoreResponse>(authResult)),
            Problem);
    }
    [HttpPut]
    [Route("UpdateStore/{id}")]
    public async Task<IActionResult> UpdateStore(int id,UpdateStoreRequest request)
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
        var commandDTO = new UpdateStoreDTO()
        {
            Name = request.Name,
            Description = request.Description,
            Address = request.Address,
            PhoneNumber = request.PhoneNumber,
            StoreImage = storeImage,
            CoverImage = coverImage
        };
        var authResult = await _mediator.Send(
            new UpdateStoreCommand(commandDTO,id));
        return authResult.Match(
            authResult => Ok(_mapper.Map<AddStoreResponse>(authResult)),
            Problem);
    }
    [HttpGet]
    [Route("GetStoreById/{id}")]
    public async Task<IActionResult> GetStoreInfo(int id)
    {

        var authResult = await _mediator.Send(new GetStoreInfoQuery(id));
        return authResult.Match(
            authResult => Ok(_mapper.Map<GetStoreInfoResponse>(authResult)),
            Problem);

    }
    [HttpGet]
    [Route("GetPopularStores")]
    public async Task<IActionResult> GetPopularStores()
    {
        var authResult = await _mediator.Send(new GetPopularStoresQuery());
        return authResult.Match(
            authResult => Ok(_mapper.Map<SeeStoresListResponse>(authResult)),
            Problem);
    }
}
