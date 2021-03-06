using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SharedSettingsAbstraction.Extensions;

namespace SharedSettingsAbstraction
{
        /// <summary>
        /// Key Value Pair
        /// </summary>
        /// <typeparam name="T">Value Type</typeparam>
    public class SettingsKey<T>
        {
        public string key { get; private set; }
        private T value; 
        private string _preferenceName;
        private T _defaultValue;
           
        /// <summary>
        /// Abstraction around shared preferences
        /// </summary>
        /// <param name="_key">Name the key</param>
        /// <param name="preferenceName">Name the preference (should be consistant accross all settings)</param>
        /// <param name="defaultValue">Give a default value</param>
        public SettingsKey(string _key, string preferenceName, T defaultValue)
            {
                key = _key;
                _preferenceName = preferenceName;
                _defaultValue = defaultValue;
                
            }
          
        /// <summary>
        /// Gets the setting
        /// </summary>
        /// <param name="con">context</param>
        /// <returns></returns>
        public T GetSetting(Context con )
            {
                var shared = con.GetSharedPreferences(_preferenceName, FileCreationMode.WorldReadable);
                value = (T)shared.All.Where(x => x.Key == key).FirstOrDefault().Value;
                    if (value == null) SetSetting(con, _defaultValue);           

                return value;
            }
        /// <summary>
        /// Set the setting with a new setting
        /// </summary>
        /// <param name="con"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public SettingsKey<T> SetSetting(Context con, T val)
        {
            var shared = con.GetSharedPreferences(_preferenceName, FileCreationMode.WorldWriteable);
            var edit = shared.Edit();
            edit.SaveObject(key, val);
            edit.Commit();
            value = val;
            return this;
        }
    }
}