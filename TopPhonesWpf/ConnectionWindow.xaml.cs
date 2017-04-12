﻿/*
 * Created by SharpDevelop.
 * User: Ruslan
 * Date: 04/01/2017
 * Time: 16:34
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
	/// Interaction logic for ConnectionWindow.xaml
	/// </summary>
	public partial class ConnectionWindow : Window
	{	
		public SqlConnection Try_Connect = new SqlConnection();
		
		public ConnectionWindow()
		{
			InitializeComponent();
		}
		void ServersCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			
		}
		void window1_Loaded(object sender, RoutedEventArgs e)
		{
			
		}
		
		void ServersCB_GotMouseCapture(object sender, MouseEventArgs e)
		{
			
		}
		void SelectDBCB_GotMouseCapture(object sender, MouseEventArgs e)
		{
			//Try_Connect.Close();
			try
            {
             	   
				Try_Connect.ConnectionString = "Data Source=" + "./BORISOV101"
                    + "; Initial Catalog= master; Persist Security Info=True;User ID=" 
                    + UserName_text.Text + ";Password=\"" + DSPass.Password + "\"";
                Try_Connect.Open();
                SqlDataAdapter Base_Adapter = new SqlDataAdapter("exec sp_helpdb", Try_Connect);
                DataSet Base_Data_Set = new DataSet();
                Base_Adapter.Fill(Base_Data_Set, "db");
              	
               SelectDBCB.ItemsSource = Base_Data_Set.Tables[0].DefaultView;
               SelectDBCB.DisplayMemberPath = "name";
                Try_Connect.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }	 
		} 
		void button1_Click(object sender, RoutedEventArgs e)
		{
			RegistryKey DataBase_Connection = Registry.CurrentConfig;
            RegistryKey Connection_Base_Party_Options = DataBase_Connection.CreateSubKey("DB_PARTY_OPTIOS");
            Connection_Base_Party_Options.SetValue("DS", Encrypt.Encrypting(ServersCB.Text));
            Connection_Base_Party_Options.SetValue("IC", Encrypt.Encrypting(SelectDBCB.Text));
            Connection_Base_Party_Options.SetValue("UID", Encrypt.Encrypting(UserName_text.Text));
            Connection_Base_Party_Options.SetValue("PDB", Encrypt.Encrypting(DSPass.Password));
            
		}
		void Window1_ContentRendered(object sender, EventArgs e)
		{
			
		}
		void SelectDBCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			throw new NotImplementedException();
		}
		
	}
}