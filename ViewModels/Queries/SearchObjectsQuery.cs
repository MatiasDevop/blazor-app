using System;
using System.Collections.Generic;
using Enums;

namespace ViewModels.Queries;

public class SearchObjectsQuery
{
    public int Skip { get; set; }
    public string SearchText { get; set; }
    public List<SearchObjectType?> Types { get; set; }
    public UserConnectionType Type { get; set; }
    public Guid? Industry { get; set; }
    public Guid? Interests { get; set; }
    public Guid? Major { get; set; }
    public string OrderBy { get; set; }
    public List<Guid?> Skills { get; set; } = new();
}