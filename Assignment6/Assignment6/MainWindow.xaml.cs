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

namespace Assignment6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> listOfDatas = new List<string>();
        string[] datas = new string[24];
        InvoiceInformation info;


        public MainWindow()
        {
            InitializeComponent();
            info = new InvoiceInformation();
            //Generate_ColumnsTest();
            GenerateDataToDataGrid();
        }

        private void GenerateDataToDataGrid()
        {
            DataGridTextColumn col1 = new DataGridTextColumn();
            DataGridTextColumn col2 = new DataGridTextColumn();
            DataGridTextColumn col3 = new DataGridTextColumn();
            DataGridTextColumn col4 = new DataGridTextColumn();
            DataGridTextColumn col5 = new DataGridTextColumn();
            DataGridTextColumn col6 = new DataGridTextColumn();
            DataGridTextColumn col7 = new DataGridTextColumn();

            dataGrid.Columns.Add(col1);
            dataGrid.Columns.Add(col2);
            dataGrid.Columns.Add(col3);
            dataGrid.Columns.Add(col4);
            dataGrid.Columns.Add(col5);
            dataGrid.Columns.Add(col6);
            dataGrid.Columns.Add(col7);

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

        private void load_image_button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "jpg files (*.jpg)|*.jpg";
            if (dlg.ShowDialog() == true)
            {
                logo_image.Source = new BitmapImage(new Uri(dlg.FileName));
            }
        }

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
                        while (!sr.EndOfStream && (line = sr.ReadLine()) != null)
                        {
                            listOfDatas.Add(line);
                        }
                    }
                    sr.Close();
                    for (int i = 0; i < listOfDatas.Count + 1; i++)
                    {
                        Console.WriteLine(i);
                    }

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
                    info.UnitPrice = listOfDatas[12];
                    info.Tax = listOfDatas[13];
                    info.TotalTax = listOfDatas[14];
                    info.Total = listOfDatas[15];
                    info.CompanyNameOfSeller = listOfDatas[16];
                    info.SellersAddress = listOfDatas[17];
                    info.SellersPostNumber = listOfDatas[18];
                    info.SellersCity = listOfDatas[19];
                    info.SellersCountry = listOfDatas[20];
                    info.SellersTelNumber = listOfDatas[21];
                    info.SellersHomePage = listOfDatas[22];

                    invoice_number_TxtBox.Text = "Invoice Number: " + info.InvoceNumber;
                    invoice_date_TxtBox.Text = "Invoice Date: " + info.InvoiceDate;
                    due_date_TxtBox.Text = "Due Date: " + info.DueDate;
                    address_ListBox.Items.Add(info.CompanyNameOfOrder);
                    address_ListBox.Items.Add(info.OwnerNameOfOrder);
                    address_ListBox.Items.Add(info.AdressOfOrder);
                    address_ListBox.Items.Add(info.PostNumberOfOrder);
                    address_ListBox.Items.Add(info.CityOfOrder);
                    address_ListBox.Items.Add(info.CountryOfOrder);

                    txtBox_Address.Text = info.CompanyNameOfSeller + "\r\n" + info.SellersAddress + "\r\n" + info.SellersPostNumber + "\r\n" + info.SellersCity + "\r\n" + info.SellersCountry;
                    txtBox_Phone.Text = info.SellersTelNumber;
                    txtBox_HomePage.Text = info.SellersHomePage;

                    dataGrid.Items.Add(new GridClass
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
                catch (Exception ex)
                {
                    MessageBox.Show("Error:  Could not read file from disk. Original error: " + ex.ToString());
                }
            }
        }
    }
}
