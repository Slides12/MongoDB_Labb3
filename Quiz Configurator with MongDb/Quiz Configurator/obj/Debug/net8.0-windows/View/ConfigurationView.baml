   M S B A M L   `   `   `  ����Y  UQuiz Configurator With MongoDB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Quiz_Configurator.ViewQuiz_Configurator.View  5      .    (Quiz_Configurator.View.ConfigurationView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X TFontAwesome.Sharp, Version=6.6.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5      0local$clr-namespace:Quiz_Configurator.View  5        � DataContext  5      �� *ConfigurationViewModel+.��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��25 �6   �� 5      $��25 �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $
��Bold"�5      $
��Left=�5      $��Center=�5      ��5      ��  �� Path$ ActivePack.Name�5      �� 5!   
   $��Right=�6    �� Orientation$ 
Horizontal=�5"      $��0��5#      .+�5%      �� $��15��6   $��15��5&      $��Right=�5'      $��Center=�5(      $��1��5)      $��5q�5*      ��5+        FontAwesome.Sharp.Icon  *	toolbox+��5,      �� *PackOptionsCommand+�� 5.      $��15��6   $��15��5/      $��Right=�50      $��Center=�51      $��1��52      ��53        *plus+��54      �� *NewQuestionCommand+�� 56      $��15��6   $��15��57      $��Right=�58      $��Center=�59      $��1��5:      $��5q�5;      ��5<        *minus+��5=      �� *DeleteQuestionCommand+5?      �� 5B   
   $��1��5C      $��5q�5D      $��1q�5E      $��9��5F       �� SelectionMode$ Extended=�5H      ��5B      �� *ActivePack.Questions+ �� SelectedItem 5G      �� *ActiveQuestion+��5J      �� 5K      .R�5L      �� .+�5M      �� $��	Question:��6$   $
��Bold"�5N   $   �� 5O      ��6$   �� *Query+5P      5Q      5T      �� 5[   
   $��1��6   $��1��5\      $��	Question:��5]      $
��Bold"�5^      $��20 0 q�5_      y�5`      �� *ActiveQuestion+   nullToVisibilityConverter �� 	Converter# [  �� 5b   
   -   5         ��Name$ questionTextBox��5b      $��2��5c      $��1��5d      	 �� AcceptsReturn$
	 True��5e      $��
20 0 20 20q�5f      
 �� TextWrapping$

 Wrap=�5h   n   ��5g      �� *ActiveQuestion.Query+ �� UpdateSourceTrigger$ PropertyChanged=�y�5h      �� *ActiveQuestion+# [  6n   �� 5m   
   $��3��6   $��2��5n      $��	20 0 20 0q�5o      $��4��5p      y�5q      �� *ActiveQuestion+# [  .+�5s      �� .+�5t      �� $��Correct Answer:��6   $
��Bold"�5u      �� 5v      ��6   �� *ActiveQuestion.CorrectAnswer+5w      �� 5y      .+�5z      �� $��First Incorrect Answer:��6   $
��Bold"�5{      �� 5|      ��6   �� *$"ActiveQuestion.IncorrectAnswers[0]+5}      �� 5      .+�5�      �� $��Second Incorrect Answer:��6   $
��Bold"�5�      �� 5�      ��6   �� *$"ActiveQuestion.IncorrectAnswers[1]+5�      �� 5�      .+�5�      �� $��Third Incorrect Answer:��6   $
��Bold"�5�      �� 5�      ��6   �� *$"ActiveQuestion.IncorrectAnswers[2]+5�      5�      5�      5�      