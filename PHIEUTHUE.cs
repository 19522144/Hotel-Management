//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hotel_Management
{
    using System;
    using System.Collections.Generic;
    
    public partial class PHIEUTHUE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUTHUE()
        {
            this.CHITIETHOADONs = new HashSet<CHITIETHOADON>();
            this.CHITIETPHIEUTHUEs = new HashSet<CHITIETPHIEUTHUE>();
        }
    
        public int MAPHIEUTHUE { get; set; }
        public System.DateTime NGAYBDTHUE { get; set; }
        public Nullable<int> MAPHONG { get; set; }
        public string GHICHU { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETHOADON> CHITIETHOADONs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETPHIEUTHUE> CHITIETPHIEUTHUEs { get; set; }
        public virtual PHONG PHONG { get; set; }
    }
}
