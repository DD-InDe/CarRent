   M S B A M L   `   `   `  ����B  >CarRent, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CarRent.PagesCarRent.Pages  5          CarRent.Pages.AuthPage   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      U QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com  5      'localclr-namespace:CarRent.Pages  5         BackgroundBrush  N� 
Background#  [  5	       N� Title$ Авторизация��5
      .��5      � .+�5   
   ��  �� Orientation$ Vertical=�6   $��Center=�5      $��Center=�5      .+�5      �� $&�� Добро пожаловать!��6     MainLightText#��[ 5      $��24(�5      $��10q�5      $��Center=�5      �� 5      #��[ 6   $
��Wrap=�5      $��16(�5      $��10q�5      $
��auto��5      $��Center=�5      [YАвторизируйтесь в системе или войдите как гость.�� 5      IGЕсли у Вас нет акккаунта, вы можете его �� 5      $%��/Pages/ClientPages/RegPage.xaml?�6   
�������.�5   /   создать5        .5"      �� 5#      $ Vertical=�6   $��Center=�5$      .+�5%      �� $��Логин:��6   
�������$��16(�5'      #��[ 5(      �� 5)      $ 
Horizontal=�6   $��Center=�5*      .+�5+      �� $"��../Resources/Light/Login.png��6   $��30��5,      �� 5-      -   5         ��Name$ LoginTextBox��5-      $	��200��5.        MainTextBox#��[ 5/      50      �� 51      $��Пароль:��6   $
��Left=�52      
�������$��16(�54      #��[ 55      �� 56      $ 
Horizontal=�6   $��Center=�57      .+�58      �� $%��../Resources/Light/Password.png��6   $��30��59      G� 5:      -   5         G�Name$ PasswordBox��5:   "   $	��200��5;   "     PassBox#��[ 5<   "   5=      5>      �� 5?      $ 
Horizontal=�6   $��Center=�5@      .+�5A      �� -   5         ��Name$ LoginButton��5A      $	��150��5C      
�������  DefaultButton#��[ 5E      $��
Войти��5F      �� 5G      -   5        $ GuestButton��5G      $	��150��5I      
�������#��[ 5K      $��
Гость��5L      5M      5N      �� 5P   
   -   5         ��Name$ LoadingImage��5P      $��50��5Q      $��50��5R      $��Center=�5S      $��Center=�5T      5U      5V      