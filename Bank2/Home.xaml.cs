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
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public event EventHandler<EventArgs>? onTransferMoneyClick;
        public event EventHandler<EventArgs>? onBillPaymentClick;
        public event EventHandler<EventArgs>? onLogOutClick;
        public event EventHandler<EventArgs>? onDeleteClick;
        public event EventHandler<EventArgs>? onChangePasswordClick;

        
        public Home()
        {
            InitializeComponent();
        }
        private void FundBtn_click(object sender, RoutedEventArgs e)
        {
            onTransferMoneyClick?.Invoke(this, EventArgs.Empty);
        }

        private void BillPayment_Click(object sender, RoutedEventArgs e)
        {
            onBillPaymentClick?.Invoke(this, EventArgs.Empty);
        }
        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            onLogOutClick?.Invoke(this, EventArgs.Empty);
        }
        private void DeletBtn_Click(object sender, RoutedEventArgs e)
        {
            onDeleteClick?.Invoke(this, EventArgs.Empty);

        }
        private void ChangePasswordBtn_Click(object sender, RoutedEventArgs e)
        {
            onChangePasswordClick?.Invoke(this, EventArgs.Empty);

        }

    }
     
}
