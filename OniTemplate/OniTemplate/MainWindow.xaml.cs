﻿using System;
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
        public EditorViewModel ViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            
            ViewModel = this.FindResource("ViewModel") as EditorViewModel;
            
            // wire up the template cells
            ViewModel.ResetCells(MainGrid);

            this.DataContext = ViewModel;
        }

        private void PaletteTree_OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Store the mouse position
            startPoint = e.GetPosition(null);
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
                var data = selected as TileEntity;
                if (data == null) return;

                // Initialize the drag & drop operation
                DataObject dragData = new DataObject(typeof(TileEntity), data);
                DragDrop.DoDragDrop(treeView, dragData, DragDropEffects.Copy);
            }
        }

        private void PaletteTree_OnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            // Get the selected item
            if (PaletteTree.SelectedItem != null)
            {
                var item = PaletteTree.SelectedItem as TileEntity;
                if (item == null) return;
                item.TileProperty = ViewModel.SelectedTileEntity.TileProperty;
                ViewModel.SetSelectedTile(item);
            }
        }

        private void MainGrid_OnDragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(TileEntity)) ||
                sender == e.Source)
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void MainGrid_OnDrop(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(typeof(TileEntity)))
            {
                ScrollViewer viewer = sender as ScrollViewer;
                var mainGrid = viewer.FindName("MainGrid") as BorderGrid;
                
                var hit = VisualTreeHelper.HitTest(viewer, e.GetPosition(this));
                if (hit == null) { return; }

                var gridPosition = mainGrid.GetColumnRow(e.GetPosition(viewer));
                UpdateGridTile(mainGrid, gridPosition);
            }
        }

        private void MainGrid_OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ScrollViewer viewer = sender as ScrollViewer;
            var mainGrid = viewer.FindName("MainGrid") as BorderGrid;

            var hit = VisualTreeHelper.HitTest(viewer, e.GetPosition(this));
            if (hit == null) { return; }

            var gridPosition = mainGrid.GetColumnRow(e.GetPosition(viewer));

            // get selected items
            if (PaletteTree.SelectedItem == null)
            {
                MessageBox.Show("Please select an element");
                return;
            }
            
            UpdateGridTile(mainGrid, gridPosition);
        }

        private void UpdateGridTile(BorderGrid mainGrid, Point gridPosition)
        {
            // get the current entity selected from the palette. could be an ore or a critter!
            var item = ViewModel.SelectedTileEntity;

            // get the template cell in the main grid
            var targetTemplateCell = ViewModel.Cells.First(x => x.Column == gridPosition.X && x.Row == gridPosition.Y);
            if (targetTemplateCell.TileEntities[0].Classification != TileType.GasElement && item.EntityType != null)
            {
                MessageBox.Show("Base gas element required before placing creature or plant");
                return;
            }

            // update the template cell with the selected values
            if (item.EntityType == null)
            {
                targetTemplateCell.TileEntities[0].ElementType = item.ElementType;
                targetTemplateCell.TileEntities[0].Classification = item.Classification;
                targetTemplateCell.TileEntities[0].DisplayName = item.DisplayName;
                targetTemplateCell.TileEntities[0].EntityType = item.EntityType;
                targetTemplateCell.TileEntities[0].ImageUri = item.ImageUri;
                targetTemplateCell.TileEntities[0].TileProperty = item.TileProperty.Copy();
            }
            else
            {
                targetTemplateCell.TileEntities[1].ElementType = item.ElementType;
                targetTemplateCell.TileEntities[1].Classification = item.Classification;
                targetTemplateCell.TileEntities[1].DisplayName = item.DisplayName;
                targetTemplateCell.TileEntities[1].EntityType = item.EntityType;
                targetTemplateCell.TileEntities[1].ImageUri = item.ImageUri;
                targetTemplateCell.TileEntities[1].TileProperty = item.TileProperty.Copy();
            }
            
            // get the current container in the grid
            var stackPanel = mainGrid.Children.Cast<UIElement>().First(g => Grid.GetRow(g) == gridPosition.Y && Grid.GetColumn(g) == gridPosition.X) as StackPanel;

            // update the render images
            var baseImage = stackPanel.Children[0] as Image;
            var baseContext = baseImage.DataContext as TileEntity;

            var entityImage = stackPanel.Children[1] as Image;
            var entityContext = entityImage.DataContext as TileEntity;
         
            BitmapFrame baseFrame = BitmapDecoder.Create(new Uri("pack://application:,,,/OniTemplate;component/Images/" + baseContext.ImageUri), BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
            BitmapFrame entityFrame = BitmapDecoder.Create(new Uri("pack://application:,,,/OniTemplate;component/Images/" + entityContext.ImageUri), BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();

            // Gets the size of the images
            int imageWidth = 50;
            int imageHeight = 50;

            // Draws the images into a DrawingVisual component
            DrawingVisual drawingVisual = new DrawingVisual();
            using (DrawingContext drawingContext = drawingVisual.RenderOpen())
            {

                if (item.EntityType != null)
                {
                    drawingContext.DrawImage(baseFrame, new Rect(0, 0, imageWidth, imageHeight));
                    drawingContext.DrawImage(entityFrame, new Rect(imageWidth, 0, imageWidth, imageHeight));
                }
                else
                {
                    drawingContext.DrawImage(baseFrame, new Rect(0, 0, imageWidth, imageHeight));
                }
            }

            // Converts the Visual (DrawingVisual) into a BitmapSource
            RenderTargetBitmap bmp = null;
            if (item.EntityType != null)
            {
                bmp = new RenderTargetBitmap(imageWidth * 2, imageHeight * 2, 96, 96, PixelFormats.Pbgra32);
            }
            else
            {
                bmp = new RenderTargetBitmap(imageWidth, imageHeight, 96, 96, PixelFormats.Pbgra32);
            }
            bmp.Render(drawingVisual);

            // Creates a PngBitmapEncoder and adds the BitmapSource to the frames of the encoder
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bmp));
            var blended = new MemoryStream();
            encoder.Save(blended);

            var renderImage = new BitmapImage();
            renderImage.BeginInit();
            renderImage.StreamSource = blended;
            renderImage.EndInit();
            baseImage.Source = renderImage;            
        }

        private void SaveAsTemplate_OnClick(object sender, RoutedEventArgs e)
        {
            var template = new Template();

            // get the name
            template.Name = ViewModel.TemplateName ?? "undefined";

            //// get the size
            //template.Info.Size.X = ViewModel.Cells.Where(x => x.TileEntity.ElementType != TileType.Null).Max(x => x.Column);
            //template.Info.Size.Y = ViewModel.Cells.Where(x => x.TileEntity.ElementType != TileType.Null).Max(x => x.Row);
            //if (ViewModel.Cells.Where(x => x.TileEntity.ElementType != TileType.Null).Min(x => x.Column) == 0) template.Info.Size.X++;
            //if (ViewModel.Cells.Where(x => x.TileEntity.ElementType != TileType.Null).Min(x => x.Row) == 0) template.Info.Size.Y++;

            //// get list of cells that aren't null
            //var cells = ViewModel.Cells.Where(x => x.TileEntity.ElementType != TileType.Null);
            //foreach (var cell in cells)
            //{
            //    var templateCell = new Cell();
            //    templateCell.DiseaseCount = cell.TileElementProperty.DiseaseCount;
            //    templateCell.DiseaseName = cell.TileElementProperty.DiseaseName;
            //    templateCell.Element = ElementConverter.Convert(cell.TileEntity.Name);
            //    templateCell.Mass = cell.TileElementProperty.MassGrams;
            //    templateCell.Temperature = cell.TileElementProperty.TemperatureKelvin;
            //    templateCell.location_x = cell.Column;
            //    templateCell.location_y = cell.Row;
            //    templateCell.preventFoWReveal = null;
            //    template.Cells.Add(templateCell);
            //}

            //// serialize all the things
            //var serializer = new SerializerBuilder()
            //    .WithNamingConvention(new CamelCaseNamingConvention())
            //    .Build();

            //var yaml = serializer.Serialize(template);
            //File.WriteAllText(@"c:\temp\dummy.yaml", yaml);
        }



    }
}
