using System.Collections;
using DevExpress.Data.PivotGrid;
using DevExpress.Web.ASPxPivotGrid;
using DevExpress.XtraPivotGrid;

namespace ASPxPivotGrid_MultipleCustomTotals {
    public partial class _Default : System.Web.UI.Page {
        protected void ASPxPivotGrid1_Load(object sender, System.EventArgs e) {
            if (IsCallback || IsPostBack) return;

            // Creates a PivotGridCustomTotal object that defines the Median Custom Total.
            PivotGridCustomTotal medianCustomTotal = new PivotGridCustomTotal(PivotSummaryType.Custom);

            // Specifies a unique PivotGridCustomTotal.Tag property value 
            // that will be used to distinguish between two Custom Totals.
            medianCustomTotal.Tag = "Median";

            // Specifies formatting settings that will be used to display
            // Custom Total column/row headers.
            medianCustomTotal.Format.FormatString = "{0} Median";
            medianCustomTotal.Format.FormatType = DevExpress.Utils.FormatType.Custom;

            // Adds the Median Custom Total for the Category Name field.
            fieldCategoryName.CustomTotals.Add(medianCustomTotal);


            // Creates a PivotGridCustomTotal object that defines the Quartiles Custom Total.
            PivotGridCustomTotal quartileCustomTotal = new PivotGridCustomTotal(PivotSummaryType.Custom);

            // Specifies a unique PivotGridCustomTotal.Tag property value 
            // that will be used to distinguish between two Custom Totals.
            quartileCustomTotal.Tag = "Quartiles";

            // Specifies formatting settings that will be used to display 
            // Custom Total column/row headers.
            quartileCustomTotal.Format.FormatString = "{0} Quartiles";
            quartileCustomTotal.Format.FormatType = DevExpress.Utils.FormatType.Custom;

            // Adds the Quartiles Custom Total for the Category Name field.
            fieldCategoryName.CustomTotals.Add(quartileCustomTotal);


            // Enables the Custom Totals to be displayed instead of Automatic Totals.
            fieldCategoryName.TotalsVisibility = PivotTotalsVisibility.CustomTotals;
        }

        // Handles the CustomCellValue event. 
        // Fires for each data cell. If the processed cell is a Custom Total,
        // provides an appropriate Custom Total value.
        protected void ASPxPivotGrid1_CustomCellValue(object sender, PivotCellValueEventArgs e) {

            // Exits if the processed cell does not belong to a Custom Total.
            if (e.ColumnCustomTotal == null && e.RowCustomTotal == null) return;
            
            // Obtains a list of summary values against which
            // the Custom Total will be calculated.
            ArrayList summaryValues = GetSummaryValues(e);

            // Obtains the name of the Custom Total that should be calculated.
            string customTotalName = GetCustomTotalName(e);

            // Calculates the Custom Total value and assigns it to the Value event parameter.
            e.Value = GetCustomTotalValue(summaryValues, customTotalName);
        }

        // Returns the Custom Total name.
        private string GetCustomTotalName(PivotCellValueEventArgs e) {
            return e.ColumnCustomTotal != null ?
                e.ColumnCustomTotal.Tag.ToString() :
                e.RowCustomTotal.Tag.ToString();
        }

        // Returns a list of summary values against which
        // a Custom Total will be calculated.
        private ArrayList GetSummaryValues(PivotCellValueEventArgs e) {
            ArrayList values = new ArrayList();

            // Creates a summary data source.
            PivotSummaryDataSource sds = e.CreateSummaryDataSource();

            // Iterates through summary data source records
            // and copies summary values to an array.
            for (int i = 0; i < sds.RowCount; i++) {
                object value = sds.GetValue(i, e.DataField);
                if (value == null) {
                    continue;
                }
                values.Add(value);
            }

            // Sorts summary values.
            values.Sort();

            // Returns the summary values array.
            return values;
        }

        // Returns the Custom Total value by an array of summary values.
        private object GetCustomTotalValue(ArrayList values, string customTotalName) {

            // Returns a null value if the provided array is empty.
            if (values.Count == 0) {
                return null;
            }

            // If the Median Custom Total should be calculated,
            // calls the GetMedian method.
            if (customTotalName == "Median") {
                return GetMedian(values);
            }

            // If the Quartiles Custom Total should be calculated,
            // calls the GetQuartiles method.
            if (customTotalName == "Quartiles") {
                return GetQuartiles(values);
            }

            // Otherwise, returns a null value.
            return null;
        }

        // Calculates a median for the specified sorted sample.
        private decimal GetMedian(ArrayList values) {
            if ((values.Count % 2) == 0) {
                return ((decimal)(values[values.Count / 2 - 1]) +
                    (decimal)(values[values.Count / 2])) / 2;
            }
            else {
                return (decimal)values[values.Count / 2];
            }
        }

        // Calculates the first and third quartiles for the specified sorted sample
        // and returns them inside a formatted string.
        private string GetQuartiles(ArrayList values) {
            ArrayList part1 = new ArrayList();
            ArrayList part2 = new ArrayList();
            if ((values.Count % 2) == 0) {
                part1 = values.GetRange(0, values.Count / 2);
                part2 = values.GetRange(values.Count / 2, values.Count / 2);
            }
            else {
                part1 = values.GetRange(0, values.Count / 2 + 1);
                part2 = values.GetRange(values.Count / 2, values.Count / 2 + 1);
            }
            return string.Format("({0}, {1})",
                GetMedian(part1).ToString("c2"),
                GetMedian(part2).ToString("c2"));
        }
    }
}
