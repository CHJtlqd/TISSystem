using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace TISSystem
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }
        public string strConn = "Data Source=127.0.0.1;Initial Catalog=tisDB;Persist Security Info=True;User ID=sa;Password=p@ssw0rd!";
        private void Window_Activated(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();
                string CmdString = @"SELECT s_num
      , s_inform
      , s_driverstate
      , s_delivery
      , s_location
      , fk_r_sender
      , fk_r_deliver
      , fk_r_receiver
  FROM dbo.Sinformation";

                SqlCommand cmd = new SqlCommand(CmdString, conn);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable("Sinformatoin");

                sda.Fill(dt);

                grdSendData.ItemsSource = dt.DefaultView;
            }
        }
    }
}
