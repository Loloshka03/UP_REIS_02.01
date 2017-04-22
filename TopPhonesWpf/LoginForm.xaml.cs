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
			try {
				ConnectionClass ConCheck = new ConnectionClass();
            RegistryKey DataBase_Connection = Registry.CurrentConfig;
            RegistryKey Connection_Base_Party_Options = DataBase_Connection.CreateSubKey("DB_PARTY_OPTIOS");
            LoginTextBox.Text = Encrypt.Decrypt(Convert.ToString(Connection_Base_Party_Options.GetValue("LOG")));
            PasswordBox.Password = Encrypt.Decrypt(Convert.ToString(Connection_Base_Party_Options.GetValue("PASS")));
            if (LoginTextBox.Text != "")
            {
            	slip.IsChecked = true;
            	LoginTextBox.Foreground = new SolidColorBrush(Color.FromRgb(0,0,0));
            	PasswordBox.Foreground = new SolidColorBrush(Color.FromRgb(0,0,0));
            }
            else
            {
            	LoginTextBox.Text = "Логин";
            	PasswordBox.Password = "Пароль";
            }
			}
			catch
			{
			}
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
		{	cw.ServersCB.Items.Add ("Выберите источник данных:");
			cw.ServersCB.SelectedIndex = 0;
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
            if (slip.IsChecked == true)
            {
            Connection_Base_Party_Options.SetValue("LOG", Encrypt.Encrypting(LoginTextBox.Text));
            Connection_Base_Party_Options.SetValue("PASS", Encrypt.Encrypting(PasswordBox.Password));
            }
            SqlConnection connectionUser = new SqlConnection(ConCheck.ConnectString);
            SqlCommand Select_USID = new SqlCommand("select [dbo].[Klienty].[id_klienty]"+
                " from [dbo].[Klienty] inner join[dbo].[roli] on " + 
                "[dbo].[Klienty].[id_roli] =[dbo].[roli].[ID_roli]"+
                "where login='" + LoginTextBox.Text + "' and pass='" + PasswordBox.Password + "'", connectionUser);
            SqlCommand Select_ISA = new SqlCommand("select [dbo].[roli].[Role_Name]" +
                " from [dbo].[Klienty] inner join[dbo].[roli] on " +
                "[dbo].[Klienty].[id_roli] =[dbo].[roli].[id_roli]" +
                "where login='" + LoginTextBox.Text + "' and pass='" + PasswordBox.Password + "'", connectionUser);
            try
            {
                connectionUser.Open();
                USID = Select_USID.ExecuteScalar().ToString();
                ISA = Select_ISA.ExecuteScalar().ToString();
            switch (ISA)
            {
            	case "Боженька":
            		AdminPanel admnpnl = new AdminPanel();
            		admnpnl.Show();
            		break;
            	case "Ремонтник":
            		SotrudnikWindow strwndw = new SotrudnikWindow();
            		strwndw.role = "Ремонтник";
            		strwndw.Show();
            		break;
            	case "Продавец":
            		SotrudnikWindow strwndw1 = new SotrudnikWindow();
            		strwndw1.role = "Продавец";
            		strwndw1.Show();
            		break;

            	default:
            		KlientWindow klntwndw = new KlientWindow();
            		klntwndw.Show();
            		break;
            	
            	
            }
            
            	
            	this.Close();
                connectionUser.Close();
                
            }
            catch (Exception bl)
            { if (bl.Message == "Ссылка на объект не указывает на экземпляр объекта.")
            	{
            	MessageBox.Show("Неверный логин или пароль");
            }
            	else
            	{
            		MessageBox.Show(bl.Message);
            	}
		}
		}
		
		void grid1_KeyDown(object sender, KeyEventArgs e)
		{
			
		}
		
		void Window1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.F1)
			{
				Spravka sprv = new Spravka();
				sprv.send = "Логин";
				sprv.Show();
			}
		}
		
		void LoginTextBox_GotFocus(object sender, RoutedEventArgs e)
		{
				LoginTextBox.Foreground = new SolidColorBrush(Color.FromRgb(0,0,0));
			if (LoginTextBox.Text=="Логин") 
			{LoginTextBox.Text="";
			}				
		}
		
		void LoginTextBox_LostFocus(object sender, RoutedEventArgs e)
		{
			if (LoginTextBox.Text=="") 
			{LoginTextBox.Text="Логин";
LoginTextBox.Foreground = new SolidColorBrush(Color.FromRgb(193,193,193));}
		}
		
		void LoginTextBox_MouseDown(object sender, MouseButtonEventArgs e)
		{
	if (LoginTextBox.Text=="Логин") 
			{LoginTextBox.Text="";}			
		}
		
		void LoginTextBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
{if (LoginTextBox.Text=="Логин") 
			{LoginTextBox.Text="";}}			
		}
		
		void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
		{
				PasswordBox.Foreground = new SolidColorBrush(Color.FromRgb(0,0,0));
			if (PasswordBox.Password=="Pass") 
			{PasswordBox.Password="";
			}	
		}
		
		void PasswordBox_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (PasswordBox.Password=="Pass") 
			{PasswordBox.Password="";}	
		}
		
		void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
		{
			if (PasswordBox.Password=="") 
			{PasswordBox.Password="Pass";
PasswordBox.Foreground = new SolidColorBrush(Color.FromRgb(193,193,193));}
		}
		
		void PasswordBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if (PasswordBox.Password=="Pass") 
			{PasswordBox.Password="";}	
		}
	}
}