using ETicaretAPI.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ETicaretAPI.Application.Features.Commands.ProductImagesFile.RemoveProductImages
{
    public class RemoveProductImagesCommandHandler : IRequestHandler<RemoveProductImagesCommandRequest, RemoveProductImagesCommandResponse>
    {
        readonly IProductReadRepository _productReadRepository;
        readonly IProductWriteRepository _productWriteRepository;
        public RemoveProductImagesCommandHandler(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }
        public async Task<RemoveProductImagesCommandResponse> Handle(RemoveProductImagesCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Product? product = await _productReadRepository.Table.Include(p => p.ProductImagesFiles).FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.Id));
            Domain.Entities.ProductImagesFile? productImagesFile = product?.ProductImagesFiles.FirstOrDefault(P => P.Id == Guid.Parse(request.ImageId));
            if (productImagesFile != null)
            {
                product?.ProductImagesFiles.Remove(productImagesFile);
            }
            await _productWriteRepository.SaveAsync();
            return new();
        }
    }
}
