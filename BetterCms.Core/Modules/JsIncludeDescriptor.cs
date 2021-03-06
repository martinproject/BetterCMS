﻿using System.Collections.Generic;

using BetterCms.Core.Modules.Projections;
using BetterCms.Core.Mvc.Extensions;

namespace BetterCms.Core.Modules
{
    /// <summary>
    /// Describes a JS file include.
    /// </summary>
    public class JsIncludeDescriptor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JsIncludeDescriptor" /> class.
        /// </summary>
        /// <param name="module">The container module.</param>
        /// <param name="name">The module name.</param>
        /// <param name="fileName">Name of the module file.</param>
        /// <param name="minFileName">Name of the minified file.</param>
        /// <param name="isAutoGenerated">if set to <c>true</c> then it indicates that this JS include file is auto generated and is not going to be minimized or loaded from CDN.</param>
        public JsIncludeDescriptor(ModuleDescriptor module, string name, string fileName = null, string minFileName = null, bool isAutoGenerated = false)
        {
            Links = new List<IActionProjection>();
            Globalization = new List<IActionProjection>();

            Module = module;
            Name = name;
            FileName = fileName ?? name + ".js";
            IsAutoGenerated = isAutoGenerated;
            Path = VirtualPath.Combine(module.JsBasePath, fileName ?? name + ".js");

            // If minFileName is not given then CMS will try to load it from a bcms.[module-name].min.js file.
            if (!string.IsNullOrEmpty(minFileName))
            {
                MinPath = VirtualPath.Combine(module.JsBasePath, minFileName);
            }
        }

        /// <summary>
        /// Gets or sets the server side container module.
        /// </summary>
        /// <value>
        /// The container module.
        /// </value>
        public ModuleDescriptor Module { get; private set; }

        /// <summary>
        /// Gets the name of the file.
        /// </summary>
        /// <value>
        /// The name of the file.
        /// </value>
        public string FileName { get; private set; }

        /// <summary>
        /// Gets or sets the name of the java script module (like bcms.page).
        /// </summary>
        /// <value>
        /// The name of the java script module.
        /// </value>
        public string Name { get; private set; }
        
        /// <summary>
        /// Gets the 'friendly' module name to use internally in java script.
        /// </summary>
        /// <value>
        /// The 'friendly' module name to use internally.
        /// </value>
        public string FriendlyName
        {
            get
            {                
                return Name.Replace(".", string.Empty);
            }
        }

        /// <summary>
        /// Gets or sets the JS include path (like '/file/bcms-pages/scripts/bcms.page').
        /// </summary>
        /// <value>
        /// The js module path.
        /// </value>
        public string Path { get; private set; }

        /// <summary>
        /// Gets path of the minified JS file if it was provided.
        /// </summary>
        /// <value>
        /// The path of the minified JS file if it was provided.
        /// </value>
        public string MinPath { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this JS include file is auto generated.
        /// </summary>
        /// <value>
        /// <c>true</c> if this JS include file is auto generated; otherwise, <c>false</c>.
        /// </value>
        public bool IsAutoGenerated { get; private set; }

        /// <summary>
        /// Gets or sets the url list.
        /// </summary>
        /// <value>
        /// The urls.
        /// </value>
        public IList<IActionProjection> Links { get; set; }

        /// <summary>
        /// Gets or sets the js globalization.
        /// </summary>
        /// <value>
        /// The js globalization.
        /// </value>
        public IList<IActionProjection> Globalization { get; set; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return Path;
        }
    }
}
