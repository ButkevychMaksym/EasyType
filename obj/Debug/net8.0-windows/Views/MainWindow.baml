   M S B A M L   `   `   `  ����C  ?EasyType, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:EasyType.ViewsEasyType.Views  5   	   9!clr-namespace:EasyType.ViewModelsEasyType.ViewModels  5   	       EasyType.Views.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:EasyType.Views     5   	   0vm!clr-namespace:EasyType.ViewModels     5   	     � Title$7  1EasyType - Тест швидкості друку��5	   	   $	��750��61   $
��1200��6>   ���#282C34 � DataContext 5      '   !EasyType.ViewModels.MainViewModel  5   
    � 	Resources 5      ,   &EasyType.Views.InverseBooleanConverter   InverseBoolConverter  ButtonStyle �� 
TargetType �� Property �� Value  TextInputStyle  DisplayTextStyle&   System.Windows.Media.TextOptions��%�  &	        &	      &	     &	 �      5   
   6(   �� 5   
   " ��6$   .�5      ��  � ��$	 150��6&   �� 5       � ��$ 45��6'   �� 5       � ��$ 10q�6'   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ 16(�6)   �� 5       � �� �#282C346+   5      �� 5   
   " ��6'   .�5      ��  � ��$ 10q�6'   �� 5       � ��$	 7.5q�6(   �� 5       � �� �#21252B6+   �� 5        � �� �#3E44516,   �� 5!       � ��$	 0.5q�60   �� 5"       � ��$ 16(�6)   �� 5#       � ��$ Consolas)�6+   �� 5$       � �� �#61AFEF6+   �� 5%       �@��TextWrapping$
 Wrap=�6-   5&      �� 5(   
   " ��6)   .�5)      ��  �@��
IsReadOnly$
 True��6+   �� 5*       � ��
 ���� 6+   �� 5+       � ��$ 0q�60   �� 5,       � ��$ Stretch=�62   �� 5-       � ��$ Stretch=�64   �� 5.       � ��$ 10q�6'   �� 5/       � ��$	 7.5q�6(   �� 50       � �� �#ABB2BF6+   �� 51       � ��$ 16(�6)   �� 52       � ��$ Consolas)�6+   �� 53       �@ TextFormattingMode$ Display=�6?   54      55      .��57      �  � RowDefinitions 58   
   �� 59      $
��Auto �6   �� 5:      $
��0.4* �6   �� 5;      $
��0.5* �6   �� 5<      $
��Auto �6   .+�5?   
   �� $��0��6   $��20q�6"   $��Center=�6.   .+�5@      �� $��24(�6   $
��Bold"�6&   ���#61AFEF$��Center=�6M   �� 5A      $�Час: ��6   ���#ABB2BF6#    �� 5B      ���#ABB2BF�6   �� *AppState.RemainingTime+ �� Mode$ OneWay=�6K    �� 5C      $�
 сек | ��6   ���#ABB2BF6%    �� 5D      $�WPM: ��6   ���#ABB2BF6#    �� 5E      ���#ABB2BF�6   �� *AppState.WPM+ �� StringFormat$ F0��$ OneWay=�6R    �� 5F      $	� | ��6   ���#ABB2BF6!    �� 5G      $�Точність: ��6   ���#ABB2BF6(    �� 5H      ���#ABB2BF�6   �� *AppState.Accuracy+$ F0��$ OneWay=�6W    �� 5I      $�%��6   ���#ABB2BF6   5J      5K      �� 5M   
   $��1��6   ���#21252B���#3E4451$	��0.5q�5N   <   	 �� CornerRadius$	 5��5O      ._�5P      �� -   5        
 ��Name$
 DisplayText��5P      #��[ 6/   5Q      �� 5S   
   -   5         ��Name$ 	InputText��5S      $��2��6   #��[ 62    �� TextWrapping$
 Wrap=�5V      {�5T      �� *AppState.IsActive+��5U      �� *	UserInput+ �� UpdateSourceTrigger$ PropertyChanged=�5V      �� 5X   
   $��3��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $��20q�6X   .+�5Y      �� $��
Старт��6   #��[ 6%   ���#98C379��5Z   *   �� *StartCommand+{�5[      �� *AppState.IsActive+ �� 	Converter# [  �� 5\      $��Стоп��6   #��[ 6$   ���#E06C75��5]   *   �� *ResetCommand+{�5^      �� *AppState.IsActive+�� 5_      $��Налаштування��6   #��[ 6,   ���#61AFEF��5`   *   �� *OpenSettingsCommand+5a      5b      5c      