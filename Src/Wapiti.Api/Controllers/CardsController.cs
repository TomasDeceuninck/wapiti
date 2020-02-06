using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wapiti.Application.Cards.Queries.ListCards;

namespace Wapiti.Api.Controllers
{
    public class CardsController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ListCardsViewModel>> List()
        {
            return Ok(await Mediator.Send(new ListCardsQuery()));
        }
    }
}
