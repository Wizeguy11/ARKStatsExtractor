﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARKBreedingStats
{
    public partial class StatDisplay : UserControl
    {
        private bool percent = false;
        public StatDisplay()
        {
            InitializeComponent();
        }

        public string Title
        {
            set { this.labelName.Text = value; }
        }

        public void setNumbers(int levelWild, int levelDom, double valueBreeding, double valueDom)
        {
            // visualization of wild level

            float barLengthPercentage = (float)(levelWild * Math.Max(1, (100.0f / Properties.Settings.Default.BarMaximum)));

            this.panelBar.Width = (int)(148 * barLengthPercentage / 100.0f);
                int r = 511 - (int)(barLengthPercentage * 255) / 33;
                int g = (int)(barLengthPercentage * 255) / 33;
                if (r < 0) { r = 0; }
                if (g < 0) { g = 0; }
                if (r > 255) { r = 255; }
                if (g > 255) { g = 255; }
                panelBar.BackColor = Color.FromArgb(r, g, 0);
            labelWildLevel.Text = levelWild.ToString();
            labelLevelDom.Text = levelDom.ToString();
            labelBreedingValue.Text = (percent ? Math.Round(100 * valueBreeding, 1).ToString() + " %" : valueBreeding.ToString());
            labelDomValue.Text = (percent ? Math.Round(100 * valueDom, 1).ToString() + " %" : valueDom.ToString());
        }

        public bool Percent { set { percent = value; } }

    }
}