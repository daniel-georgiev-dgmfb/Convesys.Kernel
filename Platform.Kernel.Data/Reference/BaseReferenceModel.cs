//  ----------------------------------------------------------------------- 
//   <copyright file="BaseReferenceModel.cs" company="Glasswall Solutions Ltd.">
//       Glasswall Solutions Ltd.
//   </copyright>
//  ----------------------------------------------------------------------- 

namespace Platform.Kernel.Data.Reference
{
    public class BaseReferenceModel : BaseModel
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }
    }
}