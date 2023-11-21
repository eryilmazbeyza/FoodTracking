using System.ComponentModel.DataAnnotations;

namespace foodtrackingcodefirst.Models
{
    public class Nutrition
    {
        [Key]
        public int NutritionID { get; set; }
        public string NutritionType { get; set; }
        public string Vitamins { get; set; }
        public string Minerals { get; set; }

        public bool PhisicalActivity { get; set; }

        public string BloodValue { get; set; }


    }
}
