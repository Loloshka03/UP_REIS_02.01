/*
 * Created by SharpDevelop.
 * User: Ruslan
 * Date: 11.04.2017
 * Time: 2:39
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
using System.Data;
using Microsoft.Win32;
	
namespace TopPhonesWpf
{
	/// <summary>
	/// Interaction logic for AdminPanel.xaml
	/// </summary>
	public partial class AdminPanel : Window
	{
		string vyb;
		object bl;
		SelectionChangedEventArgs i;
		public AdminPanel()
		{
			InitializeComponent();
		}
		void button1_Click(object sender, RoutedEventArgs e)
		{
			KlientWindow klntwndw = new KlientWindow();
			klntwndw.Show();
		}
		void button2_Click(object sender, RoutedEventArgs e)
		{
			SotrudnikWindow strdnkwndw = new SotrudnikWindow();
			strdnkwndw.Show();
		}
	
		void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
	
		}
		void button4_Click(object sender, RoutedEventArgs e) //кнопка добавить
		{		
			try{
			switch (Convert.ToString(cmbx1.SelectedItem))
			{
					
				case "Производитель":
					ConnectionClass ConCheck = new ConnectionClass();
            		RegistryKey DataBase_Connection = Registry.CurrentConfig;
            		RegistryKey Connection_Base_Party_Options = DataBase_Connection.CreateSubKey("DB_PARTY_OPTIOS");
            		ConCheck.Connection_Options(Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("DS").ToString()),            		                            
                	Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("IC").ToString()), 
                	Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("UID").ToString()), 
                	Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("PDB").ToString()));
                	SqlConnection connection = new SqlConnection(ConCheck.ConnectString);
                	connection.Open();
                	SqlCommand command = new SqlCommand("[dbo].[Prizvoditel_add]", connection);
                	command.CommandType = CommandType.StoredProcedure;
                	command.Parameters.AddWithValue("@id", txtbx1.Text);
                	command.Parameters.AddWithValue("@name_proizv", txtbx2.Text);
                	command.Parameters.AddWithValue("@Phone_proizv", txtbx3.Text);
                	command.Parameters.AddWithValue("@Adress_proizv", txtbx4.Text);
                	command.ExecuteNonQuery();
                	connection.Close();
                	cmbx1_SelectionChanged(bl, i);
					break;
				case "Поставщик":
					ConnectionClass ConCheck1 = new ConnectionClass();
            		RegistryKey DataBase_Connection1 = Registry.CurrentConfig;
            		RegistryKey Connection_Base_Party_Options1 = DataBase_Connection1.CreateSubKey("DB_PARTY_OPTIOS");
            		ConCheck1.Connection_Options(Encrypt.Decrypt(Connection_Base_Party_Options1.GetValue("DS").ToString()),            		                            
                	Encrypt.Decrypt(Connection_Base_Party_Options1.GetValue("IC").ToString()), 
                	Encrypt.Decrypt(Connection_Base_Party_Options1.GetValue("UID").ToString()), 
                	Encrypt.Decrypt(Connection_Base_Party_Options1.GetValue("PDB").ToString()));
                	SqlConnection connection1 = new SqlConnection(ConCheck1.ConnectString);
                	connection1.Open();
                	SqlCommand command1 = new SqlCommand("[dbo].[Prizvoditel_add]", connection1);
                	command1.CommandType = CommandType.StoredProcedure;
                	command1.Parameters.AddWithValue("@id", txtbx1.Text);
                	command1.Parameters.AddWithValue("@name_proizv", txtbx2.Text);
                	command1.Parameters.AddWithValue("@Phone_proizv", txtbx3.Text);
                	command1.Parameters.AddWithValue("@Adress_proizv", txtbx4.Text);
                	command1.ExecuteNonQuery();
                	connection1.Close();
                	cmbx1_SelectionChanged(bl, i);
					break;
				case "Рекламодатель":
					ConnectionClass ConCheck2 = new ConnectionClass();
            		RegistryKey DataBase_Connection2 = Registry.CurrentConfig;
            		RegistryKey Connection_Base_Party_Options2 = DataBase_Connection2.CreateSubKey("DB_PARTY_OPTIOS");
            		ConCheck2.Connection_Options(Encrypt.Decrypt(Connection_Base_Party_Options2.GetValue("DS").ToString()),            		                            
                	Encrypt.Decrypt(Connection_Base_Party_Options2.GetValue("IC").ToString()), 
                	Encrypt.Decrypt(Connection_Base_Party_Options2.GetValue("UID").ToString()), 
                	Encrypt.Decrypt(Connection_Base_Party_Options2.GetValue("PDB").ToString()));
                	SqlConnection connection2 = new SqlConnection(ConCheck2.ConnectString);
                	connection2.Open();
                	SqlCommand command2 = new SqlCommand("[dbo].[Reklamodatel_add]", connection2);
                	command2.CommandType = CommandType.StoredProcedure;
                	command2.Parameters.AddWithValue("@id", txtbx1.Text);
                	command2.Parameters.AddWithValue("@naim_reklam", txtbx2.Text);
                	command2.Parameters.AddWithValue("@adress_reklam", txtbx3.Text);
                	command2.Parameters.AddWithValue("@Phone_reklam", txtbx4.Text);
                	command2.Parameters.AddWithValue("@Fax_reklam", txtbx5.Text);
                	command2.Parameters.AddWithValue("@E_mail_reklam", txtbx6.Text);
                	command2.Parameters.AddWithValue("@dolj_reklam", txtbx7.Text);
                	command2.Parameters.AddWithValue("@Fam_reklam", txtbx8.Text);
                	command2.Parameters.AddWithValue("@Im_reklam", txtbx9.Text);
                	command2.Parameters.AddWithValue("@Otch_reklam", txtbx10.Text);
                	command2.ExecuteNonQuery();
                	connection2.Close();
                	cmbx1_SelectionChanged(bl, i);
				break;
				//case ""
			}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка при добавлении данных. Ошибка " + ex.Message);
			}
		}
		
		void del_button_click(object sender, RoutedEventArgs e)
		{
			switch (Convert.ToString(cmbx1.SelectedItem))
			{
					
				case "Производитель":
					ConnectionClass ConCheck = new ConnectionClass();
            		RegistryKey DataBase_Connection = Registry.CurrentConfig;
            		RegistryKey Connection_Base_Party_Options = DataBase_Connection.CreateSubKey("DB_PARTY_OPTIOS");
            		ConCheck.Connection_Options(Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("DS").ToString()),            		                            
                	Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("IC").ToString()), 
                	Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("UID").ToString()), 
                	Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("PDB").ToString()));
                	SqlConnection connection = new SqlConnection(ConCheck.ConnectString);
                	connection.Open();
                	SqlCommand command = new SqlCommand("[dbo].[Proizvoditel_del]", connection);
                	command.CommandType = CommandType.StoredProcedure;
                	command.Parameters.AddWithValue("@id_proizvoditel", txtbx1.Text);
                	command.ExecuteNonQuery();
                	connection.Close();
                	cmbx1_SelectionChanged(bl, i);
					break;
				case "Поставщик":
				//	ConnectionClass ConCheck1 = new ConnectionClass();
            	//	RegistryKey DataBase_Connection1 = Registry.CurrentConfig;
            	//	RegistryKey Connection_Base_Party_Options1 = DataBase_Connection.CreateSubKey("DB_PARTY_OPTIOS");
            	//	ConCheck.Connection_Options(Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("DS").ToString()),            		                            
                //	Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("IC").ToString()), 
                //	Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("UID").ToString()), 
                //	Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("PDB").ToString()));
                //	SqlConnection connection1 = new SqlConnection(ConCheck.ConnectString);
                //	connection.Open();
                //	SqlCommand command1 = new SqlCommand("[dbo].[Prizvoditel_add]", connection);
                //	command.CommandType = CommandType.StoredProcedure;
                //	command.Parameters.AddWithValue("@id", txtbx1.Text);
                //	command.Parameters.AddWithValue("@name_proizv", txtbx2.Text);
                //	command.Parameters.AddWithValue("@Phone_proizv", txtbx3.Text);
                //	command.Parameters.AddWithValue("@Adress_proizv", txtbx4.Text);
                //	command.ExecuteNonQuery();
                //	connection.Close();
					break;
			}
		}
		
	
		void window1_Loaded(object sender, RoutedEventArgs e)
		{
			cmbx1.Items.Add("Договор");
			cmbx1.Items.Add("Поставщик");
			cmbx1.Items.Add("Производитель");
			cmbx1.Items.Add("Рекламодатель");
			cmbx1.Items.Add("Должность");
			cmbx1.Items.Add("Контракты");
			cmbx1.Items.Add("Клиенты");
			cmbx1.Items.Add("Отдел маркетинга");
			cmbx1.Items.Add("Подразделения");
			cmbx1.Items.Add("Приказ о переводе");
			cmbx1.Items.Add("Приказ о приеме на работу");
			cmbx1.Items.Add("Приказ об увольнении");
			cmbx1.Items.Add("Продажа");
			cmbx1.Items.Add("Реклама");
			cmbx1.Items.Add("Ремонт");
			cmbx1.Items.Add("Счет");
			cmbx1.Items.Add("Склад");
			cmbx1.Items.Add("Сотрудник");
			cmbx1.Items.Add("Штатное расписание");
			cmbx1.Items.Add("Товар");
			cmbx1.Items.Add("Товар на складах");
			cmbx1.Items.Add("Товар склд");
			
		}
		void cmbx1_RequestBringIntoView(object sender, RequestBringIntoViewEventArgs e)
		{ 
			//switch (cmbx1.Name)
		}
		void cmbx1_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			switch(Convert.ToString(cmbx1.SelectedItem))
			{
				case "Производитель":
					//----------------------------------------------------
			//Отображение\Скрытие нужных элементов управления
					txtbx5.Visibility = Visibility.Hidden;
					txtbx6.Visibility = Visibility.Hidden;
					txtbx7.Visibility = Visibility.Hidden;
					txtbx8.Visibility = Visibility.Hidden;
					txtbx9.Visibility = Visibility.Hidden;
					txtbx10.Visibility = Visibility.Hidden;
					txtbx11.Visibility = Visibility.Hidden;
					txtbx12.Visibility = Visibility.Hidden;
					txtbx13.Visibility = Visibility.Hidden;
			//-----------------------------------------------------
			//Вывод таблицы			
					
			vyb = "Производитель";
			string sql = "SELECT * FROM Proizvoditel";
            DataTable edaTable = new DataTable();
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
                SqlDataAdapter adapter = new SqlDataAdapter(command);
				
                connection.Open();
                adapter.Fill(edaTable);
                phonesGrid.ItemsSource = edaTable.DefaultView;

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
					break;
			//----------------------------------------------------------------------------
		case "Поставщик":
				vyb = "Поставщик";
			string sql1 = "SELECT * FROM Postavshik";
            DataTable edaTable1 = new DataTable();
            SqlConnection connection1 = null;
            try
            {
            	ConnectionClass ConCheck1 = new ConnectionClass();
            	RegistryKey DataBase_Connection = Registry.CurrentConfig;
            	RegistryKey Connection_Base_Party_Options = DataBase_Connection.CreateSubKey("DB_PARTY_OPTIOS");
            	ConCheck1.Connection_Options(Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("DS").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("IC").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("UID").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("PDB").ToString()));
                connection1 = new SqlConnection(ConCheck1.ConnectString);
                SqlCommand command = new SqlCommand(sql1, connection1);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
				
                connection1.Open();
                adapter.Fill(edaTable1);
                phonesGrid.ItemsSource = edaTable1.DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection1 != null)
                    connection1.Close();
			
			}
            break;
            //---------------------------------------------------------------------------------------------------
           case "Рекламодатель":
            
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
                phonesGrid.ItemsSource = edaTable2.DefaultView;

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
            
            break;
           case "Договор":
				 string sql3 = "SELECT * FROM Dogovor";
            DataTable edaTable3 = new DataTable();
            SqlConnection connection3 = null;
            try
            {
            	ConnectionClass ConCheck3 = new ConnectionClass();
            	RegistryKey DataBase_Connection = Registry.CurrentConfig;
            	RegistryKey Connection_Base_Party_Options = DataBase_Connection.CreateSubKey("DB_PARTY_OPTIOS");
            	ConCheck3.Connection_Options(Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("DS").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("IC").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("UID").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("PDB").ToString()));
                connection3 = new SqlConnection(ConCheck3.ConnectString);
                SqlCommand command = new SqlCommand(sql3, connection3);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
				
                connection3.Open();
                adapter.Fill(edaTable3);
                phonesGrid.ItemsSource = edaTable3.DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection3 != null)
                    connection3.Close();
			
			}            
            break;
           case "Должность":
             string sql4 = "SELECT * FROM Dolj";
            DataTable edaTable4 = new DataTable();
            SqlConnection connection4 = null;
            try
            {
            	ConnectionClass ConCheck4 = new ConnectionClass();
            	RegistryKey DataBase_Connection = Registry.CurrentConfig;
            	RegistryKey Connection_Base_Party_Options = DataBase_Connection.CreateSubKey("DB_PARTY_OPTIOS");
            	ConCheck4.Connection_Options(Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("DS").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("IC").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("UID").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("PDB").ToString()));
                connection4 = new SqlConnection(ConCheck4.ConnectString);
                SqlCommand command = new SqlCommand(sql4, connection4);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
				
                connection4.Open();
                adapter.Fill(edaTable4);
                phonesGrid.ItemsSource = edaTable4.DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection4 != null)
                    connection4.Close();
			
			}            
            break;
           case "Клиенты":
            string sql5 = "SELECT * FROM Klienty";
            DataTable edaTable5 = new DataTable();
            SqlConnection connection5 = null;
            try
            {
            	ConnectionClass ConCheck5 = new ConnectionClass();
            	RegistryKey DataBase_Connection = Registry.CurrentConfig;
            	RegistryKey Connection_Base_Party_Options = DataBase_Connection.CreateSubKey("DB_PARTY_OPTIOS");
            	ConCheck5.Connection_Options(Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("DS").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("IC").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("UID").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("PDB").ToString()));
                connection5 = new SqlConnection(ConCheck5.ConnectString);
                SqlCommand command = new SqlCommand(sql5, connection5);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
				
                connection5.Open();
                adapter.Fill(edaTable5);
                phonesGrid.ItemsSource = edaTable5.DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection5 != null)
                    connection5.Close();
			
			}
            break;
           case "Контракты":
            string sql6 = "SELECT * FROM Kontrakt";
            DataTable edaTable6 = new DataTable();
            SqlConnection connection6 = null;
            try
            {
            	ConnectionClass ConCheck6 = new ConnectionClass();
            	RegistryKey DataBase_Connection = Registry.CurrentConfig;
            	RegistryKey Connection_Base_Party_Options = DataBase_Connection.CreateSubKey("DB_PARTY_OPTIOS");
            	ConCheck6.Connection_Options(Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("DS").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("IC").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("UID").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("PDB").ToString()));
                connection6 = new SqlConnection(ConCheck6.ConnectString);
                SqlCommand command = new SqlCommand(sql6, connection6);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
				
                connection6.Open();
                adapter.Fill(edaTable6);
                phonesGrid.ItemsSource = edaTable6.DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection6 != null)
                    connection6.Close();
			
			}
            break;
           case "Отдел маркетинга":
            string sql7 = "SELECT * FROM Otdel_marketinga";
            DataTable edaTable7 = new DataTable();
            SqlConnection connection7 = null;
            try
            {
            	ConnectionClass ConCheck7 = new ConnectionClass();
            	RegistryKey DataBase_Connection = Registry.CurrentConfig;
            	RegistryKey Connection_Base_Party_Options = DataBase_Connection.CreateSubKey("DB_PARTY_OPTIOS");
            	ConCheck7.Connection_Options(Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("DS").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("IC").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("UID").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("PDB").ToString()));
                connection7 = new SqlConnection(ConCheck7.ConnectString);
                SqlCommand command = new SqlCommand(sql7, connection7);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
				
                connection7.Open();
                adapter.Fill(edaTable7);
                phonesGrid.ItemsSource = edaTable7.DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection7 != null)
                    connection7.Close();
			
			}
            	break;
            case "Подразделения":
            string sql8 = "SELECT * FROM Podrazdel";
            DataTable edaTable8 = new DataTable();
            SqlConnection connection8 = null;
            try
            {
            	ConnectionClass ConCheck8 = new ConnectionClass();
            	RegistryKey DataBase_Connection = Registry.CurrentConfig;
            	RegistryKey Connection_Base_Party_Options = DataBase_Connection.CreateSubKey("DB_PARTY_OPTIOS");
            	ConCheck8.Connection_Options(Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("DS").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("IC").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("UID").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("PDB").ToString()));
                connection8 = new SqlConnection(ConCheck8.ConnectString);
                SqlCommand command = new SqlCommand(sql8, connection8);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
				
                connection8.Open();
                adapter.Fill(edaTable8);
                phonesGrid.ItemsSource = edaTable8.DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection8 != null)
                    connection8.Close();
			
			}	
            	break;
            case "Приказ о переводе":
            	string sql9 = "SELECT * FROM Prikaz_perevod";
            DataTable edaTable9 = new DataTable();
            SqlConnection connection9 = null;
            try
            {
            	ConnectionClass ConCheck9 = new ConnectionClass();
            	RegistryKey DataBase_Connection = Registry.CurrentConfig;
            	RegistryKey Connection_Base_Party_Options = DataBase_Connection.CreateSubKey("DB_PARTY_OPTIOS");
            	ConCheck9.Connection_Options(Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("DS").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("IC").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("UID").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("PDB").ToString()));
                connection9 = new SqlConnection(ConCheck9.ConnectString);
                SqlCommand command = new SqlCommand(sql9, connection9);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
				
                connection9.Open();
                adapter.Fill(edaTable9);
                phonesGrid.ItemsSource = edaTable9.DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection9 != null)
                    connection9.Close();
			
			}	
            	break;
            case "Приказ об увольнении":
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
                phonesGrid.ItemsSource = edaTable10.DefaultView;

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
            	break;
            case "Приказ о приеме на работу":
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
                phonesGrid.ItemsSource = edaTable11.DefaultView;

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
            	
            	break;
            case "Продажа":
            	string sql12 = "SELECT * FROM Prodaja";
            DataTable edaTable12 = new DataTable();
            SqlConnection connection12 = null;
            try
            {
            	ConnectionClass ConCheck12 = new ConnectionClass();
            	RegistryKey DataBase_Connection = Registry.CurrentConfig;
            	RegistryKey Connection_Base_Party_Options = DataBase_Connection.CreateSubKey("DB_PARTY_OPTIOS");
            	ConCheck12.Connection_Options(Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("DS").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("IC").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("UID").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("PDB").ToString()));
                connection12 = new SqlConnection(ConCheck12.ConnectString);
                SqlCommand command = new SqlCommand(sql12, connection12);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
				
                connection12.Open();
                adapter.Fill(edaTable12);
                phonesGrid.ItemsSource = edaTable12.DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection12 != null)
                    connection12.Close();
			
			}
            	break;
            case "Реклама":
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
                phonesGrid.ItemsSource = edaTable13.DefaultView;

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
            	break;
            case "Ремонт":
            	string sql14 = "SELECT * FROM Remont";
            DataTable edaTable14 = new DataTable();
            SqlConnection connection14 = null;
            try
            {
            	ConnectionClass ConCheck14 = new ConnectionClass();
            	RegistryKey DataBase_Connection = Registry.CurrentConfig;
            	RegistryKey Connection_Base_Party_Options = DataBase_Connection.CreateSubKey("DB_PARTY_OPTIOS");
            	ConCheck14.Connection_Options(Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("DS").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("IC").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("UID").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("PDB").ToString()));
                connection14 = new SqlConnection(ConCheck14.ConnectString);
                SqlCommand command = new SqlCommand(sql14, connection14);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
				
                connection14.Open();
                adapter.Fill(edaTable14);
                phonesGrid.ItemsSource = edaTable14.DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection14 != null)
                    connection14.Close();
			
			}
            	break;
            case "Счет":
            	string sql15 = "SELECT * FROM Schet";
            DataTable edaTable15 = new DataTable();
            SqlConnection connection15 = null;
            try
            {
            	ConnectionClass ConCheck15 = new ConnectionClass();
            	RegistryKey DataBase_Connection = Registry.CurrentConfig;
            	RegistryKey Connection_Base_Party_Options = DataBase_Connection.CreateSubKey("DB_PARTY_OPTIOS");
            	ConCheck15.Connection_Options(Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("DS").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("IC").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("UID").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("PDB").ToString()));
                connection15 = new SqlConnection(ConCheck15.ConnectString);
                SqlCommand command = new SqlCommand(sql15, connection15);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
				
                connection15.Open();
                adapter.Fill(edaTable15);
                phonesGrid.ItemsSource = edaTable15.DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection15 != null)
                    connection15.Close();
			
			}
            	break;
            case "Склад":
            string sql16 = "SELECT * FROM sklad";
            DataTable edaTable16 = new DataTable();
            SqlConnection connection16 = null;
            try
            {
            	ConnectionClass ConCheck16 = new ConnectionClass();
            	RegistryKey DataBase_Connection = Registry.CurrentConfig;
            	RegistryKey Connection_Base_Party_Options = DataBase_Connection.CreateSubKey("DB_PARTY_OPTIOS");
            	ConCheck16.Connection_Options(Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("DS").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("IC").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("UID").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("PDB").ToString()));
                connection16 = new SqlConnection(ConCheck16.ConnectString);
                SqlCommand command = new SqlCommand(sql16, connection16);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
				
                connection16.Open();
                adapter.Fill(edaTable16);
                phonesGrid.ItemsSource = edaTable16.DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection16 != null)
                    connection16.Close();
			
			}	
            break;
           case "Сотрудник":
            string sql17 = "SELECT * FROM Sotrudnik";
            DataTable edaTable17 = new DataTable();
            SqlConnection connection17 = null;
            try
            {
            	ConnectionClass ConCheck17 = new ConnectionClass();
            	RegistryKey DataBase_Connection = Registry.CurrentConfig;
            	RegistryKey Connection_Base_Party_Options = DataBase_Connection.CreateSubKey("DB_PARTY_OPTIOS");
            	ConCheck17.Connection_Options(Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("DS").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("IC").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("UID").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("PDB").ToString()));
                connection17 = new SqlConnection(ConCheck17.ConnectString);
                SqlCommand command = new SqlCommand(sql17, connection17);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
				
                connection17.Open();
                adapter.Fill(edaTable17);
                phonesGrid.ItemsSource = edaTable17.DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection17 != null)
                    connection17.Close();
			
			}
            break;
           case "Штатное расписание":
            string sql18 = "SELECT * FROM Stat_rasp";
            DataTable edaTable18 = new DataTable();
            SqlConnection connection18 = null;
            try
            {
            	ConnectionClass ConCheck18 = new ConnectionClass();
            	RegistryKey DataBase_Connection = Registry.CurrentConfig;
            	RegistryKey Connection_Base_Party_Options = DataBase_Connection.CreateSubKey("DB_PARTY_OPTIOS");
            	ConCheck18.Connection_Options(Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("DS").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("IC").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("UID").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("PDB").ToString()));
                connection18 = new SqlConnection(ConCheck18.ConnectString);
                SqlCommand command = new SqlCommand(sql18, connection18);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
				
                connection18.Open();
                adapter.Fill(edaTable18);
                phonesGrid.ItemsSource = edaTable18.DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection18 != null)
                    connection18.Close();
			
			}
            	break;
            case "Товар":
            string sql19 = "SELECT * FROM Tovar";
            DataTable edaTable19 = new DataTable();
            SqlConnection connection19 = null;
            try
            {
            	ConnectionClass ConCheck19 = new ConnectionClass();
            	RegistryKey DataBase_Connection = Registry.CurrentConfig;
            	RegistryKey Connection_Base_Party_Options = DataBase_Connection.CreateSubKey("DB_PARTY_OPTIOS");
            	ConCheck19.Connection_Options(Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("DS").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("IC").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("UID").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("PDB").ToString()));
                connection19 = new SqlConnection(ConCheck19.ConnectString);
                SqlCommand command = new SqlCommand(sql19, connection19);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
				
                connection19.Open();
                adapter.Fill(edaTable19);
                phonesGrid.ItemsSource = edaTable19.DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection19 != null)
                    connection19.Close();
			
			}
            	break;
            case "Товар на складах":
            string sql20 = "SELECT * FROM Tovar_na_skladakh";
            DataTable edaTable20 = new DataTable();
            SqlConnection connection20 = null;
            try
            {
            	ConnectionClass ConCheck20 = new ConnectionClass();
            	RegistryKey DataBase_Connection = Registry.CurrentConfig;
            	RegistryKey Connection_Base_Party_Options = DataBase_Connection.CreateSubKey("DB_PARTY_OPTIOS");
            	ConCheck20.Connection_Options(Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("DS").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("IC").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("UID").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("PDB").ToString()));
                connection20 = new SqlConnection(ConCheck20.ConnectString);
                SqlCommand command = new SqlCommand(sql20, connection20);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
				
                connection20.Open();
                adapter.Fill(edaTable20);
                phonesGrid.ItemsSource = edaTable20.DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection20 != null)
                    connection20.Close();
			
			}
            	break;
            case "товар склд":
            string sql21 = "SELECT * FROM Tovar_na_skladakh";
            DataTable edaTable21 = new DataTable();
            SqlConnection connection21 = null;
            try
            {
            	ConnectionClass ConCheck21 = new ConnectionClass();
            	RegistryKey DataBase_Connection = Registry.CurrentConfig;
            	RegistryKey Connection_Base_Party_Options = DataBase_Connection.CreateSubKey("DB_PARTY_OPTIOS");
            	ConCheck21.Connection_Options(Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("DS").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("IC").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("UID").ToString()), 
                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("PDB").ToString()));
                connection21 = new SqlConnection(ConCheck21.ConnectString);
                SqlCommand command = new SqlCommand(sql21, connection21);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
				
                connection21.Open();
                adapter.Fill(edaTable21);
                phonesGrid.ItemsSource = edaTable21.DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection21 != null)
                    connection21.Close();
			
			}
            break;
		}
          
		}

	}
}