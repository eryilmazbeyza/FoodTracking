using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace foodtrackingcodefirst.Models
{
    public class Diet
    {
        public int DietID { get; set; }
        public string DietType { get; set; }
        public DateTime DietStart { get; set; }
        public DateTime DietEnd { get; set; }
        public string DietPlan { get; set; }

        [ForeignKey("Nutrition")]
        public int NutritionID { get; set; }

        public virtual Nutrition Nutrition { get; set; }
    }
}
