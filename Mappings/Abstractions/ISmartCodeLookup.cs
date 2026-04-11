using System;
using Domain.Entities;

namespace Mappings.Abstractions
{
    public interface ISmartCodeLookup
    {
        SmartCode GetById(Guid id);
    }
}
