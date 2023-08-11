using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.ProductImagesFile.RemoveProductImages
{
    public class RemoveProductImagesCommandRequest : IRequest<RemoveProductImagesCommandResponse>
    {
        public string Id { get; set; }
        public string? ImageId { get; set; }
    }
}
