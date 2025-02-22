namespace EosWebApi;

public enum Kind
{
    /// <summary>
    /// Main data (Default when kind is not designated)
    /// </summary>
    Main,

    /// <summary>
    /// Thumbnail image
    /// </summary>
    Thumbnail,

    /// <summary>
    /// Display image
    /// </summary>
    Display,

    /// <summary>
    /// Embedded image 
    /// * RAW only
    /// </summary>
    Embedded,

    // not used here
    // Info
}
