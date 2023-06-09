﻿using ConstructionStoreArzuTorg.Employee;
using Syncfusion.Windows.Shared;
using System;
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
using System.Windows.Shapes;

namespace ConstructionStoreArzuTorg.Add
{
    /// <summary>
    /// Логика взаимодействия для AddProductView.xaml
    /// </summary>
    public partial class AddProductView : Window
    {
        public AddProductView()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (ConstructionStoreEntities db = new ConstructionStoreEntities())
            {
                var firstlist = db.Категория.ToList();
                foreach (var item in firstlist)
                    CategoryComboBox.Items.Add(item.Название);

                var secontlist = db.РазмерыТовара.ToList();
                foreach (var item in secontlist)
                    DimensionsComboBox.Items.Add(item.Размер);

                var thristlist = db.Единицы_измерения.ToList();
                foreach (var item in thristlist)
                    UnitComboBox.Items.Add(item.Название);

                var forelist = db.Сезонность.Distinct().ToList();
                foreach (var item in forelist)
                    NameSeasonComboBox.Items.Add(item.Название_сезона);
            }
        }
        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {

            foreach (var control in grid.Children)
            {
                if (control is TextBox)
                {
                    var textbox = (TextBox)control;
                    if (textbox.Text == string.Empty)
                    {
                        MessageBox.Show("Ошибка");
                        return;
                    }
                    
                }
                if (control is ComboBox)
                {
                    var comboBox = (ComboBox)control;
                    if (comboBox.SelectedValue == null || comboBox.SelectedValue.ToString() == string.Empty)
                    {
                        MessageBox.Show("Ошибка");
                        return;
                    }

                }
            }
            using (ConstructionStoreEntities db = new ConstructionStoreEntities())
            {
                Товар product = new Товар();
                int disco = int.Parse(DiscountComboBox.Text);
                var category = db.Категория.Where(x => x.Название == CategoryComboBox.Text).FirstOrDefault();
                var dimensions = db.РазмерыТовара.Where(x => x.Размер == DimensionsComboBox.Text).FirstOrDefault();
                var unit = db.Единицы_измерения.Where(x => x.Название == UnitComboBox.Text).FirstOrDefault();
                var discount = db.Сезонность.Where(x => x.Процент == disco).FirstOrDefault();
                product.ID_Категории = category.ID_Категории;
                product.ID_Размеров = dimensions.ID_Размеров;
                product.ID_Единицы_измерения = unit.ID_Измерений;
                product.Сезонность = discount.ID;
                product.Название = NameTextBox.Text;
                product.Стоимость = int.Parse(PriceTextBox.Text);

                db.Товар.Add(product);
                db.SaveChanges();
            }
            new ProductListView().Show();
            Close();
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            new ProductListView().Show();
            Close();
        }

        private void NameSeasonComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (NameSeasonComboBox.SelectedItem == null)
                return;
            using (ConstructionStoreEntities db = new ConstructionStoreEntities())
            {
                var selectedItem = NameSeasonComboBox.SelectedItem.ToString();

                var needSeasones = db.Сезонность.ToList();

                var season = new List<int>();

                var needSeasons = db.Сезонность.Where(x => x.Название_сезона == selectedItem).ToList().Distinct().ToList();

                foreach (var i in needSeasons)
                {
                    var needSeason = needSeasones.Where(x => x.ID == i.ID).FirstOrDefault();
                    season.Add(needSeason.Процент);
                }


                DiscountComboBox.ItemsSource = season.Distinct();

            }
        }
    }
}
