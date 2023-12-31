﻿using _4Tourists.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

namespace _4Tourists.OKNO
{
    /// <summary>
    /// Логика взаимодействия для InfoCountryWindow.xaml
    /// </summary>
    public partial class InfoCountryWindow : Window
    {
        public static List<Country> countries {  get; set; }
        public static List<City> citys { get; set; }
        Country contextCountru;
        City contextCity;
        public static Country cou { get; set; }
        public static City cit { get; set; }
        public InfoCountryWindow(City city)
        {
            InitializeComponent();
            contextCity = city;
            cit = city;
            
            //City citay = new City();
            //citay.Name = CityTB.Text.Trim();
            //var ctid = CountryCB.SelectedItem as Country;
            //citay.IdCountry = ctid.Id;

           
            this.DataContext = this;
        }

        private void InitializeDataInPage()
        {
            citys = new List<City>(DBConnection.TouristsGo.City.ToList());
            countries = new List<Country>(DBConnection.TouristsGo.Country.ToList());
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            var error = string.Empty;
            var val = new ValidationContext(contextCity);
            var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();

            if (Validator.TryValidateObject(contextCity, val, results, true))
            {
                foreach (var result in results)
                {
                    error += $"{result.ErrorMessage}\n";
                }
            }
            if (!string.IsNullOrWhiteSpace(error))
            {
                MessageBox.Show(error);
                return;
            }
            if (contextCity.Id == 0)
                DBConnection.TouristsGo.City.Add(contextCity);
            DBConnection.TouristsGo.SaveChanges();
            this.Close();
        }
    }
}
