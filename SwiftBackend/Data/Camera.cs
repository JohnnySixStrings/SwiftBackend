namespace SwiftBackend.Data;

public class Camera
{
    public int CameraId { get; set; }
    public string Name { get; set; }
    public IList<Filter> Filters { get; set; }
    public IList<Lense> Lenses { get; set; }
    public Macro Macro { get; set; }
    public Zoom Zoom { get; set; }
}
