using Confitec.Controllers.Base;
using Confitec.Core.Constantes;
using Confitec.Core.DTOs;
using Crosscuting.Notificacoes;
using Dominio.Contratos.Servicos.Base;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Confitec.Controllers
{
    [Route(Urls.Version01 + "usuario")]
    public class UsuarioController : BaseController
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(ControllerInjectorBase injector, IUsuarioService usuarioService)
            : base(injector)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IQueryable<Usuario>), 200)]
        [ProducesResponseType(typeof(IQueryable<MensagemNotificacao>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IQueryable<Usuario>>> Get() => CustomResponse(await _usuarioService.GetAsync());

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IQueryable<Usuario>), 200)]
        [ProducesResponseType(typeof(IQueryable<MensagemNotificacao>), 404)]
        [ProducesResponseType(typeof(IQueryable<MensagemNotificacao>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Usuario>> Get([FromRoute] Guid id)
        {
            var Usuario = await _usuarioService.GetByIdAsync(id);
            return CustomResponse(Usuario, 200, Usuario is null ? 404 : 400);
        }

        [HttpPost]
        [ProducesResponseType(typeof(UsuarioAddResponse), 201)]
        [ProducesResponseType(typeof(IEnumerable<MensagemNotificacao>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<UsuarioAddResponse>> Post([FromBody] UsuarioAddRequest Usuario)
        {
            var entidade = Injector.Mapper.Map<Usuario>(Usuario);
            entidade = await _usuarioService.AddAsync(entidade);
            return CustomResponse(Injector.Mapper.Map<UsuarioAddResponse>(entidade));
        }

        [HttpPut]
        [ProducesResponseType(typeof(UsuarioUpdateResponse), 200)]
        [ProducesResponseType(typeof(IEnumerable<MensagemNotificacao>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<UsuarioUpdateResponse>> Put([FromBody] UpdateRequestBase<UsuarioUpdateRequest> usuario)
        {
            var entidade = Injector.Mapper.Map<Usuario>(usuario?.Dados);
            entidade = await _usuarioService.UpdateAsync(entidade, usuario?.Props);
            return CustomResponse(Injector.Mapper.Map<UsuarioUpdateResponse>(entidade));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(IEnumerable<MensagemNotificacao>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<bool>> Delete(Guid id) => CustomResponse(await _usuarioService.RemoveAsync(id));
    }
}
