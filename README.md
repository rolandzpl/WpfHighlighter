# WpfHighlighter
A simple project enabling highlighting in WPF.

Project _SearchHighlight.Wpf_ contains converter implementation: _SearchMatchValueConverter_.
The implementation converts text into collection of inlines (WPF). Areas matching the search
are decorated different style. Text should be bound to a control via attached property _BindableInlines_ 
which adds inlines provided by the converter to the control. The control must be a subclass of _TextBlock_.

See project _WpfHighlighter.Demo_ for details.

## Example

Below you can see a xaml fragment of the demo project:
````xml
<Window x:Class="WpfHighlighter.Demo.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:conv="clr-namespace:WpfHighlighter.Demo.Converters;assembly=SearchHighlight.Wpf"
        mc:Ignorable="d">

    <Window.Resources>
        <conv:SearchMatchValueConverter x:Key="SearchMatchValueConverter" />
    </Window.Resources>

    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto" />
            <RowDefinition Height="*" />
            <RowDefinition Height="Auto" />
        </Grid.RowDefinitions>

        <TextBox Grid.Row="0" HorizontalAlignment="Left" Width="200" 
                 Text="{Binding SearchText, UpdateSourceTrigger=PropertyChanged, Delay=250}" />

        <DataGrid Grid.Row="1" ItemsSource="{Binding Lines}" 
                  AutoGenerateColumns="False" 
                  CanUserAddRows="False"
                  IsReadOnly="True">
            <DataGrid.Columns>
                <DataGridTemplateColumn Header="First Name">
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <TextBlock>
                                <conv:BindableInlinesExtensions.BindableInlines>
                                    <MultiBinding Converter="{StaticResource SearchMatchValueConverter}" ConverterParameter="FirstName">
                                        <Binding Path="FirstName" />
                                        <Binding Path="Matches" />
                                    </MultiBinding>
                                </conv:BindableInlinesExtensions.BindableInlines>
                            </TextBlock>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
                <DataGridTemplateColumn Header="Last Name">
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <TextBlock>
                                <conv:BindableInlinesExtensions.BindableInlines>
                                    <MultiBinding Converter="{StaticResource SearchMatchValueConverter}" ConverterParameter="LastName">
                                        <Binding Path="LastName" />
                                        <Binding Path="Matches" />
                                    </MultiBinding>
                                </conv:BindableInlinesExtensions.BindableInlines>
                            </TextBlock>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
                <DataGridTextColumn Header="Birth Date" Binding="{Binding BirthDate}" />
            </DataGrid.Columns>
        </DataGrid>
    </Grid>
</Window>

````