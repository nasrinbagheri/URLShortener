using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using URLShortener.Web.Dtos;

namespace URLShortener.Web.Controllers
{
    public class BaseController : ControllerBase
    {
        private readonly IMapper _mapper;
        public BaseController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ResultDto<TOutput> ToResultDto<TInput, TOutput>(TInput source)
        {
            var result = _mapper.Map<TOutput>(source);

            return new ResultDto<TOutput>
            {
                Succeeded = true,
                Result = result,
                Error = null
            };
        }
    }
}
