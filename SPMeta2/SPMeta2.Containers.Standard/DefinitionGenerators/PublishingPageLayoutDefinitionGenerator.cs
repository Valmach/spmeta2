﻿using System;
using System.Collections.Generic;
using System.IO;
using SPMeta2.BuiltInDefinitions;
using SPMeta2.Containers.Services.Base;
using SPMeta2.Definitions;
using SPMeta2.Enumerations;
using SPMeta2.Standard.Definitions;
using SPMeta2.Standard.Enumerations;
using SPMeta2.Syntax.Default;

namespace SPMeta2.Containers.Standard.DefinitionGenerators
{
    public class PublishingPageLayoutDefinitionGenerator : TypedDefinitionGeneratorServiceBase<PublishingPageLayoutDefinition>
    {
        public override DefinitionBase GenerateRandomDefinition(Action<DefinitionBase> action)
        {
            return WithEmptyDefinition(def =>
            {
                def.Title = Rnd.String();
                def.FileName = Rnd.String() + ".aspx";

                def.Description = Rnd.String();
                def.Content = Rnd.Bool()
                        ? PublishingPageLayoutTemplates.ArticleLeft :
                        PublishingPageLayoutTemplates.ArticleRight;

                def.AssociatedContentTypeId = Rnd.Bool()
                        ? BuiltInPublishingContentTypeId.WelcomePage
                        : BuiltInPublishingContentTypeId.ArticlePage;

                def.NeedOverride = true;
            });
        }

        public override IEnumerable<DefinitionBase> GetAdditionalArtifacts()
        {
            var sitePublishing = BuiltInSiteFeatures.SharePointServerPublishingInfrastructure
                               .Inherit(f =>
                               {
                                   f.Enable = true;
                               });

            var webPublishing = BuiltInWebFeatures.SharePointServerPublishing
                              .Inherit(f =>
                              {
                                  f.Enable = true;
                              });

            return new[] { sitePublishing, webPublishing };
        }

        public override DefinitionBase GetCustomParenHost()
        {
            return BuiltInListDefinitions.Calalogs.MasterPage.Inherit<ListDefinition>(def =>
            {
                def.RequireSelfProcessing = false;
            });
        }
    }
}
