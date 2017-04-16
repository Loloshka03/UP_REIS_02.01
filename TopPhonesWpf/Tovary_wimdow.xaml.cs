/*
 * Created by SharpDevelop.
 * User: Ruslan
 * Date: 04/15/2017
 * Time: 21:22
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
using System.Configuration;

namespace TopPhonesWpf
{
	/// <summary>
	/// Interaction logic for Tovary_wimdow.xaml
	/// </summary>
	public partial class Tovary_wimdow : Window
	{
		public Tovary_wimdow()
		{
			InitializeComponent();
		}
		void window1_Loaded(object sender, RoutedEventArgs e)
		{
			 string sql = "SELECT dbo.Proizvoditel.Name_proizv, dbo.sklad.nazvanie_tovara_sklad, dbo.Tovar.kol_vo, dbo.Tovar.cena FROM            dbo.Proizvoditel INNER JOIN dbo.Tovar ON dbo.Proizvoditel.ID_proizvod = dbo.Tovar.Proizvoditel_ID INNER JOIN dbo.tovarskld ON dbo.Tovar.ID_Tovarpr = dbo.tovarskld.kod_tovara_id INNER JOIN dbo.Tovar_na_skladakh ON dbo.tovarskld.id_nomer_tovara_na_sklade = dbo.Tovar_na_skladakh.nomer_tovara_na_sklade CROSS JOIN dbo.sklad";
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

                // установка команды на добавление для вызова хранимой процедуры
               // adapter.InsertCommand = new SqlCommand("other`_add", connection);
                
             //   adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
              //  adapter.InsertCommand.Parameters.Add(new SqlParameter("@nane_eda", SqlDbType.NVarChar, 50, "Nazvaniye"));
               // adapter.InsertCommand.Parameters.Add(new SqlParameter("@cena_eda", SqlDbType.NVarChar, 50, "Poroda"));
               // SqlParameter parameter = adapter.InsertCommand.Parameters.Add("@Id_eda", SqlDbType.Int, 0, "id_nomer_otdela_sklada");
                //parameter.Direction = ParameterDirection.Output;

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
	}
}