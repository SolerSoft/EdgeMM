namespace EdgeMM.Data.Edge
{
    /// <summary>
    /// Yaml serialization class for a list of models by category.
    /// </summary>
    /// <remarks>
    /// This is the outer format of models.yml in the MODELS folder.
    /// </remarks>
    public class ModelsData : List<Dictionary<string, List<ModelReferenceData>>>
    {
    }
}