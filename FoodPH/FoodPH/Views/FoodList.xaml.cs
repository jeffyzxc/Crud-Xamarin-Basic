using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodPH.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;


namespace FoodPH.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FoodList : ContentPage
    {
        FoodListViewModel _FoodList;
       
        public FoodList()
        {
            InitializeComponent();
            //_FoodList = new FoodListViewModel();
           // FoodListView.ItemsSource = _FoodList.ListOfFood;
           
          
        }

    }
}