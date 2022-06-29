namespace EdgeMM.Data
{
    /// <summary>
    /// Yaml serialization class for a list of models by category.
    /// </summary>
    /// <remarks>
    /// This is the outer format of models.yml in the MODELS folder.
    /// </remarks>
    internal class ModelsData : List<Dictionary<string, List<ModelData>>>
    {
    }
}