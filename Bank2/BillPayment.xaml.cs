using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bank2
{
    /// <summary>
    /// Interaction logic for BillPayment.xaml
    /// </summary>
    public partial class BillPayment : Page
    {
        public event EventHandler<EventArgs>? onPayClick;
        public BillPayment()
        {
            InitializeComponent();
            DatePickerBox.SelectedDate = DateTime.Now;

        }
        private void PayBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Payment is successful.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            onPayClick?.Invoke(this, EventArgs.Empty);
        }
    }
}
