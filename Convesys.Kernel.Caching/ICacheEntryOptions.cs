using System;

namespace Convesys.Kernel.Caching
{
	public interface ICacheEntryOptions
	{
        DateTimeOffset AbsoluteExpiration { get; set; }
        TimeSpan SlidingExpiration { get; set; }
    }
}