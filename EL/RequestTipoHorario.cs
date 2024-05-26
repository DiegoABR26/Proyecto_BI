namespace Proyect_BI.EL
{
    public class RequestTipoHorario
    {
        public int Id_Horario { get; set; }
        public string? Hora_Inicio { get; set; }
        public string? Hora_Final { get; set; }
        public int CANT_HORAS_TRABJ { get; set; }
        public int Actividad { get; set; }

    }
}
