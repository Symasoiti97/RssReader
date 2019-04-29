using DataBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using WpfAppRss.Models;

namespace WpfAppRss.ViewModels
{
    #region
    //class BindableSelectedItemBehavior : Behavior<TreeView>
    //{

    //    private OperationDataBase _operationDataBase;

    //    public BindableSelectedItemBehavior()
    //    {
    //        _activeContent = ActiveContent.GetInstance();
    //        _operationDataBase = OperationDataBase.GetInstance();
    //    }

    //    #region SelectedItem Property

    //    public object SelectedItem
    //    {
    //        get { return (object)GetValue(SelectedItemProperty); }
    //        set { SetValue(SelectedItemProperty, value); }
    //    }

    //    public static readonly DependencyProperty SelectedItemProperty =
    //        DependencyProperty.Register("SelectedItem", typeof(object), typeof(BindableSelectedItemBehavior), new UIPropertyMetadata(null, OnSelectedItemChanged));

    //    private static void OnSelectedItemChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    //    {
    //        var item = e.NewValue as TreeViewItem;
    //        if (item != null)
    //        {
    //            item.SetValue(TreeViewItem.IsSelectedProperty, true);
    //        }
    //    }

    //    #endregion

    //    protected override void OnAttached()
    //    {
    //        base.OnAttached();

    //        this.AssociatedObject.SelectedItemChanged += OnTreeViewSelectedItemChanged;
    //    }

    //    protected override void OnDetaching()
    //    {
    //        base.OnDetaching();

    //        if (this.AssociatedObject != null)
    //        {
    //            this.AssociatedObject.SelectedItemChanged -= OnTreeViewSelectedItemChanged;
    //        }
    //    }

    //    private void OnTreeViewSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
    //    {
    //        this.SelectedItem = e.NewValue;

    //        if (SelectedItem is RssChanelTitle)
    //        {
    //            RssChanelTitle selectTitle = (RssChanelTitle)SelectedItem as RssChanelTitle;
    //            _activeContent.RssChanelTitle = selectTitle;

    //            ICollection<string> collectionName = _operationDataBase.FindRssItemTitels(_activeContent.RssChanelTitle.RssChanelTitleName);
    //            ObservableCollection<RssItemTitle> rssItemTitles = new ObservableCollection<RssItemTitle>();

    //            foreach (var i in collectionName)
    //            {
    //                rssItemTitles.Add(new RssItemTitle { RssItemTitleName = i });
    //            }

    //            _activeContent.RssItemTitles = rssItemTitles;

    //        }
    //        else if (SelectedItem is Catalog)
    //        {
    //            Catalog selectCategory = (Catalog)SelectedItem as Catalog;
    //            string item = selectCategory.CatalogName;
    //            _activeContent.Catalog = item;
    //            MessageBox.Show(item);
    //        }
    //    }
    //}
    #endregion
}
