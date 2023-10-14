namespace Business.Models
{
	public class TipoSituacao : EntityKey
    {
		public TipoSituacao(TipoSituacaoEnum id, string nomeTipoSituacao)
		{
			Id = id;
			NomeTipoSituacao = nomeTipoSituacao;
		}

		public new TipoSituacaoEnum Id { get; set; }
        public string NomeTipoSituacao { get; set; }
    }

    public enum TipoSituacaoEnum
    {
        EmElaboracao = 0,
        Ativado = 1,
        Desativado = 2,
        //EmAprovacao = 3
    }
}
