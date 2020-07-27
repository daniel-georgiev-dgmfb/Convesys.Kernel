using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Convesys.Kernel.Mime
{
    public class MimeEntity
    {
        public MimeEntity(IEnumerable<MimeHeader> headers, Stream content)
        {
            Headers = headers ?? throw new ArgumentNullException(nameof(headers));
            Content = content ?? throw new ArgumentNullException(nameof(content));
        }

        public IEnumerable<MimeHeader> Headers { get; }

        public Stream Content { get; }

        public override bool Equals(object obj)
        {
            return obj is MimeEntity entity && Equals(entity);
        }

        private bool Equals(MimeEntity other)
        {
            return Headers.SequenceEqual(other.Headers) && Equals(Content, other.Content);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Headers != null ? Headers.GetHashCode() : 0) * 397) ^ (Content != null ? Content.GetHashCode() : 0);
            }
        }
    }
}
