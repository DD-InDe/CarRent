   M S B A M L   `   `   `  ����B  >CarRent, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CarRent.PagesCarRent.Pages  5          CarRent.Pages.CarEditPage   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ] YXceed.Wpf.Toolkit.NET5, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44olen)http://schemas.xceed.com/wpf/xaml/toolkit  5      'localclr-namespace:CarRent.Pages  5      -   5          N� Title$+  %Редактирование авто��5
      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��0.5* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $	��100 �6   .+�5   
   ��    LightBorder#��[  6   $��Center=�5      $��Center=�5      $��	10,0,10,0q�5      ._�5      ��  �� Orientation$ Vertical=�6   .+�5      �� $ 
Horizontal=�6   $��Right=�5      .+�5      �� $��Vin-номер��6      MainThinLightText#��[ 5       �� 5      -   5         ��Name$ VinNumTextBox��5         MainTextBox#��[ 5      $	��250��5       �� 	MaxLength$ 17��5!      ��5#      �� *CarVin+5$      �� 5%      $ 
Horizontal=�6   $��Right=�5&      .+�5'      �� $ ��Бренд и модель��6    #��[ 5(       �� 5)      -   5         ��Name$ BrandModelComboBox��5)      $	��250��5*       �� DisplayMemberPath$ 	NamesOnly��5+        MainComboBox#��[ 5-       �� SelectedItem 5,      �� *
BrandModel+5-      5.      �� 5/      $ 
Horizontal=�6   $��Right=�50      .+�51      �� $"��Стоимость авто:��6    #��[ 52       �� 53      -   5        $ CarPriceTextBox��53      $	��250��54      $ 10��55      #��[ 58      ��56      �� *
CarPrice+58      59      �� 5:      $ 
Horizontal=�6   $��Right=�5;      .+�5<      �� $1��+Стоимость аренды (день):��6    #��[ 5=       �� 5>      -   5        $ RentPriceTextBox��5>      $	��250��5?      $ 7��5@      #��[ 5C      ��5A      �� *	RentPrice+5C      5D      �� 5E      $ 
Horizontal=�6   $��Right=�5F      .+�5G      �� $��Статус:��6    #��[ 5H       �� 5I      -   5        $ StatusComboBox��5I      $	��250��5J      $
 Name��5K      #��[ 5M       5L      �� *	CarStatus+5M      5N      �� 5O      $ 
Horizontal=�6   $��Right=�5P      .+�5Q      �� $��	Цвет:��6    #��[ 5R       #  Xceed.Wpf.Toolkit.ColorPicker  5S      -   5        	  Name$	 ColorPicker��5S   '   $��5q�5T   '   $��30��5U   '   $	��250��5V   '   
   SelectedColor
 5W   '   �� *Color+5X      5Y      5Z      �� 5\   
   -   5         ��Name$ CarPhotoImage��5\      $��1��5]      $��Uniform=�5^      $��	10,0,10,0q�5`      $	��600��5a      ��5b      �� *Photo+�� 5d   
   $ 
Horizontal=�6   $��1��5e      $��2��5f      $��Center=�5g      $��Center=�5h      .+�5i      �� -	   5         ��Name$ 
BackButton��5i      $	��200��5k        DefaultButton#��[ 5l      $��
Назад��5m      �� 5n      -
   5        $ 
SaveButton��5n      $	��200��5p      #��[ 5q      $��Сохранить��5r      5s      �� 5u   
   -   5        $ LoadingImage��5u      $��2��5v      $��2��5w      $��50��5x      $��50��5y      $��Center=�5z      $��Center=�5{      5|      5}      