using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodPH.Models;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Realms;
using Xamarin.Forms;
using FoodPH.Views;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace FoodPH.ViewModels
{
    public class FoodListViewModel : INotifyPropertyChanged
    {


        Realm _realm = Realm.GetInstance();
        
        private ObservableCollection<FoodListModel> _listOfFood = new ObservableCollection<FoodListModel>();

        public ObservableCollection<FoodListModel> ListOfFood
        {
            get { return _listOfFood; }
            set { _listOfFood = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<T> ToObservableCollection<T>(IEnumerable<T> enumeration)
        {
            return new ObservableCollection<T>(enumeration);
        }


        private FoodListModel _foodDetails = new FoodListModel();

        public FoodListModel FoodListModel
        {
            
            get { return _foodDetails; }
            set { _foodDetails = value;
                OnPropertyChanged();
            }
        }

        public FoodListViewModel()
        {
            
            ListOfFood = new ObservableCollection<FoodListModel>(_realm.All<FoodListModel>().ToList());
        }

        //CRUD FOR FOOD PH

        public Command AddFood
        {
            get
            {
                return new Command(() =>
                {
                    _foodDetails.foodId = _realm.All<FoodListModel>().Count() + 1;

                    _realm.Write(() =>
                    {
                        _realm.Add(_foodDetails);
                    });
                    var add = new AddFood();
                    add.DisplayAlert("Added", "Successfully Added", "Okay");
                });
            }

        }
        //listView Click
        public Command openUpdateFood
        {
            get
            {
                return new Command<FoodListModel>( async (e) =>
                {

                    FoodListModel = new FoodListModel
                    {
                        foodId = e.foodId,
                        description = e.description,
                        title = e.title
                    };


                    OnPropertyChanged();
                    var updateFood = new updateFood();
                    updateFood.BindingContext = this;
                    await App.Current.MainPage.Navigation.PushAsync(updateFood);
                });
            }
        }

        public Command updateFood
        {
            get
            {
                return new Command(() =>
                {
                    var FoodUpdate = new FoodListModel
                    {
                        foodId = _foodDetails.foodId,
                        description = _foodDetails.description,
                        title = _foodDetails.title
                    };

                    _realm.Write(() =>
                    {
                        _realm.Add(FoodUpdate, update: true);

                    });
                    var updateFood = new updateFood();
                    updateFood.DisplayAlert("Updated", "Successfully Updated", "Okay");
                });
            }
        }



        public Command deleteFood
        {
            get
            {
                return new Command<FoodListModel>((e) =>
                {

                    var getfoodid = _realm.All<FoodListModel>().First(x => x.foodId == e.foodId); 

                    using (var transanction = _realm.BeginWrite())
                    {
                        _realm.Remove(getfoodid);
                        transanction.Commit();
                    }
                    ListOfFood = new ObservableCollection<FoodListModel>(_realm.All<FoodListModel>().ToList());
                    OnPropertyChanged();
                    var deleteFood = new FoodList();
                    deleteFood.DisplayAlert("Deleted", "Successfully Deleted", "Okay");
                });
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
