using System.Collections.Generic;

namespace Twilight.Kernel.Smtp.Text
{
    public interface ITokenEnumerator
    {
        /// <summary>
        /// Peek at the next token.
        /// </summary>
        /// <returns>The token at the given number of tokens past the current index, or Token.None if no token exists.</returns>
        Token Peek();

        /// <summary>
        /// Take the given number of tokens.
        /// </summary>
        /// <returns>The last token that was consumed.</returns>
        Token Take();

        /// <summary>
        /// Create a checkpoint that will ensure the tokens are kept in the buffer from this point forward.
        /// </summary>
        /// <returns>A disposable instance that is used to release the checkpoint.</returns>
        ITokenEnumeratorCheckpoint Checkpoint();
        
        /// <summary>
        /// The complete list of tokens.
        /// </summary>
        IReadOnlyList<Token> Tokens { get; }
        
        /// <summary>
        /// Returns the current position of the enumerator.
        /// </summary>
        int Position { get; }
    }
}