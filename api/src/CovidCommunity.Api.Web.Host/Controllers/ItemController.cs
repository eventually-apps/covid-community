using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CovidCommunity.Api.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CovidCommunity.Api.Web.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController: ApiControllerBase
    {
        [HttpPost("requestItem")]
        public async void RequestItem()
        {

        }

        [HttpPost("donateItem")]
        public async void DonateItem()
        {

        }

    }
}
