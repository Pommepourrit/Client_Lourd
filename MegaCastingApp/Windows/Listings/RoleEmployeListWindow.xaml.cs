﻿using MegaCastingApp.ViewModel.Listings;
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

namespace MegaCastingApp.Windows.Listings
{
    /// <summary>
    /// Logique d'interaction pour RoleEmployeListWindow.xaml
    /// </summary>
    public partial class RoleEmployeListWindow : UserControl
    {
        public RoleEmployeListWindow()
        {
            InitializeComponent();
            DataContext = new RoleEmployeListViewModel();
        }
    }
}
