using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Kernel.Data.Temporal
{
    public interface IBitemporalValue : IBitemporalMarker
    {
        Interval TransactionInterval { get; }

        Interval EffectiveInterval { get; }

        void Invalidate();

        void Invalidate(DateTime onThisDate);
    }
}
