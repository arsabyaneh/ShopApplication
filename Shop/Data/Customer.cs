using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data
{
    public class Customer : INotifyPropertyChanged
    {
        private long _ID;
        private string _Code;
        private string _FirstName;
        private string _LastName;
        private Gender _Gender;
        private DateTime _BirthDate;
        private string _Country;
        private string _Telephone;
        private string _Address;

        public ObjectState State { get; set; }

        public Customer()
        {
            State = ObjectState.New;
        }

        public long ID
        {
            get
            {
                return _ID;
            }
            set
            {
                long old = _ID;

                _ID = value;

                if (old != _ID)
                    this.OnPropertyChanged(new PropertyChangedEventArgs("ID"));
            }
        }

        public string Code
        {
            get
            {
                return _Code;
            }
            set
            {
                string old = _Code;

                _Code = value;

                if (old != _Code)
                    this.OnPropertyChanged(new PropertyChangedEventArgs("Code"));
            }
        }

        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                string old = _FirstName;

                _FirstName = value;

                if (old != _FirstName)
                    this.OnPropertyChanged(new PropertyChangedEventArgs("FirstName"));
            }
        }

        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                string old = _LastName;

                _LastName = value;

                if (old != _LastName)
                    this.OnPropertyChanged(new PropertyChangedEventArgs("LastName"));
            }
        }

        public Gender Gender
        {
            get
            {
                return _Gender;
            }
            set
            {
                Gender old = _Gender;

                _Gender = value;

                if (old != _Gender)
                    this.OnPropertyChanged(new PropertyChangedEventArgs("Gender"));
            }
        }

        public DateTime BirthDate
        {
            get
            {
                return _BirthDate;
            }
            set
            {
                DateTime old = _BirthDate;

                _BirthDate = value;

                if (old != _BirthDate)
                    this.OnPropertyChanged(new PropertyChangedEventArgs("BirthDate"));
            }
        }

        public string Country
        {
            get
            {
                return _Country;
            }
            set
            {
                string old = _Country;

                _Country = value;

                if (old != _Country)
                    this.OnPropertyChanged(new PropertyChangedEventArgs("Country"));
            }
        }

        public string Telephone
        {
            get
            {
                return _Telephone;
            }
            set
            {
                string old = _Telephone;

                _Telephone = value;

                if (old != _Telephone)
                    this.OnPropertyChanged(new PropertyChangedEventArgs("Telephone"));
            }
        }

        public string Address
        {
            get
            {
                return _Address;
            }
            set
            {
                string old = _Address;

                _Address = value;

                if (old != _Address)
                    this.OnPropertyChanged(new PropertyChangedEventArgs("Address"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (this.PropertyChanged == null)
                return;

            this.PropertyChanged(this, e);
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", FirstName, LastName);
        }

        public string FullName
        {
            get
            {
                return this.ToString();
            }
        }
    }
}
