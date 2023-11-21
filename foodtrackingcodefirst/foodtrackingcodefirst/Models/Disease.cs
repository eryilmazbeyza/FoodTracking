using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace foodtrackingcodefirst.Models
{
    public class Disease
    {
        [Key]
        public int DiseaseID { get; set; }
        public string DiseaseName { get; set; }
        public string SideEffects {  get; set; }

        [ForeignKey("PatientID")]
        public int PatientID { get; set; }
        public virtual Patient Patient { get; set; }

    }
}
