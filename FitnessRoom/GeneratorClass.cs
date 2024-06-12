using FitnessRoom.DB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessRoom
{
	internal class GeneratorClass
	{
		public void GenerateReport()
		{
			// Создание экземпляра контекста базы данных
			using (var context = new FitnessRoomEntities())
			{
				// Получение данных о клиентах и их посещениях
				var clientVisits = context.Client
										  .Select(c => new
										  {
											  ClientSurname = c.surnameClient,
											  ClientName = c.nameClient,
											  ClientPatronimic = c.middleNameClient,

											  Attendence = c.Attendance.Select(v => v.countСlasses)
										  }).ToList();

				// Путь к файлу отчета
				string reportPath = "Отчет.txt";

				// Создание файла отчета
				using (StreamWriter sw = new StreamWriter(reportPath))
				{
					// Заголовок отчета
					sw.WriteLine("Отчет о посещениях клиентов");
					sw.WriteLine("Дата создания отчета: " + DateTime.Now.ToString());
					sw.WriteLine("--------------------------------------------------");

					// Запись данных о каждом клиенте
					foreach (var client in clientVisits)
					{
						sw.WriteLine("Фамилия клиента: " + client.ClientSurname);
						sw.WriteLine("Имя клиента: " + client.ClientName);
						sw.WriteLine("Отчество клиента: " + client.ClientPatronimic);
						sw.Write("Количество посещений:");
						foreach (var date in client.Attendence)
						{
							sw.WriteLine(date.ToString());
						}
						sw.WriteLine("--------------------------------------------------");
					}
				}
			}
		}
	}
}
