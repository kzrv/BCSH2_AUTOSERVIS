   M S B A M L   `   `   `  ����K  GKozyrev_Hriha_SP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Kozyrev_Hriha_SP.UtilsKozyrev_Hriha_SP.Utils  5      )    #Kozyrev_Hriha_SP.Utils.CustomerData   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:Kozyrev_Hriha_SP.Utils     5      -   5          >�Name$  customerData��5	   7    � 	Resources 5
      6   0Kozyrev_Hriha_SP.Utils.RoleToVisibilityConverter   RoleToVisibilityConverter��%   &	          5   
   6*   5      .��5      �  � DataContext 6   ��  �� ElementName$ customerData�� �� Path$ DataContext�.+�5   
   �  � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��* �6#    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    .+�5      �� $��Name:��6   $��0��6$   $��1��64   $��3,10,0,0q�6B   $��Center=�6T   
�������$��12(�5      $��Medium"�5      $��
Montserrat)�5      �� 5       $��1��6   $��1��6&   $��8,10,0,0q�5"      $��Center=�5#      $��13(�62   $��Medium"�5$      $��
Montserrat)�5%      
������� �� 
CaretBrush
 �����
�������$��0,0,0,2q�5)      $��28��5*      $��Center=�5+      $��20,0,0,0q�5,      ��5!      �� $ Jmeno� �� Mode$ TwoWay=�	 �� ValidatesOnExceptions	 . 
 �� NotifyOnValidationError
 .  �� UpdateSourceTrigger$ PropertyChanged=�.��5,   )   ��5-      �� 5.       �� ImageSource$% /Resources/Images/user-icon.png��6!    j� Stretch$
 None=�5/   &    j� 
AlignmentX$
 Left=�50   &   .��51   &   52      �� 53      $��Surname:��6   $��0��6'   $��2��67   $��3,10,0,0q�6E   $��Center=�6W   
�������$��12(�54      $��Medium"�55      $��
Montserrat)�56      �� 57      -   5        $��
pscTextBox��59      $��1��57      $��2��6&   $��8,10,0,0q�58      $��Center=�5;      $��13(�5<      $��Medium"�5=      $��
Montserrat)�5>      
�������
 �����
�������$��0,0,0,2q�5B      $��28��5C      $��Center=�5D      $��20,0,0,0q�5E      ��5:      �� $ Prijmeni�$ TwoWay=�	 . 
 . $ PropertyChanged=�.��5E   )   ��5F      �� 5G      $% /Resources/Images/user-icon.png��6!   $
 None=�5H   !   $
 Left=�5I   !   .��5J   &   5K      �� 5L      $��Tel number:��6   $��0��6*   $��3��6:   $��3,10,0,0q�6H   $��Center=�6Z   
�������$��12(�5M      $��Medium"�5N      $��
Montserrat)�5O      �� 5P      -   5        $��mestoTextBox��5S      $��1��5P      $��3��5Q      $��8,10,0,0q�5R      $��Center=�5U      $��13(�5V      $��Medium"�5W      $��
Montserrat)�5X      
�������
 �����
�������$��0,0,0,2q�5\      $��28��5]      $��Center=�5^      $��20,0,0,0q�5_      ��5T      �� $ TelCislo�$ TwoWay=�	 . 
 . $ PropertyChanged=�.��5_   )   ��5`      �� 5a      $$ /Resources/Images/tel-icon.png��6!   $
 None=�5b   !   $
 Left=�5c   !   .��5d   &   5e      �� 5f      $��	Comments:��6   $��0��6(   $��4��68   $��3,10,0,0q�6F   $��Center=�6X   
�������$��12(�5g      $��Medium"�5h      $��
Montserrat)�5i      �� 5j      -   5        $��popisneCodeTextBox��5l      $��1��5j      $��4��6&   $��8,10,0,0q�5k      $��Center=�5n      $��60��5o       �� TextWrapping$
 Wrap=�5p      $��13(�5q      $��Medium"�5r      $��
Montserrat)�5s      
�������
 �����
�������$��0,0,0,2q�5w      $��Center=�5x      $��20,0,0,0q�5y      ��5m      �� $ Poznamky�$ TwoWay=�	 . 
 . $ PropertyChanged=�.��5y   )   ��5z      �� 5{      $  /Resources/Images/info.png��6!   $
 None=�5|   !   $
 Left=�5}   !   .��5~   &   5      5�      5�      5�      