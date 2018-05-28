using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Stock_Management.Handler;
using Stock_Management.Viewmodel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Stock_Management.View
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class ProductView : Page
	{
		public ProductView()
		{
			this.InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
            
		}

		private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
		{

		}

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            DisplayDeleteFileDialog();
        }
	    private async void DisplayDeleteFileDialog()
	    {
	        ContentDialog deleteFileDialog = new ContentDialog
	        {
	            Title = "Delete file permanently?",
	            Content = "If you delete this file, you won't be able to recover it. Do you want to delete it?",
	            PrimaryButtonText = "Delete",
	            CloseButtonText = "Cancel",
                

	        };

	        
	        ContentDialogResult result = await deleteFileDialog.ShowAsync();

	        // Delete the file if the user clicked the primary button.
	        /// Otherwise, do nothing.
	        if (result == ContentDialogResult.Primary)
	        {

	            // Delete the file.
	            ProductViewModel vm = (ProductViewModel) DataContext;
	            if (vm.DeleteProductCommand.CanExecute(null))
	            {
	                vm.DeleteProductCommand.Execute(null);
	            }
	        }
	        else
	        {
	            // The user clicked the CLoseButton, pressed ESC, Gamepad B, or the system back button.
	            // Do nothing.
	        }
	    }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DisplayManualOrder();
        }

	    private async void DisplayManualOrder()
	    {
	        ProductViewModel vm = (ProductViewModel) DataContext;
	        ContentDialog manualOrder = new ContentDialog
	        {
	            Title = "How much do you wanna add?",
	            PrimaryButtonText = "Add",
	            CloseButtonText = "Cancel"

	        };
            TextBox inputTextBox = new TextBox();

            manualOrder.Content = inputTextBox;
	        ContentDialogResult result = await manualOrder.ShowAsync();


	        Binding amountBinding = new Binding
            {
                Source = vm,
                Path = new PropertyPath("OrderAmount"),
                Mode = BindingMode.TwoWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };

            inputTextBox.SetBinding(TextBox.TextProperty, amountBinding);


	        if (result == ContentDialogResult.Primary)
	        {
	            vm.ManualOrderCommand.CanExecute(null);
	            {
	                vm.ManualOrderCommand.Execute(null);
	            }
	        }
	        




	    }

        

	}
}
