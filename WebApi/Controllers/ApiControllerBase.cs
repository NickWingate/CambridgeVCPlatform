using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiControllerBase<T> : ControllerBase where T : class
    {
        protected readonly CVCPlatformDbContext _context;
        protected readonly IMapper _mapper;
        protected readonly ILogger<T> _logger;

        public ApiControllerBase(CVCPlatformDbContext context,
            IMapper mapper, 
            ILogger<T> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Log exception and alert client
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        protected ActionResult HandleException(Exception ex, string functionName)
        {
            _logger.LogError(ex, $"Error in {functionName}");
            return StatusCode(500, "Error completing your requests. Please try again later");
        }
    }
}
