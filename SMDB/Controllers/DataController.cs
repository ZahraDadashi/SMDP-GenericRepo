using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; 
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using SMDP.SMDPModels;
using Microsoft.AspNetCore.Authorization;
using SMDP;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using SMDP.Repository;
using System.Security.Cryptography;
using SMDP.SMDPModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;




namespace SMDP.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]


    public class DataController : ControllerBase
    {
        private readonly MarketRepository _smdps;

        private LogSingleton _logger;       
        public DataController()
        {
            _logger = LogSingleton.Instance;
            _smdps = new MarketRepository(new SMDPModels.SmdpContext());
        }

        [ProducesResponseType(typeof(List<DailyPrice>), 200)]
        [HttpGet("/DailyPrice")]       
        public dynamic DailyPrice(long a)
         {
            string userAgent = Request.Headers["User-Agent"].ToString();
            string method = Request.Method.ToString();
            string userr = User?.Identity.Name;
            var Dailypricelist = _smdps.DailyPrice(a);
            var json = System.Text.Json.JsonSerializer.Serialize(Dailypricelist);


            _logger.WriteRequest(userAgent);
            _logger.WriteKind(method);
            _logger.GetUser(userr);
            _logger.WriteResponse(json);

            return Dailypricelist;
         }

        [ProducesResponseType(typeof(List<Fund>), 200)]
        [HttpGet("/Fund")]
        public dynamic Fund()
        {           
            string userAgent = Request.Headers["User-Agent"].ToString();
            string method = Request.Method.ToString();
            string userr = User?.Identity.Name;
            var Fundlist = _smdps.Fund();
            var json = System.Text.Json.JsonSerializer.Serialize(Fundlist);


            _logger.WriteRequest(userAgent);
            _logger.WriteKind(method);
            _logger.GetUser(userr);
            _logger.WriteResponse(json);
           
            return Fundlist;
        }
      
        [ProducesResponseType(typeof(List<Industry>), 200)]
        [HttpGet("/Industry")]    
        
        public dynamic Industry()
        {
            string userAgent = Request.Headers["User-Agent"].ToString();
            string method = Request.Method.ToString();
            string userr = User?.Identity.Name;
            var Industrylist = _smdps.Industry();
            var json = System.Text.Json.JsonSerializer.Serialize(Industrylist);


            _logger.WriteRequest(userAgent);
            _logger.WriteKind(method);
            _logger.GetUser(userr);
            _logger.WriteResponse(json);

            return Industrylist;
        }

        [ProducesResponseType(typeof(List<Instrument>), 200)]
        [HttpGet("/Instrument")]        
        public dynamic Instrument()
        {
            string userAgent = Request.Headers["User-Agent"].ToString();
            string method = Request.Method.ToString();
            string userr = User?.Identity.Name;
            var Instrumentlist = _smdps.Instrument();
            var json = System.Text.Json.JsonSerializer.Serialize(Instrumentlist);


            _logger.WriteRequest(userAgent);
            _logger.WriteKind(method);
            _logger.GetUser(userr);
            _logger.WriteResponse(json);

            return Instrumentlist;
        }

        [ProducesResponseType(typeof(List<LetterType>), 200)]
        [HttpGet("/LetterType")]
        public dynamic LetterType()
        {
            string userAgent = Request.Headers["User-Agent"].ToString();
            string method = Request.Method.ToString();
            string userr = User?.Identity.Name;
            var lettertypeList = _smdps.Lettertype();
            var json = System.Text.Json.JsonSerializer.Serialize(lettertypeList);


            _logger.WriteRequest(userAgent);
            _logger.WriteKind(method);
            _logger.GetUser(userr);
            _logger.WriteResponse(json);

            return lettertypeList;
        }

    }
}