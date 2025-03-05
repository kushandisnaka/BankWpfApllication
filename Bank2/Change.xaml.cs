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
    /// Interaction logic for Change.xaml
    /// </summary>
    
    public partial class Change : Page
    {

       

        BankDbContext db;
        public event EventHandler<EventArgs>? onChangeClick;
        public string UserName { get; set; }

        public Change(string username)
        {
            InitializeComponent();
            UserName = username;
            db = new();
          

        }
        private void ChangeBtn_Click(object sender, RoutedEventArgs e)
        {

            string currentPassword = CurrentPassword.Text;
            string newPassword = NewPassword.Text;
            string confirmNewPassword = ConfirmPassword1.Text;


            var user = db.Users.ToList().Find(u => u.Password == currentPassword && u.Email == UserName);


            //var user = db.Users.ToList().Find(u => u.Id == loggedInUser.Id);
            if (user == null)
            {
                MessageBox.Show("Incorrect current password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (newPassword != confirmNewPassword)
            {
                MessageBox.Show("New password and confirm password do not match.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            user.Password = newPassword;
            db.Users.Update(user);
            db.SaveChanges();
            MessageBox.Show("Password changed successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            onChangeClick?.Invoke(this, EventArgs.Empty);

        }
    }
    
}
