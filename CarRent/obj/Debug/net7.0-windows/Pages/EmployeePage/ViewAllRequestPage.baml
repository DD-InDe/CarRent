   M S B A M L   `   `   `  ����B  >CarRent, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:CarRent.Pages.EmployeePageCarRent.Pages.EmployeePage  5      3    -CarRent.Pages.EmployeePage.ViewAllRequestPage   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:CarRent.Pages.EmployeePage     5      -   5          N� Title$  Заявки��5	      .��5
      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ��    
MainBorder#��[  6   ._�5      ��  �� Orientation$ Vertical=�6   .+�5      �� $ 
Horizontal=�6   .+�5      �� $��Поиск:��6      MainLightText#��[ 5       �� 5      -   5         ��Name$ SearchTextBox��5      $	��400��5        MainTextBox#��[ 5      5      �� 5      $ 
Horizontal=�6   .+�5      �� -   5         ��Name$ 
OpenFilter��5      $
��Left=�5      $	��200��5      $!��Открыть фильтр��5        DefaultButton#��[ 5       �� 5!      -   5        $ CreateDocButton��5!      $/��)Сформировать документ��5#      #��[ 5$      5%      5&      � 5'      -   5         �Name$ Popup��5'       � AllowsTransparency$
 True��5(      $��False��5)      .��5*      ��   DefaultBorder#��[ 6   
���iii�
���   �._�5-      �� $ Vertical=�6%   .+�5.      �� $ 
Horizontal=�6)   $��Right=�5/   )   .+�50   "   �� $��Статус:��6,   #��[ 51   ,   �� 52   "   -   5         ��Name$ StatusComboBox��52   +   $	��300��53   +    �� DisplayMemberPath$
 Name��54   +     MainComboBox#��[ 56   +   57      �� 58      $ 
Horizontal=�6)   $��Right=�59   )   .+�5:   "   �� $��Клиент:��6,   #��[ 5;   ,   �� 5<   "   -   5        $ ClientComboBox��5<   +   $	��300��5=   +   $ FullName��5>   +   #��[ 5@   +   5A      5B      5C      5D      5E      5F      �� 5H   
   -   5        	 ��Name$	 RequestListView��5H      
������ $��0q�5J      $��1��5K      $��Disabled=�5L      ��5N      �� 5O      
 �� 
TargetType"
 ��6   .�5P      ��  �� Property � ��  BackgroundBrush �� Value# [ 5Q      5R      ��5T      �� 5U      .R�5V      �� $ Vertical=�6!   .+�5W      �� #��[ 6$   ��5X      `� 5Y   "    �� StringFormat$ Клиент: {0}��6/   .1�5Z   &   ��  �� Path$ Client.FullName�6.   5[   #   5]      �� 5^      $ 
Horizontal=�6%   .+�5_      �� $��Статус:��6(   #��[ 5`   (   �� 5a      #��[ 5c   (   ��5a   (   �� *RequestStatus.Name+��5b   (   �� *RequestColor+5c   (   5d      �� 5e      #��[ 6$   ��5f      `� 5g   "   $ Срок: {0}-{1}��6/   .1�5h   &   �� $ StartDateOnly�6.   �� 5i   &   $ EndDateOnly�6.   5j   #   5l      �� 5m      #��[ 6$   ��5n      `� 5o   "   $ Авто: {0}��6/   .1�5p   &   �� $ Car.BrandModel.NamesOnly�6.   5q   #   5s      5t      5u      5w      �� 5y   
   -	   5         ��Name$ LoadingImage��5y      $��1��5z      $��50��5{      $��50��5|      $��Center=�5}      $��Center=�5~      5      5�      