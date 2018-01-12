using System;
using System.IO;
using Microsoft.Win32;

namespace OniTemplate.Helpers
{
    public class FileHelper
    {
        public string GetOniTemplateDirectory()
        {
            string oniLocation = string.Empty;

            try
            {
                using (RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
                {
                    using (RegistryKey registryKey = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 457140"))
                    {
                        if (registryKey != null)
                        {
                            oniLocation = (string)registryKey.GetValue("InstallLocation");
                        }
                    }
                }
            }
            catch
            {
                // registry is a fickle beast, swallow it.
            }

            if (oniLocation == string.Empty)
            {
                // try 32-bit!
                try
                {
                    using (RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32))
                    {
                        using (RegistryKey registryKey = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 457140"))
                        {
                            if (registryKey != null)
                            {
                                oniLocation = (string)registryKey.GetValue("InstallLocation");
                            }
                        }
                    }
                }
                catch
                {
                    // registry is a fickle beast, swallow it.
                }
            }

            if (oniLocation == string.Empty)
            {
                return Environment.CurrentDirectory;
            }

            var templatePath = Path.Combine(oniLocation, "OxygenNotIncluded_Data\\StreamingAssets\\templates");
            return templatePath;
        }
    }
}
