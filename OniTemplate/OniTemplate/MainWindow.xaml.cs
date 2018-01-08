using System;
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
                TreeViewItem treeViewItem = FindAncestor<TreeViewItem>((DependencyObject)e.OriginalSource);

                // Find the data behind the ListViewItem
                var data = treeViewItem.DataContext as PaletteItem;

                // Initialize the drag & drop operation
                DataObject dragData = new DataObject(typeof(PaletteItem), data);
                DragDrop.DoDragDrop(treeViewItem, dragData, DragDropEffects.Move);
            }
        }

        private static T FindAncestor<T>(DependencyObject current)
            where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }

        private void MainGrid_OnDragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(PaletteItem)) ||
                sender == e.Source)
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void MainGrid_OnDrop(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(typeof(PaletteItem)))
            {
                PaletteItem data = e.Data.GetData(typeof(PaletteItem)) as PaletteItem;
                ScrollViewer viewer = sender as ScrollViewer;
                var mainGrid = viewer.FindName("MainGrid") as BorderGrid;
                
                var hit = VisualTreeHelper.HitTest(viewer, e.GetPosition(this));
                if (hit == null) { return; }

                var gridPosition = mainGrid.GetColumnRow(e.GetPosition(viewer));

                var cell = mainGrid.Children.Cast<UIElement>().First(g =>
                    Grid.GetRow(g) == gridPosition.X && Grid.GetColumn(g) == gridPosition.Y) as Image;
                var current = cell.DataContext as TemplateCell;
                current.PaletteItem = data;
                cell.Source = new BitmapImage(new Uri("pack://application:,,,/OniTemplate;component/Images/" + data.ImageUri));
                cell.UpdateLayout();
            }
        }


    }
}
