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

namespace date_over_3
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // 增加新的記帳事項
        private void plus_Click(object sender, RoutedEventArgs e)
        {
            costbook item = new costbook();
            Todolist.Children.Add(item);
        }

        // 增加新的日記
        private void plusdairy_Click(object sender, RoutedEventArgs e)
        {
            dairy item = new dairy();
            word.Children.Add(item);
        }


        //當關閉視窗時
        private void Window_Closed(object sender, EventArgs e)
        {
            //日記方面

            // 新增一個串列裝每個項目轉成的文字
            List<string> datas = new List<string>();

            // 轉換每一個項目
            foreach (dairy item in word.Children)
            {
                string line = "";

                // 加上|符號和日期文字
                line += "|" + item.day.Text + "|" + item.notebook.Text;

                // 加入串列中
                datas.Add(line);
            }

            // 存檔
            System.IO.File.WriteAllLines(@"D:\temp\dairy.txt", datas);

            //記帳本方面

            // 新增一個串列裝每個項目轉成的文字
            List<string> Datas = new List<string>();

            // 轉換每一個項目
            foreach (costbook item in Todolist.Children)
            {
                string line = "";

                // 加上|符號和日期事項和金額
                line += "|" + item.date.Text + "|" + item.thing.Text + "|" + item.number.Text;

                // 加入串列中
                Datas.Add(line);
            }
            // 存檔
            System.IO.File.WriteAllLines(@"D:\temp\money.txt", Datas);

        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //記帳本方面

            // 開檔
            string[] lines = System.IO.File.ReadAllLines(@"D:\temp\money.txt");

            foreach (string line in lines)
            {
                // 用 | 符號拆開
                string[] parts = line.Split('|');

                // 建立 costbook
                costbook item = new costbook();

                item.date.Text = parts[1];
                item.thing.Text = parts[2];
                item.number.Text = parts[3];

                Todolist.Children.Add(item);
            }
            int sum = 0;

            foreach (costbook item in Todolist.Children)
            {
                sum += int.Parse(item.number.Text);
                SUMBOX.Text = sum.ToString();
            }

            //日記方面

            //開檔
            string[] Lines = System.IO.File.ReadAllLines(@"D:\temp\dairy.txt");

            foreach (string Line in Lines)
            {
                // 用 | 符號拆開
                string[] parts = Line.Split('|');

                // 建立 dairy
                dairy Item = new dairy();

                Item.day.Text = parts[1];
                Item.notebook.Text = parts[2];
                 word.Children.Add(Item);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //建立一個空的數字
            int Sum = 0;

            {
                // 計算每一個項目
                foreach (costbook item in Todolist.Children)
                {
                    //將價格相加
                    Sum += item.itemPriceValue;
                }
                //顯示價格
                SUMBOX.Text = Sum.ToString();

            }

        }
    }
    }



  