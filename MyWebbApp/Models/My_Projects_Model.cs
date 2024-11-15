using System.ComponentModel.DataAnnotations;


namespace MyWebbApp.Models
{
    public class My_Projects_Model
    {
        public int ID { get; set; }
        public string? ProjectName { get; set; }
        public string? Technology { get; set; }
        public int Timeofwork { get; set; }
        public string? Delineation { get; set; }

    }
}
