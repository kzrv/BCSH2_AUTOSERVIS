   M S B A M L   `   `   `  ����K  GKozyrev_Hriha_SP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Kozyrev_Hriha_SP.ViewsKozyrev_Hriha_SP.Views  5      Q-clr-namespace:Kozyrev_Hriha_SP.CustomControlsKozyrev_Hriha_SP.CustomControls  5      ?$clr-namespace:Kozyrev_Hriha_SP.UtilsKozyrev_Hriha_SP.Utils  6S   )    #Kozyrev_Hriha_SP.Views.Registration   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:Kozyrev_Hriha_SP.Views     5      Hcustomcontrols-clr-namespace:Kozyrev_Hriha_SP.CustomControls     5      5conv$clr-namespace:Kozyrev_Hriha_SP.Utils     6S   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        � 	Resources  5      9   3Kozyrev_Hriha_SP.Utils.BooleanToVisibilityConverter    BooleanToVisibilityConverter��%   &	          5   
   6,   5      .��5      ��  �� CornerRadius$ 12��6   ��5   
   �� 5       �� ImageSource$&  /Resources/Images/back-image.jpg��6    j� Stretch$
 None=�5      ._�5   
   �� $ 10��6    J� Opacity$
 0.95Q�5   
   ���#212529���#212529._�5      �  � RowDefinitions 5      �� 5      $��30 �6$   �� 5       .+�5#      � $��0��6    � ColumnDefinitions 5%      �� 5&      �� 5'      $��25 �6+   �� 5(      $��25 �6+   �� 5)      $��5 �6+   .+�5,      �� $��REGISTRATION��6    
�������$��10(�5.      $��
Montserrat)�5/      $��0��50      $��Center=�51      $��10,0,0,0q�52      54      �� 56      $	��220��6   $��1��57       �� Orientation$ Vertical=�58      $��0,35,0,0q�59      .+�5<      �� $$��/Resources/Images/reg-icon.png��6   $	��100��5=      $	��100��6%   �� 5B      $ 
Horizontal=�6   $��Center=�6&   $��0,20,0,0q�6C   .+�5C      A� $��10��6"   $��10��6-   ���#462AD8$��2q�6H   $��1��6S   
���   �6g   A� 5D      $��10��6"   $��10��6-   
�������$��2q�6E   $��1��6P   
���   �6d   A� 5E      $��10��6"   $��10��6-   
�������$��2q�6E   $��1��6P   
���   �6d   5F      �� 5G      $
��Name��6    
�������$��12(�5I      $��Medium"�5J      $��
Montserrat)�5K      $��0,15,0,0q�5L      �� 5N      -   5         ��Name$ txtName��5N      $��13(�5P      )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$
	 Petr��5Q      $��Medium"�5R      $��
Montserrat)�5S      
�������
 �� 
CaretBrush

 �����
�������$��0,0,0,2q�5W      $��28��5X      $��Center=�5Y      $��0,5,0,0q�5Z      $��20,0,0,0q�5[      ��5O      �� *Name+ �� UpdateSourceTrigger$ PropertyChanged=�.��5[   .   ��5]      �� 5^      $% \Resources\Images\user-icon.png��6)   $
 None=�5_   &    j� 
AlignmentX$
 Left=�5`   &   .��5a   .   5b      �� 5c      $��Surname��6    
�������$��12(�5e      $��Medium"�5f      $��
Montserrat)�5g      $��0,15,0,0q�5h      �� 5j      -   5        $ 
txtSurname��5j      $��13(�5l      $��Medium"�5m      $	 Novak��5n      $��
Montserrat)�5o      
�������

 �����
�������$��0,0,0,2q�5s      $��28��5t      $��Center=�5u      $��0,5,0,0q�5v      $��20,0,0,0q�5w      ��5k      �� *	Surname+$ PropertyChanged=�.��5w   .   ��5y      �� 5z      $% \Resources\Images\user-icon.png��6)   $
 None=�5{   &   $
 Left=�5|   &   .��5}   .   5~      �� 5      $��Telephone Number��6    
�������$��12(�5�      $��Medium"�5�      $��
Montserrat)�5�      $��0,15,0,0q�5�      �� 5�      -   5        $ txtTelephone��5�      $��13(�5�      $��Medium"�5�      $	 +420(607)-770-532��5�      $��
Montserrat)�5�      
�������

 �����
�������$��0,0,0,2q�5�      $��28��5�      $��Center=�5�      $��0,5,0,0q�5�      $��20,0,0,0q�5�      ��5�      �� *	TelNumber+$ PropertyChanged=�.��5�   .   ��5�      �� 5�      $$ \Resources\Images\tel-icon.png��6)   $
 None=�5�   &   $
 Left=�5�   &   .��5�   .   5�      �� 5�      ���#D7596D$��12(�5�      $��Medium"�5�      $��
Montserrat)�5�      $��0,10,0,0q�5�      $
��Wrap=�5�      ��5�       �� *Error+5�      �� 5�      $	��220��5�      $��1��5�      $ 
Horizontal=�5�      .+�5�      �� -   5         ��Name$ 	btnCancel��5�   %   $��0q�5�   "   $��CANCEL��5�   "   
�������$��12(�5�   "   $��
Montserrat)�5�   "    � Cursor$
 Hand��5�   "   $��0,15,0,0q�5�   "   $	��105��64   ��5�   "   �� *CancelCommand+��5�      �� 5�   "    �� 
TargetType" ��6(   .�5�   &   ��  �� Property � �� �� Value
 �����6C    �� Triggers 5�   &   P� 5�   *    P� Property �@J�IsMouseOver P� Value . . �5�   .   ��  � �� �#28AEED6K   5�   +   5�   #   ��5�      �� 5�   "    �� 
TargetType" ��62   .R�5�   &   �� $	��105��6-   $��40��69   $ 20��5�   &   #��z��5�   &   ._�5�   *   �� $��Center=�6;   $��Center=�5�   4   5�   '   5�   #   5�      �� 5�      -   5        $ btnNext��5�   !   $��0q�5�      $
��NEXT��5�      
�������$��12(�5�      $��
Montserrat)�5�      $
 Hand��5�      $��	10,15,0,0q�5�      $	��105��61   ��5�      �� *NextCommand+��5�      �� 5�      " ��6$   .�5�   "   ��  � �� �#462AD86?    5�   "   P� 5�   &    �@J�IsMouseOver . . �5�   *   ��  � �� �#28AEED6G   5�   '   5�      ��5�      �� 5�      " ��6.   .R�5�   "   �� $	��105��6)   $��40��65   $ 20��5�   &   #��z��5�   &   ._�5�   &   �� $��Center=�67   $��Center=�5�   4   5�   #   5�      5�      5�      �� 5�      $ 
Horizontal=�6!   $��Center=�5�      $��0,15,0,0q�5�      5�      5�      5�      5�      5�      5�      