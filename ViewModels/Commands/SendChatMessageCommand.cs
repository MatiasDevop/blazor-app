using System;

namespace ViewModels.Commands;

public class SendChatMessageCommand
{
    public Guid UserId { get; set; }
    public string Message { get; set; }
}