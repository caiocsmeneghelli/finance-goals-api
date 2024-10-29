using System;
using AutoMapper;
using FinanceGoals.Application.ViewModels;
using FinanceGoals.Domain.Entities;

namespace FinanceGoals.Application.Mapper;

public class GoalProfile : Profile
{
    public GoalProfile()
    {
        CreateMap<Goal, GoalViewModel>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
    }
}
