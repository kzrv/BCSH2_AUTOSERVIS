   M S B A M L   `   `   `  ����K  GKozyrev_Hriha_SP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Kozyrev_Hriha_SP.UtilsKozyrev_Hriha_SP.Utils  5      &     Kozyrev_Hriha_SP.Utils.VisitData   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:Kozyrev_Hriha_SP.Utils     5      -   5          >�Name$  	visitData��5   8   .��5
      �  � DataContext 6   ��  �� ElementName$ 	visitData�� �� Path$ DataContext�.+�5   
   �  � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��* �6#    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    .+�5      �� $��Start date:��6   $��0��6*   $��1��6:   $��3,10,0,0q�6H   $	��Top=�6Z   
�������$��12(�5      $��Medium"�5      $��
Montserrat)�5      (  "System.Windows.Controls.DatePicker  5      $��1��6   $��1��5      $��3,10,0,0q�5       $��Center=�5"      $��13(�5#      $��Medium"�5$      $��
Montserrat)�5%      ���#212529
�������$��0,0,0,2q�5(      $��28��5)      $��Center=�5*      $��20,0,0,0q�5+         SelectedDate 5!      �� $ DatumZacatek� �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�	 �� ValidatesOnExceptions	 . 
 �� NotifyOnValidationError
 . ��5.      �� 5/       �� ImageSource$$ /Resources/Images/calendar.png��6!    j� Stretch$
 None=�50       j� 
AlignmentX$
 Left=�51      53      �� 54      $��	End date:��6   $��0��6(   $��2��68   $��3,10,0,0q�6F   $	��Top=�6X   
�������$��12(�55      $��Medium"�56      $��
Montserrat)�57        58      $��1��6   $��2��59      $��3,10,0,0q�5:      $��Center=�5<      $��13(�5=      $��Medium"�5>      $��
Montserrat)�5?      ���#212529
�������$��0,0,0,2q�5B      $��28��5C      $��Center=�5D      $��20,0,0,0q�5E       5;      �� $ 
DatumKonec�$ PropertyChanged=�$ TwoWay=�	 . 
 . ��5F      �� 5G      $$ /Resources/Images/calendar.png��6!   $
 None=�5H      $
 Left=�5I      5K      �� 5M      $��Price:��6   $��0��6%   $��3��65   $��3,10,0,0q�6C   $��Center=�6U   
�������$��12(�5N      $��Medium"�5O      $��
Montserrat)�5P      �� 5Q      -   5        $��mestoTextBox��5T   
   $��1��5Q      $��3��5R   
   $��3,10,0,0q�5S   
   $��Center=�5V   
   $��13(�5W   
   $��Medium"�5X   
   $��
Montserrat)�5Y   
   
������� �� 
CaretBrush
 �����
�������$��0,0,0,2q�5]   
   $��28��5^   
   $��Center=�5_   
   $��20,0,0,0q�5`   
   ��5U   
   �� $ CenaProhlidky�$ TwoWay=�	 . 
 . .��5`      ��5a      �� 5b      $! /Resources/Images/coins.png��6!   $
 None=�5c      $
 Left=�5d      .��5e   &   5f      5g      5h      5i      