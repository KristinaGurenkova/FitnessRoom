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
	/// Логика взаимодействия для ListAparatusWin.xaml
	/// </summary>
	public partial class ListAparatusWin : Window
	{
		FitnessRoomEntities roomEntities = new FitnessRoomEntities();
		public ListAparatusWin()
		{
			InitializeComponent();
			Update();
		}
		public void Update()
		{
			dataGrid.ItemsSource = roomEntities.TrainingApparatus.ToList();
		}

		private void AddBt_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				TrainingApparatus apparatus = new TrainingApparatus()
				{
					nameApparatus = nameTtx.Text,
					description = descTxt.Text,
					accessCount = 20,
				};
				roomEntities.TrainingApparatus.Add(apparatus);
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
			var x = dataGrid.SelectedItem as TrainingApparatus;
			x.nameApparatus = nameTtx.Text;
			x.description = descTxt.Text;
			roomEntities.SaveChanges();
			Update();
		}

		private void DeleteBt_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				var x = dataGrid.SelectedItem as TrainingApparatus;
				roomEntities.TrainingApparatus.Remove(x);
				roomEntities.SaveChanges();
				Update();
			}
			catch
			{
				MessageBox.Show("Объект не был выбран");
			}
		}

		private void dataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
		{
			try
			{
				var x = dataGrid.SelectedItem as TrainingApparatus;
				nameTtx.Text = x.nameApparatus;
				descTxt.Text = x.description;
			
			}
			catch { }
		}

		private void Back_Click(object sender, RoutedEventArgs e)
		{
			AdminWin adminWin = new AdminWin();
			Close();
			adminWin.Show();
		}
	}
}
