   M S B A M L   `   `   `  ����Y  UQuiz Configurator With MongoDB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Quiz_Configurator.ViewQuiz_Configurator.View  5      '    !Quiz_Configurator.View.PlayerView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:Quiz_Configurator.View     5        � 	Resources  5         MyButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� Padding �� CornerRadius �� Triggers P� Property	 P� Value
 �� 
TargetName��%  &	        �� 5   
   " ��6&   .�5      ��  �@�OverridesDefaultStyle$
 True��66   �� 5       � ��$ 5q�6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $��border��6!   $��1q�5      $	 4,2q�5      
�������$ 3��5      #��z��5      ._�5      �� $��Center=�6/   $��Center=�6L   5       5      P� 5       �@J�IsMouseOver$
	 True��6=   . �5   "   �� $
 border��6)    � ��
 �   �6T   5      5       5"      5#      5$      .��5'      �  � ColumnDefinitions 5(   
   �� 5)      $��* �6   �� 5*      $��* �6    � RowDefinitions 5-   
   �� 5.      $��* �6   �� 5/      $��* �6   .+�54   
   �� $��Center=�6   $��Bottom=�62   $��2��6M   .+�55   
   �� $��35(�6;   $
��Wrap=�6I    �� Padding$ 
30 0 30 10q�6]    �� TextAlignment$ Center=�6r   ��6   �� *PlayerViewModel.Query+6r   �� 56      $��20(�6   $ Center=�6&   �� 57      $�Question��6    �� 58      �6   �� *PlayerViewModel.Index+ �� 59      $�of��6    �� 5:      �6   �� **(PlayerViewModel.CurrentAmountOfQuestions+5;      5<      �� 5A   
   $��1��6   $��Right=�6"   .+�5B      �� $	��220��6   $��80��6%   $��10q�5C      #��[  5E      ��5D      �� * PlayerViewModel.QuestionColor1+��5F      �� *%#PlayerViewModel.CheckButtonCommand1+��5G      ��  �� RelativeSource �� *Self+.��5H      �� $	��200��5I      $��70��5J      $
��Wrap=�5K      $ Center=�5L      ��5H      �� *PlayerViewModel.Question1+5L      5M      �� 5N      $	��220��6   $��80��6!   $��10q�5O      #��[  5Q      ��5P      �� * PlayerViewModel.QuestionColor2+��5R      �� *%#PlayerViewModel.CheckButtonCommand2+��5S      ��  �� *Self+.��5T      �� $	��200��5U      $��70��5V      $
��Wrap=�5W      $ Center=�5X      ��5T      �� *PlayerViewModel.Question2+5X      5Y      5Z      �� 5\   
   $��1��6   $��1��6"   $
��Left=�5]      .+�5_      �� $	��220��6   $��80��6%   $��10q�5`      #��[  5b      ��5a      �� * PlayerViewModel.QuestionColor3+��5c      �� *%#PlayerViewModel.CheckButtonCommand3+��5d      ��  �� *Self+.��5e      �� $	��200��5f      $��70��5g      $
��Wrap=�5h      $ Center=�5i      ��5e      �� *PlayerViewModel.Question3+5i      5j      �� 5l      $	��220��6   $��80��6%   $��10q�5m      #��[  5o      ��5n      �� * PlayerViewModel.QuestionColor4+��5p      �� *%#PlayerViewModel.CheckButtonCommand4+��5q      ��  �� *Self+.��5r      �� $	��200��5s      $��70��5t      $
��Wrap=�5u      $ Center=�5v      ��5r      �� *PlayerViewModel.Question4+5v      5w      5x      �� 5{   
   $
��Bold"�5}      $��30(�5~      $��Right=�5      $	��Top=�5�      $��1��5�      $��20q�5�      ��5{      �� *PlayerViewModel.Seconds+ �� UpdateSourceTrigger$ PropertyChanged=�5�      5�      5�      