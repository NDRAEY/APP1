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
('�����'),
('��������'),
('��������')

INSERT INTO Stage VALUES
('���������'),
('��������'),
('������')

DBCC CHECKIDENT ('[SystemUsers]', RESEED, 1000);
GO

INSERT INTO SystemUsers VALUES
('�������', '����', '��������', '������', 1, 'nik', '25d55ad283aa400af464c76d713c07ad', 3),
('������', '����', '��������', '������', 2, 'iva', '25d55ad283aa400af464c76d713c07ad', 3),
('����������', '������', '��������', '������', 3, 'kysymys', '25d55ad283aa400af464c76d713c07ad', 3),
('��������', '������', '��������', '������', 2, 'vastaus', '25d55ad283aa400af464c76d713c07ad', 3),
('���', '�����', '���������', '������', NULL, 'piirustus', '25d55ad283aa400af464c76d713c07ad', 1),
('������', '����������', '����������', '������', 3, 'tulostus', '25d55ad283aa400af464c76d713c07ad', 3),
('����������', '�������', '���������', '������', NULL, 'ystava', '25d55ad283aa400af464c76d713c07ad', 2)

INSERT INTO Conferences VALUES
('�������', '2022-11-10', '����������'),
('������� � �������', '2023-03-12', '���-�������'),
('�����', '2021-03-24', '����������'),
('��������', '2022-05-29', '����-�����'),
('��������', '2024-01-04', '����-�������')

INSERT INTO Contributions VALUES
(1000, 1, '� ������ ��������� II'),
(1003, 2, '��� ����� ����� � ��� ��� ����������'),
(1000, 3, '���������� ���������� ��������'),
(1000, 4, '�������� ��� � ��� ����'),
(1001, 5, '����, ����������� � ������������ �����'),
(1005, 1, '������!'),
(1002, 2, '�������� ������������� ������ ��� �������'),
(1003, 3, '�������� � �������� ������������������ ����� � CISCO � ������� �����'),
(1001, 5, '����� ������ � ������� ���������� ���������'),
(1000, 3, '���� ��� ������ �� ������� � �����'),
(1003, 4, '�������'),
(1000, 2, '����������� ����� �� System.Data'),
(1002, 1, '��� �������� ������ �������� ���� �� ��� ������� ��������'),
(1002, 2, '����������� ����������'),
(1003, 1, '������� ��� �������'),
(1002, 4, '����� ����'),
(1001, 5, '� ������ ������'),
(1003, 5, '��� �������� ������������� � �� ����� ����� ������ 120 �������. ����� �������?'),
(1003, 5, '�������� � �� ���� Notepad++'),
(1003, 1, '���� ����� ��������� ����� �� ���� ������')