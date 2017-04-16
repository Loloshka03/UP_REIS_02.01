/*
 * Created by SharpDevelop.
 * User: Ruslan
 * Date: 04/01/2017
 * Time: 13:36
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
using Microsoft.Win32;
using System.Data.SqlClient;

namespace TopPhonesWpf
{
	/// <summary>
	/// Interaction logic for RegistrationWindow.xaml
	/// </summary>
	public partial class RegistrationWindow : Window
	{
		public RegistrationWindow()
		{
			InitializeComponent();
		}
		void button1_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.ShowDialog();
			//if ofd.
		}
		void button2_Click(object sender, RoutedEventArgs e)
		{
				switch (Pass_box.Password == ConfPass_Box.Password)
            {
                case (true):
                    string NewUserCkeck;
                    ConnectionClass ConCheck = new ConnectionClass();
                    RegistryKey DataBase_Connection = Registry.CurrentConfig;
                    RegistryKey Connection_Base_Party_Options = DataBase_Connection.CreateSubKey("DB_PARTY_OPTIOS");
                    ConCheck.Connection_Options(Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("DS").ToString()),
                                                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("IC").ToString()), 
                                                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("UID").ToString()), 
                                                Encrypt.Decrypt(Connection_Base_Party_Options.GetValue("PDB").ToString()));
                    SqlConnection connectionNewUser = new SqlConnection(ConCheck.ConnectString);
                    SqlCommand Select_USID = new SqlCommand("select [dbo].[Klienty].[login]" +
                    " from [dbo].[Klient] inner join[dbo].[roli] on " +
                    "[dbo].[Klient].[id_roli] =[dbo].[roli].[id_roli]" +
                    "where login='" + Login_text.Text + "' and pass='" + Pass_box.Password + "'", connectionNewUser);
                    try
                    {
                        connectionNewUser.Open();
                        NewUserCkeck = Select_USID.ExecuteScalar().ToString();
                        connectionNewUser.Close();
                        MessageBox.Show("Пользователь с именем " + NameClient_textbox.Text + ", уже есть!");
                    }
                    catch
                    {
                        string GuestRole;
                        int Tel_Value;
                        SqlConnection connectionNewUserInsert = new SqlConnection(ConCheck.ConnectString);
                        SqlCommand SelectGuestRole = new SqlCommand("select ID_roli from [dbo].[roli] where Role_Name = 'Гость'"
                            , connectionNewUserInsert);
                        connectionNewUserInsert.Open();
                        SqlCommand CreateNewUser = new SqlCommand("insert into [dbo].[Klienty]" +
                        "([Name_Klient],[klient_otch],[klient_fam],[Phone_klient],[id_roli],[login],[pass],[Klient_adress])" +
                        "values ('" + NameClient_textbox.Text + "','" + FamKlient_textbox.Text + "','" + Otch_klient_Textbox.Text
                        + "','" + PhoneKlient_box.Text + "',"
                        + "'1'" + ",'" + Login_text.Text + "','" + Pass_box.Password + "','" + "ул. Лолошкина д.14 корп.88')"
                        , connectionNewUserInsert);
                        CreateNewUser.ExecuteNonQuery();
                        connectionNewUserInsert.Close();
                        MessageBox.Show("Вы прошли регистрацию!");
                        this.Close();
                    }
                    break;
                case (false):
                    MessageBox.Show("Пароли не совпадают, повторите попытку");
                    break;
            }
		}
	}
}