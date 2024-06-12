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
using System.Windows.Navigation;
using System.Windows.Shapes;
using FitnessRoom.DB;
using FitnessRoom.Views;

namespace FitnessRoom
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		FitnessRoomEntities roomEntities = new FitnessRoomEntities();
		public MainWindow()
		{
			InitializeComponent();
		}

		private void EnterBt_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				var x = roomEntities.User.Where(m => m.login == login.Text && m.pass == pass.Password).Single();
				switch (x.idRole)
				{
					case 1:
						AdminWin adminWin = new AdminWin();
						Close();
						adminWin.Show();
						break;
					case 2:
						ManagerWin managerWin = new ManagerWin();
						Close();
						managerWin.Show();
						break;
					case 3:
						var id = roomEntities.Trainer.Where(k=>k.idUser == x.idUser).Single();
						TrainerWin trainerWin = new TrainerWin(id.idTrainer);
						Close();
						trainerWin.Show();
						break;
				}
			}
			catch
			{
				MessageBox.Show("Нет такого пользователя");
			}
		}
	}
}
