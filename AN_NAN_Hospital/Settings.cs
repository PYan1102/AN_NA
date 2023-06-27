using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnCube_Switch
{
    internal class Settings
    {
        internal static string InputPath { get => Properties.Settings.Default.InputPath; set => Properties.Settings.Default.InputPath = value; }
        internal static string OutputPath { get => Properties.Settings.Default.OutputPath; set => Properties.Settings.Default.OutputPath = value; }

        internal static string BackupPath { get => Properties.Settings.Default.BackupPath; set => Properties.Settings.Default.BackupPath = value; }

        internal static void Save()
        {
            Properties.Settings.Default.Save();
        }
    }
}
