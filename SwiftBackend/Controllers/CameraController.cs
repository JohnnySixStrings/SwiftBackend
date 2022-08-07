using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwiftBackend.Data;

namespace SwiftBackend.Controllers;

[Route("/")]
public class CameraController : ControllerBase
{
    private readonly ApplicationDbContext _db;
    public CameraController(ApplicationDbContext db)
    {
        _db = db;
    }

    [HttpGet("cameras/{id}")]
    public async Task<IActionResult> GetCameraAsync([FromRoute] int id)
    {
        var camera = await _db.Cameras
            .Select(c => new Camera
            {
                CameraId = c.CameraId,
                Name = c.Name,
                Filters = c.Filters,
                Lenses = c.Lenses,
                Macro = c.Macro,
                Zoom = c.Zoom,
            })
            .Where(c => c.CameraId == id)
            .FirstOrDefaultAsync();
        if (camera is null) return NotFound();
        return Ok(camera);
    }

    [HttpGet("cameras")]
    public async Task<IActionResult> GetCamerasAsync()
    {
        var cameras = await _db.Cameras
            .Select(c => new Camera
            {
                CameraId = c.CameraId,
                Name = c.Name,
                Filters = c.Filters,
                Lenses = c.Lenses,
                Macro = c.Macro,
                Zoom = c.Zoom,
            }).ToArrayAsync();
        return Ok(cameras);
    }

    [HttpPost("cameras")]
    public async Task<IActionResult> PostCameraAsync([FromBody] Camera camera)
    {
        await _db.Cameras.AddAsync(camera);
        await _db.SaveChangesAsync();
        return Created($"api/cameras/{camera.CameraId}", camera);
    }

    [HttpPut("cameras/{id}")]
    public async Task<IActionResult> PutCameraAsync([FromBody] Camera camera, [FromRoute] int id)
    {
        _db.Cameras.Update(camera);
        await _db.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("cameras/{id}")]
    public async Task<IActionResult> DeleteCameraAsync([FromRoute] int id)
    {
        var camera = await _db.Cameras.FindAsync(id);
        if (camera is null) return NotFound();
        _db.Cameras.Remove(camera);
        _db.SaveChangesAsync();
        return NoContent();
    }
}
