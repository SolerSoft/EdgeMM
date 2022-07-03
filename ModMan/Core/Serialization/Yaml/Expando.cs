namespace ModMan.Core.Serialization.Yaml
{
    /// <summary>
    /// A base class for yaml data classes.
    /// </summary>
    /// <remarks>
    /// Using this base class ensures that data not explicitly serialized by the class isn't lost.
    /// </remarks>
    public class Expando : Dictionary<string, object>
    {
    }
}