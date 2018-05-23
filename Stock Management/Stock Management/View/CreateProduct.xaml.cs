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
				ProductViewModel.SelectedSupplier = s;

				
				SupplierEmail.Text = s.Email;
				SupplierAddress.Text = s.Address;
				SupplierPhone.Text = s.Phone;
			}
			else
			{
				// If SelectedSupplier is null, a new supplier is to be created
				//ProductViewModel.SelectedSupplier = null;
				
				
				
				/*
				 * CODE BELOW IS NOT USABLE
				 * Reason: Supplier should be created at Product Creation, not before
				 */

				// If user haven't selected a Supplier from the dropdown
				// Get the text from all Supplier textBoxes and create a new Supplier

				// Validate the Supplier 
				/*
				

				// Call the ICommand through the ProductViewModel
				ProductViewModel vm = (ProductViewModel) DataContext;

				if (vm.QuerySubmitSupplier.CanExecute(s))
				{
					// Execute the ICommand with <string>QueryText as param
					vm.QuerySubmitSupplier.Execute(s);
				}
				*/
			}
		}
	}
}
