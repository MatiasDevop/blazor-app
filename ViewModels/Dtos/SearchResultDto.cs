using System;
using Enums;

namespace ViewModels.Dtos;

public class SearchResultDto
{
    public Guid Id { get; set; }
    public SearchObjectType Type { get; set; }
}