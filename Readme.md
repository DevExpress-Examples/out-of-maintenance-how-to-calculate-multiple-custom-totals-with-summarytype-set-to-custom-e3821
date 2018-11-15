<!-- default file list -->
*Files to look at*:

* [Default.aspx](./CS/ASPxPivotGrid_MultipleCustomTotals/Default.aspx) (VB: [Default.aspx](./VB/ASPxPivotGrid_MultipleCustomTotals/Default.aspx))
* [Default.aspx.cs](./CS/ASPxPivotGrid_MultipleCustomTotals/Default.aspx.cs) (VB: [Default.aspx](./VB/ASPxPivotGrid_MultipleCustomTotals/Default.aspx))
<!-- default file list end -->
# How to calculate multiple Custom Totals with SummaryType set to Custom


<p>The following example demonstrates how to calculate and display multiple Custom Totals for a field.</p>
<br>
<p>In this example, two Custom Totals are implemented for the Category Name field. The first one displays a median calculated against summary values, while the second one displays the first and third quartiles.</p>
<br>
<p>To accomplish this task, we create two PivotGridCustomTotal objects and set their summary type to <a href="https://documentation.devexpress.com/#CoreLibraries/DevExpressDataPivotGridPivotSummaryTypeEnumtopic">PivotSummaryType.Custom</a>. We also assign the Custom Totals' names to <a href="https://documentation.devexpress.com/#CoreLibraries/DevExpressXtraPivotGridPivotGridCustomTotalBase_Tagtopic">PivotGridCustomTotalBase.Tag</a> properties to be able to distinguish between the Custom Totals when we calculate their values. Finally, we add the created objects to the Category Name field's <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxPivotGridPivotGridField_CustomTotalstopic">PivotGridField.CustomTotals</a> collection and enable the Custom Totals to be displayed for this field by setting the <a href="https://documentation.devexpress.com/#CoreLibraries/DevExpressXtraPivotGridPivotGridFieldBase_TotalsVisibilitytopic">PivotGridFieldBase.TotalsVisibility</a> property to <a href="https://documentation.devexpress.com/#CoreLibraries/DevExpressXtraPivotGridPivotTotalsVisibilityEnumtopic">PivotTotalsVisibility.CustomTotals</a>.</p>
<br>
<p>Custom Total values are actually calculated in the <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxPivotGridASPxPivotGrid_CustomCellValuetopic">ASPxPivotGrid.CustomCellValue</a> event. First, the event handler prepares a list of summary values against which a Custom Total will be calculated. For this purpose, it creates a summary datasource and copies the summary values to an array. After that, the array is sorted and passed to an appropriate method that calculates a median or quartile value against the provided array. Finally, the resulting value is assigned to the event parameter's <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxPivotGridPivotCellValueEventArgs_Valuetopic">PivotCellValueEventArgs.Value</a> property.</p>

<br/>


