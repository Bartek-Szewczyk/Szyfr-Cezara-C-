using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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


namespace Szyfr_Cezara
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();





        }


        public void Szyfruj()
        {
            char[] alphabet = new char[] { 'a', 'ą', 'b', 'c', 'ć', 'd', 'e', 'ę', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'ł', 'm', 'n', 'ń', 'o', 'ó', 'p', 'q', 'r', 's', 'ś', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'ź', 'ż' };

            int key = (int)slValue.Value;

            char[] znak = new char[] { '.', ',', '?', '!', '@' };

            string orginaltext = text1.Text.ToLower().Replace(" ", "").Replace(".", "").Replace(",", "").Trim(znak);




            char[] secretText = orginaltext.ToCharArray();


            char[] encryptedText = new char[secretText.Length];


            for (int i = 0; i < secretText.Length; i++)
            {

                char secretItem = secretText[i];
                int index = Array.IndexOf(alphabet, secretItem);
                int letterPosition = (index += key) % 35;
                char encriptedCharacter = alphabet[letterPosition];
                encryptedText[i] = encriptedCharacter;

            }

            string secretTextFinal = String.Join("", encryptedText);

            text2.Text = secretTextFinal;



        }


        public void btn1_Click(object sender, RoutedEventArgs e)
        {

            if (combobox1.Text == "Szyfrowanie")
            {
                if (slValue.Value == 0)
                {
                    MessageBox.Show("Klucz ma wartość 0, tekst jest taki sam", "Szyfr Cezara", MessageBoxButton.OK, MessageBoxImage.Information);
                    text2.Text = text1.Text;
                }
                else
                {
                    Szyfruj();
                }

            }
            else
            {
                if (slValue.Value == 0)
                {
                    MessageBox.Show("Klucz ma wartość 0, tekst jest taki sam", "Szyfr Cezara", MessageBoxButton.OK, MessageBoxImage.Information);
                    text2.Text = text1.Text;
                }
                else
                {
                    Deszyfrowanie();
                }

            }

        }

        private void Deszyfrowanie()
        {
            char[] alphabet = new char[] { 'ż', 'ź', 'z', 'y', 'x', 'w', 'v', 'u', 't', 'ś', 's', 'r', 'q', 'p', 'ó', 'o', 'ń', 'n', 'm', 'ł', 'l', 'k', 'j', 'i', 'h', 'g', 'f', 'ę', 'e', 'd', 'ć', 'c', 'b', 'ą', 'a' };

            int key = (int)slValue.Value;

            string orginaltext = text1.Text.ToLower().Replace(" ", "");

            char[] secretText = orginaltext.ToCharArray();

            char[] encryptedText = new char[secretText.Length];


            for (int i = 0; i < secretText.Length; i++)
            {

                char secretItem = secretText[i];
                int index = Array.IndexOf(alphabet, secretItem);
                int letterPosition = (index += key) % 35;
                char encriptedCharacter = alphabet[letterPosition];
                encryptedText[i] = encriptedCharacter;

            }

            string secretTextFinal = String.Join("", encryptedText);

            text2.Text = secretTextFinal;
        }

        private void btnclean_Click(object sender, RoutedEventArgs e)
        {
            Clean();
        }

        private void Clean()
        {

            text1.Text = "Wprowadz Tekst";
            text2.Text = "";
            slValue.Value = 0;
            encrypted.IsSelected = true;
        }
    }
}
