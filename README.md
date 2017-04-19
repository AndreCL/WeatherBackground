# WeatherBackground
Set 2-day forecast from DMI (Danmarks Meteorologiske Institut) as background for windows machine

It doesn't include automatic scheduler, as that seems a bit intrusive.

ATM you need to manually setup a task in task scheduler. 

Returns 0 when successful

Returns -1 when WebException (no connection to network)

Returns -2 for oher webclient exceptions

## Setup

Open the config file, set your Zip Code (only danish zip codes supported).

## Todo:

- Implement other countries

- Implement auto detection of zip code
