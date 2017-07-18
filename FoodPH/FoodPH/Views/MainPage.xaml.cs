using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using FoodPH.Views;
namespace FoodPH
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
        }

        private void Show_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FoodList());
        }

        private void Add_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddFood());
        }
    }
}
