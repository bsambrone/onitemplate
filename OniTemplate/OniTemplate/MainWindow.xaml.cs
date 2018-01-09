using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OniTemplate.Editor;
using OniTemplate.Editor.Model;
using OniTemplate.Extensions;
using OniTemplate.Model;
using OniTemplate.Model.Serialization;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace OniTemplate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Point startPoint;

        public double CurrentRow = 0;
        public double CurrentColumn = 0;
        public EditorViewModel ViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            
            ViewModel = this.FindResource("ViewModel") as EditorViewModel;

            PaletteTree.ItemsSource = ViewModel.PaletteCollections;
            
            // wire up the template cells
            ViewModel.ResetCells(MainGrid);

            this.DataContext = ViewModel;
        }

        private void PaletteTree_OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Store the mouse position
            startPoint = e.GetPosition(null);

            // Get the selected item
            if (PaletteTree.SelectedItem != null)
            {
                var item = PaletteTree.SelectedItem as PaletteItem;
                ViewModel.SelectedTileProperty.Element = item.Name;
            }
        }

        private void PaletteTree_OnMouseMove(object sender, MouseEventArgs e)
        {
            // Get the current mouse position
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                // Get the dragged TreeView
                var treeView = sender as TreeView;
                var selected = treeView.SelectedItem;

                // Find the data behind the TreeViewItem
                var data = selected as PaletteItem;
                if (data == null) return;
                var dragObject = new DragElement();
                dragObject.ImageUri = data.ImageUri;
                dragObject.Name = data.Name;

                // Initialize the drag & drop operation
                DataObject dragData = new DataObject(typeof(DragElement), dragObject);
                DragDrop.DoDragDrop(treeView, dragData, DragDropEffects.Copy);
            }
        }

        private void MainGrid_OnDragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(DragElement)) ||
                sender == e.Source)
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void MainGrid_OnDrop(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(typeof(DragElement)))
            {
                DragElement data = e.Data.GetData(typeof(DragElement)) as DragElement;
                ScrollViewer viewer = sender as ScrollViewer;
                var mainGrid = viewer.FindName("MainGrid") as BorderGrid;
                
                var hit = VisualTreeHelper.HitTest(viewer, e.GetPosition(this));
                if (hit == null) { return; }

                var gridPosition = mainGrid.GetColumnRow(e.GetPosition(viewer));
                CurrentRow = gridPosition.X;
                CurrentColumn = gridPosition.Y;

                var cell = mainGrid.Children.Cast<UIElement>().First(g => Grid.GetRow(g) == gridPosition.Y && Grid.GetColumn(g) == gridPosition.X) as Image;   
                var newPaletteItem = new PaletteItem() { ImageUri = data.ImageUri, Name = data.Name, TileType = data.TileType };
                cell.DataContext = newPaletteItem;
                Binding imageBinding = new Binding("PaletteItem.ImageUri");
                imageBinding.Source = cell;
                imageBinding.Mode = BindingMode.TwoWay;
                imageBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                imageBinding.Converter = new ImagePathConverter();
                BindingOperations.SetBinding(cell, Image.SourceProperty, imageBinding);
                cell.Source = new BitmapImage(new Uri("pack://application:,,,/OniTemplate;component/Images/" + data.ImageUri));

                var targetTemplateCell = ViewModel.Cells.First(x => x.Column == gridPosition.X && x.Row == gridPosition.Y);
                // since all value types, copy those little guys
                targetTemplateCell.TileProperty = new TileProperty()
                {
                    DiseaseCount = ViewModel.SelectedTileProperty.DiseaseCount,
                    DiseaseName = ViewModel.SelectedTileProperty.DiseaseName,
                    Element = ViewModel.SelectedTileProperty.Element,
                    MassGrams = ViewModel.SelectedTileProperty.MassGrams,
                    TemperatureKelvin = ViewModel.SelectedTileProperty.TemperatureKelvin,
                };
                
                targetTemplateCell.PaletteItem = newPaletteItem;
                
            }
        }

        private void MainGrid_OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ScrollViewer viewer = sender as ScrollViewer;
            var mainGrid = viewer.FindName("MainGrid") as BorderGrid;

            var hit = VisualTreeHelper.HitTest(viewer, e.GetPosition(this));
            if (hit == null) { return; }

            var gridPosition = mainGrid.GetColumnRow(e.GetPosition(viewer));
            CurrentRow = gridPosition.X;
            CurrentColumn = gridPosition.Y;

            // get selected items
            if (PaletteTree.SelectedItem == null)
            {
                MessageBox.Show("Please select an element");
                return;
            }
            var item = PaletteTree.SelectedItem as PaletteItem;

            var cell = mainGrid.Children.Cast<UIElement>().First(g => Grid.GetRow(g) == gridPosition.Y && Grid.GetColumn(g) == gridPosition.X) as Image;
            var newPaletteItem = new PaletteItem() { ImageUri = item.ImageUri, Name = item.Name, TileType = item.TileType };
            cell.DataContext = newPaletteItem;
            Binding imageBinding = new Binding("PaletteItem.ImageUri");
            imageBinding.Source = cell;
            imageBinding.Mode = BindingMode.TwoWay;
            imageBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            imageBinding.Converter = new ImagePathConverter();
            BindingOperations.SetBinding(cell, Image.SourceProperty, imageBinding);
            cell.Source = new BitmapImage(new Uri("pack://application:,,,/OniTemplate;component/Images/" + item.ImageUri));

            var targetTemplateCell = ViewModel.Cells.First(x => x.Column == gridPosition.X && x.Row == gridPosition.Y);
            targetTemplateCell.PaletteItem = newPaletteItem;

            // since all value types, copy those little guys
            targetTemplateCell.TileProperty = new TileProperty()
            {
                DiseaseCount = ViewModel.SelectedTileProperty.DiseaseCount,
                DiseaseName = ViewModel.SelectedTileProperty.DiseaseName,
                Element = ViewModel.SelectedTileProperty.Element,
                MassGrams = ViewModel.SelectedTileProperty.MassGrams,
                TemperatureKelvin = ViewModel.SelectedTileProperty.TemperatureKelvin,
            };
            targetTemplateCell.PaletteItem = newPaletteItem;

        }

        private void SaveAsTemplate_OnClick(object sender, RoutedEventArgs e)
        {
            var template = new Template();

            // get the name
            template.Name = ViewModel.TemplateName ?? "undefined";

            // get the size
            template.Info.Size.X = ViewModel.Cells.Where(x => x.PaletteItem.TileType != TileType.Null).Max(x => x.Column);
            template.Info.Size.Y = ViewModel.Cells.Where(x => x.PaletteItem.TileType != TileType.Null).Max(x => x.Row);
            if (ViewModel.Cells.Where(x => x.PaletteItem.TileType != TileType.Null).Min(x => x.Column) == 0) template.Info.Size.X++;
            if (ViewModel.Cells.Where(x => x.PaletteItem.TileType != TileType.Null).Min(x => x.Row) == 0) template.Info.Size.Y++;

            // get list of cells that aren't null
            var cells = ViewModel.Cells.Where(x => x.PaletteItem.TileType != TileType.Null);
            foreach (var cell in cells)
            {
                var templateCell = new Cell();
                templateCell.DiseaseCount = cell.TileProperty.DiseaseCount;
                templateCell.DiseaseName = cell.TileProperty.DiseaseName;
                templateCell.Element = ElementConverter.Convert(cell.PaletteItem.Name);
                templateCell.Mass = cell.TileProperty.MassGrams;
                templateCell.Temperature = cell.TileProperty.TemperatureKelvin;
                templateCell.location_x = cell.Column;
                templateCell.location_y = cell.Row;
                templateCell.preventFoWReveal = null;
                template.Cells.Add(templateCell);
            }

            // serialize all the things
            var serializer = new SerializerBuilder()
                .WithNamingConvention(new CamelCaseNamingConvention())
                .Build();

            var yaml = serializer.Serialize(template);
            File.WriteAllText(@"c:\temp\dummy.yaml", yaml);
        }
    }
}
