   M S B A M L   `   `   `  ����G  CFinalProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:FinalProjectFinalProject  5      #    FinalProject.PublisherControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:FinalProject     5      .��5	      � -   5        $��child��5	        � RowDefinitions  5
   
   �� 5      $��1* �6   6*   �� 5      $��1* �6   6*   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $��6* �6#   60   �� 5      $��1* �6#   60   .+�5      �� -   5        $��gbPublisher��5   '   $��0��6   $��New Publisher��5   A   .��5      � $��1��6    5      �� 5      6-   �� 5      6-   �� 5      6-   .+�5      �� $��1��6   .+�5      �� $��Name:��6     �� Left$ 10��60   
 �� Top$ 82��6A   $
��Left=�6Q   $��Center=�6l   $��87��6�   6�   �� 5      $��Created At:��6    $ 10��66   $	 127��6G   $
��Left=�6X   $��Center=�6s   $��89��6�   �� 5      -   5        $��tbName��5   �   $	 124��6"    �� TextWrapping$
 Wrap=�64   $ 82��6H   $	��167��6X   $
��Left=�6d   $	��Top=�6   $��22��6�   6�   (  "System.Windows.Controls.DatePicker  5      -   5        $��dtpCreatedAt��5   �   $	 124��6%   $	 131��67   $	��167��6H   $
��Left=�6T   $��22��6o   $	��Top=�6{   6�   5       5!      5"      �� 5#      -   5        $��	gbActions��5#   '   $��1��6   $��Actions��5$   ;   .��5%      �� .+�5&      �� -   5        $��btnSave��5&   �      btn#��[  6   $
��Save��6:   $	��100��6I   $��50��6U   $ 10��6a   $ 10��6r   
���   �
�������$��Center=�6�   $	��Top=�6�   6�   �� 5'      -   5        $��	btnUpdate��5'   �   #��[  6   $��Update��6:   $	��100��6K   $��50��6W   $ 10��6c   $ 90��6t   
���   �
�������$��Center=�6�   $	��Top=�6�   6�   �� 5(      -   5        $��	btnDelete��5(   �   #��[  6   $��Delete��6:   $	��100��6K   $��50��6W   $ 10��6c   $	 170��6t   
���   �
�������$��Center=�6�   $	��Top=�6�   6�   5)      5*      5+      &   System.Windows.Controls.DataGrid  5,   
   -	   5        $��dgPublisher��5,   3   $��1��6   
�������$��4,4,4,4q�6F   5.      5/      50      