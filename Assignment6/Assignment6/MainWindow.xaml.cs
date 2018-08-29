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
using Microsoft.Win32;
using System.IO;
using System.Text.RegularExpressions;

namespace Assignment6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //the list of the data that we read from the text file
        List<string> listOfDatas = new List<string>();
        //the information of that reads from the textfile (but not the grid)
        InvoiceInformation info;
        //handles the count of the discount
        Manager manager = new Manager();

        public MainWindow()
        {
            InitializeComponent();
            info = new InvoiceInformation();
            GenerateDataToDataGrid();
            InitializeGUI();
        }
        /// <summary>
        /// Initilialize the GUI
        /// the Total and the AMount to pay textboxes needs to be read only
        /// </summary>
        void InitializeGUI()
        {
            txtBox_AmountToPayNumber.IsReadOnly = true;
            txtBox_Total.IsReadOnly = true;
        }

        /// <summary>
        /// Create the Datagrid and its columns
        /// </summary>
        private void GenerateDataToDataGrid()
        {
            DataGridTextColumn col1 = new DataGridTextColumn();
            DataGridTextColumn col2 = new DataGridTextColumn();
            DataGridTextColumn col3 = new DataGridTextColumn();
            DataGridTextColumn col4 = new DataGridTextColumn();
            DataGridTextColumn col5 = new DataGridTextColumn();
            DataGridTextColumn col6 = new DataGridTextColumn();
            DataGridTextColumn col7 = new DataGridTextColumn();

            dataGrid_ProductDetails.Columns.Add(col1);
            dataGrid_ProductDetails.Columns.Add(col2);
            dataGrid_ProductDetails.Columns.Add(col3);
            dataGrid_ProductDetails.Columns.Add(col4);
            dataGrid_ProductDetails.Columns.Add(col5);
            dataGrid_ProductDetails.Columns.Add(col6);
            dataGrid_ProductDetails.Columns.Add(col7);

            col1.Binding = new Binding("Item");
            col2.Binding = new Binding("Description");
            col3.Binding = new Binding("Quantity");
            col4.Binding = new Binding("UnitPrice");
            col5.Binding = new Binding("Tax");
            col6.Binding = new Binding("TotalTax");
            col7.Binding = new Binding("Total");

            col1.Header = "Item ID";
            col2.Header = "Description";
            col3.Header = "Quantity";
            col4.Header = "Unit Price";
            col5.Header = "Tax (%)";
            col6.Header = "Total Tax";
            col7.Header = "Total";
        }

        /// <summary>
        /// Iamge Loading
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void load_image_button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "jpg files (*.jpg)|*.jpg";
            if (dlg.ShowDialog() == true)
            {
                logo_image.Source = new BitmapImage(new Uri(dlg.FileName));
            }
        }

        /// <summary>
        /// Load a text file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void load_in_file_button_Click(object sender, RoutedEventArgs e)
        {
            listOfDatas.Clear();
            StreamReader sr;
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = "c:\\";
            dlg.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            dlg.FilterIndex = 2;
            dlg.RestoreDirectory = true;
            string line;
            if (dlg.ShowDialog() == true)
            {
                string file = dlg.FileName;
                try
                {
                    using (sr = new StreamReader(file))
                    {
                        //read the text file line by line and add it to a list
                        while (!sr.EndOfStream && (line = sr.ReadLine()) != null)
                        {
                            listOfDatas.Add(line);
                        }
                    }
                    sr.Close();

                    //set the datas 
                    info.InvoceNumber = listOfDatas[0];
                    info.InvoiceDate = listOfDatas[1];
                    info.DueDate = listOfDatas[2];
                    info.CompanyNameOfOrder = listOfDatas[3];
                    info.OwnerNameOfOrder = listOfDatas[4];
                    info.AdressOfOrder = listOfDatas[5];
                    info.PostNumberOfOrder = listOfDatas[6];
                    info.CityOfOrder = listOfDatas[7];
                    info.CountryOfOrder = listOfDatas[8];
                    info.Item = listOfDatas[9];
                    info.Description = listOfDatas[10];
                    info.Quantity = listOfDatas[11];
                    info.Tax = listOfDatas[13];
                    info.Total = listOfDatas[15];
                    info.TotalTax = listOfDatas[14];
                    info.UnitPrice = listOfDatas[12];
                    info.CompanyNameOfSeller = listOfDatas[16];
                    info.SellersAddress = listOfDatas[17];
                    info.SellersPostNumber = listOfDatas[18];
                    info.SellersCity = listOfDatas[19];
                    info.SellersCountry = listOfDatas[20];
                    info.SellersTelNumber = listOfDatas[21];
                    info.SellersHomePage = listOfDatas[22];

                    txtBox_InvoiceNumber.Text = "Invoice Number: " + info.InvoceNumber;
                    txtBox_IvoiceDate.Text = "Invoice Date: " + info.InvoiceDate;
                    txtBox_DueDate.Text = "Due Date: " + info.DueDate;
                    //Add the address of the buyer to a listbox
                    listBox_CompanyAddress.Items.Add(info.CompanyNameOfOrder);
                    listBox_CompanyAddress.Items.Add(info.OwnerNameOfOrder);
                    listBox_CompanyAddress.Items.Add(info.AdressOfOrder);
                    listBox_CompanyAddress.Items.Add(info.PostNumberOfOrder);
                    listBox_CompanyAddress.Items.Add(info.CityOfOrder);
                    listBox_CompanyAddress.Items.Add(info.CountryOfOrder);
                    //Add the address of the company to a listbox
                    txtBox_Address.Text = info.CompanyNameOfSeller + "\r\n" + info.SellersAddress + "\r\n" + info.SellersPostNumber + "\r\n" + info.SellersCity + "\r\n" + info.SellersCountry;
                    txtBox_Phone.Text = info.SellersTelNumber;
                    txtBox_HomePage.Text = info.SellersHomePage;
                    //Add the total price to the textbox
                    txtBox_Total.Text = info.Total;
                    //Set the data in the gridclass
                    dataGrid_ProductDetails.Items.Add(new GridClass
                    {
                        Item = info.Item,
                        Description = info.Description,
                        Quantity = info.Quantity,
                        Tax = info.Tax,
                        Total = info.Total,
                        TotalTax = info.TotalTax,
                        UnitPrice = info.UnitPrice
                    });
                    
                    
                }
                //catch any error if happens
                catch (Exception ex)
                {
                    MessageBox.Show("Error:  Could not read file from disk. Original error: " + ex.ToString());
                }
            }
        }
        /// <summary>
        /// Counts the new value if there is a discount given
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void change_discount_voucher_button_Click(object sender, RoutedEventArgs e)
        {
            manager.CountTotalAmount(info.Total, txtBox_DiscountNumber.Text);
            txtBox_AmountToPayNumber.Text = manager.Total.ToString();
        }
        /// <summary>
        /// The textbox can handle the dot and commas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBox_DiscountNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "(,[^0-9]).?");
        }
    }
}
