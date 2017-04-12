/*
 * Created by SharpDevelop.
 * User: Ruslan
 * Date: 01.04.2017
 * Time: 12:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Data.SqlClient;
using Microsoft.Win32;

namespace TopPhonesWpf
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		public string USID;
        public string ISA;
        public string ALA;
        public string EOA;
        public string MA;
        public string PRA;
		ConnectionWindow cw = new ConnectionWindow();
		public Window1()
		{
			InitializeComponent();
		}
		void window1_Loaded(object sender, RoutedEventArgs e)
		{
			Window2 NewsForm = new Window2();
			NewsForm.Show();
			
			
		}
		void button1_Click(object sender, RoutedEventArgs e)
		{
			RegistrationWindow registationWindow = new RegistrationWindow();
			registationWindow.Show();
		}
		void Button_Click(object sender, RoutedEventArgs e)
		{
			System.Data.Sql.SqlDataSourceEnumerator Server_List = 
            System.Data.Sql.SqlDataSourceEnumerator.Instance;
            System.Data.DataTable Server_Table = Server_List.GetDataSources();
            foreach (DataRow row in Server_Table.Rows)
            {
            	cw.ServersCB.Items.Clear();
            	cw.ServersCB.Items.Add(row[0]+"\\"+row[1]);
            }	
            cw.Show();
		}
		void Window1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			
		}
		void button2_Click(object sender, RoutedEventArgs e)
		{
			System.Data.Sql.SqlDataSourceEnumerator Server_List = 
            System.Data.Sql.SqlDataSourceEnumerator.Instance;
            System.Data.DataTable Server_Table = Server_List.GetDataSources();
            foreach (DataRow row in Server_Table.Rows)
            {
            	cw.ServersCB.Items.Clear();
            	cw.ServersCB.Items.Add(row[0]+"\\"+row[1]);
            }	
            cw.Show();
		}
		void button3_Click(object sender, RoutedEventArgs e)
		{
			ConnectionClass ConCheck = new ConnectionClass();
            RegistryKey DataBase_Connection = Registry.CurrentConfig;
            RegistryKey Connection_Base_Party_Options = DataBase_Connection.CreateSubKey("DB_PARTY_OPTIOS");
            ConCheck.Connection_Options(Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("DS").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("IC").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("UID").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("PDB").ToString()));
            SqlConnection connectionUser = new SqlConnection(ConCheck.ConnectString);
            SqlCommand Select_USID = new SqlCommand("select [dbo].[Login].[ID_Login]"+
                " from [dbo].[Login] inner join[dbo].[roli] on " + 
                "[dbo].[Login].[roli_id] =[dbo].[roli].[ID_roli]"+
                "where login='" + LoginTextBox.Text + "' and pass='" + PasswordBox.Password + "'", connectionUser);
            SqlCommand Select_ISA = new SqlCommand("select [dbo].[roli].[Role_Name]" +
                " from [dbo].[Login] inner join[dbo].[roli] on " +
                "[dbo].[Login].[roli_id] =[dbo].[roli].[ID_roli]" +
                "where login='" + LoginTextBox.Text + "' and pass='" + PasswordBox.Password + "'", connectionUser);
                // SqlCommand Select_ALA = new SqlCommand("select [dbo].[Party_Role].[Alkogolik_Access]" +
             //   " from [dbo].[Alkogolik] inner join[dbo].[Party_Role] on " +
             //   "[dbo].[Alkogolik].[Party_Role_id] =[dbo].[Party_Role].[id_Party_Role]" +
             //   "where alkogolic_log='" + LoginTextBox.Text + "' and alkogolik_pass='" + PasswordBox.Password + "'", connectionUser);
            //SqlCommand Select_EOA = new SqlCommand("select [Party_Role].[Eda_Other_Access]" +
            //    " from [dbo].[Alkogolik] inner join[dbo].[Party_Role] on " +
            //    "[dbo].[Alkogolik].[Party_Role_id] =[dbo].[Party_Role].[id_Party_Role]" +
            //    "where alkogolic_log='" + LoginTextBox.Text + "' and alkogolik_pass='" + PasswordBox.Password + "'", connectionUser);
           // SqlCommand Select_MA = new SqlCommand("select [dbo].[Party_Role].[Main_Access] "+
             //   " from [dbo].[Alkogolik] inner join[dbo].[Party_Role] on " +
             //   "[dbo].[Alkogolik].[Party_Role_id] =[dbo].[Party_Role].[id_Party_Role]" +
             //   "where alkogolic_log='" + LoginTextBox.Text + "' and alkogolik_pass='" + PasswordBox.Password + "'", connectionUser);
            //SqlCommand Select_PRA = new SqlCommand("select [dbo].[Party_Role].[Alko_Price_Access]"+ 
            //    " from [dbo].[Alkogolik] inner join[dbo].[Party_Role] on " +
            //    "[dbo].[Alkogolik].[Party_Role_id] =[dbo].[Party_Role].[id_Party_Role]" +
            //    "where alkogolic_log='"+LoginTextBox.Text+"' and alkogolik_pass='"+PasswordBox.Password+"'", connectionUser);
            try
            {
                connectionUser.Open();
                USID = Select_USID.ExecuteScalar().ToString();
                ISA = Select_ISA.ExecuteScalar().ToString();
            //    ALA = Select_ALA.ExecuteScalar().ToString();
            //    EOA = Select_EOA.ExecuteScalar().ToString();
            //    MA = Select_MA.ExecuteScalar().ToString();
            //    PRA = Select_PRA.ExecuteScalar().ToString();
            MessageBox.Show(ISA);
            switch (ISA)
            {
            	case "Admin":
            		AdminPanel admnpnl = new AdminPanel();
            		admnpnl.Show();
            		break;
            	case "Sotrudnik":
            		SotrudnikWindow strwndw = new SotrudnikWindow();
            		strwndw.Show();
            		break;
            	default:
            		KlientWindow klntwndw = new KlientWindow();
            		klntwndw.Show();
            		break;
            	
            }
            	
           
                connectionUser.Close();
                
            }
            catch (Exception bl)
            {
            	MessageBox.Show(bl.Message);
            }
		}
	}
}