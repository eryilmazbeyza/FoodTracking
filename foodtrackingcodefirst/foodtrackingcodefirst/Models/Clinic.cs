using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace foodtrackingcodefirst.Models
{
    public class Clinic
    {
        [Key]
        public int ClinicID { get; set; }

        public string ClinicName { get; set; }
        public string DoctorName { get; set; }
        public string DoctorSpecialty { get; set; }
        public int ClinicNumber { get; set; }
        [ForeignKey("PatientID")]
        public int PatientID { get; set; }
        public virtual Patient Patient { get; set; }    

    }
}
