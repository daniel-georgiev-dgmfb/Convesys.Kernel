using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Platform.Kernel.Resilience
{
    public abstract class ExecutionContext
    {
        private IDictionary<string, object> _settings { get; }

        public IReadOnlyDictionary<string, object> Settings { get { return new ReadOnlyDictionary<string, object>(this._settings); } }

        public ExecutionContext()
        {
            this._settings = new Dictionary<string, object>();
        }

        public ExecutionContext(IDictionary<string, object> settings)
        {
            this._settings = settings;
        }
    }
}