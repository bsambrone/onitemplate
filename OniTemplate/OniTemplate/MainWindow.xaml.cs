﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public EditorViewModel EditorViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            EditorViewModel = new EditorViewModel();
            PaletteTree.ItemsSource = EditorViewModel.PaletteCollections;
            
            // wire up the template cells
            EditorViewModel.ResetCells(MainGrid);

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
                //TreeViewItem treeViewItem = FindAncestor<TreeViewItem>((DependencyObject)e.OriginalSource);

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

                var cell = mainGrid.Children.Cast<UIElement>().First(g =>
                    Grid.GetRow(g) == gridPosition.Y && Grid.GetColumn(g) == gridPosition.X) as Image;
                cell.DataContext = new PaletteItem() { ImageUri = data.ImageUri, Name = data.Name };
                Binding imageBinding = new Binding("PaletteItem.ImageUri");
                imageBinding.Source = cell;
                imageBinding.Mode = BindingMode.TwoWay;
                imageBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                imageBinding.Converter = new ImagePathConverter();
                BindingOperations.SetBinding(cell, Image.SourceProperty, imageBinding);
                cell.Source = new BitmapImage(new Uri("pack://application:,,,/OniTemplate;component/Images/" + data.ImageUri));
            }
        }


    }
}
