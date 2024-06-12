using FitnessRoom.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FitnessRoom.Views
{
	/// <summary>
	/// Логика взаимодействия для AparatusWin.xaml
	/// </summary>
	public partial class AparatusWin : Window
	{
		FitnessRoomEntities roomEntities = new FitnessRoomEntities();
		public AparatusWin()
		{
			InitializeComponent();
			dataGrid.ItemsSource = roomEntities.TrainingApparatus.ToList();
		}

		private void Back_Click(object sender, RoutedEventArgs e)
		{
			ManagerWin managerWin = new ManagerWin();
			Close();
			managerWin.Show();
        }

		private void SearchBt_Click(object sender, RoutedEventArgs e)
		{
			dataGrid.ItemsSource = roomEntities.TrainingApparatus.Where(m => m.nameApparatus == surnameTxt.Text).ToList();
		}
	}
}
