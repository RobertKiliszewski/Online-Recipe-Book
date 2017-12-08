using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Online_Recipe_Book
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private IMobileServiceTable<Recipes> recipesTable = App.MobileService.GetTable<Recipes>();
        private static MobileServiceCollection<Recipes, Recipes> recipes;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Recipes item = new Recipes
            {
                title = titleBox.Text,
                ingredients = ingredientsBox.Text ,
                steps = stepsBox.Text
            };
            await recipesTable.InsertAsync(item);
        }

        private async void Button_Click_1Async(object sender, RoutedEventArgs e)
        {
            recipes = await recipesTable.Take(5).ToCollectionAsync();
            this.Frame.Navigate(typeof(Display));
        }

        public static MobileServiceCollection<Recipes, Recipes> getRecipes()
        {
            return recipes;
        }
    }
}