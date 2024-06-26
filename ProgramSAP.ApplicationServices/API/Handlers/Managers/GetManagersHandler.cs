﻿using MediatR;
using ProgramSAP.ApplicationServices.API.Domain.Manager.GetAll;
using ProgramSAP.DataAccess.Entities;
using ProgramSAP.DataAccess.Repositories;

namespace ProgramSAP.ApplicationServices.API.Handlers.Managers;

public class GetManagersHandler : IRequestHandler<GetManagersRequest, GetManagersResponse>
{
    private readonly IRepository<Manager> managerRepository;

    public GetManagersHandler(IRepository<Manager> managerRepository)
    {
        this.managerRepository = managerRepository;
    }
    public async Task<GetManagersResponse> Handle(GetManagersRequest request, CancellationToken cancellationToken)
    {
        var managers = await managerRepository.GetAll();
        var domainManagers = managers.Select(x => new Domain.Manager.Manager()
        {
            Id = x.Id,
            Name = x.Name,
            Surname = x.Surname,
        });

        var response = new GetManagersResponse()
        {
            Data = domainManagers.ToList()
        };

        return response;
    }
}
