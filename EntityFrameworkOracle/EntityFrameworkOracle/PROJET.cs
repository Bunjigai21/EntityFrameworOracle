//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityFrameworkOracle
{
    using System;
    using System.Collections.Generic;
    
    public partial class PROJET
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PROJET()
        {
            this.EMPLOYEs = new HashSet<EMPLOYE>();
        }
    
        public string CODEPROJET { get; set; }
        public string NOMPROJET { get; set; }
        public System.DateTime DEBUTPROJ { get; set; }
        public System.DateTime FINPREVUE { get; set; }
        public string NOMCONTACT { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPLOYE> EMPLOYEs { get; set; }
    }
}