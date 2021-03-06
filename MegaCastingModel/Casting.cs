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
    
    public partial class Casting
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Casting()
        {
            this.Artiste = new HashSet<Artiste>();
        }
    
        public long Identifiant { get; set; }
        public string Libelle { get; set; }
        public Nullable<System.DateTime> Date_Debut_Publication { get; set; }
        public int Nb_Jour_Diffusion { get; set; }
        public Nullable<System.DateTime> Date_Debut_Contrat { get; set; }
        public Nullable<int> Nb_Poste { get; set; }
        public string Description_Poste { get; set; }
        public string Description_Profil { get; set; }
        public string Type_Contrat { get; set; }
        public string Adresse_Contrat { get; set; }
        public long Annonceur { get; set; }
        public long Employe { get; set; }
        public long Metier { get; set; }
    
        public virtual Annonceur Annonceur1 { get; set; }
        public virtual Employe Employe1 { get; set; }
        public virtual Metier Metier1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Artiste> Artiste { get; set; }
    }
}
