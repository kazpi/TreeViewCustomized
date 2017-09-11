using System;
using System.Collections;
using System.Collections.Generic;
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

namespace TreeViewCustomized
{
    public class TreeViewControl : Control
    {
        static TreeViewControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TreeViewControl), new FrameworkPropertyMetadata(typeof(TreeViewControl)));
        }



        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemsSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(TreeViewControl), new PropertyMetadata(null));



        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemTemplate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemTemplateProperty =
            DependencyProperty.Register("ItemTemplate", typeof(DataTemplate), typeof(TreeViewControl), new PropertyMetadata(null));



        public TreeViewControl()
        {

        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            var ctrl = GetTemplateChild("treebase") as TreeView;
            if (ctrl != null)
            {
                _treeView = ctrl;
            }
        }

        private TreeView _treeView;
    }
}
