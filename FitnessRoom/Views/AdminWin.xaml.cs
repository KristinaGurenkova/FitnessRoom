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
	/// Логика взаимодействия для AdminWin.xaml
	/// </summary>
	public partial class AdminWin : Window
	{
		FitnessRoomEntities roomEntities = new FitnessRoomEntities();
		public AdminWin()
		{
			InitializeComponent();
			Update();
		}
		public void Update()
		{
			dataGrid.ItemsSource = roomEntities.Client.ToList();
		}

		private void AddBt_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				Client client = new Client()
				{
					surnameClient = surnameTxt.Text,
					nameClient = nameTxt.Text,
					middleNameClient = middlenameTxt.Text,
					number = numberTxt.Text,
				};
				roomEntities.Client.Add(client);
				roomEntities.SaveChanges();
				var x = roomEntities.Client.Where(m=>m.surnameClient == surnameTxt.Text && m.nameClient == nameTxt.Text && m.middleNameClient == middlenameTxt.Text && m.number == numberTxt.Text).Single();

				Attendance attendance = new Attendance()
				{
					idClient = x.idClient,
					countСlasses = 1,
				};
				roomEntities.Attendance.Add(attendance);
				roomEntities.SaveChanges();
			}
			catch
			{
				MessageBox.Show("Некоторые данные были введены не корректно");
			}
			Update();
		}

		private void ChangeBt_Click(object sender, RoutedEventArgs e)
		{
			var x = dataGrid.SelectedItem as Client;
			x.surnameClient = surnameTxt.Text;
			x.nameClient = nameTxt.Text;
			x.middleNameClient = middlenameTxt.Text;
			x.number = numberTxt.Text;
			roomEntities.SaveChanges();
			Update();
		}

		private void DeleteBt_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				var x = dataGrid.SelectedItem as Client;
				roomEntities.Client.Remove(x);
				roomEntities.SaveChanges();
				Update();
			}
			catch
			{
				MessageBox.Show("Клиент не был выбран");
			}
		}

		private void TrainerBt_Click(object sender, RoutedEventArgs e)
		{
			ListTrainerWin listTrainerWin = new ListTrainerWin();
			Close();
			listTrainerWin.Show();
		}

		private void AparatusBt_Click(object sender, RoutedEventArgs e)
		{
			ListAparatusWin listAparatusWin = new ListAparatusWin();
			Close();
			listAparatusWin.Show();
		}

		private void dataGrid_SelectedCellsChanged_1(object sender, SelectedCellsChangedEventArgs e)
		{
			try
			{
				var x = dataGrid.SelectedItem as Client;
				surnameTxt.Text = x.surnameClient;
				nameTxt.Text = x.nameClient;
				middlenameTxt.Text = x.middleNameClient;
				numberTxt.Text = x.number;
			}
			catch { }
		}

		private void Back_Click(object sender, RoutedEventArgs e)
		{
			MainWindow mainWindow = new MainWindow();
			Close();
			mainWindow.Show();
		}
	}
}
