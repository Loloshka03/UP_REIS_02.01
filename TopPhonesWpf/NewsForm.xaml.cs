/*
 * Created by SharpDevelop.
 * User: Ruslan
 * Date: 04/01/2017
 * Time: 12:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Data.SqlClient;
using Microsoft.Win32;
using System.Data;
using System.Linq;

namespace TopPhonesWpf
{
	/// <summary>
	/// Interaction logic for Window2.xaml
	/// </summary>
	public partial class Window2 : Window
	{
		Window1 lf = new Window1();
		ConnectionWindow cw = new ConnectionWindow();
		
		public Window2()
		{
			InitializeComponent();
		}
		void button1_Click(object sender, RoutedEventArgs e)
		{	try{
				this.Close();
				ConnectionClass ConCheck = new ConnectionClass();
            	RegistryKey DataBase_Connection = Registry.CurrentConfig;
            	RegistryKey Connection_Base_Party_Options = DataBase_Connection.CreateSubKey("DB_PARTY_OPTIOS");
            	ConCheck.Connection_Options(Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("DS").ToString())
                	, Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("IC").ToString())
                	, Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("UID").ToString())
                	, Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("PDB").ToString()));
            	SqlConnection connectionCheck = new SqlConnection(ConCheck.ConnectString);
            
            	try
            		{
                		connectionCheck.Open();
            		}
            	catch (Exception ex)
            		{
                		MessageBox.Show(ex.Message);
            		}
            	switch (connectionCheck.State == ConnectionState.Open)
            		{
                		case (true):
            			lf.ConnectState_label.Content = "Подключение есть!";
                    	break;
                		case (false):
                    	MessageBox.Show("Не удается подключится к БД");
                    	lf.ConnectState_label.Content = "Нет подключения к БД!!";
						System.Data.Sql.SqlDataSourceEnumerator Server_List = 
            			System.Data.Sql.SqlDataSourceEnumerator.Instance;
            			System.Data.DataTable Server_Table = Server_List.GetDataSources();
            			foreach (DataRow row in Server_Table.Rows)
            			{
            				cw.ServersCB.Items.Clear();
            				cw.ServersCB.Items.Add(row[0]+"\\"+row[1]);
            			}	
                    		cw.Show();
                    		break;
            		 }
					}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message + "Проверьте настройки подключения");
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
			
		}
	}
}