//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _4Tourists.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Registration
    {
        public int IdBooking { get; set; }
        public Nullable<int> IdClient { get; set; }
        public Nullable<int> NumberReg { get; set; }
    
        public virtual Booking Booking { get; set; }
        public virtual Clients Clients { get; set; }
    }
}
