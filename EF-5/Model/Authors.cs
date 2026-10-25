using System.ComponentModel.DataAnnotations;

namespace EF_5.Model
{
    public class Authors
    {
        [Key]
        public int AuthorId { get; set; }
        public object AuthorID { get; internal set; }
        public string Author_Name { get; set; }
        public int Author_Age { get; set; }
        public string Author_EXP { get; set; }
    }
}
