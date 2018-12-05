﻿using SilveR.StatsModels;
using System;
using System.Collections.Generic;

namespace SilveR.Validators
{
    public class OneWayANOVADatasetBasedInputsValidator : ValidatorBase
    {
        private readonly OneWayANOVADatasetBasedInputsModel owVariables;

        public OneWayANOVADatasetBasedInputsValidator(OneWayANOVADatasetBasedInputsModel ow)
            : base(ow.DataTable)
        {
            owVariables = ow;
        }

        public override ValidationInfo Validate()
        {
            //go through all the column names, if any are numeric then stop the analysis
            List<string> allVars = new List<string>();
            allVars.Add(owVariables.Treatment);
            allVars.Add(owVariables.Response);

            if (!CheckColumnNames(allVars))
                return ValidationInfo;

            if (!CheckFactorsHaveLevels(owVariables.Treatment))
                return ValidationInfo;

            //Check that the response does not contain non-numeric 
            if (!CheckIsNumeric(owVariables.Response))
            {
                ValidationInfo.AddErrorMessage("The response variable selected (" + owVariables.Response + ") contains non-numerical data that cannot be processed. Please check raw data and make sure the data was entered correctly.");
                return ValidationInfo;
            }

            if (!String.IsNullOrEmpty(owVariables.Treatment))
            {
                if (!CheckResponsesPerLevel(owVariables.Treatment, owVariables.Response, ReflectionExtensions.GetPropertyDisplayName<OneWayANOVADatasetBasedInputsModel>(i => i.Treatment)))
                    return ValidationInfo;
            }

            if (!String.IsNullOrEmpty(owVariables.Treatment) && !String.IsNullOrEmpty(owVariables.Response)) //if a treat and response is selected...
            {
                //Check that the number of responses for each level is at least 2
                Dictionary<string, int> levelResponses = ResponsesPerLevel(owVariables.Treatment, owVariables.Response);
                foreach (KeyValuePair<string, int> level in levelResponses)
                {
                    if (level.Value < 2)
                    {
                        //ValidationInfo.AddErrorMessage("There is no replication in one or more of the levels of the treatment factor. Please select another factor.");
                        ValidationInfo.AddErrorMessage("There is no replication in one or more of the levels of the treatment factor (" + owVariables.Treatment + ").  Please amend the dataset prior to running the analysis.");
                        return ValidationInfo;
                    }
                }

                //check response and doses contain values
                if (!CheckFactorAndResponseNotBlank(owVariables.Treatment, owVariables.Response, "treatment factor")) return ValidationInfo;
            }
            else if (String.IsNullOrEmpty(owVariables.Treatment) && !String.IsNullOrEmpty(owVariables.Response))
            //if only a response selected (doing absolute change) then check that more than 1 value is in the dataset!
            {
                if (CountResponses(owVariables.Response) == 1)
                {
                    ValidationInfo.AddErrorMessage("The response selected (" + owVariables.Response + ") contains only 1 value. Please select another factor.");
                    return ValidationInfo;
                }
            }

            //if get here then no errors so return true
            return ValidationInfo;
        }
    }
}