using System;
using Enums;

namespace ViewModels.Commands;

public class BlockUserCommand
{
    public Guid UserId { get; set; }
    public BlockReason Reason { get; set; }
    public string ReasonDescription { get; set; }
    public bool ReportOnly { get; set; }
}