using FitnessRoom.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
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
	/// Логика взаимодействия для TrainerWin.xaml
	/// </summary>
	public partial class TrainerWin : Window
	{
		FitnessRoomEntities roomEntities = new FitnessRoomEntities();
		public int idTrainer { get; set; }
		public TrainerWin(int id)
		{
			InitializeComponent();
			idTrainer = id;
			Update();
		}
		public void Update()
		{
			dataGrid.ItemsSource = roomEntities.Client.Where(m=>m.idTrainer == idTrainer).ToList();
		}

		private void ForTrainingBt_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				var y = roomEntities.TrainingApparatus.Where(m => m.nameApparatus == nameApparatusTxt.Text).Single();
				var date = Convert.ToDateTime(dataTxt.Text);
				Schedule schedule = new Schedule()
				{
					date = date,
					idApparatus = y.idApparatus,
				};
				roomEntities.Schedule.Add(schedule);
				roomEntities.SaveChanges();

				var k = roomEntities.Schedule.Where(l => l.date == date && l.idApparatus == y.idApparatus).Single();
				var x = dataGrid.SelectedItem as Client;
				x.idSchedule = k.idSchedule;
				roomEntities.SaveChanges();


			}
			catch
			{}
			Update();
		}

		private void AttendanceBt_Click(object sender, RoutedEventArgs e)
		{
			AttendanceWin attendanceWin = new AttendanceWin(idTrainer);
			Close();
			attendanceWin.Show();
		}

		private void Back_Click(object sender, RoutedEventArgs e)
		{
			MainWindow mainWindow = new MainWindow();
			Close();
			mainWindow.Show();
		}
	}
}
