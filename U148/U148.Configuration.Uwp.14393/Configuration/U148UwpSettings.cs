using System;
using Newtonsoft.Json;
using SoftwareKobo.Configuration;
using U148.Models;
using Windows.Storage;

namespace U148.Configuration
{
    public class U148UwpSettings : AppSettingsBase, IU148UwpSettings
    {
        public SimulateDevice SimulateDevice
        {
            get
            {
                return Get(nameof(SimulateDevice), ApplicationDataLocality.Local, () => SimulateDevice.Android);
            }
            set
            {
                Set(nameof(SimulateDevice), value, ApplicationDataLocality.Local);
                RaisePropertyChanged();
            }
        }

        public ThemeMode ThemeMode
        {
            get
            {
                return Get(nameof(ThemeMode), ApplicationDataLocality.Local, () => ThemeMode.Day);
            }
            set
            {
                Set(nameof(ThemeMode), value, ApplicationDataLocality.Local);
                RaisePropertyChanged();
            }
        }

        public UserInfo UserInfo
        {
            get
            {
                var json = Get<string>(nameof(UserInfo), ApplicationDataLocality.Local, () => null);
                try
                {
                    return JsonConvert.DeserializeObject<UserInfo>(json);
                }
                catch (Exception)
                {
                    return null;
                }
            }
            set
            {
                Set(nameof(UserInfo), JsonConvert.SerializeObject(value), ApplicationDataLocality.Local);
                RaisePropertyChanged();
            }
        }
    }
}