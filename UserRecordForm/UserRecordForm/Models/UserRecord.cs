using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UserRecordForm.Models
{
    
    public class UserRecord
    {
        public Nullable<int> userId { get; set; }
        public string email { get;set;}
        public string username  { get; set; }
        public string password { get; set; }
        public string mnumber { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address   { get; set; }   

        public string dropdownCity { get; set; }   
        public Nullable<System.DateTime> dob { get; set; }  
        
        public int age { get; set; }  
        public int ssc_total_mark { get; set; }  
        public int ssc_obtained_mark { get; set; }  
        public float percentage_ssc { get; set; }
        public List<UserRecord> showAllRecords { get; set; }

        public List<UserRecord> sortedList { get; set; }


    }
}
/*
namespace UserRecordForm.Models
{
    using System;
    using System.Collections.Generic;

    public partial class UserRec1
    {
        public int userId { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string mnumber { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string dropdownCity { get; set; }
        public Nullable<System.DateTime> dob { get; set; }
        public Nullable<int> age { get; set; }
        public Nullable<int> ssc_total_mark { get; set; }
        public Nullable<int> ssc_obtained_mark { get; set; }
        public Nullable<decimal> percentage_ssc { get; set; }
        public List<UserRec1> showAllRecords { get; set; }


    }
}*/
