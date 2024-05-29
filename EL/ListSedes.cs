namespace Proyect_BI.EL
{
    public class ListSedes
    {
        public ListSedes()
        {
            List = new List<Sedes>();
        }
        public List<Sedes> List { get; set; }
        public int errorIndicator { get; set; }
        public string? message_error { get; set; }
    }
}
