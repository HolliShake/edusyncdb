﻿using APPLICATION.Dto.AccessGroup;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class AccessGroupService : GenericService<AccessGroup, GetAccessGroupDto>, IAccessGroupService
{
    public AccessGroupService(AppDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async new Task<ICollection<GetAccessGroupDto>> GetAllAsync()
    {
        return _mapper.Map<ICollection<GetAccessGroupDto>>(await _dbModel
            .Include(ag => ag.AccessGroupActions)
            .ToListAsync());
    }

    public async new Task<AccessGroup?> GetAsync(int id)
    {
        return _mapper.Map<AccessGroup?>(await _dbModel
            .Include(ag => ag.AccessGroupActions)
            .Where(ag => ag.Id == id).FirstOrDefaultAsync());
    }
}