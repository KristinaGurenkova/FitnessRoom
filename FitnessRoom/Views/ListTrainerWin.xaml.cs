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
	/// Логика взаимодействия для ListTrainerWin.xaml
	/// </summary>
	public partial class ListTrainerWin : Window
	{
		FitnessRoomEntities roomEntities = new FitnessRoomEntities();
		public ListTrainerWin()
		{
			InitializeComponent();
			Update();
		}
		public void Update()
		{
			dataGrid.ItemsSource = roomEntities.Trainer.ToList();
		}

		private void Back_Click(object sender, RoutedEventArgs e)
		{
			AdminWin adminWin = new AdminWin();
			Close();
			adminWin.Show();
		}

		private void AddBt_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				User user = new User()
				{
					login = loginTxt.Text,
					pass = passTxt.Text,
					idRole = 3
				};
				roomEntities.User.Add(user);
				roomEntities.SaveChanges();
				var s = roomEntities.Specialization.Where(m => m.nameSpecialization == specTxt.Text).Single();
				var id = roomEntities.User.Where(l => l.login == loginTxt.Text && l.pass == passTxt.Text).Single();
				Trainer trainer = new Trainer()
				{
					surnameTrainer = surnameTxt.Text,
					nameTrainer = nameTxt.Text,
					middleNameTrainer = middlenameTxt.Text,
					idSpecialization = s.idSpecialization,
					idUser = id.idUser
				};
				roomEntities.Trainer.Add(trainer);
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
			try
			{
				var x = dataGrid.SelectedItem as Trainer;
				var s = roomEntities.Specialization.Where(m => m.nameSpecialization == specTxt.Text).Single();
				x.surnameTrainer = surnameTxt.Text;
				x.nameTrainer = nameTxt.Text;
				x.middleNameTrainer = middlenameTxt.Text;
				x.idSpecialization = s.idSpecialization;
				roomEntities.SaveChanges();
				Update();
			}
			catch
			{}
		}

		private void DeleteBt_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				var x = dataGrid.SelectedItem as Trainer;
				roomEntities.Trainer.Remove(x);
				roomEntities.SaveChanges();
				Update();
			}
			catch
			{
				MessageBox.Show("Тренер не был выбран");
			}
		}

		private void dataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
		{
			try
			{
				var x = dataGrid.SelectedItem as Trainer;
				surnameTxt.Text = x.surnameTrainer;
				nameTxt.Text = x.nameTrainer;
				middlenameTxt.Text = x.middleNameTrainer;
				specTxt.Text = x.Specialization.nameSpecialization;
				loginTxt.Text = x.User.login;
				passTxt.Text = x.User.pass;
			}
			catch { }
		}
	}
}
