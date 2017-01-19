using System.ComponentModel.DataAnnotations;

namespace _02_MVC.Models
{
    public class Result
    {
        public Result(string value)
        {
            this.Value = value;
        }

        [Display(Name = "Result")]
        public string Value { get; set; }
    }
}