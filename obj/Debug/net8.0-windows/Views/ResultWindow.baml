   M S B A M L   `   `   `  ����C  ?EasyType, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:EasyType.ViewsEasyType.Views  5   	   !    EasyType.Views.ResultWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:EasyType.Views     5   	     � Title$.  (Результати тесту EasyType��5   	   $	��336��6+   $	��400��68   ���#282C34 � WindowStartupLocation$ CenterOwner=�5
   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$ 
ToolWindow=�5   	    � 	Resources 5         DialogButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType	 �� CornerRadius  ResultTextStyle  ResultValueTextStyle
 �� BasedOn��%^  &	        &	     &	 �    7  �� 5   
   " ��6*   .�5      ��  � ��$	 120��6&   �� 5       � ��$ 45��6'   �� 5       � ��$ 10q�6'   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ 16(�6)   �� 5       � �� �#282C346+   �� 5       � �� �#61AFEF6+   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $	 5��6!   #��z��62   #��z��5   !   #��z��5   !   ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5       5!      �� 5#   
   " ��6(   .�5$      ��  � ��$ 20(�6)   �� 5%       � �� �#ABB2BF6+   �� 5&       � ��$	 0 5q�6'   �� 5'       � ��$ Center=�64   5(      �� 5*   
   " ��6-   8
   .�5+      ��  � ��$
 Bold"�6+   �� 5,       � �� �#61AFEF6+   5-      5/      .��51      � $��0,0,0,-6q�6   .+�52   
   �� $��Center=�6   $��Center=�60   .+�53      �� $"��Тест завершено!��6   $��28(�54      $��	ExtraBold"�6&   ���#98C379$��0 0 0 25q�55      $��Center=�6*   �� 57       �� Orientation$ 
Horizontal=�6   $��Center=�62   $	��0 5q�6O   .+�58      �� $+��%Швидкість друку (WPM): ��6   #��[ 6;   �� 59      -   5         ��Name$ WpmTextBlock��59      #��[ 62   5:      �� 5<      $ 
Horizontal=�6   $��Center=�62   $	��0 5q�6O   .+�5=      �� $��Точність: ��6   #��[ 6.   �� 5>      -   5        $ AccuracyTextBlock��5>      #��[ 67   �� 5?      $��%��6   #��[ 6%   5@      �� 5B      $ 
Horizontal=�6   $��Center=�62   $	��0 5q�6O   .+�5C      �� $��
Мова: ��6   $��16(�6*   ���#ABB2BF68   �� 5D      -   5        $ LanguageTextBlock��5D      $��16(�67   $
��Bold"�6E   ���#ABB2BF6W   5E      �� 5G      $ 
Horizontal=�6   $��Center=�62   $	��0 5q�6O   .+�5H      �� $��Режим тексту: ��6   $��16(�62   ���#ABB2BF6@   �� 5I      -   5        $ TextModeTextBlock��5I      $��16(�67   $
��Bold"�6E   ���#ABB2BF6W   5J      �� 5L      -   5        $��Закрити��5L      #��[  6'   $��0 40 0 0q�6l   5M      5N      5O      