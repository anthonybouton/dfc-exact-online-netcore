using System;
using System.Collections.Generic;
using DataFunc.Integrations.ExactOnline.Infrastructure.Attributes;

namespace DataFunc.Integrations.ExactOnline.Projects.Models
{
    [ExactOnlineResource("api/v1/{0}/project/Projects")]
    public class ProjectDetailModel
    {

            /// <summary>The account for this project</summary>
            public Guid? Account { get; set; }
            /// <summary>Code of Account</summary>
            public string AccountCode { get; set; }
            /// <summary>Contact person of Account</summary>
            public Guid? AccountContact { get; set; }
            /// <summary>Name of Account</summary>
            public string AccountName { get; set; }
            /// <summary>Is additional invoice is allowed for project</summary>
            public bool? AllowAdditionalInvoicing { get; set; }
            /// <summary>Block time and cost entries</summary>
            public bool? BlockEntry { get; set; }
            /// <summary>Block rebilling</summary>
            public bool? BlockRebilling { get; set; }
            /// <summary>Budgeted amount of sales in the default currency of the company</summary>
            public double? BudgetedAmount { get; set; }
            /// <summary>Budgeted amount of costs in the default currency of the company</summary>
            public double? BudgetedCosts { get; set; }
            /// <summary>Budgeted amount of revenue in the default currency of the company</summary>
            public double? BudgetedRevenue { get; set; }
            /// <summary>BudgetOverrunHours: 10-Allowed, 20-Not Allowed</summary>
            public byte? BudgetOverrunHours { get; set; }
            /// <summary>Budget type</summary>
            public short? BudgetType { get; set; }
            /// <summary>Budget type description</summary>
            public string BudgetTypeDescription { get; set; }
            /// <summary>Used only for PSA to link a project classification to the project</summary>
            public Guid? Classification { get; set; }
            /// <summary>Description of Classification</summary>
            public string ClassificationDescription { get; set; }
            /// <summary>Code</summary>
            public string Code { get; set; }
            /// <summary>Used only for PSA to store the budgetted costs of a project (except for project type Campaign and Non-billable). Positive quantities only</summary>
            public double? CostsAmountFC { get; set; }
            /// <summary>Creation date</summary>
            public DateTime? Created { get; set; }
            /// <summary>User ID of creator</summary>
            public Guid? Creator { get; set; }
            /// <summary>Name of creator</summary>
            public string CreatorFullName { get; set; }
            /// <summary>Used only for PSA to store the customer&apos;s PO number</summary>
            public string CustomerPOnumber { get; set; }
            /// <summary>Description of the project</summary>
            public string Description { get; set; }
            /// <summary>Division code</summary>
            public int? Division { get; set; }
            /// <summary>Name of Division</summary>
            public string DivisionName { get; set; }
            /// <summary>End date of the project. In combination with the start date the status is determined</summary>
            public DateTime? EndDate { get; set; }
            /// <summary>Item used for fixed price invoicing. To be defined per project. If empty the functionality relies on the setting</summary>
            public Guid? FixedPriceItem { get; set; }
            /// <summary>Description of FixedPriceItem</summary>
            public string FixedPriceItemDescription { get; set; }
            [ExactOnlinePrimaryKey]
            /// <summary>Primary key</summary>
            public Guid ID { get; set; }
            /// <summary>Internal notes not to be printed in invoice</summary>
            public string InternalNotes { get; set; }

            /// <summary>Responsible person for this project</summary>
            public Guid? Manager { get; set; }
            /// <summary>Name of Manager</summary>
            public string ManagerFullname { get; set; }
            /// <summary>Purchase markup percentage</summary>
            public double? MarkupPercentage { get; set; }
            /// <summary>Last modified date</summary>
            public DateTime? Modified { get; set; }
            /// <summary>User ID of modifier</summary>
            public Guid? Modifier { get; set; }
            /// <summary>Name of modifier</summary>
            public string ModifierFullName { get; set; }
            /// <summary>For additional information about projects</summary>
            public string Notes { get; set; }
            /// <summary>Used only for PSA. This item is used for prepaid invoicing. If left empty, the functionality relies on a setting</summary>
            public Guid? PrepaidItem { get; set; }
            /// <summary>Description of PrepaidItem</summary>
            public string PrepaidItemDescription { get; set; }
            /// <summary>PrepaidType: 1-Retainer, 2-Hour type bundle</summary>
            public short? PrepaidType { get; set; }
            /// <summary>Description of PrepaidType</summary>
            public string PrepaidTypeDescription { get; set; }
            /// <summary>Collection of employee restrictions</summary>
            public double? SalesTimeQuantity { get; set; }
            /// <summary>Source quotation</summary>
      
            public Guid? SourceQuotation { get; set; }
            /// <summary>Start date of a project. In combination with the end date the status is determined</summary>
            public DateTime? StartDate { get; set; }
            /// <summary>Alert when exceeding (Hours)</summary>
            public double? TimeQuantityToAlert { get; set; }
            /// <summary>Reference to ProjectTypes</summary>
            public int? Type { get; set; }
            /// <summary>Description of Type</summary>
            public string TypeDescription { get; set; }
            /// <summary>Using billing milestones</summary>
            public bool? UseBillingMilestones { get; set; }
        }
}