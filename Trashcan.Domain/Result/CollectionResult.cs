using System.Runtime.InteropServices;

namespace Trashcan.Domain.Result;

public class CollectionResult<T> : BaseResult<IEnumerable<T>>
{
    public int Count { get; set; }
}