   M S B A M L   `   `   `  ����>  :BLA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:BLABLA  5          BLA.UsersPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      #localclr-namespace:BLA     5        N� Title$  	UsersPage��5	       � 	Resources 5         BLA.PasswordConverter   PasswordConverter  PrimaryColor  SecondaryColor  ButtonHoverColor  	TextColor �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value��%4  &	        &	      &	 4     &	 S     &	 t     '�� �     7  7    5   
   6"   ��5   
   	#FF4CAF50��6:   ��5   
   #E8F5E9��6:   ��5   
   	#FF45A049��6>   ��5   
   #333333��65   �� 5   
   " ��6   .�5      ��  � ��8   6+   �� 5       � ��
 �����6+   �� 5       � ��$ 14(�6)   �� 5       � ��$ 0q�60   �� 5       � ��$	 5 2q�6(   �� 5       � ��$	 2 0q�6'    5      P� 5       �@J�IsMouseOver . . �5      ��  � ��8  63   5      5       5!      .��5#      � #��[ 6   .+�5%   
   �� $7��1Управление пользователями��6   $��Center=�5&      $��26(�5'      $
��Bold"�6   #��[ 5(      �� 5+   
   -   5        $/��)Добавить пользователя��5+      $
��Left=�5,      $	��Top=�5-      $��	10,50,0,0q�5.      5/      &   System.Windows.Controls.DataGrid  52   
   -   5          Name$ 	UsersGrid��52      	   AutoGenerateColumns	 .  $��10,80,10,10q�54      
�������
   
IsReadOnly
 .    Columns 57      0  *System.Windows.Controls.DataGridTextColumn  59      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Логин��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 5;   %   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5:   %   �� *Login+5;   %     5>      $ Пароль��6%   $ * 5@   %    5?   %   �� *
Password+ �� 	Converter# [  5@   %     5C      $ Роль��6%   $ * 5E   %    5D   %   �� *Role+5E   %   4  .System.Windows.Controls.DataGridTemplateColumn  5H      $	 150 6)      CellTemplate 5I      �� 5J      .R�5K      ��  �� Orientation$ 
Horizontal=�6)   $��Center=�6B   .+�5L   "   �� -   5        $��Изменить��5L   )   
 � Tag 5N   )   �� *Id+�� 5O   "   -   5        $��Удалить��5O   )   ���	#FFE44B4B 5R   )   �� *Id+5S      5T      5V      5X      5Y      5Z      