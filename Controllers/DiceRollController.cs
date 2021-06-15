using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Dice.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DiceRollController : ControllerBase
    {
        private readonly ILogger<DiceRollController> _logger;

        public DiceRollController(ILogger<DiceRollController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public DiceRollResult Post(DiceRoll rolls)
        {
            DiceRollResult result = new DiceRollResult();
            result.sumOfRolls = 0;
            result.actualRolls = new List<int>();
            var rng = new Random();
            int rollValue = 0;

            _logger.LogInformation("Request received from IP: {0}", GetIp());

            for (int i = 0; i < rolls.numberOfRolls; i++)
            {
                rollValue = rng.Next(1, 7);

                result.actualRolls.Add(rollValue);
                result.sumOfRolls += rollValue;
            }

            return result;
        }

        [HttpGet]
        public int Get()
        {
            var roll = new Random();

            return roll.Next(1, 7);
        }

        public string GetIp()  
        {  
            string ip = HttpContext.Connection.RemoteIpAddress?.ToString();

            return ip;  
        }
    }
}