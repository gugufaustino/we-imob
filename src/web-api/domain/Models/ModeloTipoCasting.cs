namespace Business.Models
{
    public class ModeloTipoCasting : EntityKey
    {
        public TipoCastingEnum IdTipoCasting { get; set; }
        public int IdModelo { get; set; }
        public Modelo Modelo { get; set; }
        public TipoCasting TipoCasting { get; set; }
    }
}
