namespace ModMan.EdgeTX.Data
{
    /// <summary>
    /// Yaml serialization class for a list of models by category.
    /// </summary>
    /// <remarks>
    /// This is the outer format of models.yml in the MODELS folder. We can't serialize it directly because EgeTX used
    /// the category name as the key. The Yaml serializer expects the key to map to a property.
    /// </remarks>
    public class ModelsData : List<Dictionary<string, List<ModelReferenceData>>>
    {
    }
}