/*
 * Created by SharpDevelop.
 * User: Ruslan
 * Date: 11.04.2017
 * Time: 2:40
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Net.Configuration;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Win32;

namespace TopPhonesWpf
{
	/// <summary>
	/// Interaction logic for SotrudnikWindow.xaml
	/// </summary>
	public partial class SotrudnikWindow : Window
	{
		public string role;
		public SotrudnikWindow()
		{
			InitializeComponent();
		}
		void window1_Loaded(object sender, RoutedEventArgs e)
		{
			menuItem1.Visibility = Visibility.Collapsed;
			mnuitm2.Visibility = Visibility.Hidden;
			mnuitm3.Visibility = Visibility.Hidden;
			mnuitm4.Visibility = Visibility.Hidden;
			mnuitm5.Visibility = Visibility.Hidden;
			button1.Visibility = Visibility.Hidden;
			switch (role) 
			{
				case "Ремонтник":
					menuItem1.Visibility = Visibility.Visible;
					break;
				case "Продавец":
					mnuitm2.Visibility = Visibility.Visible;
					break;
				case "Маркетолог":
					mnuitm5.Visibility = Visibility.Visible;
					break;
				case "Отдел кадров":
					mnuitm4.Visibility = Visibility.Visible;
					break;
				case "склад":
					mnuitm3.Visibility = Visibility.Visible;
					break;
				case "Боженька":
						menuItem1.Visibility = Visibility.Visible;
						mnuitm2.Visibility = Visibility.Visible;
						mnuitm5.Visibility = Visibility.Visible;
						mnuitm4.Visibility = Visibility.Visible;
						mnuitm3.Visibility = Visibility.Visible;
						break;
			}
		}
		void Rrm_zakaz_complekt_Click(object sender, RoutedEventArgs e)
		{
			Zakaz_complektuushix_masterskaya zcmstrs = new Zakaz_complektuushix_masterskaya();
			zcmstrs.Show();
		}
		void Rrm_register_remont_Click(object sender, RoutedEventArgs e)
		{
			Remont_window rmntwndw = new Remont_window();
			rmntwndw.Show();
		}
		void Prod_zakaz_Click(object sender, RoutedEventArgs e)
		{
			Zakaz_complektuushix_masterskaya zcmstrs = new Zakaz_complektuushix_masterskaya();
			zcmstrs.Show();
		}
		void Sklad_edit_tovar_Click(object sender, RoutedEventArgs e)
		{
			txtbx1.Visibility = Visibility.Visible;
			txtbx2.Visibility = Visibility.Visible;
			txtbx3.Visibility = Visibility.Visible;
			txtbx4.Visibility = Visibility.Visible;
			cmbx1.Visibility  = Visibility.Visible;
			cmbx2.Visibility = Visibility.Visible;
			string sql = "SELECT dbo.Proizvoditel.Name_proizv, dbo.sklad.nazvanie_tovara_sklad, dbo.Tovar.kol_vo, dbo.Tovar.cena FROM            dbo.Proizvoditel INNER JOIN dbo.Tovar ON dbo.Proizvoditel.ID_proizvod = dbo.Tovar.Proizvoditel_ID INNER JOIN dbo.tovarskld ON dbo.Tovar.ID_Tovarpr = dbo.tovarskld.kod_tovara_id INNER JOIN dbo.Tovar_na_skladakh ON dbo.tovarskld.id_nomer_tovara_na_sklade = dbo.Tovar_na_skladakh.nomer_tovara_na_sklade CROSS JOIN dbo.sklad";
            DataTable phones = new DataTable();
            string proizv = "select * from dbo.Proizvoditel";
            string postav = "SELECT * from dbo.Postavshik";
            DataSet proizvoditel = new DataSet();
            DataSet postavshik = new DataSet();
            
            SqlConnection connection = null;
            try
            {
            	ConnectionClass ConCheck = new ConnectionClass();
            	RegistryKey DataBase_Connection = Registry.CurrentConfig;
            	RegistryKey Connection_Base_Party_Options = DataBase_Connection.CreateSubKey("DB_PARTY_OPTIOS");
            	ConCheck.Connection_Options(Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("DS").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("IC").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("UID").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("PDB").ToString()));
                connection = new SqlConnection(ConCheck.ConnectString);
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataAdapter getproizv = new SqlDataAdapter(proizv, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                SqlDataAdapter getpostav = new SqlDataAdapter(postav, connection);

                // установка команды на добавление для вызова хранимой процедуры
               // adapter.InsertCommand = new SqlCommand("other`_add", connection);
                
             //   adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
              //  adapter.InsertCommand.Parameters.Add(new SqlParameter("@nane_eda", SqlDbType.NVarChar, 50, "Nazvaniye"));
               // adapter.InsertCommand.Parameters.Add(new SqlParameter("@cena_eda", SqlDbType.NVarChar, 50, "Poroda"));
               // SqlParameter parameter = adapter.InsertCommand.Parameters.Add("@Id_eda", SqlDbType.Int, 0, "id_nomer_otdela_sklada");
                //parameter.Direction = ParameterDirection.Output;

                connection.Open();
                getpostav.Fill(postavshik);
                getproizv.Fill(proizvoditel);
                cmbx1.ItemsSource = proizvoditel.Tables[0].DefaultView;
                cmbx1.DisplayMemberPath = "Name_proizv";
                cmbx2.ItemsSource = postavshik.Tables[0].DefaultView;
                cmbx2.DisplayMemberPath = "Name_postavshik";
                adapter.Fill(phones);
                tovaryGrid.ItemsSource = phones.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
		}
		void button1_Click(object sender, RoutedEventArgs e)
		{
					ConnectionClass ConCheck = new ConnectionClass();
            		RegistryKey DataBase_Connection = Registry.CurrentConfig;
            		RegistryKey Connection_Base_Party_Options = DataBase_Connection.CreateSubKey("DB_PARTY_OPTIOS");
            		ConCheck.Connection_Options(Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("DS").ToString()),            		                            
                	Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("IC").ToString()), 
                	Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("UID").ToString()), 
                	Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("PDB").ToString()));
                	SqlConnection connection = new SqlConnection(ConCheck.ConnectString);
                	connection.Open();
                	SqlCommand command = new SqlCommand("[dbo].[Sklad_add]", connection);
                	command.CommandType = CommandType.StoredProcedure;
                	command.Parameters.AddWithValue("@nazvanie_tovara_sklad", txtbx1.Text);
                	command.ExecuteNonQuery();
                	MessageBox.Show("Склад есть!");
                	SqlCommand Tovar = new SqlCommand("[dbo].[Tovar_add]", connection);
                	Tovar.CommandType = CommandType.StoredProcedure;
                	Tovar.Parameters.AddWithValue("@id", "2");
                	Tovar.Parameters.AddWithValue("@kol_vo", txtbx2.Text);
                	Tovar.Parameters.AddWithValue("@cena", txtbx3.Text);
                	Tovar.Parameters.AddWithValue("Postavshik_id", Convert.ToString(cmbx2.SelectedIndex + 1));
                	Tovar.Parameters.AddWithValue("proizvoditel_id", Convert.ToString(cmbx1.SelectedIndex + 1));
                	Tovar.ExecuteNonQuery();
                	MessageBox.Show("Товар есть!");
                	SqlCommand Tovarskld = new SqlCommand("[dbo].[Tovarskld_add]", connection);
                	Tovarskld.CommandType = CommandType.StoredProcedure;
                	Tovarskld.Parameters.AddWithValue("@vystavlen", txtbx4.Text);
                	Tovarskld.Parameters.AddWithValue("@kod_tovara_id", "2");
                	Tovarskld.ExecuteNonQuery();
                	MessageBox.Show("ТоварСКЛД есть!");
                	SqlCommand Tovar_na_skld = new SqlCommand("[dbo].[Tovar_na_skladakh_add]", connection);
                	Tovar_na_skld.CommandType = CommandType.StoredProcedure;
                	Tovar_na_skld.Parameters.AddWithValue("@kol_vo_tovara_na_sklade", txtbx2.Text);
                	Tovar_na_skld.Parameters.AddWithValue("@nomer_tovara_na_sklade", "16");
                	Tovar_na_skld.Parameters.AddWithValue("@nomer_otdela_sklada", "19");
                	Tovar_na_skld.ExecuteNonQuery();
                	MessageBox.Show("Вроде все! (но это не точно)");
                	connection.Close();
		}
		void Ok_rab_add_Click(object sender, RoutedEventArgs e)
		{
			if (MessageBox.Show("Увольнение", "Вы хотите уволить сотрудника?",  MessageBoxButton.OKCancel)  == MessageBoxResult.OK)
			{
				string sql10 = "SELECT * FROM Prikaz_uvoln";
            DataTable edaTable10 = new DataTable();
            SqlConnection connection10 = null;
            try
            {
            	ConnectionClass ConCheck10 = new ConnectionClass();
            	RegistryKey DataBase_Connection = Registry.CurrentConfig;
            	RegistryKey Connection_Base_Party_Options = DataBase_Connection.CreateSubKey("DB_PARTY_OPTIOS");
            	ConCheck10.Connection_Options(Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("DS").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("IC").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("UID").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("PDB").ToString()));
                connection10 = new SqlConnection(ConCheck10.ConnectString);
                SqlCommand command = new SqlCommand(sql10, connection10);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
				
                connection10.Open();
                adapter.Fill(edaTable10);
                tovaryGrid.ItemsSource = edaTable10.DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection10 != null)
                    connection10.Close();
			
			}	
			}
			else
			{
			string sql11 = "SELECT * FROM Prikaz_priem_na_rab";
            DataTable edaTable11 = new DataTable();
            SqlConnection connection11 = null;
            try
            {
            	ConnectionClass ConCheck11 = new ConnectionClass();
            	RegistryKey DataBase_Connection = Registry.CurrentConfig;
            	RegistryKey Connection_Base_Party_Options = DataBase_Connection.CreateSubKey("DB_PARTY_OPTIOS");
            	ConCheck11.Connection_Options(Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("DS").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("IC").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("UID").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("PDB").ToString()));
                connection11 = new SqlConnection(ConCheck11.ConnectString);
                SqlCommand command = new SqlCommand(sql11, connection11);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
				
                connection11.Open();
                adapter.Fill(edaTable11);
                tovaryGrid.ItemsSource = edaTable11.DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection11 != null)
                    connection11.Close();
			
			}	
            	
			}
			 
		}
		void Mark_add_rklmd_Click(object sender, RoutedEventArgs e)
		{
			string sql2 = "SELECT * FROM Reklamodatel";
            DataTable edaTable2 = new DataTable();
            SqlConnection connection2 = null;
            try
            {
            	ConnectionClass ConCheck2 = new ConnectionClass();
            	RegistryKey DataBase_Connection = Registry.CurrentConfig;
            	RegistryKey Connection_Base_Party_Options = DataBase_Connection.CreateSubKey("DB_PARTY_OPTIOS");
            	ConCheck2.Connection_Options(Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("DS").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("IC").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("UID").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("PDB").ToString()));
                connection2 = new SqlConnection(ConCheck2.ConnectString);
                SqlCommand command = new SqlCommand(sql2, connection2);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
				
                connection2.Open();
                adapter.Fill(edaTable2);
                tovaryGrid.ItemsSource = edaTable2.DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection2 != null)
                    connection2.Close();
			
			}
		}
		void Mark_add_reklama_Click(object sender, RoutedEventArgs e)
		{
			string sql13 = "SELECT * FROM Reklama";
            DataTable edaTable13 = new DataTable();
            SqlConnection connection13 = null;
            try
            {
            	ConnectionClass ConCheck13 = new ConnectionClass();
            	RegistryKey DataBase_Connection = Registry.CurrentConfig;
            	RegistryKey Connection_Base_Party_Options = DataBase_Connection.CreateSubKey("DB_PARTY_OPTIOS");
            	ConCheck13.Connection_Options(Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("DS").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("IC").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("UID").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("PDB").ToString()));
                connection13 = new SqlConnection(ConCheck13.ConnectString);
                SqlCommand command = new SqlCommand(sql13, connection13);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
				
                connection13.Open();
                adapter.Fill(edaTable13);
                tovaryGrid.ItemsSource = edaTable13.DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection13 != null)
                    connection13.Close();
			
			}
		}
		
	}
}