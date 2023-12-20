using System;
using EgyptReciepts.Shared;
using Volo.Abp.AutoMapper;
using EgyptReciepts.Branches;
using AutoMapper;

namespace EgyptReciepts;

public class EgyptRecieptsApplicationAutoMapperProfile : Profile
{
    public EgyptRecieptsApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Branch, BranchDto>();
        CreateMap<Branch, BranchExcelDto>();
    }
}