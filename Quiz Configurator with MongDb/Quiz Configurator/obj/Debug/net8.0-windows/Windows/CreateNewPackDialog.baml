   M S B A M L   `   `   `  ����Y  UQuiz Configurator With MongoDB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Quiz_Configurator.ModelQuiz_Configurator.Model  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	   3    -Quiz_Configurator.Windows.CreateNewPackDialog   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:Quiz_Configurator.Model     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	     � Title$  CreateNewPackDialog��5	   	   $	��280��6%   $	��200��62    � 
ResizeMode$ NoResize=�6>    � WindowStyle$ 
ToolWindow=�6T    � WindowStartupLocation$ CenterOwner=�6m    � 	Resources 5       S� 
MethodName S� 
ObjectTypeU QSystem.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a  System.Enum   DifficultyEnumProvider S� MethodParameters M� TypeName��%w   &	        S� 5   
   $ 	GetValues��6   "  64    5      M� 5      $ local:Difficulty��6   5      5      .��5      � .+�5   
   �� $��
10 0 10 10q�6   $��3��6)   .+�5      �� $��
Pack Name:��6   $
��Bold"�6)   �� 5      ��6   �� *
PackName+	 �� Mode$	 TwoWay=��� 5      $��Difficulty:��6   $
��Bold"�6*   �� 5      -   5        
 ��Name$
 comboBox��5       �� SelectedIndex$ 1��5      ��5      ��  �� Source# [   �� SelectedItem 5      �� *PackDifficulty+$	 TwoWay=��� 5      $��	Category:��6   $
��Bold"�6(   �� 5       -   5        $
 CategoryComboBox��5       $ 1��5"      ��5!      �� *
Categories+ 5#      �� *PackCategory+$	 TwoWay=�]� 5&      .+�5'      �� $��Time Limit:��6   $
��Bold"�6.   �� 5(       �� ContentStringFormat$  {0} seconds��5)      $��Right=�5*      ��5(      ��  �� ElementName$ slider�� �� Path$ Value�5*      5+      �� 5,      -   5         ��Name$ slider��5,       � Minimum$ 5Q�5-       � Maximum$	 120Q�5.       �� TickFrequency$ 5Q�5/       �� TickPlacement$ BottomRight=�50       �� IsSnapToTickEnabled$
 True��51       � Value 52      �� *PackTimeLimit+]� 54      $��Bottom=�6   .+�55      �� -   5        $��Cancel��55      $��20��6*   $��50��66   $��
20 20 0 20q�6A   6U   �� 56      -   5        $��Create��56      $��20��6+   $��50��67   6B   58      5:      5;      5<      