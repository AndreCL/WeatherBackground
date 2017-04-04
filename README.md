# WeatherBackground
Set 2-day forecast from DMI (Danmarks Meteorologiske Institut) as background for windows machine

It doesn't include automatic scheduler, as that seems a bit intrusive.

ATM you need to manually setup a task in task scheduler. 

Returns 0 when successful

Returns -1 when no connection to DMI (for example no internet connection)

TODO:

Which city not hardcoded (maybe use location or locale)
Implement task scheduler
