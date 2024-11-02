using Microsoft.AspNetCore.Mvc;
using System.IO;

[ApiController]
[Route("api/[controller]")]
public class UploadController : ControllerBase
{
    private readonly IWebHostEnvironment _environment;

    public UploadController(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    [HttpPost("upload-image")]
    public async Task<IActionResult> UploadImage(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("No file was uploaded.");

        // Generate a unique file name to avoid overwriting existing files
        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

        // Define the path to save the image
        var filePath = Path.Combine(_environment.WebRootPath, "uploads", fileName);

        // Ensure the uploads folder exists
        Directory.CreateDirectory(Path.GetDirectoryName(filePath));

        // Save the file
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        // Construct the URL for the uploaded file
        var fileUrl = $"{Request.Scheme}://{Request.Host}/uploads/{fileName}";

        return Ok(new { Url = fileUrl });
    }
}