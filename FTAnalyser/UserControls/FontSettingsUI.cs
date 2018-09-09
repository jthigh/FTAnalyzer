﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace FTAnalyzer.UserControls
{
    public partial class FontSettingsUI : UserControl, IOptions
    {
        private Font selectedFont;
        private int fontNumber;

        public FontSettingsUI()
        {
            InitializeComponent();
            fontNumber = Properties.FontSettings.Default.FontNumber;
            tbFontScale.Value = fontNumber;
            SetSelectedFont(fontNumber);
        }

        #region IOptions Members

        public void Save()
        {
            Properties.FontSettings.Default.SelectedFont = selectedFont;
            Properties.FontSettings.Default.FontNumber = tbFontScale.Value;
            OnFontChanged();
        }

        public void Cancel()
        {
            //NOOP;
        }

        public bool HasValidationErrors()
        {
            return CheckChildrenValidation(this);
        }

        private bool CheckChildrenValidation(Control control)
        {
            bool invalid = false;

            for (int i = 0; i < control.Controls.Count; i++)
            {
                if (!String.IsNullOrEmpty(errorProvider1.GetError(control.Controls[i])))
                {
                    invalid = true;
                    break;
                }
                else
                {
                    invalid = CheckChildrenValidation(control.Controls[i]);
                    if (invalid)
                    {
                        break;
                    }
                }
            }

            return invalid;
        }

        public string DisplayName
        {
            get { return "Font Settings"; }
        }

        public string TreePosition
        {
            get { return DisplayName; }
        }

        public Image MenuIcon
        {
            get { return null; }
        }

        #endregion

        public static event EventHandler GlobalFontChanged;
        protected static void OnFontChanged()
        {
            //Update Fonts on all forms
        }

        private void SetSelectedFont(int value)
        {
            switch (value)
            {
                case 1:
                    selectedFont = new Font(lbSample.Font.Name, 8.25f);
                    break;
                case 2:
                    selectedFont = new Font(lbSample.Font.Name, 10f);
                    break;
                case 3:
                    selectedFont = new Font(lbSample.Font.Name, 12f);
                    break;
                case 4:
                    selectedFont = new Font(lbSample.Font.Name, 14f);
                    break;
                default:
                    selectedFont = new Font(lbSample.Font.Name, 8.25f);
                    break;
            }
        }

        private void tbFontScale_Scroll(object sender, EventArgs e)
        {
            SetSelectedFont(tbFontScale.Value);
            lbSample.Font = selectedFont;
        }
    }
}
