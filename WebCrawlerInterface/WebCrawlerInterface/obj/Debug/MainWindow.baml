   M S B A M L   `   `   `  ����N  JWebCrawlerInterface, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:WebCrawlerInterfaceWebCrawlerInterface  5   	   $    WebCrawlerInterface.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:WebCrawlerInterface     5   	   -   5          � Title$  Web Crawler��5   	   $	��610��6   $	��800��6A   $��Bahnschrift)�6M    � AllowsTransparency .  � WindowStyle$
 None=�6�   .��5	      � ���#1E1E1E.+�5
   
   ��  �� Orientation$ Vertical=�6   .+�5      �� -   5         ��Name$ upbar��5      $
��50px��6(   ���#21A2F1$ 
Horizontal=�6K   .+�5      �� $��Center=�6   $
��Bold"�63   $
��22px(�6E   .��6U   Web Crawler6b   �� 5      -   5        $��Center=�5      $
��22px(�63   $��	600,0,0,0q�6C    � Cursor$
 Hand��6V   .��6�   -6�   �� 5      -   5        $��Center=�5      $
��22px(�63   $��0,0,0,0q�6C   $
 Hand��6T   .��6~   x6�   5      �� 5      $��	10,10,0,0q�6   $ 
Horizontal=�6,   $��200px��6E   .+�5      �� -   5         ��Name$ myStatusBox��5      $��200px��6/   $��550px��6>   �� 5      $��70,0,0,0q�6   $ Vertical=�6/   .+�5      �� -   5        $
��50px��5      $��120px��6+   $��Start Main Crawling��69   6W   �� 5      -   5         ��Name$ btnPauseCrawling��5   <   $
��50px��6   $��120px��6,   $��Pause Main Crawling��6W   6�   �� 5      -   5        $ btnStopCrawling��5   <   $
��50px��6   $��120px��6,   $��Stop Main Crawling��6s   6�   �� 5      -	   5        $ btnSeeCrawlingTasks��5   <   $
��50px��6   $��120px��6,   $��See tasks for URLs��6Z   6�   5      5      �� 5      $��	10,10,0,0q�6   $ 
Horizontal=�6,   $��200px��6E   .+�5      �� -
   5        $ 
myEndedBox��5      $��200px��6.   $��550px��6=   �� 5      $��70,0,0,0q�6   $ Vertical=�6/   .+�5      �� -   5        $ 
btnNewRoot��5   V   $��120px��6   $
��50px��6,   $��Add New Root URL��6:   6j   �� 5       -   5        $ btnSettings��5    N   $��120px��6   $
��50px��6,   $��Settings��6:   6c   �� 5!      -   5        $ btnLogs��5!   J   $��120px��6   $
��50px��6,   $
��Logs��6:   6[   5"      5%      �� 5(      $��	10,10,0,0q�6   $ 
Horizontal=�6,   $��200px��6E   .+�5*      �� -   5        $ 
myStatsBox��5*      $	��778��6.   $��0,0,0,84q�6:   5+      5-      5.      5/      