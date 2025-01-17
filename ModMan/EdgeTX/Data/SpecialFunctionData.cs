﻿using ModMan.Core.Serialization.Yaml;
using SharpYaml.Serialization;

namespace ModMan.EdgeTX.Data
{
    /// <summary>
    /// Data for an EdgeTX special function.
    /// </summary>
    public class SpecialFunctionData : Expando
    {
        #region Public Properties

        /// <summary>
        /// A comment about the function.
        /// </summary>
        /// <remarks>
        /// Note that EdgeTX does not currently support comments, but since it's yaml we can extend it.
        /// </remarks>
        [YamlMember("comment", 1)]
        public string Comment { get; set; }

        [YamlMember("def", 4)]
        public string Definition { get; set; }

        [YamlMember("func", 3)]
        public string Function { get; set; }

        /// <summary>
        /// The name of the special function.
        /// </summary>
        /// <remarks>
        /// Note that EdgeTX does not currently support this, but since it's yaml we can add it.
        /// </remarks>
        [YamlMember("name", 0)]
        public string Name { get; set; }

        [YamlMember("swtch", 2)]
        public string Switch { get; set; }

        #endregion Public Properties
    }
}