Xamarin Shared Preference Abstraction
==================

Abstraction around shared settings in Android Xamarin

## Disclamer:

This will only save primitives ie. strings, ints, etc.

if you wish to save complex objects, you should look at doing some sqlite.


## How to use:

New up a settingskey class

````c#

var sk = new SharedSettingsAbstraction.Setting.SettingsKey<string>("KeyName", "PreferenceName", "DefaultValuehere");
           var setting = sk.getSetting(Context con)
		   var setsetting = sk.SetSetting(Context con, "New Value!")

````
