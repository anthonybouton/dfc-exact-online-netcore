using System;
using DataFunc.Integrations.ExactOnline.Infrastructure.Attributes;

namespace DataFunc.Integrations.ExactOnline.Items.Models
{
    [ExactOnlineResource("api/v1/{0}/logistics/Items")]
    public class ItemDetailModel
    {
        /// <summary>Barcode of the item (numeric string)</summary>
        public string Barcode { get; set; }
        /// <summary>Item code</summary>
        public string Code { get; set; }
        /// <summary>The currency of the current and proposed cost price</summary>
        public string CostPriceCurrency { get; set; }
        /// <summary>Proposed cost price</summary>
        public double? CostPriceNew { get; set; }
        /// <summary>The current standard cost price</summary>
        public double? CostPriceStandard { get; set; }
        /// <summary>Creation date</summary>
        public DateTime? Created { get; set; }
        /// <summary>User ID of creator</summary>
        public Guid? Creator { get; set; }
        /// <summary>Name of creator</summary>
        public string CreatorFullName { get; set; }
        /// <summary>Description of the item</summary>
        public string Description { get; set; }
        /// <summary>Division code</summary>
        public int? Division { get; set; }
        /// <summary>Together with StartDate this determines if the item is active</summary>
        public DateTime? EndDate { get; set; }
        /// <summary>Extra description text, slightly longer than the regular description (255 instead of 60)</summary>
        public string ExtraDescription { get; set; }
        /// <summary>GL account the cost entries will be booked on. This overrules the GL account from the item group. If the license contains &apos;Intuit integration&apos; this property overrides the value in Settings, not the item group.</summary>
        public Guid? GLCosts { get; set; }
        /// <summary>GL account the revenue will be booked on. This overrules the GL account from the item group. If the license contains &apos;Intuit integration&apos; this property overrides the value in Settings, not the item group.</summary>
        public Guid? GLRevenue { get; set; }
        /// <summary>GL account the stock entries will be booked on. This overrules the GL account from the item group. If the license contains &apos;Intuit integration&apos; this property overrides the value in Settings, not the item group.</summary>
        public Guid? GLStock { get; set; }
        /// <summary>Gross weight for international goods shipments</summary>
        public double? GrossWeight { get; set; }
        [ExactOnlinePrimaryKey]
        /// <summary>Primary key</summary>
        public Guid ID { get; set; }
        /// <summary>Indicates if batches are used for this item</summary>
        public byte IsBatchItem { get; set; }
        /// <summary>This property is obsolete. Use property &apos;IsBatchItem&apos; instead.</summary>
        public byte IsBatchNumberItem { get; set; }
        /// <summary>Indicates if fractions (for example 0.35) are allowed for quantities of this item</summary>
        public bool? IsFractionAllowedItem { get; set; }
        /// <summary>Indicates that an Item is produced to Inventory, not purchased</summary>
        public byte IsMakeItem { get; set; }
        /// <summary>Only used for packages (IsPackageItem=1). To indicate if this package is a new contract type package</summary>
        public byte IsNewContract { get; set; }
        /// <summary>Is On demand Item</summary>
        public byte IsOnDemandItem { get; set; }
        /// <summary>Indicates if the item is a package item. Can only be created in the hosting administration</summary>
        public bool? IsPackageItem { get; set; }
        /// <summary>Indicates if the item can be purchased</summary>
        public bool? IsPurchaseItem { get; set; }
        /// <summary>Indicated if the item is used in voucher functionality</summary>
        public byte IsRegistrationCodeItem { get; set; }
        /// <summary>Indicates if the item can be sold</summary>
        public bool? IsSalesItem { get; set; }
        /// <summary>Indicates that serial numbers are used for this item</summary>
        public bool? IsSerialItem { get; set; }
        /// <summary>This property is obsolete. Use property &apos;IsSerialItem&apos; instead.</summary>
        public bool? IsSerialNumberItem { get; set; }
        /// <summary>If you have the Trade or Manufacturing license and you check this property the item will be shown in the stock positions overview, stock counts and transaction lists. If you have the Invoice module and you check this property you will get a general journal entry based on the Stock and Costs G/L accounts of the item group. If you don’t want the general journal entry to be created you should change the Stock/Costs G/L account on the Item group page to the type Costs instead of Inventory.</summary>
        public bool? IsStockItem { get; set; }
        /// <summary>Indicates if the item is provided by an outside supplier</summary>
        public bool? IsSubcontractedItem { get; set; }
        /// <summary>Indicates if tax needs to be calculated for this item</summary>
        public byte? IsTaxableItem { get; set; }
        /// <summary>Indicates if the item is a time unit item (for example a labor hour item)</summary>
        public byte IsTime { get; set; }
        /// <summary>Indicates if the item can be exported to a web shop</summary>
        public byte IsWebshopItem { get; set; }
        /// <summary>GUID of Item group of the item</summary>
        public Guid? ItemGroup { get; set; }
        /// <summary>Net weight for international goods shipments</summary>
        public double? NetWeight { get; set; }
        /// <summary>Net Weight unit for international goods shipment, only available in manufacturing packages</summary>
        public string NetWeightUnit { get; set; }
        /// <summary>Notes</summary>
        public string Notes { get; set; }
        /// <summary>Code of SalesVat</summary>
        public string SalesVatCode { get; set; }
        /// <summary>Description of SalesVatCode</summary>
        public string SalesVatCodeDescription { get; set; }
        /// <summary>Search code of the item</summary>
        public string SearchCode { get; set; }
        /// <summary>Together with EndDate this determines if the item is active</summary>
        public DateTime? StartDate { get; set; }
        /// <summary>Quantity that is in stock</summary>
        public double? Stock { get; set; }
        /// <summary>The standard unit of this item</summary>
        public string Unit { get; set; }
        /// <summary>Type of unit: A=Area, L=Length, O=Other, T=Time, V=Volume, W=Weight</summary>
        public string UnitType { get; set; }
    }
}