using System;

namespace Portal.Blazor.Jobs.Models;

public class GroupModel
{
    public Guid Id { get; set; }
    public string Label { get; set; }
    public int Order { get; set; }
}
