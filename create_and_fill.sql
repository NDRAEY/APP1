USE [PS1]

CREATE TABLE Roles (
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(MAX)
)

CREATE TABLE Stage (
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(MAX)
)

CREATE TABLE SystemUsers (
	TabelId INT PRIMARY KEY IDENTITY,
	Surname NVARCHAR(MAX),
	Name NVARCHAR(MAX),
	Patronymic NVARCHAR(MAX),
	Country NVARCHAR(MAX),
	Stage INT FOREIGN KEY REFERENCES [Stage](Id) NULL,
	Login NVARCHAR(MAX),
	PasswordHash NVARCHAR(MAX),
	Role INT FOREIGN KEY REFERENCES [Roles](Id)
)

CREATE TABLE Conferences (
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(MAX),
	Date DATE,
	Place NVARCHAR(MAX)
)

CREATE TABLE Contributions (
	Id INT PRIMARY KEY IDENTITY,
	TabelId INT FOREIGN KEY REFERENCES [SystemUsers](TabelId),
	ConferenceId INT FOREIGN KEY REFERENCES [Conferences](Id),
	Topic NVARCHAR(MAX)
)

INSERT INTO Roles VALUES
('Глава'),
('Менеджер'),
('Участник')

INSERT INTO Stage VALUES
('Профессор'),
('Академик'),
('Доктор')

DBCC CHECKIDENT ('[SystemUsers]', RESEED, 1000);
GO

INSERT INTO SystemUsers VALUES
('Никонов', 'Иван', 'Петрович', 'Россия', 1, 'nik', '25d55ad283aa400af464c76d713c07ad', 3),
('Иванов', 'Иван', 'Иванович', 'Россия', 2, 'iva', '25d55ad283aa400af464c76d713c07ad', 3),
('Довгополов', 'Никита', 'Петрович', 'Россия', 3, 'kysymys', '25d55ad283aa400af464c76d713c07ad', 3),
('Товпегин', 'Никита', 'Петрович', 'Россия', 2, 'vastaus', '25d55ad283aa400af464c76d713c07ad', 3),
('Нют', 'Юджин', 'Алехандро', 'Россия', NULL, 'piirustus', '25d55ad283aa400af464c76d713c07ad', 1),
('Катков', 'Иннокентий', 'Михайлович', 'Россия', 3, 'tulostus', '25d55ad283aa400af464c76d713c07ad', 3),
('Налабордин', 'Валерий', 'Артемович', 'Россия', NULL, 'ystava', '25d55ad283aa400af464c76d713c07ad', 2)

INSERT INTO Conferences VALUES
('Сканван', '2022-11-10', 'Миенненвен'),
('Кюсюмюс и вастаус', '2023-03-12', 'Эди-Викконе'),
('Сааде', '2021-03-24', 'Кескивилль'),
('Машинида', '2022-05-29', 'Ууси-Тавуа'),
('Биоквант', '2024-01-04', 'Пика-Вейсаур')

INSERT INTO Contributions VALUES
(1000, 1, 'О пользе Елизаветы II'),
(1003, 2, 'Кто такие Бески и чем они промышляют'),
(1000, 3, 'Глобальное помутнение рассудка'),
(1000, 4, 'Звуковой шум и его вред'),
(1001, 5, 'Яйца, Сальмонелла и растительное масло'),
(1005, 1, 'Готика!'),
(1002, 2, 'Создание гиперзвуковой машины для Максима'),
(1003, 3, 'Покемоны и создание децентрализованных сетей в CISCO в регионе Алола'),
(1001, 5, 'Гарри Поттер и решение кубических уравнений'),
(1000, 3, 'Шины баз данных на арбузах и дынях'),
(1003, 4, 'Куменен'),
(1000, 2, 'Зависимость людей от System.Data'),
(1002, 1, 'Кто позволил Пикачу вырубить свет во всём острове Бескилле'),
(1002, 2, 'Константный вакитуинен'),
(1003, 1, 'Радиола для Родиона'),
(1002, 4, 'Вдвыд ОХОХ'),
(1001, 5, 'Я сломал СИШАРП'),
(1003, 5, 'Иви раскопал электрокабель и от удара током погбли 120 человек. Каким образом?'),
(1003, 5, 'Визуалка и ее брат Notepad++'),
(1003, 1, 'Даня нашел секретный рычаг на Ладе Приоре')