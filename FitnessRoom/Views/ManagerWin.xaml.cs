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
	/// Логика взаимодействия для ManagerWin.xaml
	/// </summary>
	public partial class ManagerWin : Window
	{
		FitnessRoomEntities roomEntities = new FitnessRoomEntities();
		public ManagerWin()
		{
			InitializeComponent();
			Update();
		}
		public void Update()
		{
			dataGrid.ItemsSource = roomEntities.Client.ToList();
		}

		private void TrainerBt_Click(object sender, RoutedEventArgs e)
		{
			TrainerListMWin trainerListM = new TrainerListMWin();
			Close();
			trainerListM.Show();
		}

		private void AparatusBt_Click(object sender, RoutedEventArgs e)
		{
			AparatusWin aparatusWin = new AparatusWin();
			Close();
			aparatusWin.Show();
		}

		private void OneMonth_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				var x = dataGrid.SelectedItem as Client;
				x.idSeasonTicket = 1;
				roomEntities.SaveChanges();
				Update();
			}
			catch
			{}
		}

		private void SixMonth_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				var x = dataGrid.SelectedItem as Client;
				x.idSeasonTicket = 2;
				roomEntities.SaveChanges();
				Update();
			}
			catch
			{ }
		}

		private void TwelveMonth_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				var x = dataGrid.SelectedItem as Client;
				x.idSeasonTicket = 3;
				roomEntities.SaveChanges();
				Update();
			}
			catch
			{ }
		}

		private void Delete_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				var x = dataGrid.SelectedItem as Client;
				x.idSeasonTicket = null;
				roomEntities.SaveChanges();
				Update();
			}
			catch
			{ }
		}

		private void Back_Click(object sender, RoutedEventArgs e)
		{
			MainWindow mainWindow = new MainWindow();
			Close();
			mainWindow.Show();
		}

		private void SearchBt_Click(object sender, RoutedEventArgs e)
		{
			dataGrid.ItemsSource = roomEntities.Client.Where(m=>m.surnameClient == surnameTxt.Text).ToList();
		}

		private void ToAppoint_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				var x = dataGrid.SelectedItem as Client;
				var k = roomEntities.Trainer.Where(m=>m.surnameTrainer == surnameTrainerTxt.Text).Single();
				x.idTrainer = k.idTrainer;
				roomEntities.SaveChanges();
			}
			catch
			{ }
			Update();
		}

		private void ReportBt_Click(object sender, RoutedEventArgs e)
		{
			GeneratorClass generatorClass = new GeneratorClass();
			generatorClass.GenerateReport();
			MessageBox.Show("Отчет сгенерирован");
		}
	}
}
