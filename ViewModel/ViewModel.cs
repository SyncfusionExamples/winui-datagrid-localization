using Microsoft.UI.Xaml.Data;
using Syncfusion.UI.Xaml.Data;
using Syncfusion.UI.Xaml.DataGrid;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Globalization.NumberFormatting;

namespace Localization
{
    public class ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<OrderInfo> _orders;
        public ObservableCollection<OrderInfo> Orders
        {
            get { return _orders; }
            set { _orders = value; }
        }
        public ViewModel()
        {
            _orders = new ObservableCollection<OrderInfo>();
            this.GenerateOrders();
        }

        private void GenerateOrders()
        {
            for (int i = 0; i < 3; i++)
            {
                _orders.Add(new OrderInfo() { OrderID = 1001, CustomerName = "Maria Anders", Country = "Germany", CustomerID = "ALFKI", UnitPrice = 107.28, IsDelivered = true }); ;
                _orders.Add(new OrderInfo() { OrderID = 1002, CustomerName = "Ana Trujilo", Country = "Mexico", CustomerID = "ANATR", UnitPrice = 360.78, IsDelivered = false });
                _orders.Add(new OrderInfo() { OrderID = 1003, CustomerName = "Antonio Moreno", Country = "Mexico", CustomerID = "ANTON", UnitPrice = 400.42, IsDelivered = true });
                _orders.Add(new OrderInfo() { OrderID = 1004, CustomerName = "Thomas Hardy", Country = "UK", CustomerID = "AROUT", UnitPrice = 107.15, IsDelivered = true });
                _orders.Add(new OrderInfo() { OrderID = 1005, CustomerName = "Christina Berglund", Country = "Sweden", CustomerID = "BERGS", UnitPrice = 203.78, IsDelivered = true });
                _orders.Add(new OrderInfo() { OrderID = 1006, CustomerName = null, Country = "Germany", CustomerID = "BLAUS", UnitPrice = 59.30, IsDelivered = false });
                _orders.Add(new OrderInfo() { OrderID = 1007, CustomerName = "Frederique Citeaux", Country = "France", CustomerID = "BLONP", UnitPrice = 107.00, IsDelivered = false });
                _orders.Add(new OrderInfo() { OrderID = 1008, CustomerName = "Martin Sommer", Country = "Spain", CustomerID = "BOLID", UnitPrice = 350.89, IsDelivered = true });
                _orders.Add(new OrderInfo() { OrderID = 1009, CustomerName = "Laurence Lebihan", Country = "France", CustomerID = "BONAP", UnitPrice = 200.96, IsDelivered = true });
                _orders.Add(new OrderInfo() { OrderID = 1010, CustomerName = "Elizabeth Lincoln", Country = "Canada", CustomerID = "BOTTM", UnitPrice = 540.43, IsDelivered = false });
            }
           
        }

        /// <summary>
        /// Used to set the system default currency to numeric column NumberFormatter.
        /// </summary>
        public CurrencyFormatter SystemCurrency
        {
            get
            {
                return new CurrencyFormatter(Windows.System.UserProfile.GlobalizationPreferences.Currencies[0]);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
    }

}
