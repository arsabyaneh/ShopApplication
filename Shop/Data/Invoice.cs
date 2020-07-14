using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data
{
    public class Invoice : INotifyPropertyChanged
    {
        private long _ID;
        private string _Code;
        private DateTime _InvoiceDate;
        private decimal _Discount;
        private long _CustomerID;

        public ObjectState State { get; set; }

        public InvoiceItemCollection InvoiceItems { get; set; }

        public Invoice()
        {
            State = ObjectState.New;
            InvoiceItems = new InvoiceItemCollection();
            InvoiceItems.CollectionChanged += InvoiceItems_CollectionChanged;
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

        public DateTime InvoiceDate
        {
            get
            {
                return _InvoiceDate;
            }
            set
            {
                DateTime old = _InvoiceDate;

                _InvoiceDate = value;

                if (old != _InvoiceDate)
                    this.OnPropertyChanged(new PropertyChangedEventArgs("InvoiceDate"));
            }
        }

        public decimal Discount
        {
            get
            {
                return _Discount;
            }
            set
            {
                decimal old = _Discount;

                _Discount = value;

                if (old != _Discount)
                    this.OnPropertyChanged(new PropertyChangedEventArgs("Discount"));
            }
        }

        public long CustomerID
        {
            get
            {
                return _CustomerID;
            }
            set
            {
                long old = _CustomerID;

                _CustomerID = value;

                if (old != _CustomerID)
                    this.OnPropertyChanged(new PropertyChangedEventArgs("CustomerID"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (this.PropertyChanged == null)
                return;

            this.PropertyChanged(this, e);
        }

        private void InvoiceItems_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                foreach(var item in e.OldItems)
                {
                    if ( (item as InvoiceItem).State != ObjectState.New )
                        InvoiceItems.RemovedInvoiceItems.Add((InvoiceItem)item);
                }
            }
        }
    }
}
