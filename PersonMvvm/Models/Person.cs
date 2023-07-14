using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonMvvm.Models
{
    public class Person : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        private int id;
        public int PersonId
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }
        private string firstname;
        public string FirstName
        {
            get { return firstname; }
            set { firstname = value; OnPropertyChanged("FirstName"); }
        }
        private string lastname;
        public string LastName
        {
            get { return lastname; }
            set { lastname = value; OnPropertyChanged("LastName"); }
        }
    }
}
