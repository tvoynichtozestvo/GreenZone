   M S B A M L   `   `   `  ����>  :BLA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:BLABLA  5          BLA.FertilizerPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      #localclr-namespace:BLA     5        N� Title$  FertilizerPage��5	      .��5      � ���#F1F8E9.+�5   
   �� $1��+Управление удобрениями��6   $��26(�5      $
��Bold"�5      ���#388E3C$
��Left=�5      $	��Top=�5      $��	20,20,0,0q�5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��FertilizerData��5      $��20,100,20,20q�5         AutoGenerateColumns .    HeadersVisibility$ Column=�5         RowBackground �#FFFFFF   AlternatingRowBackground �#F0F4C7   GridLinesVisibility$
 None=�5      ���#388E3C$	��0.5q�5      $   HorizontalScrollBarVisibility$
 Auto=�5      "   VerticalScrollBarVisibility$
 Auto=�5          ColumnHeaderStyle 5!      �� 5"      	 �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"	  6   .�5#      �� 
 �� Property
 � �� �� Value �#388E3C63   �� 5$      
 � ��
 �����63   �� 5%      
 � ��$ 16(�61   �� 5&      
 � ��$
 Bold"�63   �� 5'      
 � ��$
 Left=�6C   �� 5(      
 � ��$ 40��6/   �� 5)      
 � ��$ 10q�60   5*      5,      �� 5/   
    �� Orientation$ 
Horizontal=�6   $
��Left=�6.   $	��Top=�6I   $��	20,60,0,0q�6a   .+�51      �� -   5         ��Name$ addFertilizerBtn��51      $)��#Добавить удобрение��52      ���	#FF4CAF50
�������$	��180��55      $��40��56      $��14(�57      $
��Bold"�58      $��Center=�59      $��Center=�5:      ��5<      �� 5=      "	 ��6   .�5>      �� 
 � �� �	#FF4CAF5067   �� 5?      
 � ��
 �����67   �� 5@      
 � ��$
 10,0q�64   �� 5A      
 � ��$ 14(�65   �� 5B      
 � ��$
 Bold"�67    �� Triggers 5C      P� 5D       P� Property �@J�IsMouseOver P� Value . . �5E   "   �� 
 � �� �#2E7D326?   5F      P� 5G       � �� . . �5H   "   �� 
 � �� �#1B5E206?   5I      5K      5M      �� 5P      -   5        $ 	updateBtn��5P      $%��Обновить таблицу��5Q      ���	#FF4CAF50
�������$	��180��5T      $��40��5U      $��14(�5V      $
��Bold"�5W      $
��10,0q�5X      $��Center=�5Y      $��Center=�5Z      ��5\      �� 5]      "	 ��6   .�5^      �� 
 � �� �	#FF4CAF5067   �� 5_      
 � ��
 �����67   �� 5`      
 � ��$
 10,0q�64   �� 5a      
 � ��$ 14(�65   �� 5b      
 � ��$
 Bold"�67    5c      P� 5d       �@J�IsMouseOver . . �5e   "   �� 
 � �� �#2E7D326?   5f      P� 5g       � �� . . �5h   "   �� 
 � �� �#1B5E206?   5i      5k      5m      5o      5q      5s      