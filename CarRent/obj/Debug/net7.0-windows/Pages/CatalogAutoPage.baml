   M S B A M L   `   `   `  ����B  >CarRent, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CarRent.PagesCarRent.Pages  5      #    CarRent.Pages.CatalogAutoPage   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:CarRent.Pages     5      -   5          N� Title$  Каталог авто��5	      .��5
      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ��    
MainBorder#��[  6   ._�5      ��  �� Orientation$ Vertical=�6   .+�5      �� $ 
Horizontal=�6   .+�5      �� $��Поиск:��6      MainLightText#��[ 5       �� 5      -   5         ��Name$ SearchTextBox��5      $	��400��5        MainTextBox#��[ 5      5      �� 5      $ 
Horizontal=�6   .+�5      �� -   5         ��Name$ 
OpenFilter��5      $
��Left=�5      $	��200��5      $!��Открыть фильтр��5        DefaultButton#��[ 5       �� 5!      -   5        $ 	AddButton��5!      $
��Left=�5#      $	��200��5$      $y�	Collapsed=�5%      $��Добавить авто��5&      #��[ 5'      5(      � 5)      -   5         �Name$ Popup��5)       � AllowsTransparency$
 True��5*      $��False��5+      .��5,      ��   DefaultBorder#��[ 6   
���iii�
���   �._�5/      �� $ Vertical=�6%   .+�50      �� $ 
Horizontal=�6)   .+�51   "   �� $��Марка:��6,   #��[ 52   ,   �� 53   "   -   5         ��Name$ BrandComboBox��53   +   $	��300��54   +    �� DisplayMemberPath$
 Name��55   +     MainComboBox#��[ 57   +   58      �� 59      $ 
Horizontal=�6)   .+�5:   "   �� $��Модель:��6,   #��[ 5;   ,   �� 5<   "   -   5        $ ModelComboBox��5<   +   $	��300��5=   +   $
 Name��5>   +   #��[ 5@   +   5A      �� 5B      $ 
Horizontal=�6)   .+�5C   "   �� $��Класс:��6,   #��[ 5D   ,   �� 5E   "   -   5        $ ClassComboBox��5E   +   $	��300��5F   +   $
 Name��5G   +   #��[ 5I   +   5J      5K      5L      5M      5N      5O      �� 5Q   
   -	   5        	 ��Name$	 CarListView��5Q      
������ $��0q�5S      $��1��5T      $��Disabled=�5U      ��5W      �� 5X      .R�5Y      � 
 � Orientation$
 
Horizontal=�6    ��5Z       ��  �� ElementName$ CarListView�� �� Path$ ActualWidth�5[      ��5]      �� 5^      .R�5_      �� #��[  6!   ._�5`      �� $ Vertical=�6)   $	��300��5a   )   $	��300��5b   )   .+�5c   "   �� $��Center=�6(   $��5q�5d   (   $	��250��5e   (   $	��180��5f   (   $��UniformToFill=�5g   (   ��5h   (   �� *Photo+�� 5i   "   #��[ 6,   $��Center=�5j   ,   ��5k   &   `� 5l   *    �� StringFormat$ {0} {1}��67   .1�5m   .   �� $ BrandModel.Brand.Name�66   �� 5n   .   $ BrandModel.Model.Name�66   5o   +   5q   #   �� 5r   "   $ 
Horizontal=�6-   .+�5s   &   �� $��Класс:��60   #��[ 5t   0   �� 5u   &   #��[ 5v   0   ��5u   0   �� *BrandModel.Class.Name+5v   0   5w   #   �� 5x   "   #��[ 6,   ��5y   ,   �� *Price+5z      5{      5|      5~      �� 5�   
   -
   5         ��Name$ LoadingImage��5�      $��1��5�      $��50��5�      $��50��5�      $��Center=�5�      $��Center=�5�      5�      5�      