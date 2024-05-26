namespace Proyect_BI.EL
{
    public class TrabajadorResult
    {
        public TrabajadorResult()
        {
            Lista = new List<Trabajador>();
        }
        public List<Trabajador> Lista { get; set; }
        public int ErrorIndicator { get; set; }
        public string? message_error { get; set; }

    }
}
