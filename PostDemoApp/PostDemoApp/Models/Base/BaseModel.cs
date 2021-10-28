using System.ComponentModel.DataAnnotations;

namespace PostDemoApp.Models.Base
{
    public abstract class BaseModel
    {
        [Key]
        public int Id { get; set; }
    }
}
