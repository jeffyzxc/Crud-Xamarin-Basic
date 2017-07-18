using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Realms;

namespace FoodPH.Models
{
    public class FoodListModel : RealmObject
    {   
        [PrimaryKey]
        public int foodId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }
}
