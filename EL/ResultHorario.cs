namespace Proyect_BI.EL
{
    public class ResultHorario
    {
        public ResultHorario()
        {

        }
        public List<RequestTipoHorario> Result { get; set; }
        public int ErrorIndicator { get; set; }
        public string MessageError{ get; set; }
    }
}
