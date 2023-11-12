using ApiApplication.ViewModel;
using AutoMapper;
using Domain.Models;
namespace ApiApplication.Configuration
{
	public class AutoMapperMaps : Profile
    {
        public AutoMapperMaps()
        {
            #region AUTH
            CreateMap<AccountViewModel, Usuario>();
            #endregion


            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
            //CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
             
            //CreateMap<Modelo, CatalogoViewModel>()
            //        .ForMember(prop => prop.NomeCorOlhos, opt => opt.MapFrom(src => src.CorOlhos.ToString()))
            //        .ForMember(prop => prop.NomeCorCabelo, opt => opt.MapFrom(src => src.CorCabelo.ToString()))
            //        .ForMember(prop => prop.NomeTipoCabelo, opt => opt.MapFrom(src => src.TipoCabelo.ToString()))
            //        .ForMember(prop => prop.NomeTipoCabeloComprimento, opt => opt.MapFrom(src => src.TipoCabeloComprimento.ToString()))
            //        .ForMember(prop => prop.NomeTipoCasting, opt => opt.MapFrom(
            //                                                                        src => src.ModeloTipoCasting
            //                                                                        .Select(i => i.TipoCasting.NomeTipoCasting).ToArray()
            //                                                                    ));

            //CreateMap<Modelo, ModeloViewModel>()
            //        .ForMember(prop => prop.NomeTipoSituacao, opt => opt.MapFrom(src => src.TipoSituacao.NomeTipoSituacao))
            //        .ForMember(prop => prop.ModeloTipoCasting, opt => opt.MapFrom(src => src.ModeloTipoCasting
            //                                                                       .Select(i => i.IdTipoCasting)
            //                                                                    ));


            //CreateMap<ModeloViewModel, Modelo>().ForMember(prop => prop.ModeloTipoCasting, opt => opt.MapFrom<ModeloTipoCastingResolver>());

            // DE -> PARA
            // Conta -> Model
             /*CreateMap<Conta, PagamentoViewModel>()
                .ForMember(prop => prop.TipoRecorrenciaDescricao, opt => opt.MapFrom(src => src.TipoRecorrencia.ToString()))
                .ReverseMap();

            CreateMap<Fornecedor, FornecedorViewModel>()
                .ForMember(prop => prop.Cep, opt => opt.MapFrom(src => src.Endereco.Cep))
                .ForMember(prop => prop.Logradouro, opt => opt.MapFrom(src => src.Endereco.Logradouro))
                .ForMember(prop => prop.Numero, opt => opt.MapFrom(src => src.Endereco.Numero))
                .ForMember(prop => prop.Complemento, opt => opt.MapFrom(src => src.Endereco.Complemento))
                .ForMember(prop => prop.Bairro, opt => opt.MapFrom(src => src.Endereco.Bairro))
                .ForMember(prop => prop.NomeMunicipio, opt => opt.MapFrom(src => src.Endereco.NomeMunicipio))
                .ForMember(prop => prop.SiglaUf, opt => opt.MapFrom(src => src.Endereco.SiglaUf))
                .ReverseMap();


            // Pagamento -> Model
            CreateMap<Pagamento, PagamentoViewModel>()
                .ForPath(dest => dest.TipoRecorrenciaDescricao, opt => opt.MapFrom(src => src.Conta.TipoRecorrencia))
                .ForPath(dest => dest.TipoRecorrencia, opt => opt.MapFrom(src => src.Conta.TipoRecorrencia))
                .ForPath(dest => dest.DescricaoFornecedor, opt => opt.MapFrom(src => src.Conta.DescricaoFornecedor))
             .ReverseMap()
                .ForPath(dest => dest.Conta.DescricaoFornecedor, opt => opt.MapFrom(src => src.DescricaoFornecedor))
                .ForPath(dest => dest.Conta.TipoRecorrencia, opt => opt.MapFrom(src => src.TipoRecorrencia));

           
              CreateMap<TipoRecorrenciaEnum, string>().ConvertUsing(src => src.ToString());
              CreateMap<Produto, ProdutoViewModel>()
                .ForMember(dest => dest.NomeFornecedor, opt => opt.MapFrom(src => src.Fornecedor.Nome));
             */
        }
    }

//    public class ModeloTipoCastingResolver : IValueResolver<ModeloViewModel, Modelo, IEnumerable<ModeloTipoCasting>>
//    {
//        public IEnumerable<ModeloTipoCasting> Resolve(ModeloViewModel source, Modelo target, IEnumerable<ModeloTipoCasting> destMember, ResolutionContext context)
//        {
//            var obj = new List<ModeloTipoCasting>();
//            foreach (var item in source.ModeloTipoCasting)
//            {
//                obj.Add(new ModeloTipoCasting { IdTipoCasting = item });
//            }
//            return obj;
//        }
//    }

}
