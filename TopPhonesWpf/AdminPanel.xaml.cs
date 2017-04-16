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
		public string chto_vyb;
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
		void button3_Click(object sender, RoutedEventArgs e)
		{
			chto_vyb = "Товары";
			 string sql = "SELECT        dbo.Proizvoditel.Name_proizv, dbo.sklad.nazvanie_tovara_sklad, dbo.Tovar.kol_vo, dbo.Tovar.cena " 
			 	+"FROM dbo.Postavshik INNER JOIN dbo.Tovar ON dbo.Postavshik.ID_Postavshik = dbo.Tovar.Postavshik_ID INNER JOIN dbo.Proizvoditel "+
			 	"ON dbo.Tovar.Proizvoditel_ID = dbo.Proizvoditel.ID_proizvod INNER JOIN dbo.tovarskld ON dbo.Tovar.ID_Tovarpr = dbo.tovarskld.kod_tovara_id " +
			 	"INNER JOIN dbo.Tovar_na_skladakh ON dbo.tovarskld.id_nomer_tovara_na_sklade = dbo.Tovar_na_skladakh.nomer_tovara_na_sklade CROSS JOIN dbo.sklad";
            DataTable phones = new DataTable();
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
                adapter.Fill(phones);
                phonesGrid.ItemsSource = phones.DefaultView;
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
		void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
	
		}
		void button4_Click(object sender, RoutedEventArgs e)
		{
			switch (chto_vyb) {
				case "Товары":
					
					break;
			}
		}
		}

	}