using System;
using Enums;

namespace ViewModels.Dtos;

public class CompanyWorkAuthorizationDto
{
    public WorkAuthorizationType? WorkAuthorization { get; set; }
    public string WorkAuthorizationOther { get; set; }
    public Guid? Id { get; set; }
}