using AutoMapper;
using Confitec.Core.DTOs;
using Dominio.Entidades;

namespace Confitec.Core.Mappers
{
    public class UsuarioMapper : Profile
    {
        public UsuarioMapper()
        {
            CreateMap<UsuarioAddRequest, Usuario>();
            CreateMap<Usuario, UsuarioAddResponse>();

            CreateMap<UsuarioUpdateRequest, Usuario>();
            CreateMap<Usuario, UsuarioUpdateResponse>();
        }
    }
}
