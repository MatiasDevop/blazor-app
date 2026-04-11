using System.Collections.Generic;

namespace ViewModels.Weavy.Commands;

public class StartConversationCommand
{
    public string Target { get; set; }
    public string Message { get; set; }
}