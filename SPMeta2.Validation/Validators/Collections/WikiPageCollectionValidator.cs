﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPMeta2.Definitions;
using SPMeta2.Validation.Common;

namespace SPMeta2.Validation.Validators.Collections
{
    public class WikiPageCollectionValidator : CollectionValidatorBase<WikiPageDefinition>
    {
        public override void Validate(List<WikiPageDefinition> model, List<ValidationResult> result)
        {
            CheckIfUnique(model, m => m.FileName, result);
        }
    }
}
