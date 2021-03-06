﻿using System;
using SPMeta2.BuiltInDefinitions;
using SPMeta2.Containers.Services.Base;
using SPMeta2.Definitions;
using SPMeta2.Models;
using SPMeta2.Standard.Definitions;
using SPMeta2.Standard.Definitions.DisplayTemplates;
using SPMeta2.Standard.Enumerations;
using SPMeta2.Syntax.Default;

namespace SPMeta2.Containers.Standard.DefinitionGenerators.DisplayTemplates
{
    public class FilterDisplayTemplateDefinitionGenerator : TypedDefinitionGeneratorServiceBase<FilterDisplayTemplateDefinition>
    {
        public override DefinitionBase GenerateRandomDefinition(Action<DefinitionBase> action)
        {
            return WithEmptyDefinition(def =>
            {
                def.FileName = string.Format("{0}.html", Rnd.String());
                def.Title = Rnd.String();

                def.Content = Rnd.Content();
            });
        }

        public override ModelNode GetCustomParenHost()
        {
            var definition = BuiltInListDefinitions.Catalogs.MasterPage.Inherit<ListDefinition>(def =>
            {

            });

            var node = new ListModelNode
            {
                Value = definition,
                Options = { RequireSelfProcessing = false }
            };

            return node;
        }
    }
}
