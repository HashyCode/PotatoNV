﻿using Potato.Fastboot;
using PotatoNV_next.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace PotatoNV_next
{
    public partial class MainWindow : Window
    {
        Core core = new Core();

        public MainWindow()
        {
            Icon = MediaConverter.ImageSourceFromBitmap(Properties.Resources.Fire.ToBitmap());
            InitializeComponent();

            nvFrom.OnFormSubmit += NvFrom_OnFormSubmit;
            core.RunWorkerCompleted += Core_RunWorkerCompleted;

            SetupLog();
        }

        private void NvFrom_OnFormSubmit(Controls.NVForm.FormEventArgs formEventArgs)
        {
            SetupLog();
            core.StartProcess(formEventArgs);
        }

        public void SetupLog()
        {
            logBox.Clear();
            Log.Info($"PotatoNV v{Controls.AboutTab.GetVersion()}");
            Log.Info("User manual: https://kutt.it/pnv-"
                + (CultureInfo.InstalledUICulture.TwoLetterISOLanguageName == "ru"
                    ? "ru"
                    : "en"));
        }

        private void Core_RunWorkerCompleted()
        {
            nvFrom.IsEnabled = true;
        }
    }
}
