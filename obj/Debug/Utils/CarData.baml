   M S B A M L   `   `   `  ����K  GKozyrev_Hriha_SP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Kozyrev_Hriha_SP.UtilsKozyrev_Hriha_SP.Utils  5      $    Kozyrev_Hriha_SP.Utils.CarData   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:Kozyrev_Hriha_SP.Utils     5      -   5          >�Name$  carData��5   8   .��5
      �  � DataContext 6   ��  �� ElementName$ carData�� �� Path$ DataContext�.+�5   
   �  � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��* �6#    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    .+�5      �� $
��Vin:��6   $��0��6#   $��1��63   $��Center=�6A   
�������$��3,10,0,0q�5      $��12(�5      $��Medium"�5       $��
Montserrat)�5!      $��28��5"      �� 5#      -   5        $��uliceTitleTextBox��5#   3   $��1��6   $��1��6&   $��8,10,0,0q�6�   $��Center=�5$      $��13(�6.   $��Medium"�5%      $��
Montserrat)�5&      
������� �� 
CaretBrush
 �����
�������$��0,0,0,2q�5*      $��28��5+       �� TextWrapping$ NoWrap=�5,      $��Center=�5-      $��20,0,0,0q�5.      ��5#   L   �� $	 Vin� �� Mode$ TwoWay=�	 �� ValidatesOnExceptions	 . 
 �� NotifyOnValidationError
 .  �� UpdateSourceTrigger$ PropertyChanged=�.��5.   &   ��5/      �� 50       �� ImageSource$  /Resources/Images/info.png��6!    j� Stretch$
 None=�51       j� 
AlignmentX$
 Left=�52      .��53   &   54      �� 55      $
��Spz:��6   $��0��6#   $��2��63   $��3,10,0,0q�6@   $��Center=�6R   
�������$��12(�56      $��Medium"�57      $��
Montserrat)�58      �� 59      -   5        $��
pscTextBox��59   3   $��1��6   $��2��6&   $��8,10,0,0q�6�   $��Center=�5:      $��13(�6.   $��Medium"�5;      $��
Montserrat)�5<      
�������
 �����
�������$��0,0,0,2q�5@      $��28��5A      $��Center=�5B      $��20,0,0,0q�5C      ��59   E   �� $	 Spz�$ TwoWay=�	 . 
 . $ PropertyChanged=�.��5C   &   ��5D      �� 5E      $  /Resources/Images/info.png��6!   $
 None=�5F      $
 Left=�5G      .��5H   &   5I      �� 5K      $��Year:��6   $��0��6$   $��3��64   $��3,10,0,0q�6A   $��Center=�6S   
�������$��12(�5L      $��Medium"�5M      $��
Montserrat)�5N      �� 5O      -   5        $��TextBox��5O   3   $��1��6   $��3��6&   $��8,10,0,0q�6�   $��Center=�5P      $��13(�6"   $��Medium"�5Q      $��
Montserrat)�5R      
�������
 �����
�������$��0,0,0,2q�5V      $��28��5W      $��Center=�5X      $��20,0,0,0q�5Y      ��5O   B   �� $ 	RokVyroby�$ TwoWay=�	 . 
 . $ PropertyChanged=�.��5Y      ��5Z      �� 5[      $  /Resources/Images/info.png��6!   $
 None=�5\      $
 Left=�5]      .��5^   &   5_      �� 5`      $��	Comments:��6   $��0��6(   $��4��68   $��3,10,0,0q�6F   $��Center=�6X   
�������$��12(�5a      $��Medium"�5b      $��
Montserrat)�5c      �� 5d      -   5        $��mestoTextBox��5d   4   $��1��6   $��4��6&   $��8,10,0,0q�6�   $��Center=�5e      $��13(�6.   $��Medium"�5f      $��
Montserrat)�5g      
�������
 �����$
 Wrap=�5j      
�������$��0,0,0,2q�5l      $��70��5m      $��Center=�5n      $��20,0,0,0q�5o      ��5d   H   �� $ Poznamky�$ TwoWay=�	 . 
 . $ PropertyChanged=�.��5o   '   ��5p      �� 5q      $  /Resources/Images/info.png��6!   $
 None=�5r      $
 Left=�5s      .��5t   &   5u      5w      5x      5y      