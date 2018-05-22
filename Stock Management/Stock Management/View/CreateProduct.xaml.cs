using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Stock_Management.Model;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Stock_Management.View
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class CreateProduct : Page
	{
		public CreateProduct()
		{
			this.InitializeComponent();
		}

	    private List<Supplier> Suggestions = ProductCatalogSingleton.Instance.SupplierList.ToList();

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void TextBlock_SelectionChanged_1(object sender, RoutedEventArgs e)
        {

        }

        private void TextBlock_SelectionChanged_2(object sender, RoutedEventArgs e)
        {

        }

        private void TextBlock_SelectionChanged_3(object sender, RoutedEventArgs e)
        {

        }

        private void TextBlock_SelectionChanged_4(object sender, RoutedEventArgs e)
        {

        }
	    private void SupplierBox_OnTextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
	    {
	        if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
	        {
	            if (sender.Text.Length > 0)
	            {
	                sender.ItemsSource = GetSuggestions(sender.Text);
	            }
	            else
	            {
	                sender.ItemsSource = Suggestions;
	            }
	        }
        }
	    private List<Supplier> GetSuggestions(string Text)
	    {
	        List<Supplier> result = null;

	        result = Suggestions.Where(supplier => supplier.Name.Contains(Text)).ToList();

	        return result;
	    }

        private void TextBlock_SelectionChanged_5(object sender, RoutedEventArgs e)
        {

        }
    }
}
