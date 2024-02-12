using Klipsby.Application.Interfaces.UnitOfWorks;
using Klipsby.Domain.Entites;
using MediatR;

namespace Klipsby.Application.Features.Products.Queries.GetAllProducts
{
    public class GelAllProductsQueryHandler : IRequestHandler<GelAllProductsQueryRequest, IList<GelAllProductsQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GelAllProductsQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<IList<GelAllProductsQueryResponse>> Handle(GelAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await unitOfWork.GetReadRepository<Product>().GetAllAsync();

            List<GelAllProductsQueryResponse> response = new();

            foreach (var product in products)
            {
                response.Add(new GelAllProductsQueryResponse
                {
                    Title = product.Title,
                    Description = product.Description,
                    Discount = product.Discount,
                    Price = product.Price - (product.Price * product.Discount / 100),
                });
            }

            return response;
        }
    }
}
