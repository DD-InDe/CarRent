   M S B A M L   `   `   `  ����  CarRent&     CarRent.Windows.CustomMessageBox   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   $	��150��5   	   $	��400��6     � WindowStyle$
  None=�5   	      	DarkBrush#��[  5	   	   ���#3a363c$	��0.5q�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��70 �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ MessageTextBlock��5      $��1��5        MainLightText#��[ 5      $
��auto��5      $��16(�5      $
��Wrap=�5      $��Center=�5      �� 5!   
   -   5         ��Name$ 	IconImage��5!      $��50��5"      $��50��5#      �� 5%   
    �� Orientation$ 
Horizontal=�6   $��2��5&      $��1��5'      $��Center=�5(      .+�5)      �� -   5         ��Name$ 	YesButton��5)      $��80��5+        DefaultButton#��[ 5,      
�������$��16(�5.      $y�	Collapsed=�5/      $
��Да��50      �� 51      -   5        $ NoButton��51      $��80��53      
�������#��[ 55      $��16(�56      $y�	Collapsed=�57      $��Нет��58      �� 59      -   5        $ OkButton��59      $��80��5;      
�������#��[ 5=      $��16(�5>      $y�	Collapsed=�5?      $
��Ок��5@      5A      5B      5C      