using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace foodtrackingcodefirst.Models
{
    public class Meal
    {

        [Key]
        public int MealID { get; set; }

        public string MealName { get; set; }
        public int Calories { get; set; }
        public int Protein { get; set; }

        public int Carbs { get; set; }
        public int Fat { get; set; }

        [ForeignKey("DietID")]
        public int DietID { get; set; }
        public virtual Diet Diet { get; set; } 
        
    }
}
