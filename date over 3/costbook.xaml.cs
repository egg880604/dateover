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
    /// costbook.xaml 的互動邏輯
    /// </summary>
    public partial class costbook : UserControl
    {
        public costbook()
        {
            InitializeComponent();
        }
        public int itemPriceValue
        {
            get
            {
                //嘗試解析價格
                try
                {
                    return int.Parse(number.Text);
                }
                //失敗後要求用家輸入數字
                catch
                {
                    MessageBox.Show("請輸入數字");
                    return 0;
                }
            }
            set
            {
                number.Text = value.ToString();
            }
        }

        // 自訂刪除事件
        public event EventHandler DeleteItem;

        // 項目價錢鍵盤按下事件
        private void itemPrice_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // 任務空白，而且按下 Backspace 鍵時，引發 DeleteItem 事件
            if (thing.Text == "" && e.Key == Key.Back)
            {
                DeleteItem(this, null);
            }
        }
    }
}
