using System;

namespace Examine.Config
{
    public interface IIndexField
    {
        string Name { get; }
        string Type { get; }
        Type Analyzer { get; }
    }
}