   M S B A M L   `   `   `  ����K  GKozyrev_Hriha_SP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Kozyrev_Hriha_SP.UtilsKozyrev_Hriha_SP.Utils  5      )    #Kozyrev_Hriha_SP.Utils.EmployeeData   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:Kozyrev_Hriha_SP.Utils     5      -   5          >�Name$  employeeData��5   7    � 	Resources 5	      6   0Kozyrev_Hriha_SP.Utils.RoleToVisibilityConverter   RoleToVisibilityConverter��%   &	          5
   
   6*   5      .��5      �  � DataContext 6   ��  �� ElementName$ employeeData�� �� Path$ DataContext�.+�5   
   �  � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��* �6#    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    .+�5      �� $��Jmeno:��6   $��0��6%   $��1��65   $��3,10,0,0q�6C   $��Center=�6U   
�������$��12(�5      $��Medium"�5      $��
Montserrat)�5      �� 5       $��1��6   $��1��6&   $��1,10,0,0q�5#      $��Center=�5$      $��13(�6.   $��Medium"�5%      $��
Montserrat)�5&      
������� �� 
CaretBrush
 �����
�������$��0,0,0,2q�5*      $��28��5+      $��Center=�5,      $��20,0,0,0q�5-      ��5"      �� $ Jmeno� �� Mode$ TwoWay=�	 �� ValidatesOnExceptions	 . 
 �� NotifyOnValidationError
 .  �� UpdateSourceTrigger$ PropertyChanged=�.��5-   %   ��5.      �� 5/       �� ImageSource$% /Resources/Images/user-icon.png��6!    j� Stretch$
 None=�50   "    j� 
AlignmentX$
 Left=�51   "   .��52   &   53      �� 54      $��	Prijmeni:��6   $��0��6(   $��2��68   $��3,10,0,0q�6F   $��Center=�6X   
�������$��12(�55      $��Medium"�56      $��
Montserrat)�57      �� 58      -   5        $��
pscTextBox��5:      $��1��58      $��2��6&   $��1,10,0,0q�59      $��Center=�5<      $��13(�5=      $��Medium"�5>      $��
Montserrat)�5?      
�������
 �����
�������$��0,0,0,2q�5C      $��28��5D      $��Center=�5E      $��20,0,0,0q�5F      ��5;      �� $ Prijmeni�$ TwoWay=�	 . 
 . $ PropertyChanged=�.��5F   %   ��5G      �� 5H      $% /Resources/Images/user-icon.png��6!   $
 None=�5I      $
 Left=�5J      .��5K   &   5L      �� 5M      $��Plat:��6   $��0��6$   $��3��64   $��3,10,0,0q�6B   $��Center=�6T   
�������$��12(�5N      $��Medium"�5O      $��
Montserrat)�5P      �� 5Q      -   5        $��popisneCodeTextBox��5S      $��1��5Q      $��3��6&   $��1,10,0,0q�5R      $��Center=�5U      $��28��5V       �� TextWrapping$
 Wrap=�5W      $��13(�5X      $��Medium"�5Y      $��
Montserrat)�5Z      
�������
 �����
�������$��0,0,0,2q�5^      $��Center=�5_      $��20,0,0,0q�5`      ��5T      �� $
 Plat�$ TwoWay=�	 . 
 . $ PropertyChanged=�.��5`   )   ��5a      �� 5b      $! /Resources/Images/coins.png��6!   $
 None=�5c   !   $
 Left=�5d   !   .��5e   &   5f      �� 5h      $��Den nastupu:��6   $��0��6+   $��4��6;   $��3,10,0,0q�6I   $��Center=�6[   
�������$��12(�5i      $��Medium"�5j      $��
Montserrat)�5k      (  "System.Windows.Controls.DatePicker  5l      -   5          Name$ picker��5n      $��1��5l      $��4��5m      $��1,10,0,0q�5o      $��Center=�5q      $��13(�5r      $��Medium"�5s      $��
Montserrat)�5t      ���#212529
�������$��0,0,0,2q�5z      $��28��5{      $��Center=�5|      $��20,0,0,0q�5}         SelectedDate 5p      �� $ 
DenNastupu�$ TwoWay=�	 . 
 . ��5~      �� 5      $$ /Resources/Images/calendar.png��6!   $
 None=�5�   !   $
 Left=�5�   !   5�      5�      5�      5�      