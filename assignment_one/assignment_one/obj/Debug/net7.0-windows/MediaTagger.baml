   M S B A M L   `   `   `  ����I  Eassignment_one, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:assignment_oneassignment_one  5           assignment_one.MediaTagger   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:assignment_one     5        � 	Resources  5	       �� 
TargetType �� Property �� Value��%�   '��       �� 5
   
   " ��6   .�5      ��  � ��$ 50��6&   �� 5       � ��$ 50��6'   �� 5       � ��$ 10q�6'   5      5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
      Command$/ )local:CustomCommands.SaveMediaTagsCommand��6   6O   .��5      �� $��Right=�6   .+�5   
   �� $	��714��6   .+�5      � .+�5      �� -   5         ��Name$ 
AlbumCover��5      $	��340��6,   $	��700��69   $��Right=�6F   $0��*pack://application:,,,/Images/textured.jpg��6b   $
��Fill=�6�   5      r� 5      -   5         r�Name$ myMediaElement��5       r� LoadedBehavior$ Manual=�67   	 r� UnloadedBehavior$	 Manual=�6O   6�   �� 5      -   5        
 ��Name$
 	tagBanner��5      $��Bottom=�6/   ���	#800000FF
�������$��awaiting file��6t   $��50��6�   $	��700��6�   $��Right=�6�    �� TextAlignment$ Right=�6�   $y�Visible=�6�   �� 5      -   5         ��Name$ tagEditorMenu��5      $	��Top=�64   ���	#800000FF$	��330��6c   $	��700��6p   $��10,0,0,0q�6|   $y�	Collapsed=�6�   .+�5      �� -   5         ��Name$ editorHeader��5      
������ $��50(�6M   $��
Tag Editor��6[   
�������6�   �� 5      -   5        $ 
titleLabel��5      
������ 
�������$��30��6^   $	��700��6j   $��	10,10,0,0q�6v   $��Title��6�   �� 5       -   5        $ performerLabel��5       
������ 
�������$��30��6b   $	��700��6n   $��	10,10,0,0q�6z   $��Artist��6�   �� 5!      -   5        $ 
albumLabel��5!      
������ 
�������$��30��6^   $	��700��6j   $��	10,10,0,0q�6v   $��Album��6�   �� 5"      -	   5        $ releaseDateLabel��5"      
������ 
�������$��30��6d   $	��700��6p   $��	10,10,0,0q�6|   $
��Year��6�   �� 5#      -
   5         ��Name$ SaveTagsBtn��5#      $/��)local:CustomCommands.SaveMediaTagsCommand��62   $
��Save��6f   $	��100��6u   $��30��6�   $��Center=�6�   $	��Top=�6�   $��	10,10,0,0q�6�   5$      5%      5&      �� 5'   
    �� Orientation$ 
Horizontal=�6   $��80��6.   $��Right=�6:   .+�5(      �� -   5        $ PlayBtn��5(      $+��%local:CustomCommands.PlayMediaCommand��6&   ��5)      �� 5*       �� 
TargetType" ��6&   .R�5+      �� $��Center=�6+   $��Center=�6H   $��50��6c   $��50��6n   5,      .��5.      �� $,��&pack://application:,,,/Images/play.png��6   $��Uniform=�6H   $��Right=�6Z   $��50��6v   5/      �� 50      -   5        $ PauseBtn��50      $,��&local:CustomCommands.PauseMediaCommand��6'   ��51      �� 52      " ��6&   .R�53      �� $��Center=�6+   $��Center=�6H   $��50��6c   $��50��6n   54      .��56      �� $-��'pack://application:,,,/Images/pause.png��6   $��Uniform=�6I   $��50��6[   $	��Top=�6g   57      �� 58      -   5        $ StopBtn��58      $+��%local:CustomCommands.StopMediaCommand��6&   ��59      �� 5:      " ��6&   .R�5;      �� $��Center=�6+   $��Center=�6H   $��50��6c   $��50��6n   5<      .��5>      �� $.��(pack://application:,,,/Images/square.png��6   $��Uniform=�6J   5?      �� 5@      -   5        $
 timeDisplay��5@      $��Right=�6-   $��Bottom=�6I   $��50��6d   $��50��6o   $��5q�6{   $��00:00:00��6�   �� 5A      -   5         ��Name$ mediaProgressBar��5A      $��20��6/   $	��450��6;   6G   5D      5E      5F      