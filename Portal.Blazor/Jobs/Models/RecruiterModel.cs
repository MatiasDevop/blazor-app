using System;
using ViewModels.Dtos;

namespace Portal.Blazor.Jobs.Models;

public class RecruiterModel
{
    public Guid Id { get; set; }
    public string Company { get; set; }
    public string userName { get; set; }
    public bool IsRecruiter{ get; set; }
}
