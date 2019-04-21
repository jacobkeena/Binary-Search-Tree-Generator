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

namespace BinarySearchTree
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

        

        private void GenerateNumbers_Clicked(object sender, RoutedEventArgs e)
        {
            BST bst = new BST();
            Random rnd = new Random();
            int totalNumbers = 0;
            int minRange = 0;
            int maxRange = 0;

            if (string.IsNullOrEmpty(minBox.Text) || string.IsNullOrEmpty(maxBox.Text) || string.IsNullOrEmpty(numberAmount.Text))
            {
                MessageBox.Show("Each box must have a value", "Error", MessageBoxButton.OK);
                return;
            }


            try
            {
                totalNumbers = int.Parse(numberAmount.Text);
                minRange = int.Parse(minBox.Text);
                maxRange = int.Parse(maxBox.Text);
                if (totalNumbers < 1)
                {
                    MessageBox.Show("Please enter a whole number greater than 0 and less than 1,000,000,000.", "Error", MessageBoxButton.OK);
                    return;
                }
                //selectionRange = totalNumbers * 2; // I need a pool of numbers larger than the amount inside the tree
            }
            catch (FormatException)
            {
                MessageBox.Show("Amount a whole number greater than 0 and less than 1,000,000,000. ", "Error", MessageBoxButton.OK);
                return;
            }
            finally
            {
                for (uint i = 0; i < totalNumbers; i++)
                {
                    //randomly generate numbers within the selection range 
                    bst.AddNumber(rnd.Next(minRange, maxRange));
                }

                successMessage.Text = $"Binary tree successfully created with {totalNumbers} random values inserted";
                WriteToDisplayBox(bst.root);

            }
        }


        public void WriteToDisplayBox(Node node)
        {
            displayBSTBox.Text = "";
            if(node.Left == null)
            {
                displayBSTBox.Text += node.data.ToString() + " ";
            }
            else
            {
                WriteToDisplayBox(node.Left);
            }
            if(node.Right == null)
            {
                displayBSTBox.Text += node.data.ToString() + " ";
            }
            else
            {
                WriteToDisplayBox(node.Right);
            }
        }
    }


}
