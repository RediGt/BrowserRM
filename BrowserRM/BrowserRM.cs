﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace BrowserRM
{
    public partial class Browser : Form
    {
        public Browser()
        {
            InitializeComponent();
            InitializeBrowser();
        }

        private ChromiumWebBrowser browser;

        public void InitializeBrowser()
        {
            CefSettings settings = new CefSettings();
            // Initialize cef with the provided settings
            Cef.Initialize(settings);
            // Create a browser component
            browser = new ChromiumWebBrowser("https://www.meteo.lv/");
            // Add it to the form and fill it to the form window.
            this.Controls.Add(browser);
            browser.Dock = DockStyle.Fill;
            browser.AddressChanged += Browser_AddressChanged;
        }

        private void toolStripButtonGo_Click(object sender, EventArgs e)
        {
            try
            {
                 browser.Load(toolStripAddressBar.Text);
            }
            catch
            {

            }
        }

        private void toolStripButtonBack_Click(object sender, EventArgs e)
        {
            browser.Back();
            
        }

        private void toolStripButtonForward_Click(object sender, EventArgs e)
        {
            browser.Forward();
        }

        private void Browser_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            var selectedBrowser = (ChromiumWebBrowser)sender;
            this.Invoke(new MethodInvoker(() =>
            {
                toolStripAddressBar.Text = e.Address;
            }));
        }
    }
}