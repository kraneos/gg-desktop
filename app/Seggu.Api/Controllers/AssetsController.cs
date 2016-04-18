using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.ModelBinding;
using Seggu.Api.Data;
using Seggu.Api.Domain;
using Seggu.Service.ViewModels;

namespace Seggu.Api.Controllers
{
    public class AssetsController : BaseApiController<Asset, AssetVM>
    {
    }
}
