using System;
using System.Collections.Generic;
using System.Linq;
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

namespace CaesarSubstitution_GUI_Version
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string ButtonText;
        public ICommand ButtonTextCommand;

        public MainWindow()
        {
            InitializeComponent();
            ButtonText = "Encrypt";

        }

        public void AddOutputText()
        {
            
        }

        private void CheckboxEncrypt_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
