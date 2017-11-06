using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vega.Presistence;
using AutoMapper;
using Vega.Controllers.Resources;
using Microsoft.EntityFrameworkCore;
using Vega.Models;

namespace Vega.Controllers
{
    //[Produces("application/json")]
    //[Route("api/Makes")]
    public class MakesController : Controller
    {
        private VegaDbContext _context;
        private IMapper _mapper;

        public MakesController(VegaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("api/makes")]
        public async Task<IEnumerable<MakeResource>> GetMakes()
        {
            var makes = await _context.Makes.Include(m => m.Models).ToListAsync();

            return _mapper.Map<List<Make>, List<MakeResource>>(makes);
        }


    }
}