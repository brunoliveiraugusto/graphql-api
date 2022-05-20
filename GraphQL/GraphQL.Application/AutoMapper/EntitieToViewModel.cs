﻿using AutoMapper;
using GraphQL.Application.ViewModels;
using GraphQL.Domain.Entities;

namespace GraphQL.Application.AutoMapper
{
    public class EntitieToViewModel : Profile
    {
        public EntitieToViewModel()
        {
            CreateMap<TargetHistory, TargetHistoryViewModel>();
        }
    }
}
