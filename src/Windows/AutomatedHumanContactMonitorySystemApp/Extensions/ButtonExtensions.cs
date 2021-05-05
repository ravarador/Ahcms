using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AutomatedHumanContactMonitorySystemApp.Extensions
{
    public static class ButtonExtensions
    {
        public static void SetActiveButton(this Button button)
        {
            button.ForeColor = Color.FromArgb(224, 224, 224);
            button.BackColor = Color.FromArgb(44, 30, 214);
        }

        public static void UnsetActiveButton(this Button button)
        {
            button.ForeColor = Color.FromArgb(224, 224, 224);
            button.BackColor = Color.FromArgb(85, 67, 255);
        }
    }
}
