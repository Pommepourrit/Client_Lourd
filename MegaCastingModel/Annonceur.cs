//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MegaCastingModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Annonceur
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Annonceur()
        {
            this.Casting = new HashSet<Casting>();
            this.Metier = new HashSet<Metier>();
            this.Offre = new HashSet<Offre>();
            this.PartenaireDiffusion = new HashSet<PartenaireDiffusion>();
        }
    
        public long Identifiant { get; set; }
        public string Libelle { get; set; }
        public string Mail { get; set; }
        public string Telephone { get; set; }
        public string Nom_Contact { get; set; }
        public string Prenom_Contact { get; set; }
        public string Mail_Contact { get; set; }
        public string Telephone_Contact { get; set; }
        public string Adresse { get; set; }
        public string Code_Postal { get; set; }
        public string Ville { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Casting> Casting { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Metier> Metier { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Offre> Offre { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartenaireDiffusion> PartenaireDiffusion { get; set; }
    }
}
