using KeyVaultExample.Services;
using Microsoft.AspNetCore.Mvc;

namespace AzureSecrets.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class KeyVaultController : ControllerBase
    {
        private readonly ILogger<KeyVaultController> _logger;

        private readonly IConfiguration _configuration;

        private readonly IKeyVaultSecretManager _keyVaultSecterManager;
        

        public KeyVaultController(ILogger<KeyVaultController> logger, IConfiguration configuration, IKeyVaultSecretManager keyVaultSecterManager)
        {
            _logger = logger;
            _configuration = configuration;
            _keyVaultSecterManager = keyVaultSecterManager;
        }

        [HttpGet("GetKeyVaultSecrets")]
        public async Task<IActionResult> GetKeyVaultSecret(string secret)
        {
            var response = await _keyVaultSecterManager.GetSecretAsync(secret);
            return Ok(response);
        }

        [HttpGet("GetKeyVaultSecretFromConfiguration")]
        public async Task<IActionResult> GetKeyVaultSecretFromConfiguration(string secret)
        {
            var response = _configuration[secret];
            return Ok(response);
        }

    }
}

