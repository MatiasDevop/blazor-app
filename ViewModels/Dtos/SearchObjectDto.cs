using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Enums;

namespace ViewModels.Dtos;

public class SearchObjectDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string SubTitle { get; set; }
    public SearchObjectType Type { get; set; }
    public List<string> Passions { get; set; } = new();
    public List<string> Degrees { get; set; } = new();
    public List<string> Skills { get; set; } = new();
    public List<string> Industries { get; set; } = new();
    public List<string> WebDomain { get; set; } = new();
    public List<string> Phones { get; set; } = new();
    public string Email { get; set; }
    public string Date { get; set; }
    public string Description { get; set; }
    public string Gender { get; set; }
    public string Orientation { get; set; }
    public string UserType { get; set; }
    public List<string> PositionsOpen { get; set; } = new();
    public string City { get; set; }
    public string State { get; set; }
    public string School { get; set; }
    public DateTime? PostDate { get; set; }
}