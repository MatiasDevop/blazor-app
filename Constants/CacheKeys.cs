using System;

namespace Constants
{
    public static class CacheKeys
    {
        public static string CanTransition(Guid id) => $"CanTransition-{id}";
        public static string CanGetReceipt(Guid id) => $"CanGetReceipt-{id}";
    }
}