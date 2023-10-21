using Business.Models;

namespace Data.Contexto
{
	public class AppDbSeedData
    {
        public static void SeedTipoSituacao(AppDbContext context)
        {
            var lstAdd = new List<TipoSituacao>();
            var lstUpdate = new List<TipoSituacao>();

            foreach (TipoSituacaoEnum item in Enum.GetValues(typeof(TipoSituacaoEnum)))
            {
                var entity = context.TipoSituacao.FirstOrDefault(i => i.Id == item);
                if (entity == null)
                    lstAdd.Add(new TipoSituacao(item, item.ToString()));
                else
                {
                    entity.NomeTipoSituacao = item.ToString();
                    lstUpdate.Add(entity);
                }
            }

            context.AddRange(lstAdd);
            context.UpdateRange(lstUpdate);
            context.SaveChanges();
        }


    }
}
