using System;
using System.Collections.Generic;

namespace Portal.Blazor.Extensions;

public static class ListExtensions
{
    public static void DisposeAll(this List<IDisposable> list)
    {
        if (list is null) return;
        foreach (var obj in list)
        {
            obj.Dispose();
        }
        list.Clear();
    }
}
