using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Portal.Blazor.Weavy;

public class AppReference : ExtendableJsObjectReference {
    public AppReference(IJSObjectReference app) : base(app) { }
        
    public ValueTask Build() {
        return ObjectReference.InvokeVoidAsync("build");
    }

    public ValueTask Open(string url = null) {
        return ObjectReference.InvokeVoidAsync("open", url);
    }

    public ValueTask Close() {
        return ObjectReference.InvokeVoidAsync("close");
    }

    public ValueTask Toggle() {
        return ObjectReference.InvokeVoidAsync("toggle");
    }

    // Used for cleanup
    public async Task Remove() {
        await ObjectReference.InvokeVoidAsync("remove");
        await DisposeAsync();
    }
}
