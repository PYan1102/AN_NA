using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AN_NAN_Hospital
{
    internal class Settings
    {
        internal static string InputPath { get => Properties.Settings.Default.InputPath; set => Properties.Settings.Default.InputPath = value; }
        internal static string OutputPath { get => Properties.Settings.Default.OutputPath; set => Properties.Settings.Default.OutputPath = value; }

        internal static void Save()
        {
            Properties.Settings.Default.Save();
        }
    }
}
