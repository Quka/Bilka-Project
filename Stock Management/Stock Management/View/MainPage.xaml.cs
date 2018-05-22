using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Stock_Management
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private List<Product> Suggestions = ProductCatalogSingleton.Instance.ProductList.ToList();

        public MainPage()
        {
            this.InitializeComponent();
            
        }
        

        private void AutoSuggestBox_TextChanged(AutoSuggestBox Sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                if (Sender.Text.Length>0)
                {
                    Sender.ItemsSource = GetSuggestions(Sender.Text);
                }
                else
                {
                    Sender.ItemsSource = Suggestions;
                }   
            }
            
        }

        
        private List<Product> GetSuggestions(string Text)
        {
            List<Product> result = null;

            result = Suggestions.Where(x => x.Name.Contains(Text)).ToList();

            return result;

        }

		private void SelectSuggestionProduct(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
		{

		}
	}
}
