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

namespace TopPhonesWpf
{
	/// <summary>
	/// Interaction logic for KlientWindoe.xaml
	/// </summary>
	public partial class KlientWindow : Window
	{
		public KlientWindow()
		{
			InitializeComponent();
		}
		void button1_Click(object sender, RoutedEventArgs e)
		{
			Tovary_wimdow tvrwndw = new Tovary_wimdow();
			tvrwndw.Show();
		}
	}
}