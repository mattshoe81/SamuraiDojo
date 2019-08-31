using System;

namespace SamuraiDojo.IoC.Interfaces
{
    public interface IUnderTestAttribute
    {
        Type Type { get; set; }
    }
}