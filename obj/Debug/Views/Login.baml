   M S B A M L   `   `   `  ����K  GKozyrev_Hriha_SP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Kozyrev_Hriha_SP.ViewsKozyrev_Hriha_SP.Views  5      I)clr-namespace:Kozyrev_Hriha_SP.ViewModelsKozyrev_Hriha_SP.ViewModels  5      Q-clr-namespace:Kozyrev_Hriha_SP.CustomControlsKozyrev_Hriha_SP.CustomControls  5      ?$clr-namespace:Kozyrev_Hriha_SP.UtilsKozyrev_Hriha_SP.Utils  5
      "    Kozyrev_Hriha_SP.Views.Login   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:Kozyrev_Hriha_SP.Views     5      ?	viewModel)clr-namespace:Kozyrev_Hriha_SP.ViewModels     5      Hcustomcontrols-clr-namespace:Kozyrev_Hriha_SP.CustomControls     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      /conv$clr-namespace:Kozyrev_Hriha_SP.Utils  5
        � 	Resources  5      9   3Kozyrev_Hriha_SP.Utils.BooleanToVisibilityConverter    BooleanToVisibilityConverter��%   &	          5   
   6,   5      .��5      ��  �� CornerRadius$ 12��6   ��5   
   �� 5       �� ImageSource$, &/Resources/Images/login_background.jpg��6    j� Stretch$
 Fill=�5      ._�5   
   �� $ 10��6    J� Opacity$
 0.95Q�5   
   ���#212529���#212529._�5      �  � RowDefinitions 5      �� 5       $��30 �6$   �� 5!      .+�5$      � $��0��6    � ColumnDefinitions 5&      �� 5'      �� 5(      $��25 �6+   �� 5)      $��25 �6+   �� 5*      $��5 �6+   .+�5-      �� $��LOG IN��6    
�������$��10(�5/      $��
Montserrat)�50      $��0��51      $��Center=�52      $��10,0,0,0q�53      55      �� 57      $	��220��6   $��1��58       �� Orientation$ Vertical=�59      $��0,35,0,0q�5:      .+�5=      �� $%��/Resources/Images/user-logo.png��6   $	��100��5>      $	��100��6%   � 5A      -   5        $��loadingIndicator��5A   "    � IsIndeterminate . $��20q�5D   "   y�5C   "   �� *IsLoggingIn+	 �� 	Converter#	 [  5D   "   �� 5G      $��Email��6    
�������$��12(�5I      $��Medium"�5J      $��
Montserrat)�5K      $��0,35,0,0q�5L      �� 5N      -   5        
 ��Name$
 txtUser��5N      $��13(�5P      $��Medium"�5Q      $��
Montserrat)�5R      
�������)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Novak��5T       �� 
CaretBrush
 �����
�������$��0,0,0,2q�5W      $��28��5X      $��Center=�5Y      $��0,5,0,0q�5Z      $��20,0,0,0q�5[      ��5O      �� *
UserName+ �� UpdateSourceTrigger$ PropertyChanged=�.��5[   .   ��5]      �� 5^      $% \Resources\Images\user-icon.png��6)   $
 None=�5_   &    j� 
AlignmentX$
 Left=�5`   &   .��5a   .   5b      �� 5d      $��Password��6    
�������$��12(�5f      $��Medium"�5g      $��
Montserrat)�5h      $��0,15,0,0q�5i      5k      9   3Kozyrev_Hriha_SP.CustomControls.BindablePasswordBox  5m      $��28��5n   #   $��0,5,0,0q�5o   #      Password 5m   9   �� *
Password+ �� Mode$ TwoWay=�$ PropertyChanged=�5r      �� 5t      ���#D7596D$��12(�5v      $��Medium"�5w      $��
Montserrat)�5x      $��0,10,0,0q�5y      $
��Wrap=�5z      ��5t       �� *ErrorMessage+5z      � 5|      $��Center=�6   $��5q�5}      �� 5~      -   5         ��Name$ btnLogin��5~      $��0q�5�      $��LOG IN��5�       �� 	IsDefault . 
�������$��12(�5�      $��
Montserrat)�5�       � Cursor$
 Hand��5�      $��0,20,0,0q�5�      ��5      �� *LoginCommand+��5�      �� 5�       �� 
TargetType" ��6$   .�5�   "   ��  �� Property � �� �� Value �#462AD86?    �� Triggers 5�   "   P� 5�   &    P� Property �@J�IsMouseOver P� Value . . �5�   *   ��  � �� �#28AEED6G   5�   '   5�      ��5�      �� 5�       �� 
TargetType" ��6.   .R�5�   "   �� $	��150��6)   $��40��65   $ 20��5�   &   #��z��5�   &   ._�5�   &   �� $��Center=�67   $��Center=�5�   4   5�   #   5�      5�      �� 5�      $ 
Horizontal=�6!   $��Center=�5�      $��0,15,0,0q�5�      5�      5�      5�      5�      5�      5�      