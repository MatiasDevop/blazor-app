using System;
using System.Collections.Generic;
using Enums;

namespace ViewModels.Queries;

public class SearchMatchesQuery
{
    public int Skip { get; set; }
    public int Count { get; set; } = 10;
    public bool Descending { get; set; }
    public UserConnectionType Type { get; set; }
    public Guid? Industry { get; set; }
    public Guid? Interests { get; set; }
    public Guid? Major { get; set; }
    public List<Guid?> Skills { get; set; } = new();
    public string OrderBy { get; set; }
}