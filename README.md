# Система управления тренажерным залом «FitnessRoom».
### Название приложения: FitnessRoom
### Описание приложения:
**Система «FitnessRoom» предназначена для управления тренажерным залом. Она позволяет вносить данные о клиентах, тренерах, тренажерах, а также записывать клиентов на тренеровку и отслеживать их посещаймость.**

# Функции, реализованные в программе:
1. **Добавление, редактирование и удаление данных.** Присутствует возможноность добавления, редактирования и удаления данных о клиентах, тренерах, тренажерах.
2. **Запись на тренеровку.** Присутствует запись клиентов на тренировку к конкретным тренерам.
3. **Информация о посещаемости.** Присутствует возможность ввода информации о посещаймости клиентов.
4. **Поиск.** Присутствует возможность поиска клиентов, тренеров, тренажеров.
5. **Генерация отчета** Присутствует генерация отчета о посещаймости клиентов.

# Технологии, которые были использованы для разработки приложения:
- **C#** - объектно-ориентированный язык программирования.
- **Visual Studio Community 2022** - интегрированная среда разработки (IDE), которая обеспечивает удобное создание, отладку и развертывание приложений.
- **Windows Presentation Foundation** - система для построения клиентских приложений Windows с визуально привлекательными возможностями взаимодействия с пользователем, графическая подсистема в составе .NET Framework, использующая язык XAML.
- **Microsoft SQL Server** - система управления реляционными базами данных (РСУБД), разработанная корпорацией Microsoft.
- **Entity Framework** - это набор технологий в ADO.NET, которые поддерживают разработку программных приложений, ориентированных на данные.

# Описание базы данных:
#### Файл базы данных называется FitnessRoom.bacpac <br/>
Файл базы данных расположен в проекте по пути **ElectronicJournal\ElectronicJournal\bin\Debug** </br>
В базе данных находятся 9 таблиц _Role_, _User_, _Trainer_, _Client_, _Schedule_, _Specialization_, _TrainingApparatus_, _Attendance_, _SeasonTicket_.

- **Таблица «Role»** _(idRole, nameRole)_ содержит информацию о ролях
- **Таблица «User»** _(idUser, login, pass, idRole)_ содержит информацию о пользователях
- **Таблица «Trainer»** _(idTrainer, nameTrainer, surnameTrainer, middleNameTrainer, idUser, idSpecialization)_ содержит информацию о тренерах
- **Таблица «Client»** _(idClient, nameClient, surnameClient, middleNameClient, idSeasonTicket, idTrainer, number, idSchedule)_ содержит информацию о клиентах
- **Таблица «Schedule»** _(idSchedule, date, idApparatus)_ содержит информацию о расписании
- **Таблица «Specialization»** _(idSpecialization, nameSpecialization)_ содержит информацию о специализации
- **Таблица «TrainingApparatus»** _(idApparatus, nameApparatus, description, accessCount)_ содержит информацию о тренажерах
- **Таблица «Attendance»** _(idAttendance, idClient, countClasses)_ содержит информацию о посещаймости
- **Таблица «SeasonTicket** _(idSeasonTicket, nameTicket)_ содержит информацию об абонементах

# Скриншоты приложения:

<p align="center">
  <img <img src="https://github.com/KristinaGurenkova/FitnessRoom/blob/main/Screenshots/MainWindow.png">
</br>Главная страница
</br> </br> </br>
</p>

<p align="center">
  <img <img src="https://github.com/KristinaGurenkova/FitnessRoom/blob/main/Screenshots/TrainerWin.png">
</br>Окно тренера
</br> </br> </br>
</p>

<p align="center">
  <img <img src="https://github.com/KristinaGurenkova/FitnessRoom/blob/main/Screenshots/AttWin.png">
</br>Окно посещаймости
</br> </br> </br>
</p>

<p align="center">
  <img <img src="https://github.com/KristinaGurenkova/FitnessRoom/blob/main/Screenshots/ManagerWin.png">
</br>Окно менеджера
</br> </br> </br>
</p>

<p align="center">
  <img <img src="https://github.com/KristinaGurenkova/FitnessRoom/blob/main/Screenshots/ManagerWinTR.png">
</br>Список тренеров
</br> </br> </br>
</p>

<p align="center">
  <img <img src="https://github.com/KristinaGurenkova/FitnessRoom/blob/main/Screenshots/ManagerWinAppr.png">
</br>Список тренажеров
</br> </br> </br>
</p>

<p align="center">
  <img <img src="https://github.com/KristinaGurenkova/FitnessRoom/blob/main/Screenshots/AdminWin.png">
</br>Окно администратора
</br> </br> </br>
</p>

<p align="center">
  <img <img src="https://github.com/KristinaGurenkova/FitnessRoom/blob/main/Screenshots/AddTrainers.png">
</br>Добавления тренеров
</br> </br> </br>
</p>

<p align="center">
  <img <img src="https://github.com/KristinaGurenkova/FitnessRoom/blob/main/Screenshots/AddApparatus.png">
</br>Добавление тренажеров
</br> </br> </br>
</p>
<h3>Видео</h3>

https://github.com/KristinaGurenkova/FitnessRoom/blob/main/Screenshots/Video.wmv
