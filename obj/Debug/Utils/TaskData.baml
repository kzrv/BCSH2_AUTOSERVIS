   M S B A M L   `   `   `  ����K  GKozyrev_Hriha_SP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Kozyrev_Hriha_SP.UtilsKozyrev_Hriha_SP.Utils  5      %    Kozyrev_Hriha_SP.Utils.TaskData   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:Kozyrev_Hriha_SP.Utils     5      -   5          >�Name$  taskData��5   6   .��5
      �  � DataContext 6   ��  �� ElementName$ taskData�� �� Path$ DataContext�.+�5   
   �  � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��* �6#    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    .+�5      �� $��Name:��6   $��0��6$   $��1��64   $��3,10,0,0q�6B   $��Center=�6T   
�������$��12(�5      $��Medium"�5      $��
Montserrat)�5      �� 5      $��1��6   $��1��6&   $��3,10,0,0q�5       $��Center=�5!      $��13(�6.   $��Medium"�5"      $��
Montserrat)�5#      
������� �� 
CaretBrush
 �����
�������$��0,0,0,2q�5'      $��28��5(      $��Center=�5)      $��20,0,0,0q�5*      ��5      �� $ Nazev� �� Mode$ TwoWay=� �� ValidatesOnExceptions . 	 �� NotifyOnValidationError	 . 
 �� UpdateSourceTrigger$
 PropertyChanged=�.��5*   %   ��5+      �� 5,       �� ImageSource$  /Resources/Images/info.png��6!    j� Stretch$
 None=�5-   "    j� 
AlignmentX$
 Left=�5.   "   .��5/   &   50      �� 51      $��Description:��6   $��0��6+   $��2��6;   $��3,10,0,0q�6I   $��Center=�6[   
�������$��12(�52      $��Medium"�53      $��
Montserrat)�54      �� 55      -   5        $��
pscTextBox��57      $��1��55      $��2��6&   $��3,10,0,0q�56      $��Center=�59      $��13(�5:      $��Medium"�5;      $��
Montserrat)�5<      
�������
 �����
�������$��0,0,0,2q�5@      $	��110��5A       �� TextWrapping$
 Wrap=�5B      $��Center=�5C      $��20,0,0,0q�5D      ��58      �� $ Popis�$ TwoWay=� . 	 . $
 PropertyChanged=�.��5D   %   ��5E      �� 5F      $  /Resources/Images/info.png��6!   $
 None=�5G      $
 Left=�5H      .��5I   &   5J      �� 5K      $��Cena:��6   $��0��6$   $��3��64   $��3,10,0,0q�6B   $��Center=�6T   
�������$��12(�5L      $��Medium"�5M      $��
Montserrat)�5N      �� 5O      -   5        $��mestoTextBox��5R      $��1��5O      $��3��5P      $��3,10,0,0q�5Q      $��Center=�5T      $��13(�5U      $��Medium"�5V      $��
Montserrat)�5W      
�������
 �����
�������$��0,0,0,2q�5[      $��28��5\      $��Center=�5]      $��20,0,0,0q�5^      ��5S      �� $ Coast�$ TwoWay=� . 	 . $
 PropertyChanged=�.��5^   %   ��5_      �� 5`      $! /Resources/Images/coins.png��6!   $
 None=�5a      $
 Left=�5b      .��5c   &   5d      5e      5f      5g      