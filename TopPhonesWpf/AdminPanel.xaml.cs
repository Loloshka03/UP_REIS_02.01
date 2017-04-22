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
		tablefillclass tfk = new tablefillclass ();
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
			strdnkwndw.role = "Боженька";
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
			case "Договор":
					ConnectionClass ConCheck3 = new ConnectionClass();
            		RegistryKey DataBase_Connection3 = Registry.CurrentConfig;
            		RegistryKey Connection_Base_Party_Options3 = DataBase_Connection3.CreateSubKey("DB_PARTY_OPTIOS");
            		ConCheck3.Connection_Options(Encrypt.Decrypt(Connection_Base_Party_Options3.GetValue("DS").ToString()),            		                            
                	Encrypt.Decrypt(Connection_Base_Party_Options3.GetValue("IC").ToString()), 
                	Encrypt.Decrypt(Connection_Base_Party_Options3.GetValue("UID").ToString()), 
                	Encrypt.Decrypt(Connection_Base_Party_Options3.GetValue("PDB").ToString()));
                	SqlConnection connection3 = new SqlConnection(ConCheck3.ConnectString);
                	connection3.Open();
                	SqlCommand command3 = new SqlCommand("[dbo].[Dogovor_add]", connection3);
                	command3.CommandType = CommandType.StoredProcedure;
                	command3.Parameters.AddWithValue("@Date_remont", txtbx1.Text);
                	command3.Parameters.AddWithValue("@time_remont", txtbx2.Text);
                	
                	command3.ExecuteNonQuery();
                	connection3.Close();
                	cmbx1_SelectionChanged(bl, i);
				break;
			case "Должность":
					ConnectionClass ConCheck4 = new ConnectionClass();
            		RegistryKey DataBase_Connection4 = Registry.CurrentConfig;
            		RegistryKey Connection_Base_Party_Options4 = DataBase_Connection4.CreateSubKey("DB_PARTY_OPTIOS");
            		ConCheck4.Connection_Options(Encrypt.Decrypt(Connection_Base_Party_Options4.GetValue("DS").ToString()),            		                            
                	Encrypt.Decrypt(Connection_Base_Party_Options4.GetValue("IC").ToString()), 
                	Encrypt.Decrypt(Connection_Base_Party_Options4.GetValue("UID").ToString()), 
                	Encrypt.Decrypt(Connection_Base_Party_Options4.GetValue("PDB").ToString()));
                	SqlConnection connection4 = new SqlConnection(ConCheck4.ConnectString);
                	connection4.Open();
                	SqlCommand command4 = new SqlCommand("[dbo].[dolj_add]", connection4);
                	command4.CommandType = CommandType.StoredProcedure;
                	command4.Parameters.AddWithValue("@Nazv_dolj", txtbx1.Text);
                	command4.ExecuteNonQuery();
                	connection4.Close();
                	cmbx1_SelectionChanged(bl, i);
				break;
			case "Клиенты":
					ConnectionClass ConCheck5 = new ConnectionClass();
            		RegistryKey DataBase_Connection5 = Registry.CurrentConfig;
            		RegistryKey Connection_Base_Party_Options5 = DataBase_Connection5.CreateSubKey("DB_PARTY_OPTIOS");
            		ConCheck5.Connection_Options(Encrypt.Decrypt(Connection_Base_Party_Options5.GetValue("DS").ToString()),            		                            
                	Encrypt.Decrypt(Connection_Base_Party_Options5.GetValue("IC").ToString()), 
                	Encrypt.Decrypt(Connection_Base_Party_Options5.GetValue("UID").ToString()), 
                	Encrypt.Decrypt(Connection_Base_Party_Options5.GetValue("PDB").ToString()));
                	SqlConnection connection5 = new SqlConnection(ConCheck5.ConnectString);
                	connection5.Open();
                	SqlCommand command5 = new SqlCommand("[dbo].[Klienty_add]", connection5);
                	command5.CommandType = CommandType.StoredProcedure;
                	command5.Parameters.AddWithValue("@Name_Klient", txtbx1.Text);
                	command5.Parameters.AddWithValue("@Phone_klient", txtbx2.Text);
                	command5.Parameters.AddWithValue("@Klient_adress", txtbx3.Text);
                	command5.Parameters.AddWithValue("@Klient_otch", txtbx4.Text);
                	command5.Parameters.AddWithValue("@Klient_fam", txtbx5.Text);
                	command5.Parameters.AddWithValue("@Login", txtbx6.Text);
                	command5.Parameters.AddWithValue("@pass", txtbx7.Text);
                	command5.Parameters.AddWithValue("@rol", txtbx8.Text);
                	command5.ExecuteNonQuery();
                	connection5.Close();
                	cmbx1_SelectionChanged(bl, i);
                	break;
                case"Отдел маркетинга":
                	ConnectionClass ConCheck6 = new ConnectionClass();
            		RegistryKey DataBase_Connection6 = Registry.CurrentConfig;
            		RegistryKey Connection_Base_Party_Options6 = DataBase_Connection6.CreateSubKey("DB_PARTY_OPTIOS");
            		ConCheck6.Connection_Options(Encrypt.Decrypt(Connection_Base_Party_Options6.GetValue("DS").ToString()),            		                            
                	Encrypt.Decrypt(Connection_Base_Party_Options6.GetValue("IC").ToString()), 
                	Encrypt.Decrypt(Connection_Base_Party_Options6.GetValue("UID").ToString()), 
                	Encrypt.Decrypt(Connection_Base_Party_Options6.GetValue("PDB").ToString()));
                	SqlConnection connection6 = new SqlConnection(ConCheck6.ConnectString);
                	connection6.Open();
                	SqlCommand command6 = new SqlCommand("[dbo].[Otdel_marketinga_add]", connection6);
                	command6.CommandType = CommandType.StoredProcedure;
                	command6.Parameters.AddWithValue("@Kontact_tlf", txtbx1.Text);
                	connection6.Close();
                	cmbx1_SelectionChanged(bl, i);
                	break;
                case "Подразделения":
                	ConnectionClass ConCheck7 = new ConnectionClass();
            		RegistryKey DataBase_Connection7 = Registry.CurrentConfig;
            		RegistryKey Connection_Base_Party_Options7 = DataBase_Connection7.CreateSubKey("DB_PARTY_OPTIOS");
            		ConCheck7.Connection_Options(Encrypt.Decrypt(Connection_Base_Party_Options7.GetValue("DS").ToString()),            		                            
                	Encrypt.Decrypt(Connection_Base_Party_Options7.GetValue("IC").ToString()), 
                	Encrypt.Decrypt(Connection_Base_Party_Options7.GetValue("UID").ToString()), 
                	Encrypt.Decrypt(Connection_Base_Party_Options7.GetValue("PDB").ToString()));
                	SqlConnection connection7 = new SqlConnection(ConCheck7.ConnectString);
                	connection7.Open();
                	SqlCommand command7 = new SqlCommand("[dbo].[Podrazdel_add]", connection7);
                	command7.CommandType = CommandType.StoredProcedure;
                	command7.Parameters.AddWithValue("@Podrazdel_name", txtbx1.Text);
                	connection7.Close();
                	cmbx1_SelectionChanged(bl, i);
                	break;
                case "Приказ о переводе":
                	ConnectionClass ConCheck8 = new ConnectionClass();
            		RegistryKey DataBase_Connection8 = Registry.CurrentConfig;
            		RegistryKey Connection_Base_Party_Options8 = DataBase_Connection8.CreateSubKey("DB_PARTY_OPTIOS");
            		ConCheck8.Connection_Options(Encrypt.Decrypt(Connection_Base_Party_Options8.GetValue("DS").ToString()),            		                            
                	Encrypt.Decrypt(Connection_Base_Party_Options8.GetValue("IC").ToString()), 
                	Encrypt.Decrypt(Connection_Base_Party_Options8.GetValue("UID").ToString()), 
                	Encrypt.Decrypt(Connection_Base_Party_Options8.GetValue("PDB").ToString()));
                	SqlConnection connection8 = new SqlConnection(ConCheck8.ConnectString);
                	connection8.Open();
                	SqlCommand command8 = new SqlCommand("[dbo].[Prikaz_perevod_add]", connection8);
                	command8.CommandType = CommandType.StoredProcedure;
                	command8.Parameters.AddWithValue("@Podrazdel_name", txtbx1.Text);
                	connection8.Close();
                	cmbx1_SelectionChanged(bl, i);
                	break;
                case "Приказ о приеме на работу":
                	ConnectionClass ConCheck9 = new ConnectionClass();
            		RegistryKey DataBase_Connection9 = Registry.CurrentConfig;
            		RegistryKey Connection_Base_Party_Options9 = DataBase_Connection9.CreateSubKey("DB_PARTY_OPTIOS");
            		ConCheck9.Connection_Options(Encrypt.Decrypt(Connection_Base_Party_Options9.GetValue("DS").ToString()),            		                            
                	Encrypt.Decrypt(Connection_Base_Party_Options9.GetValue("IC").ToString()), 
                	Encrypt.Decrypt(Connection_Base_Party_Options9.GetValue("UID").ToString()), 
                	Encrypt.Decrypt(Connection_Base_Party_Options9.GetValue("PDB").ToString()));
                	SqlConnection connection9 = new SqlConnection(ConCheck9.ConnectString);
                	connection9.Open();
                	SqlCommand command9 = new SqlCommand("[dbo].[Prikaz_prikaz_priem_na_rab]", connection9);
                	command9.CommandType = CommandType.StoredProcedure;
                	command9.Parameters.AddWithValue("@Utverzh_Date", txtbx1.Text);
                	command9.Parameters.AddWithValue("@kol_vo_stavok", txtbx2.Text);
                	connection9.Close();
                	cmbx1_SelectionChanged(bl, i);
                	break;
                case "Приказ об увольнении":
                	ConnectionClass ConCheck10 = new ConnectionClass();
            		RegistryKey DataBase_Connection10 = Registry.CurrentConfig;
            		RegistryKey Connection_Base_Party_Options10 = DataBase_Connection10.CreateSubKey("DB_PARTY_OPTIOS");
            		ConCheck10.Connection_Options(Encrypt.Decrypt(Connection_Base_Party_Options10.GetValue("DS").ToString()),            		                            
                	Encrypt.Decrypt(Connection_Base_Party_Options10.GetValue("IC").ToString()), 
                	Encrypt.Decrypt(Connection_Base_Party_Options10.GetValue("UID").ToString()), 
                	Encrypt.Decrypt(Connection_Base_Party_Options10.GetValue("PDB").ToString()));
                	SqlConnection connection10 = new SqlConnection(ConCheck10.ConnectString);
                	connection10.Open();
                	SqlCommand command10 = new SqlCommand("[dbo].[Prikaz_prikaz_priem_na_rab]", connection10);
                	command10.CommandType = CommandType.StoredProcedure;
                	command10.Parameters.AddWithValue("@Date_utv", txtbx1.Text);
                	command10.Parameters.AddWithValue("@Osnov", txtbx2.Text);
                	connection10.Close();
                	cmbx1_SelectionChanged(bl, i);
                	break;
                case "Продажа":
                	ConnectionClass ConCheck11 = new ConnectionClass();
            		RegistryKey DataBase_Connection11 = Registry.CurrentConfig;
            		RegistryKey Connection_Base_Party_Options11 = DataBase_Connection11.CreateSubKey("DB_PARTY_OPTIOS");
            		ConCheck11.Connection_Options(Encrypt.Decrypt(Connection_Base_Party_Options11.GetValue("DS").ToString()),            		                            
                	Encrypt.Decrypt(Connection_Base_Party_Options11.GetValue("IC").ToString()), 
                	Encrypt.Decrypt(Connection_Base_Party_Options11.GetValue("UID").ToString()), 
                	Encrypt.Decrypt(Connection_Base_Party_Options11.GetValue("PDB").ToString()));
                	SqlConnection connection11 = new SqlConnection(ConCheck11.ConnectString);
                	connection11.Open();
                	SqlCommand command11 = new SqlCommand("[dbo].[Prikaz_prikaz_priem_na_rab]", connection11);
                	command11.CommandType = CommandType.StoredProcedure;
                	command11.Parameters.AddWithValue("@sale_prodaja", txtbx1.Text);
                	command11.Parameters.AddWithValue("@kol_vo_tovara", txtbx2.Text);
                	command11.Parameters.AddWithValue("@summ_pokup", txtbx3.Text);
                	connection11.Close();
                	cmbx1_SelectionChanged(bl, i);
                	break;
                case"Реклама":
                	ConnectionClass ConCheck12 = new ConnectionClass();
            		RegistryKey DataBase_Connection12 = Registry.CurrentConfig;
            		RegistryKey Connection_Base_Party_Options12 = DataBase_Connection12.CreateSubKey("DB_PARTY_OPTIOS");
            		ConCheck12.Connection_Options(Encrypt.Decrypt(Connection_Base_Party_Options12.GetValue("DS").ToString()),            		                            
                	Encrypt.Decrypt(Connection_Base_Party_Options12.GetValue("IC").ToString()), 
                	Encrypt.Decrypt(Connection_Base_Party_Options12.GetValue("UID").ToString()), 
                	Encrypt.Decrypt(Connection_Base_Party_Options12.GetValue("PDB").ToString()));
                	SqlConnection connection12 = new SqlConnection(ConCheck12.ConnectString);
                	connection12.Open();
                	SqlCommand command12 = new SqlCommand("[dbo].[Prikaz_prikaz_priem_na_rab]", connection12);
                	command12.CommandType = CommandType.StoredProcedure;
                	command12.Parameters.AddWithValue("@date_nach_vyx", txtbx1.Text);
                	command12.Parameters.AddWithValue("@date_okonch_vyx", txtbx2.Text);
                	command12.Parameters.AddWithValue("@End_efir_date", txtbx3.Text);
                	command12.Parameters.AddWithValue("@Prodolj", txtbx4.Text);
                	command12.Parameters.AddWithValue("@Obsch_kol_vo", txtbx5.Text);
                	command12.Parameters.AddWithValue("@Naimen_uslug", txtbx6.Text);
                	command12.Parameters.AddWithValue("@Rekl_time_sut", txtbx7.Text);
                	command12.Parameters.AddWithValue("@Oplat_sut", txtbx8.Text);
                	connection12.Close();
                	cmbx1_SelectionChanged(bl, i);
                	break;
                case"Ремонт":
                	ConnectionClass ConCheck13 = new ConnectionClass();
            		RegistryKey DataBase_Connection13 = Registry.CurrentConfig;
            		RegistryKey Connection_Base_Party_Options13 = DataBase_Connection13.CreateSubKey("DB_PARTY_OPTIOS");
            		ConCheck13.Connection_Options(Encrypt.Decrypt(Connection_Base_Party_Options13.GetValue("DS").ToString()),            		                            
                	Encrypt.Decrypt(Connection_Base_Party_Options13.GetValue("IC").ToString()), 
                	Encrypt.Decrypt(Connection_Base_Party_Options13.GetValue("UID").ToString()), 
                	Encrypt.Decrypt(Connection_Base_Party_Options13.GetValue("PDB").ToString()));
                	SqlConnection connection13 = new SqlConnection(ConCheck13.ConnectString);
                	connection13.Open();
                	SqlCommand command13 = new SqlCommand("[dbo].[Prikaz_prikaz_priem_na_rab]", connection13);
                	command13.CommandType = CommandType.StoredProcedure;
                	command13.Parameters.AddWithValue("@stoimost", txtbx1.Text);
                	command13.Parameters.AddWithValue("@type_nepoladky", txtbx2.Text);
                	connection13.Close();
                	cmbx1_SelectionChanged(bl, i);
                	break;
                case"Склад":
                	ConnectionClass ConCheck14 = new ConnectionClass();
            		RegistryKey DataBase_Connection14 = Registry.CurrentConfig;
            		RegistryKey Connection_Base_Party_Options14 = DataBase_Connection14.CreateSubKey("DB_PARTY_OPTIOS");
            		ConCheck14.Connection_Options(Encrypt.Decrypt(Connection_Base_Party_Options14.GetValue("DS").ToString()),            		                            
                	Encrypt.Decrypt(Connection_Base_Party_Options14.GetValue("IC").ToString()), 
                	Encrypt.Decrypt(Connection_Base_Party_Options14.GetValue("UID").ToString()), 
                	Encrypt.Decrypt(Connection_Base_Party_Options14.GetValue("PDB").ToString()));
                	SqlConnection connection14 = new SqlConnection(ConCheck14.ConnectString);
                	connection14.Open();
                	SqlCommand command14 = new SqlCommand("[dbo].[Prikaz_prikaz_priem_na_rab]", connection14);
                	command14.CommandType = CommandType.StoredProcedure;
                	command14.Parameters.AddWithValue("@Sklad_add", txtbx1.Text);
                	command14.Parameters.AddWithValue("@type_nepoladky", txtbx2.Text);
                	connection14.Close();
                	cmbx1_SelectionChanged(bl, i);
                	break;
						
			}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка при добавлении данных. Ошибка " + ex.Message);
			}
		}
		
		void del_button_click(object sender, RoutedEventArgs e)
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
                	SqlCommand command = new SqlCommand("[dbo].[Proizvoditel_del]", connection);
                	command.CommandType = CommandType.StoredProcedure;
                	command.Parameters.AddWithValue("@id_proizvoditel", txtbx1.Text);
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
                	SqlCommand command1 = new SqlCommand("[dbo].[Klienty_del]", connection1);
                	command1.CommandType = CommandType.StoredProcedure;
                	command1.Parameters.AddWithValue("@id_klienty", txtbx1.Text);
                	command1.ExecuteNonQuery();
                	connection1.Close();
                	cmbx1_SelectionChanged(bl, i);
					break;
				case"Клиенты":
					ConnectionClass ConCheck2 = new ConnectionClass();
            		RegistryKey DataBase_Connection2 = Registry.CurrentConfig;
            		RegistryKey Connection_Base_Party_Options2 = DataBase_Connection2.CreateSubKey("DB_PARTY_OPTIOS");
            		ConCheck2.Connection_Options(Encrypt.Decrypt(Connection_Base_Party_Options2.GetValue("DS").ToString()),            		                            
                	Encrypt.Decrypt(Connection_Base_Party_Options2.GetValue("IC").ToString()), 
                	Encrypt.Decrypt(Connection_Base_Party_Options2.GetValue("UID").ToString()), 
                	Encrypt.Decrypt(Connection_Base_Party_Options2.GetValue("PDB").ToString()));
                	SqlConnection connection2 = new SqlConnection(ConCheck2.ConnectString);
                	connection2.Open();
                	SqlCommand command2 = new SqlCommand("[dbo].[Klienty_del]", connection2);
                	command2.CommandType = CommandType.StoredProcedure;
                	command2.Parameters.AddWithValue("@id_klienty", txtbx1.Text);
                	command2.ExecuteNonQuery();
                	connection2.Close();
                	cmbx1_SelectionChanged(bl, i);
					break;
				case "Рекламодатель":
					ConnectionClass ConCheck3 = new ConnectionClass();
            		RegistryKey DataBase_Connection3 = Registry.CurrentConfig;
            		RegistryKey Connection_Base_Party_Options3 = DataBase_Connection3.CreateSubKey("DB_PARTY_OPTIOS");
            		ConCheck3.Connection_Options(Encrypt.Decrypt(Connection_Base_Party_Options3.GetValue("DS").ToString()),            		                            
                	Encrypt.Decrypt(Connection_Base_Party_Options3.GetValue("IC").ToString()), 
                	Encrypt.Decrypt(Connection_Base_Party_Options3.GetValue("UID").ToString()), 
                	Encrypt.Decrypt(Connection_Base_Party_Options3.GetValue("PDB").ToString()));
                	SqlConnection connection3 = new SqlConnection(ConCheck3.ConnectString);
                	connection3.Open();
                	SqlCommand command3 = new SqlCommand("[dbo].[Reklamodatel_del]", connection3);
                	command3.CommandType = CommandType.StoredProcedure;
                	command3.Parameters.AddWithValue("@ID_reklamodatel", txtbx1.Text);
                	command3.ExecuteNonQuery();
                	connection3.Close();
                	cmbx1_SelectionChanged(bl, i);
					break;
					}
			}
					catch (Exception bl)
					{
						MessageBox.Show("Во время удаления данных произошла следующая ошибка" + bl.Message);
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
			cmbx1.SelectedIndex = 2;
			
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
			tfk = new tablefillclass ("SELECT * FROM Proizvoditel");
                phonesGrid.ItemsSource = tfk.Table.DefaultView;
					break;
			//----------------------------------------------------------------------------
		case "Поставщик":
			tfk = new tablefillclass("SELECT * FROM Postavshik");
           	phonesGrid.ItemsSource = tfk.Table.DefaultView;

            break;
            //---------------------------------------------------------------------------------------------------
           case "Рекламодатель":
            
            tfk = new tablefillclass( "SELECT * FROM Reklamodatel");
            phonesGrid.ItemsSource = tfk.Table.DefaultView;;
            break;
           case "Договор":
            tfk = new tablefillclass("SELECT * FROM Dogovor");
                phonesGrid.ItemsSource = tfk.Table.DefaultView;
            break;
           case "Должность":
            tfk = new tablefillclass("SELECT * FROM Dolj");
                phonesGrid.ItemsSource = tfk.Table.DefaultView;
            break;
           case "Клиенты":
            txtbx5.Visibility = Visibility.Visible;
            txtbx6.Visibility = Visibility.Visible;
            txtbx7.Visibility = Visibility.Visible;
            txtbx8.Visibility = Visibility.Visible;
            txtbx9.Visibility = Visibility.Visible;
            tfk = new tablefillclass("SELECT * FROM Klienty");
                phonesGrid.ItemsSource = tfk.Table.DefaultView;
            break;
           case "Контракты":
            tfk =new tablefillclass("SELECT * FROM Kontrakt");
                phonesGrid.ItemsSource = tfk.Table.DefaultView;
            break;
           case "Отдел маркетинга":
            tfk = new tablefillclass ("SELECT * FROM Otdel_marketinga");
                phonesGrid.ItemsSource = tfk.Table.DefaultView;
            	break;
            case "Подразделения":
            	tfk = new tablefillclass( "SELECT * FROM Podrazdel");
                phonesGrid.ItemsSource = tfk.Table.DefaultView;
            	break;
            case "Приказ о переводе":
            	tfk=new tablefillclass ("SELECT * FROM Prikaz_perevod");
                phonesGrid.ItemsSource = tfk.Table.DefaultView;
            	break;
            case "Приказ об увольнении":
            	tfk = new tablefillclass( "SELECT * FROM Prikaz_uvoln");
                phonesGrid.ItemsSource = tfk.Table.DefaultView;
            	break;
            case "Приказ о приеме на работу":
            	tfk = new tablefillclass ("SELECT * FROM Prikaz_priem_na_rab");
                phonesGrid.ItemsSource = tfk.Table.DefaultView;;            	
            	break;
            case "Продажа":
            	tfk = new tablefillclass ("SELECT * FROM Prodaja");
                phonesGrid.ItemsSource = tfk.Table.DefaultView;
				break;
            case "Реклама":
				tfk = new tablefillclass("SELECT * FROM Reklama");
                phonesGrid.ItemsSource =tfk.Table.DefaultView;
            	break;
            case "Ремонт":
            	tfk= new tablefillclass("SELECT * FROM Remont");
                phonesGrid.ItemsSource = tfk.Table.DefaultView;
            	break;
            case "Счет":
            	tfk = new tablefillclass("SELECT * FROM Schet");
                phonesGrid.ItemsSource = tfk.Table.DefaultView;
            	break;
            case "Склад":
            	tfk = new tablefillclass("SELECT * FROM sklad");
                phonesGrid.ItemsSource = tfk.Table.DefaultView;
		
            break;
           case "Сотрудник":
            tfk = new tablefillclass("SELECT * FROM Sotrudnik");
                phonesGrid.ItemsSource =tfk.Table.DefaultView;
            break;
           case "Штатное расписание":
            tfk = new tablefillclass( "SELECT * FROM Stat_rasp");
                phonesGrid.ItemsSource = tfk.Table.DefaultView;
            break;
            case "Товар":
            tfk =new tablefillclass("SELECT * FROM Tovar");
           
                phonesGrid.ItemsSource = tfk.Table.DefaultView;
            	break;
            case "Товар на складах":
            	tfk =new tablefillclass("SELECT * FROM Tovar_na_skladakh");
                phonesGrid.ItemsSource = tfk.Table.DefaultView;
            	break;
            case "товар склд":
            	tfk = new tablefillclass("SELECT * FROM Tovar_na_skladakh");
				phonesGrid.ItemsSource = tfk.Table.DefaultView;
				break;
			
		}
          
		}

		
		void button4_Copy1_Click(object sender, RoutedEventArgs e) //Кнопка изменить
		{
			try
			{
				switch(Convert.ToString(cmbx1.SelectedItem))
			{
					case "Клиенты":
					ConnectionClass ConCheck5 = new ConnectionClass();
            		RegistryKey DataBase_Connection5 = Registry.CurrentConfig;
            		RegistryKey Connection_Base_Party_Options5 = DataBase_Connection5.CreateSubKey("DB_PARTY_OPTIOS");
            		ConCheck5.Connection_Options(Encrypt.Decrypt(Connection_Base_Party_Options5.GetValue("DS").ToString()),            		                            
                	Encrypt.Decrypt(Connection_Base_Party_Options5.GetValue("IC").ToString()), 
                	Encrypt.Decrypt(Connection_Base_Party_Options5.GetValue("UID").ToString()), 
                	Encrypt.Decrypt(Connection_Base_Party_Options5.GetValue("PDB").ToString()));
                	SqlConnection connection5 = new SqlConnection(ConCheck5.ConnectString);
                	connection5.Open();
                	SqlCommand command5 = new SqlCommand("[dbo].[Klienty_update]", connection5);
                	command5.CommandType = CommandType.StoredProcedure;
                	command5.Parameters.AddWithValue("@id_klienty", txtbx1.Text);
                	command5.Parameters.AddWithValue("@Name_Klient", txtbx2.Text);
                	command5.Parameters.AddWithValue("@Phone_klient", txtbx3.Text);
                	command5.Parameters.AddWithValue("@Klient_adress", txtbx4.Text);
                	command5.Parameters.AddWithValue("@Klient_otch", txtbx5.Text);
                	command5.Parameters.AddWithValue("@Klient_fam", txtbx6.Text);
                	command5.Parameters.AddWithValue("@Login", txtbx7.Text);
                	command5.Parameters.AddWithValue("@pass", txtbx8.Text);
                	command5.Parameters.AddWithValue("@id_roli", txtbx9.Text);
                	command5.ExecuteNonQuery();
                	connection5.Close();
                	cmbx1_SelectionChanged(bl, i);
                	break;	
				}
			}
			catch (Exception bl)
			{
				MessageBox.Show(bl.Message);
			}
		}
	}
}