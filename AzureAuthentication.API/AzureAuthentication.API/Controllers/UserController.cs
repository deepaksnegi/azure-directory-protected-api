using AzureAuthentication.API.Helper.TestData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace AzureAuthentication.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        #region Private Fields

        private readonly ILogger<UserController> _logger;

        #endregion

        #region Constructor

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Fetch all users. Currently users are bieng fetched from test data.
        /// </summary>
        /// <returns>users</returns>
        /// <response code="200">users</response>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(UserTestData.users);
        }

        /// <summary>
        /// Fetch a user which is matched to given guid
        /// </summary>
        /// <param name="guid">user guid</param>
        /// <returns>user</returns>
        /// <response code="200">user</response>
        /// <response code="400">if the user is not found</response>  
        [Route("{guid}")]
        [HttpGet]
        public IActionResult Get(string guid)
        {
            var user = UserTestData.users.SingleOrDefault(u => u.Guid.Equals(guid));

            if(user==null)
            {
                 return NotFound();
            }

            return Ok(user);
        }

        #endregion
    }
}
