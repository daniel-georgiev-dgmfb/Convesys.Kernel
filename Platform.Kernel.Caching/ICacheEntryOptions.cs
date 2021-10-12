using System;

namespace Platform.Kernel.Caching
{
	public interface ICacheEntryOptions
	{
        DateTimeOffset AbsoluteExpiration { get; set; }
        TimeSpan SlidingExpiration { get; set; }
    }
}