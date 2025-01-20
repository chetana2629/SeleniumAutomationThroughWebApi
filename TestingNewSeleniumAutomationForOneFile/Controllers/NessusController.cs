using Microsoft.AspNetCore.Mvc;
using TestingNewSeleniumAutomationForOneFile.Services;

[ApiController]
[Route("api/[controller]")]
public class NessusController : ControllerBase
{
    private readonly NessusAutomationService _nessusService;

    // Constructor dependency injection for NessusAutomationService
    public NessusController(NessusAutomationService nessusService)
    {
        _nessusService = nessusService ?? throw new ArgumentNullException(nameof(nessusService));
    }

    // Endpoint to launch the Nessus scan
    [HttpPost("launch-scan")]
    public IActionResult LaunchScan([FromBody] ScanRequest request)
    {
        if (request == null)
        {
            return BadRequest(new { message = "Invalid scan request." });
        }

        try
        {
            // Call the service method to create the scan
            _nessusService.CreateScan(request.Name, request.Description, request.Target);

            // Return success response
            return Ok(new { message = "Scan launched successfully!" });
        }
        catch (Exception ex)
        {
            // Return internal server error with exception message
            return StatusCode(500, new { message = "An error occurred while launching the scan.", error = ex.Message });
        }
    }
}

// DTO for ScanRequest to specify the structure of incoming request
public class ScanRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Target { get; set; }
}
