   M S B A M L   `   `   `  ����A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:WpfApp.BestellingenWpfApp.Bestellingen  5   	        WpfApp.Bestellingen.Orders   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:WpfApp.Bestellingen     5   	     � Title$  Orders��5   	   $	��450��6   $	��800��6%   .��5	      � .+�5
   
   R� -   5         R�Name$ treeViewOrders��5
      $��10,100,10,10q�6+   ��5      �� 5       �� ItemsSource 6+   �� *Items+.R�5      ��  �� Orientation$ 
Horizontal=�6!   .+�5      �� $��
Order ID: ��6$   �� 5      $
��Bold"�68   ��6$   �� *Id+68   5       �� ItemTemplate 5      �� 5      .R�5      �� $ 
Horizontal=�6)   .+�5   "   �� $��MenuItem ID: ��6,   �� 5   "   ��6,   �� *
MenuItemId+�� 5   "   $��
Quantity: ��6,   $��10,0,0,0q�6>   �� 5   "   ��6,   �� *Aantal+5      5      5      5      �� 5   
   -   5         ��Name$ 	btn_terug��5      $��Terug��6$   $
��Left=�64   $��35��6O   $��	10,10,0,0q�6[   $	��Top=�6n   $��69��6�   6�   �� 5    
   -   5        $ btn_toevoegen��5       $��	Toevoegen��6(   $
��Left=�6<   $��	10,50,0,0q�6W   $	��Top=�6j   $��69��6�   $��35��6�   6�   5!      5"      