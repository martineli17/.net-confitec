﻿using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Confitec.Controllers.Base
{
    [EnableQuery()]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class BaseController : ControllerBase
    {
        protected readonly ControllerInjectorBase Injector;
        public BaseController(ControllerInjectorBase injector)
        {
            Injector = injector;
        }

        protected ActionResult<TResponse> CustomResponse<TResponse>(TResponse response, int statusCodeSucesso = 200, int statusCodeFalha = 400)
        {
            return Injector.Notificador.IsValido()
                ? StatusCode(statusCodeSucesso, response)
                : StatusCode(ContemRegistroNaoEncontrado() ? 404 : statusCodeFalha, Injector.Notificador.Mensagens());

        }

        protected bool ContemRegistroNaoEncontrado() =>
            Injector.Notificador.Mensagens().Any(x => x.Mensagem.ToLower().Contains("não encontrado"));

        protected BaseActionResultResponse<TResponse> CreateBasicActionResult<TResponse>(TResponse response) =>
            new BaseActionResultResponse<TResponse>(response, Injector.Notificador.Mensagens());
    }
}
