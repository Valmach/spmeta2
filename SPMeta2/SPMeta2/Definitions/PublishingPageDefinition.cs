﻿using SPMeta2.Attributes;
using SPMeta2.Attributes.Regression;
using System;
namespace SPMeta2.Definitions
{

    /// <summary>
    /// Allows to define and deploy SharePoint publishing page.
    /// </summary>
    /// 

    [SPObjectTypeAttribute(SPObjectModelType.SSOM, "Microsoft.SharePoint.SPFile", "Microsoft.SharePoint")]
    [SPObjectTypeAttribute(SPObjectModelType.CSOM, "Microsoft.SharePoint.Client.File", "Microsoft.SharePoint.Client")]

    [DefaultRootHostAttribute(typeof(SiteDefinition))]
    [DefaultParentHostAttribute(typeof(ListDefinition))]

    [Serializable]

    public class PublishingPageDefinition : PageDefinitionBase
    {
        #region properties

        /// <summary>
        /// Page layout name of the target publishing page.
        /// </summary>
        /// 
        [ExpectValidation]
        public string PageLayoutFileName { get; set; }

        /// <summary>
        /// Description of the target publishing page.
        /// </summary>
        /// 
        [ExpectValidation]
        public string Description { get; set; }

        /// <summary>
        /// Content of the target publishing page.
        /// </summary>
        public string Content { get; set; }

        #endregion

        #region methods

        public override string ToString()
        {
            return string.Format("Title:[{0}] FileName:[{1}] PageLayoutFileName:[{2}]",
                new[] { Title, FileName, PageLayoutFileName });
        }

        #endregion
    }
}
