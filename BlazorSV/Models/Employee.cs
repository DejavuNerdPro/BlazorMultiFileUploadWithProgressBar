using System.ComponentModel.DataAnnotations;

namespace BlazorSV.Models
{
	public class Employee
	{
		[Required]
		public string Name { get; set; }

		[Required]
		public string City { get; set; }

        [Range(30, 32)]
        public int Age { get; set; }
    }
}
