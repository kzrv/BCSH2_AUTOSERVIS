   M S B A M L   `   `   `  ����K  GKozyrev_Hriha_SP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Kozyrev_Hriha_SP.UtilsKozyrev_Hriha_SP.Utils  5      (    "Kozyrev_Hriha_SP.Utils.ServiceData   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:Kozyrev_Hriha_SP.Utils     5      -   5          >�Name$  serviceData��5   8   .��5
      �  � DataContext 6   ��  �� ElementName$ serviceData�� �� Path$ DataContext�.+�5   
   �  � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��* �6#    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $��103.859 �6    �� 5      $��26.141 �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    .+�5      �� $��Name:��6   $��0��6$   $��1��64   $��3,23,0,0q�6B   $	��Top=�6T   
�������$��12(�5      $��Medium"�5      $��
Montserrat)�5      �� 5      $��1��6   $��1��6&   $��3,10,0,0q�5!      $	��Top=�5"      $��13(�6+   $��Medium"�5#      $��
Montserrat)�5$      
������� �� 
CaretBrush
 �����
�������$��0,0,0,2q�5(      $��50��5)       �� TextWrapping$
 Wrap=�5*      $��Center=�5+      $��20,0,0,0q�5,      ��5       �� $ NazevSluzby� �� Mode$ TwoWay=�	 �� ValidatesOnExceptions	 . 
 �� NotifyOnValidationError
 .  �� UpdateSourceTrigger$ PropertyChanged=�.��5,   %   ��5-      �� 5.       �� ImageSource$  /Resources/Images/info.png��6!    j� Stretch$
 None=�5/   "    j� 
AlignmentX$
 Left=�50   "   .��51   &   52      �� 53      $��Description:��6   $��0��6+   $��2��6;   $��3,58,0,0q�6I   $	��Top=�6[   
�������$��12(�54      $��Medium"�55      $��
Montserrat)�56      �� 57      -   5        $��
pscTextBox��59      $��1��57      $��2��6&   $��3,10,0,0q�58      $	��Top=�5;      $��13(�5<      $��Medium"�5=      $��
Montserrat)�5>      
�������
 �����
�������$��0,0,0,2q�5B      $	��120��5C      $
 Wrap=�5D      $��Center=�5E      $��20,0,0,0q�5F      $��3��6%   ��5:      �� $ Popis�$ TwoWay=�	 . 
 . $ PropertyChanged=�.��5F   6   ��5G      �� 5H      $  /Resources/Images/info.png��6!   $
 None=�5I      $
 Left=�5J      .��5K   &   5L      5M      5N      5O      