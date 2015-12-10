namespace AutogearWeb.Models
{
    public class TblPostCodeModel
    {
        public int PostCodeId { get; set; }
        public int SuburbId { get; set; }
    }

    public class TblSuburbModel
    {
        public int SuburbId { get; set; }
        public string Name { get; set; }
        public int StateId { get; set; }
    }

    public class TblStateModel
    {
        public int StateId { get; set; }
        public string Name { get; set; }
    }

    public class TblPostCodeSuburbModel
    {
        public int PostCodeId { get; set; }
        public string SuburbName { get; set; }
    }
}