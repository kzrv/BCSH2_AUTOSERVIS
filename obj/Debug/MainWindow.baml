   M S B A M L   `   `   `  ����K  GKozyrev_Hriha_SP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Kozyrev_Hriha_SPKozyrev_Hriha_SP  5   	   I)clr-namespace:Kozyrev_Hriha_SP.ViewModelsKozyrev_Hriha_SP.ViewModels  5   	   ?$clr-namespace:Kozyrev_Hriha_SP.UtilsKozyrev_Hriha_SP.Utils  5   	   ?$clr-namespace:Kozyrev_Hriha_SP.UtilsKozyrev_Hriha_SP.Utils  5	   	   ?$clr-namespace:Kozyrev_Hriha_SP.ViewsKozyrev_Hriha_SP.Views  5
   	   !    Kozyrev_Hriha_SP.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Kozyrev_Hriha_SP     5   	   8vm)clr-namespace:Kozyrev_Hriha_SP.ViewModels     5   	   5Menu$clr-namespace:Kozyrev_Hriha_SP.Utils     5   	   5conv$clr-namespace:Kozyrev_Hriha_SP.Utils     5	   	   6views$clr-namespace:Kozyrev_Hriha_SP.Views     5
   	   -   5          � Title$  
MainWindow��5   	   $	��600��6   $	��850��6)    � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	   
������  � 	Resources 5      6   0Kozyrev_Hriha_SP.Utils.RoleToVisibilityConverter   RoleToVisibilityConverter<   6Kozyrev_Hriha_SP.Utils.ByteArrayToImageSourceConverter # ByteArrayToImageSourceConverter��%:   &	        &	        5   
   6)     5   
   6/   5      .��5      � .+�5   
   �� ���#212529 �� CornerRadius$ 20��5      � 5   
    � ColumnDefinitions 5       �� 5!      $	��228 �6#   �� 5"      $	��622 �6#   .+�5%      � $
��Left=�6   $	��228��5&      .+�5(      �� ���#272B2F$ 	20,0,0,20��5)      �� 5+      $	��600��6   $	��228��5,      .+�5/          Kozyrev_Hriha_SP.Utils.Btn    BtnStyle#��[ 6   {�.   d� 	IsChecked$
 TrueY�51      $	��Top=�52      $��0,0,0,0q�53      .��56      �� ���	#FF000000$��1q�69   $ 5��6M   $��2q�6^   ._�57      �� $��	AUTOCHECK��6(   $
��Left=�58      $��60,0,0,0q�59        
Text_Style#��[ 5:      5<      5=        5A      #��[ 6   $
 TrueY�5C      ��5B      �� *HomeCommand+.��5E      � .+�5G      �� $��Resources/Images/home.png��6$     Image_Style#��[ 5H   $   �� 5J      $
��Home��6(   #��[ 5K   (   5N      5Q        5T      #��[ 6   $
 TrueY�5V      ��5U      �� *LoginCommand+y�5W      �� *
UserRole+ �� 	Converter# [  	 �� ConverterParameter$	 UNLOGIN��.��5Y      � .+�5[      �� $��Resources/Images/user.png��6$   #��[ 5\   $   �� 5^      $��Login��6(   #��[ 5_   (   5b      5e        5h      #��[ 6   $
 TrueY�5j      ��5i      �� *
RegCommand+y�5k      �� *
UserRole+# [  $	 UNLOGIN��.��5m      � .+�5o      �� $��Resources/Images/user.png��6$   #��[ 5p   $   �� 5r      $��Registration��6(   #��[ 5s   (   5v      5y        5}      #��[ 6   $
 TrueY�5      ��5~      �� *CustomerCommand+y�5�      �� *
UserRole+# [  $	 ADMIN��.��5�      � .+�5�      �� $$��Resources/Images/users-alt.png��6$   #��[ 5�   $   �� 5�      $��Customer��6(   #��[ 5�   (   5�      5�        5�      #��[ 6   $
 TrueY�5�      ��5�      �� *CustomerOrderCommand+y�5�      �� *
UserRole+# [  $	 ZAKAZNIK��.��5�      � .+�5�      �� $$��Resources/Images/clipboard.png��6$   #��[ 5�   $   �� 5�      $��Order��6(   #��[ 5�   (   5�      5�        5�      #��[ 6   $
 TrueY�5�      ��5�      �� *ZamestnanecVisitCommand+y�5�      �� *
UserRole+# [  $	 ZAMESTNANEC��.��5�      � .+�5�      �� $)��#Resources/Images/calendar-clock.png��6$   #��[ 5�   $   �� 5�      $��Visit��6(   #��[ 5�   (   5�      5�        5�      #��[ 6   $
 TrueY�5�      ��5�      �� *EmployeeCommand+y�5�      �� *
UserRole+# [  $	 ADMIN��.��5�      � .+�5�      �� $$��Resources/Images/users-alt.png��6$   #��[ 5�   $   �� 5�      $��Employee��6(   #��[ 5�   (   5�      5�        5�      #��[ 6   ��5�      �� *OrderCommand+y�5�      �� *
UserRole+# [  $	 ADMIN��.��5�      � .+�5�      �� $$��Resources/Images/clipboard.png��6$   #��[ 5�   $   �� 5�      $��Order��6(   #��[ 5�   (   5�      5�        5�      #��[ 6   ��5�      �� *VisitCommand+y�5�      �� *
UserRole+# [  $	 ADMIN��.��5�      � .+�5�      �� $)��#Resources/Images/calendar-clock.png��6$   #��[ 5�   $   �� 5�      $��Visit��6(   #��[ 5�   (   5�      5�        5�      #��[ 6   ��5�      �� *
CarCommand+y�5�      �� *
UserRole+# [  $	 ADMIN,ZAMESTNANEC��.��5�      � .+�5�      �� $'��!Resources/Images/car-mechanic.png��6$   #��[ 5�   $   �� 5�      $	��Car��6(   #��[ 5�   (   5�      5�        5�      #��[ 6   ��5�      �� *ServiceTaskCommand+y�5      �� *
UserRole+# [  $	 ADMIN��.��5     � .+�5     �� $"��Resources/Images/service.png��6$   #��[ 5  $   �� 5     $��Service��6(   #��[ 5  (   5
     5       5     #��[ 6   ��5  !   �� *PaymentCommand+y�5  !   �� *
UserRole+# [  $	 ADMIN��.��5     � .+�5     �� $!��Resources/Images/wallet.png��6$   #��[ 5  %   �� 5     $��Payment��6(   #��[ 5  )   5     5       5      #��[ 6   ��5!  !   �� *LogsCommand+y�5"  !   �� *
UserRole+# [  $	 ADMIN��.��5$     � .+�5&     �� $��Resources/Images/log.png��6$   #��[ 5'  %   �� 5)     $	��Log��6(   #��[ 5*  )   5,     5-     51       57     #��[ 6   
 � Cursor$

 Hand��58     $��Bottom=�5;     $��0,0,0,10q�5<     ��59     �� *UserSettingsCommand+y�5:     �� *
UserRole+# [  $ 	 ZAKAZNIK,ZAMESTNANEC,ADMIN��.��5?     � .+�5A     �� #��[ 5B      ��5A      �� *BinaryImageData+# [ 5B      �� 5D     #��[ 5E      ��5D  $   �� *
UserName+5E      �� 5H     $!��Resources\Images\logout.png��6      Image_Style_Click#��[ 5I      $��Right=�5J      $��10q�5K       J� InputBindings 5L     d� 5M  "    d� Gesture$ 	LeftClicka�6/    �� Command 6C   �� *LogoutCommand+ �� CommandParameter 6e   ��  �� ElementName$ 
MainWindow��5O     5R     5U     5W     � 5Y     $��1��6   .+�5[     �� -   5         ��Name$ Pages��5[  !   ��5\  !   �� *CurrentView+5^     5`     �� 5b  
   -   5         ��Name$ CloseApp��5b       ExitApp#��[ 5c     62   � 5d  
   $��Right=�6   $��Bottom=�6+   $��10q�6F   .+�5e     )   #Kozyrev_Hriha_SP.Views.Notification  -   5          Name$ NotificationArea��5e  !   5f     5h     5i     