   M S B A M L   `   `   `  ����C  ?EasyType, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:EasyType.ViewsEasyType.Views  5   	   #    EasyType.Views.SettingsWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:EasyType.Views     5   	     � Title$  Налаштування��5   	   $	��450��6   $	��600��6+   ���#282C34���#ABB2BF.��5
      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��Налаштування��6!   $��24(�65   $
��Bold"�6C   $��0 0 0 15q�6U   �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��0 0 0 10q�6;   .+�5      �� $%��Тривалість (сек): ��6   $	��180��62   $��16(�6>   �� 5      $��80��6   $��16(�6d   ��6!   �� *TestDuration+ �� UpdateSourceTrigger$ PropertyChanged=�6d   5      �� 5   
   $��2��6   $ 
Horizontal=�6"   $��0 0 0 10q�6;   .+�5      �� $��Режим тексту: ��6   $	��180��6.   $��16(�6:   �� 5      $	��150��6   $��16(�6o   ��6#   �� *	TextModes+ �� SelectedItem 6E   �� *SelectedTextMode+6o   5      �� 5    
   $��3��6   $ 
Horizontal=�6"   $��0 0 0 10q�6;   .+�5!      �� $��
Мова: ��6   $	��180��6&   $��16(�62   �� 5"      $	��150��6   $��16(�6x   ��6#   �� *AvailableLanguages+ 6N   �� *SelectedLanguage+6x   5#      �� 5%   
   $��4��6   $ 
Horizontal=�6"   $��Right=�6;   .+�5&      �� -   5        $��Зберегти��5&      $	��100��6(   $��30��64   $��5q�6@   $��16(�6d   �� 5'      -   5        $��Скасувати��5'      $	��100��6)   $��30��65   $��5q�6A   $��16(�6g   5(      5)      5*      