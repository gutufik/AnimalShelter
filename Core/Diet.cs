//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core
{
    using System;
    using System.Collections.Generic;
    
    public partial class Diet
    {
        public int DietId { get; set; }
        public System.DateTime Date { get; set; }
        public int AnimalId { get; set; }
        public int FoodId { get; set; }
        public Nullable<int> Weight { get; set; }
    
        public virtual Animal Animal { get; set; }
        public virtual Food Food { get; set; }
    }
}
