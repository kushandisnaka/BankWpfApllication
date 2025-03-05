using System.Text;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        
        BankDbContext db;
        public MainWindow()
        {
            InitializeComponent();

            db = new();
   
        }
        private void LoginBtn_click(object sender, RoutedEventArgs e)
        {

            string email = Email.Text;
            string password = pass.Password;

            var user = db.Users.ToList().Find(u => u.Email == email);
            if (user == null)
            {
                MessageBox.Show("User not found. Please sign up first.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (user.Password != password)
            {
                MessageBox.Show("Incorrect password. Try again.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (user.Email == email && user.Password == password)
            {
                MessageBox.Show("Login Successful");
            }


            var home = new Home();
            home.onTransferMoneyClick += (sender, e) =>
            {
                var transfer = new Transfer();
                transfer.onTransferClick += (sender, e) =>
                {

                    Content = home;

                };
                Content = transfer;
                
            };
            home.onBillPaymentClick += (sender, e) =>
            {
                var billPayment = new BillPayment();
                billPayment.onPayClick += (sender, e) =>
                {
                    Content = home;
                };
            Content = billPayment;
            };
            home.onLogOutClick += (sender, e) =>
            {
                var mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            };
            home.onDeleteClick += (sender, e) =>
            {
                var result = MessageBox.Show("Are you sure you want to delete your account? This action cannot be undone.",
                                      "Confirm Deletion",
                                      MessageBoxButton.YesNo,
                                      MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();

                    MessageBox.Show("Account deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                    var mainWindow = new MainWindow();
                    mainWindow.Show();
                    Close();
                }
                

            };
            home.onChangePasswordClick += (sender, e) =>
            {
                var change = new Change();
                change.onChangeClick += (sender, e) =>
                {
                   
                    Content = home;
                };
            Content =  change;
            };

            Content = home;
            
            
     
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string Email = EmailBox.Text;
            string Password = PasswordBox.Password;
            string ConfirmPassword = ConfirmPasswordBox.Password;
            string AccNumber = AccnumberBox.Text;
            string BankName = BankNameBox.Text;

            if (Password != ConfirmPassword)
            {
                MessageBox.Show("Passwords don't match!", "Passoword", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                MessageBox.Show("Login successful! Welcome to your account.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            }

            var User = new User() { 
                Email = Email, 
                Password = Password,
                Account = AccNumber,
                Bank = BankName
            };

            db.Add(User);
            db.SaveChanges();
            
               
        }

    }
}