   M S B A M L   `   `   `  ����B  >CarRent, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:CarRent.Pages.ClientPagesCarRent.Pages.ClientPages  5      1    +CarRent.Pages.ClientPages.ViewMyRequestPage   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:CarRent.Pages.ClientPages     5      -   5          N� Title$  Мои заявки��5	      .��5
      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ��    
MainBorder#��[  6   ._�5      ��  �� Orientation$ Vertical=�6   .+�5      �� $ 
Horizontal=�6   .+�5      �� $��Поиск:��6      MainLightText#��[ 5       �� 5      -   5         ��Name$ SearchTextBox��5      $	��400��5        MainTextBox#��[ 5      5      �� 5      $ 
Horizontal=�6   .+�5      �� -   5         ��Name$ 
OpenFilter��5      $
��Left=�5      $	��200��5      $!��Открыть фильтр��5        DefaultButton#��[ 5       5!      � 5"      -   5         �Name$ Popup��5"       � AllowsTransparency$
 True��5#      $��False��5$      .��5%      ��   DefaultBorder#��[ 6   
���iii�
���   �._�5(      �� $ Vertical=�6%   .+�5)      �� $ 
Horizontal=�6)   $��Right=�5*   )   .+�5+   "   �� $��Статус:��6,   #��[ 5,   ,   �� 5-   "   -   5         ��Name$ StatusComboBox��5-   +   $	��300��5.   +    �� DisplayMemberPath$
 Name��5/   +     MainComboBox#��[ 51   +   52      53      54      55      56      57      �� 59   
   -   5        	 ��Name$	 RequestListView��59      
������ $��0q�5;      $��1��5<      $��Disabled=�5=      ��5?      �� 5@      
 �� 
TargetType"
 ��6   .�5A      ��  �� Property � ��  BackgroundBrush �� Value# [ 63   5B      ��5D      �� 5E      .R�5F      �� $ Vertical=�6!   .+�5G      �� #��[ 6$   ��5H      `� 5I   "    �� StringFormat$ Клиент: {0}��6/   .1�5J   &   ��  �� Path$ Client.FullName�6.   5K   #   5M      �� 5N      #��[ 6$   ��5O      `� 5P   "   $ Статус: {0}��6/   .1�5Q   &   �� $ RequestStatus.Name�6.   5R   #   5T      �� 5U      #��[ 6$   ��5V      `� 5W   "   $ Срок: {0}-{1}��6/   .1�5X   &   �� $ StartDateOnly�6.   �� 5Y   &   $ EndDateOnly�6.   5Z   #   5\      �� 5]      #��[ 6$   ��5^      `� 5_   "   $ Авто: {0}��6/   .1�5`   &   �� $ Car.BrandModel.NamesOnly�6.   5a   #   5c      5d      5e      5g      �� 5i   
   -   5         ��Name$ LoadingImage��5i      $��1��5j      $��50��5k      $��50��5l      $��Center=�5m      $��Center=�5n      5o      5p      