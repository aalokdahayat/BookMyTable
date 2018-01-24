//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FoodOrderingWebService.DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class HotelMenuTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HotelMenuTable()
        {
            this.HotelTableAndOrderBookings = new HashSet<HotelTableAndOrderBooking>();
        }
    
        public int Id { get; set; }
        public Nullable<int> HotelId { get; set; }
        public string DishName { get; set; }
        public string DishDescription { get; set; }
        public Nullable<int> Isveg { get; set; }
        public Nullable<int> IsAvaulable { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public byte[] ts { get; set; }
    
        public virtual RestaurantsDetail RestaurantsDetail { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HotelTableAndOrderBooking> HotelTableAndOrderBookings { get; set; }
    }
}