   M S B A M L   `   `   `  ����   BLA    BLA.FlowerInfo   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008       N� Title$  
FlowerInfo�� � 	Resources    PrimaryColor �� Color  SecondaryColor  AccentColor  	TextColor  BackgroundColor  ButtonHoverColor��%�   &	        &	      &	 &     &	 9     &	 L     &	 _     �� $ #4CAF50���� $ #E8F5E9���� $ #FFC107���� $ #333333���� $ #FFFFFF���� $ #66BB6A��.��� #��[ .+��� #��[  �� CornerRadius$ 10�� �� Padding$ 10q�$��10q�._�� .+��� $*��$Информация о клумбе��$��Center=�$	��Top=�$��26(�$
��Bold"�#��[  �� $��Номер клумбы:��$
��Left=�$��	10,60,0,0q�$	��Top=�$��18(�#��[ �� -   $��numFlowerbed��$��_��$
��Left=�$��
150,60,0,0q�$	��Top=�$��18(�#��[ �� -   $��	TrueFalse��$
��Left=�$��
10,100,0,0q�$	��Top=�$��18(�#��[  ���� *	TrueFalse+ �� StringFormat$	 {0}���� $4��.Расписание полива клумбы��$
��Left=�$��
10,140,0,0q�$	��Top=�$��20(�$
��Bold"�#��[ �� -    ��Name$ 	WeekWater��$��10,180,10,60q�#��[ ���� .R��� $ 8��#��[ $��5q�$ 10q�#��[  $��1q�._��  � ColumnDefinitions �� $��2* ��� $��2* ��� $��2* ��� $��2* ��� $
��Auto ��� $��2* �.+��� $��0��$��18(�$
��Bold"�$��Center=�#��[  �� TextAlignment$ Center=����� *
weekDate+�� $��1��$��16(�$��Center=�#��[ $ Center=�$
��10,0q����� *
startWater+�� $��2��$��16(�$��Center=�#��[ $ Center=�$
��10,0q����� *
endWater+�� $��3��$��16(�$��Center=�#��[ $ Center=�$
��10,0q����� *tube+�� $��4��$��16(�$��Center=�#��[ $ Center=�$
��10,0q����� *nameFertilizer+�� $��Удалить��$��5��$
��10,0q�#��[  
�������$��0q�$	��100��$��30��$��Center=�$��Center=����� 	 �� 
TargetType"	 ��.��� 
 �� Property
 � �� �� Value# [   �� Triggers P�  P� Property �@J�IsMouseOver P� Value . . ��� 
 � ��# [ ��  �� Orientation$ 
Horizontal=�$��Right=�$��Bottom=�$��	0,0,10,10q�.+��� -    ��Name$ Delete��$!��Удалить клумбу��$��5q�#��[ 
�������$	��150��$��40��$��16(�$��0q��� -   $ AddWater��$!��Добавить полив��$��5q�#��[  
�������$	��150��$��40��$��16(�$��0q�