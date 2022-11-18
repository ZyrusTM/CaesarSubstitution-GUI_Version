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
        private string _outputBoxContent;

        public MainWindow()
        {
            InitializeComponent();
            _outputBoxContent = "Output:";
            InitializeRichTextBoxContent();
        }

        private void CheckboxEncrypt_Checked(object sender, RoutedEventArgs e)
        {
            if(decCheckbox != null)
            {
                decCheckbox.IsChecked = false;
                startButton.Content = "Encrypt";
            }
        }

        private void CheckboxDecrypt_Checked(object sender, RoutedEventArgs e)
        {
            if(encCheckbox!= null)
            {
                encCheckbox.IsChecked = false;
                startButton.Content = "Decrypt";
            }
        }

        private void ClearTxtBox(object sender, RoutedEventArgs e)
        {
            inputBox.Clear();
        }

        private void ClearKeyBox(object sender, RoutedEventArgs e)
        {
            txtKey.Clear();
        }

        private void InitializeRichTextBoxContent()
        {
            FlowDocument flowDocument = new FlowDocument();

            Run run = new Run(_outputBoxContent);

            Paragraph paragraph= new Paragraph();
            paragraph.Inlines.Add(run);

            flowDocument.Blocks.Add(paragraph);
            outputBox.Document = flowDocument;
        }

        private void StartKrypto(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(txtKey.Text, out _))
            {
                MessageBox.Show("Error: An invalid key was entered! A valid Key is a number between 1 and 25");
                return;
            }

            if (inputBox.Text == null) 
            {
                MessageBox.Show("Error: No text was inserted into the Insert Box!");
                return;
            }

            if (txtKey.Text == null)
            {
                MessageBox.Show("Error: No Key was entered");
                return;
            }

            if ((bool)encCheckbox.IsChecked)
            {
                CaesarSubstitution caesarSubstitution = new CaesarSubstitution();
                caesarSubstitution.SetData(inputBox.Text, Convert.ToInt32(txtKey.Text));
                string encText = caesarSubstitution.Encrypt();
                _outputBoxContent = encText;
                InitializeRichTextBoxContent();
            }
            else if ((bool)decCheckbox.IsChecked)
            {
                CaesarSubstitution caesarSubstitution = new CaesarSubstitution();
                caesarSubstitution.SetData(inputBox.Text, Convert.ToInt32(txtKey.Text));
                string decText = caesarSubstitution.Decrypt();
                _outputBoxContent = decText;
                InitializeRichTextBoxContent();
            }
        }
    }
}
