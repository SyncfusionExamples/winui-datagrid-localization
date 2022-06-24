using Microsoft.UI.Xaml.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localization
{
    public class OrderInfo : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        int orderID;
        string customerId;
        string country;
        string customerName;
        double? unitPrice;
        bool isDelivered;
        private ObservableCollection<ProductInfo> productDetails;

        [Display(Name = "Order ID")]
        public int OrderID
        {
            get { return orderID; }
            set
            {
                orderID = value;
                OnPropertyChanged("OrderID");
            }
        }

        [Display(Name = "Customer ID")]
        public string CustomerID
        {
            get { return customerId; }
            set
            {
                customerId = value;
                OnPropertyChanged("CustomerID");
            }
        }

        [Display(Name = "Customer Name")]
        public string CustomerName
        {
            get { return customerName; }
            set
            {
                customerName = value;
                OnPropertyChanged("CustomerName");
            }
        }

        [Display(Name = "Countrys")]
        public string Country
        {
            get { return country; }
            set
            {
                country = value;
                OnPropertyChanged("Country");
            }
        }

        [Display(Name = "Unit Price")]
        public double? UnitPrice
        {
            get { return unitPrice; }
            set
            {
                unitPrice = value;
                OnPropertyChanged("UnitPrice");
            }
        }

        [Display(Name = "Wird geliefert")]
        public bool IsDelivered
        {
            get { return isDelivered; }
            set
            {
                isDelivered = value;
                OnPropertyChanged("IsDelivered");
            }
        }

        public ObservableCollection<ProductInfo> ProductDetails
        {
            get { return productDetails; }
            set { productDetails = value;
                OnPropertyChanged("ProductDetails");
            }
        }

        private List<string> errors = new List<string>();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        private void NotifyErrorsChanged(string propertyName)
        {
            if (ErrorsChanged != null)
                ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }

        public bool HasErrors
        {
            // get { return !emailRegex.IsMatch(this.EMail); }
            get
            {
                if (this.OrderID == 1003 || this.OrderID == 1004)
                    return true;
                return false;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

        IEnumerable INotifyDataErrorInfo.GetErrors(string propertyName)
        {
            if (!propertyName.Equals("OrderID"))
                return null;

            if (this.OrderID == 1003 || this.OrderID == 1004)
                errors.Add("Delivery not available for " + this.OrderID);
            return errors;
        }
    }
}
