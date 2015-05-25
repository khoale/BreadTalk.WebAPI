namespace BreadTalk.WebAPI.Models
{
    using System.ComponentModel.DataAnnotations;

    public class People
    {
        [Required]
        public string Name { get; set; }
    }
}