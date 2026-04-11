using System.Threading.Tasks;
using Microsoft.JSInterop;
using Portal.Blazor.Services;

namespace Portal.Blazor.Weavy;

public class SpaceReference : ExtendableJsObjectReference {
    public SpaceReference(IJSObjectReference space) : base(space) { }

    public async ValueTask<AppReference> App(object appSelector = null) {
        return new(await ObjectReference.InvokeAsync<IJSObjectReference>("app", new object[] { appSelector }));
    }

    // Used for cleanup
    public async Task Remove() {
        await ObjectReference.InvokeVoidAsync("remove");
        await DisposeAsync();
    }
}
