using System.Collections.Generic;

namespace Constants
{
    public static class CompanyMultiselectFields
    {
        public const string JobIndustry = SmartTypes.JobIndustry;
        public const string CandidateJobIndustry = nameof(CandidateJobIndustry);

        public static Dictionary<string, string> FieldSmartTypes = new()
        {
            {JobIndustry, SmartTypes.JobIndustry},
            {CandidateJobIndustry, SmartTypes.JobIndustry}
        };
    }
}