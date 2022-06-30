﻿using SharpYaml.Serialization;

namespace EdgeMM.Data
{
    /// <summary>
    /// Yaml serialization class to select a model.
    /// </summary>
    /// <remarks>
    /// This is the item format of models.yml in the MODELS folder.
    /// </remarks>
    internal class ModelReferenceData
    {
        #region Public Fields

        [YamlIgnore]
        public string Category;

        [YamlMember("filename")]
        public string FileName;

        [YamlIgnore]
        public bool IsTemplate;

        [YamlMember("name")]
        public string Name;

        #endregion Public Fields
    }
}