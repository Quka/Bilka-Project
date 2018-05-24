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
using Stock_Management.Viewmodel;

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
				if (args.CheckCurrent())
				{
					sender.ItemsSource = Suggestions.Where(s => s.Name.ToUpper().Contains(sender.Text.ToUpper())).ToList();
				}
			}
		}

		private void SupplierBox_OnQuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
		{
			if (args.ChosenSuggestion != null)
			{
				Supplier s = (Supplier) args.ChosenSuggestion;

				SupplierEmail.Text = s.Email;
				SupplierAddress.Text = s.Address;
				SupplierPhone.Text = s.Phone;
			}
		}
	}
}
