   M S B A M L   `   `   `  ����B  >CarRent, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:CarRent.Pages.EmployeePageCarRent.Pages.EmployeePage  5      -    'CarRent.Pages.EmployeePage.ViewUserPage   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:CarRent.Pages.EmployeePage     5      -   5          N� Title$-  'Пользователи системы��5	      .��5
      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ��    
MainBorder#��[  6   ._�5      ��  �� Orientation$ Vertical=�6   .+�5      �� $ 
Horizontal=�6   .+�5      �� $��Поиск:��6      MainLightText#��[ 5       �� 5      -   5         ��Name$ SearchTextBox��5      $	��400��5        MainTextBox#��[ 5      5      �� 5      $ 
Horizontal=�6   .+�5      �� -   5         ��Name$ 
OpenFilter��5      $
��Left=�5      $	��200��5      $!��Открыть фильтр��5        DefaultButton#��[ 5       �� 5!      -   5        $ AddUserButton��5!      $
��Left=�5#      $	��250��5$      $/��)Добавить пользователя��5%      #��[ 5&      5'      � 5(      -   5         �Name$ Popup��5(       � AllowsTransparency$
 True��5)      $��False��5*      .��5+      ��   DefaultBorder#��[ 6   
���iii�
���   �._�5.      �� $ Vertical=�6%   .+�5/      �� $ 
Horizontal=�6)   $��Right=�50   )   .+�51   "   �� $��	Роль:��6,   #��[ 52   ,   �� 53   "   -   5         ��Name$ RoleComboBox��53   +   $	��300��54   +    �� DisplayMemberPath$
 Name��55   +     MainComboBox#��[ 57   +   58      59      5:      5;      5<      5=      �� 5?   
   -   5        	 ��Name$	 UserListView��5?      
������ $��0q�5A      $��1��5B      $��Disabled=�5C      ��5E      �� 5F      
 �� 
TargetType"
 ��6   .�5G      ��  �� Property � ��  BackgroundBrush �� Value# [ 63   5H      ��5J      �� 5K      .R�5L      �� $ Vertical=�6!   .+�5M      �� #��[ 6$   ��5N      `� 5O   "    �� StringFormat$ ФИО: {0}��6/   .1�5P   &   ��  �� Path$ FullName�6.   5Q   #   5S      �� 5T      $ 
Horizontal=�6%   .+�5U      �� $��	Роль:��6(   #��[ 5V   (   �� 5W      #��[ 5Y   (   ��5W   (   �� *	Role.Name+��5X   (   �� *	RoleColor+5Y   (   5Z      �� 5[      $ 
Horizontal=�6%   .+�5\      �� $��Почта:��6(   #��[ 5]   (   �� 5^      #��[ 5_   (   ��5^   (   �� *Email+5_   (   5`      �� 5a      $ 
Horizontal=�6%   .+�5b      �� $��Логин:��6(   #��[ 5c   (   �� 5d      #��[ 5e   (   ��5d   (   �� *UserNavigation.Login+5e   (   5f      5g      5h      5j      �� 5l   
   -   5         ��Name$ LoadingImage��5l      $��1��5m      $��50��5n      $��50��5o      $��Center=�5p      $��Center=�5q      5r      5s      