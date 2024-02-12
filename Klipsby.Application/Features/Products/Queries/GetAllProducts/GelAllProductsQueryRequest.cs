using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klipsby.Application.Features.Products.Queries.GetAllProducts
{
    public class GelAllProductsQueryRequest : IRequest<IList<GelAllProductsQueryResponse>>
    {
    }
}
