   M S B A M L   `   `   `  ����E  APersonMvvm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:PersonMvvm.ViewsPersonMvvm.Views  5      !    PersonMvvm.Views.PersonView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:PersonMvvm.Views     5      .��5
      � $��90,15,87,44q�6   
�������  � ColumnDefinitions  5   
   �� 5      $
��auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��Employee Management��6   $��0��6/   $��0��6<   $��2��6L   $��20(�6`   $
��Bold"�6n   $��Center=�6�   $��5,8,5,8q�6�    �� Padding$ 3,3,3,3q�6�   �� 5   
   $��Enter First Name��6   $��2��6,   $��0��69   $��5,8,5,8q�6I   $ 3,3,3,3q�6Z   �� 5   
   $��Enter Last Name��6   $��3��6+   $��0��68   $��5,8,5,8q�6H   $ 3,3,3,3q�6Y   �� 5   
   -   5         ��Name$ txtPersonId��5      $y�Hidden=�6'   ��6;   ��  �� Path$ CurrentPerson.PersonId� �� Mode$ TwoWay=��� 5    
   -   5        $��txtFirstName��5       $��2��6&   $��1��63   $��	5,8,118,8q�6C   $��3,3,3,3q�6V   ��6h   �� $ CurrentPerson.FirstName�$ TwoWay=��� 5!   
   -   5        $��txtLastName��5!      $��3��6%   $��1��62   $��	5,8,118,8q�6B   $��3,3,3,3q�6U   ��6g   �� $ CurrentPerson.LastName�$ TwoWay=��� 5#   
    �� Orientation$ 
Horizontal=�6   $��4��6.   $��1��6;   .+�5$      �� -   5        $��btnAdd��5$      $	��ADD��6#   $��5,8,5,8q�61   $��3,3,3,3q�6B   $��58��6y   ��6T   �� $ SaveCommand�6y   �� 5%      -   5        $��btnLoad��5%      $
��LOAD��6$   $��5,8,5,8q�63   $��3,3,3,3q�6D   $��58��6{   ��6V   �� $ LoadCommand�6{   �� 5&      -   5        $��btnClear��5&      $��CLEAR��6%   $��5,8,5,8q�65   $��3,3,3,3q�6F   $��58��6~   ��6X   �� $ ClearCommand�6~   5'      �� 5)   
   $ 
Horizontal=�6   $��5��6.   $��1��6;   .+�5*      �� -   5        $��	txtSearch��5*      $��5,5,5,5q�6'   $��3,3,3,3q�68   $��25��6J    J� RenderTransformOrigin$ 0.5,0.5&�6V   $��92��6v    �� TextWrapping$
 Wrap=�5,      ��5+      �� $ 
SearchText�	 �� UpdateSourceTrigger$	 PropertyChanged=�{�5-      �� *	HasData+�� 5.      -   5        $��	btnSearch��5.      $��SEARCH��5/      $��5,8,5,8q�6&   $��3,3,3,3q�67   ��50      �� $ DataContext.SearchCommand�
 �� RelativeSource
 ��  �� AncestorType$ 
StackPanelL�{�51      �� *	HasData+52      &   System.Windows.Controls.DataGrid  54   
   -	   5        $��dgEmployees��54         AutoGenerateColumns .     CanUserAddRows .  $��6��56   *   $��1��67   $��	5,8,118,8q�6G   $��3,3,3,3q�6Z   ! %� IsVirtualizingWhenGrouping .    EnableRowVirtualization . !   EnableColumnVirtualization . ��57      �� $ 
PersonList�$ TwoWay=� �� SelectedItem 58      �� $ SelectedPerson�$ TwoWay=�{�5<      �� *	HasData+   Columns 5=      0  *System.Windows.Controls.DataGridTextColumn  5>      ,  &System.Windows.Controls.DataGridColumn   Header$ Employee Id��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6:   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6G   �� $ PersonId�  5?      $ Employee First Name��6%   $
 auto 6B    6O   �� $ 	FirstName�  5@      $ Employee Last Name��6%   $
 auto 6A    6N   �� $ LastName�4  .System.Windows.Controls.DataGridTemplateColumn  5A      $ Action��6)   $ * 69      CellTemplate 5B      �� 5C      .R�5D      �� $ 
Horizontal=�6)   .+�5E   "   ��  ��Name$ btnEdit��6*   $
��Edit��6<   $��50��6�   $��3,3,3,3q�6�   ��6K   �� $ DataContext.EditCommand�
 �� " >���6�   �� 6�   �� 5F   "   $ 	btnDelete��6*   $��Delete��6>   $��50��6�   $��3,3,3,3q�6�   ��6O   �� $ DataContext.DeleteCommand�
 �� " >���6�   �� 6�   5G      5H      5J      5L      �� 5N   
   $ 
Horizontal=�6   $��7��6.   $��1��6;   .+�5O      �� $��Previous��6   $��60��5Q      $��5,5,5,5q�5R      $��3,3,3,3q�5S      ��5P      �� *PreviousPageCommand+{�5T      �� *HasPreviousPage+�� 5U      $��0,10,0,0q�65   $��Center=�6G   ��6   �� *CurrentPage+6G   �� 5V      $��/��6   $��0,10,0,0q�6!   �� 5W      $��0,10,0,0q�64   $��Center=�6F   ��6   �� *
TotalPages+6F   �� 5X      $
��Next��6   $��55��5Z      $��5,5,5,5q�6    $��3,3,3,3q�5[      ��5Y      �� *NextPageCommand+{�5\      �� *HasNextPage+5]      5_      5`      