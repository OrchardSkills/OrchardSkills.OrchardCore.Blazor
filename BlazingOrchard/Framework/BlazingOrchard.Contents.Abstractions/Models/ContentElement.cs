﻿using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BlazingOrchard.Contents.Models
{
    /// <summary>
    /// Common traits of <see cref="ContentItem"/>, <see cref="ContentPart"/>
    /// and <see cref="ContentField"/>
    /// </summary>
    public class ContentElement : IContent
    {
        private Dictionary<string, ContentElement>? _elements;

        protected ContentElement() : this(new JObject())
        {
        }

        protected ContentElement(JObject data)
        {
            Data = data;
        }

        [JsonIgnore]
        protected internal Dictionary<string, ContentElement> Elements =>
            _elements ??= new Dictionary<string, ContentElement>();

        [JsonIgnore] public dynamic Content => Data;
        [JsonIgnore] public JObject Data { get; set; }
        [JsonIgnore] public ContentItem ContentItem { get; set; } = default!;

        /// <summary>
        /// Whether the content has a named property or not.
        /// </summary>
        /// <param name="name">The name of the property to look for.</param>
        public bool Has(string name) => Data.ContainsKey(name);
    }
}