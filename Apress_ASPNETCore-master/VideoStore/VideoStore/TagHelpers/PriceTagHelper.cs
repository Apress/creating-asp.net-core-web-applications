using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Globalization;

namespace VideoStore.TagHelpers
{
    [HtmlTargetElement("videoPrice")]
    public class PriceTagHelper : TagHelper
    {
        public double VideoPrice { get; set; }
        public string CultureName { get; set; }
        public string Label { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var ri = new RegionInfo(CultureName);
            var currencySymbol = ri.CurrencySymbol;
                        
            output.TagName = "div";
            var price = $"{Label}{currencySymbol}{VideoPrice}";
            _ = output.Content.SetContent(price);            
        }
    }
}



