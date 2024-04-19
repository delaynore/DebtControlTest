# �������� ������� ��� �������������
## ����������� �������:
� ��� ������ �������� � �������� ������ �� ������������ ���� �� �������� ���������
������. � ���� ���� ���������� ��� ��������� ��������� ���������� �� ������ ���
������ ������. �� ������ ��� ������� �������, ������� ����� �� ����������� ������ �
���� �� ������ ������� ����������.  
������ ��������� �� ��������� ����� ������������ �������� � �����������, �������
����� ���������� ���������� � ���������� � ������ �������. �� ��� �����������
�������� ����� �������� ����������, ����� ��� � ���� � �������� ��� ����� �����������
��� �� ���� ��� �� �����.  

������ ����������:
1. ������ ������ ���� � ������� `ASP.NET Web API`, ��� �����������, ����������
���������� (razor pages) �� �����, ������ ����������� api, ����������� ������
� (���� �����) ������������ ��������� � ������� `JSON`.
2. ���������� ������� ���� ����������� ����������� � ������������ ����������,
�������� � ��������� ������ �����������, � ��� �� ������ ������ ����
��������� ����������. (�.�. ���������� CRUD - ���������). ��� ��������,
������ �� � `Sqlite`. ��� �������� ���� ����������� `EntityFramework Core 5.0` �
��������� ��� `Sqlite`, ��������� � `NuGet` ��� ���������
`Microsoft.EntityFrameworkCore.Sqlite`. 

3. ���������� ������ ����� ��������� ������:
	a. ����� �������� (ID),
	b. �������,
	c. ���,
	d. ��������,
	e. ���������,
	f. C����� ���� ������/������� � ������ (������� �� �����).
4. ��������� � ����������� ����� ���� �����:
	a. ��������,
	b. �������,
	c. ����������� ������
	5. ����� ��������:
	a. id ����� (���� ��� ��)
	b. ����� ������ ����� (����� ������� ������ �� ����� ��������� ������),
	c. ����� ����� (����� ����)
	d. ���������� ������������ ����� (����������� � ����� �����)
	e. ������ �� ���������.
6. �� �����, ������ ���������� ������ WebApi � ����� �������������:
	a. ���������� ������� ������, � ������������ �������, ������� ��� �������� ������ ����������.
	b. ���������� ���ϔ, � ������� ����� ��������� ����� �������� ���������� � ����/����� �����/������.
	c. (�����, ���� ��� ����������������� ���� ������� ������) � ����������� ������� ������ ������� �����
	���������� ��������� ���������� �� ����� (������ ������������� ��������� � ���� �����, ����� ������������ ���������). 
���� ��������� �������� �� ������ ����� 9:00 � ������ ������
18:00, ����������� ��� ��������� � �������� ���-�� ���� ��������� ��
�����. ������������ ������ �� �������� �������� �� 12 �����, �� �����
����� �� ����� ������ ���� �� ������ 21:00, ����� �������������
���������.  

## ������ ������ ������������:
��� ����������� ������ ���������� ���� Ok (200) �, ���� ���������, ��������� ������� �
JSON, ���� BadRequest (400) � ��������� �� ������.
## ���:
1. �������� 2 ������ (������) StartShift � EndShift, ��� ��������� Id ���������� (��
�� ����� ��������) � ����� ������ (StartShift) / ����� (EndShift) �����.
2. ���� ���������� � �������� ������� �������� ��� � ���� � ������������ ������.
3. ���� ��������� ����� �� ����� � ����� �� �����������, �� �� ����� ������ ���
�� ���� ���� �� ������� ���������� ����� � ������������ ������.
4. ���� ��������� �����-�� ������� ����� �� ����� �� ������ �������, �� �� �����
����� ���� �� ������� ������ ����� ����� � ������������ ������.
## ����� ������:
1. ������ �����������:
	a. �������� ����������: ������������ ���� � �������, ���, ���������, ����
����������� ���� �� ��� � ������������ ������. ����� ����������
���������� � ����, ������� ������ ������ ���������� � ������� JSON.
	b. �������� ����������: ������������ ���� � Id ����������, �������� ��
������, ���� Id ���������� �� ������ ��� ��������� �� ������ � ���� �
������������ ������. ��� �������� ���������, ������� ���������� �
������� JSON.
	c. ������� ����������: ������������ ���� � Id ����������, �������� ��
������, ���� Id ���������� �� ������ ��� ��������� �� ������ � ���� �
������������ ������.
	d. �������� ������ ���� �����������: ���������� ������ ���� ����������� �
������� JSON. ������������ �������� � ���������, ���� �� �������,
������������ ������ ���������� � ��������� ����������. ����
���������� �������������� ��������� � ������� ������
	e. �������� ������ ���� ����������.
2. (�����) ���� ���-���� ������ ������ ���������� ���������, ����� �� ������ d
������ ���������� � � ������ �����������.
