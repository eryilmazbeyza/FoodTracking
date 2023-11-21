using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace foodtrackingcodefirst.Models
{
    public class Patient
    {
        [Key]
        public int PatientID {  get; set; }
        public string PatientName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }

        [ForeignKey("DiseaseID")]
        public string DiseaseID { get; set; }
        public virtual Disease  Disease { get; set; } 


    }
}
