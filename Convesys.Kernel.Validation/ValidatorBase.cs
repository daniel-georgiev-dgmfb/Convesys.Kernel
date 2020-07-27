using System.Collections.Generic;

namespace Convesys.Kernel.Validation
{
    public abstract class ValidatorBase<T> where T : class
    {
        protected ValidatorBase<T> Successor { get; private set; }
        protected IList<string> ErrorsResult { get; }

        protected ValidatorBase()
        {
            ErrorsResult = new List<string>();
        }

        public abstract IEnumerable<string> HandleValidation(T model);

        /// <summary>
        /// Set next validation
        /// </summary>
        /// <param name="successor"></param>
        public ValidatorBase<T> SetSuccessor(ValidatorBase<T> successor)
        {
            Successor = successor;
            return Successor;
        }

    }
}
