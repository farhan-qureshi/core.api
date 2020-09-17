using System;

namespace core.api.commerce.Models
{
    public class SuccessResponse
    {
        /// <summary>
        /// Entity Id
        /// </summary>
        /// <example>1</example>
        public int? Id { get; set; }

        /// <summary>
        /// Company Id
        /// </summary>
        /// <example>755</example>
        public int CompanyId { get; set; }

        /// <summary>
        /// Last updated date time ISO format 
        /// </summary>
        /// <example>2019-11-07T13:23.0001</example>
        public DateTime LastUpdatedDateTime { get; set; }

        /// <summary>
        /// Created date time ISO format 
        /// </summary>
        /// <example>2019-11-07T13:23.0001</example>
        public DateTime CreatedDateTime { get; set; }

    }
}
