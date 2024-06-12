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
	/// Логика взаимодействия для AttendanceWin.xaml
	/// </summary>
	public partial class AttendanceWin : Window
	{
		FitnessRoomEntities roomEntities = new FitnessRoomEntities();
		public int idTrainer { get; set; }
		public AttendanceWin(int id)
		{
			InitializeComponent();
			idTrainer = id;
			Update();
		}
		public void Update()
		{
			dataGrid.ItemsSource = roomEntities.Attendance.Where(m => m.Client.idTrainer == idTrainer).ToList();
		}

		private void Back_Click(object sender, RoutedEventArgs e)
		{
			TrainerWin trainerWin = new TrainerWin(idTrainer);
			Close();
			trainerWin.Show();
		}

		private void IsPresent_Click(object sender, RoutedEventArgs e)
		{
			var m = dataGrid.SelectedItem as Attendance;
			try
			{
				var r = roomEntities.Attendance.Where(y => y.idClient == m.idClient).Single();
				r.countСlasses++;
			}
			catch
			{ }
			finally
			{
				roomEntities.SaveChanges();
			}
			Update();
		}
	}
}
