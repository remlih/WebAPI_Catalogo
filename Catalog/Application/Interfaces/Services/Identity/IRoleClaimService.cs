﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Application.Interfaces.Common;
using Catalog.Application.Requests.Identity;
using Catalog.Application.Responses.Identity;
using Catalog.Shared.Wrapper;

namespace Catalog.Application.Interfaces.Services.Identity
{
    public interface IRoleClaimService : IService
    {
        Task<Result<List<RoleClaimResponse>>> GetAllAsync();

        Task<int> GetCountAsync();

        Task<Result<RoleClaimResponse>> GetByIdAsync(int id);

        Task<Result<List<RoleClaimResponse>>> GetAllByRoleIdAsync(string roleId);

        Task<Result<string>> SaveAsync(RoleClaimRequest request);

        Task<Result<string>> DeleteAsync(int id);
    }
}