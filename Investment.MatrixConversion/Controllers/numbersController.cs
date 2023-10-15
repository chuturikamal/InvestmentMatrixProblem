using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Investment.MatrixConversion.Business.Services;
using Investment.MatrixConversion.Business.Models;
using Investment.MatrixConversion.Business.Util;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Investment.MatrixConversion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class numbersController : Controller
    {
        private readonly INumbersService _numbersService;
        public numbersController(INumbersService numbersService)
        {
            _numbersService = numbersService;
        }

        [HttpGet("init/{size}")]
        public async Task<Response> Init(int size)
        {
            try
            {
                int ret = await _numbersService.Init(size);
                return StaticCollection.GenRes(value: ret);
            }
            catch(Exception Ex)
            {
                return StaticCollection.GenRes(cause: Ex.Message, success: false);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataset">A and B needs to divide by | and digits seperate by comma</param>
        /// <param name="type"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        [HttpGet("{dataset}/{type}/{idx}")]
        public async Task<Response> GetDataSet(String dataset, String type, int idx)
        {
            try
            {
                String retVal = await _numbersService.GetDataSet(dataset, type, idx);
                return StaticCollection.GenRes(cause: retVal);
            }
            catch (Exception Ex)
            {
                return StaticCollection.GenRes(cause: Ex.Message, success: false);
            }
        }

        [HttpPost("validate")]
        public async Task<Response> validate(String sampleString)
        {
            try
            {
                bool success = await _numbersService.validate(sampleString);
                if(success)
                    return StaticCollection.GenRes(cause: "Validation Success", success: true);
                else
                    return StaticCollection.GenRes(cause: "Validation failed", success: false);
            }
            catch (Exception Ex) { return StaticCollection.GenRes(cause: Ex.Message, success: false); }
        }
    }
}

