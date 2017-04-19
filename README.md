# WeatherBackground
Set 2-day forecast from DMI (Danmarks Meteorologiske Institut) as background for windows machine

It doesn't include automatic scheduler, as that seems a bit intrusive.

ATM you need to manually setup a task in task scheduler. 

Returns 0 when successful

Returns -1 when WebException (no connection to network)

Returns -2 for oher webclient exceptions

## Setup (simple)

- Download built executable.zip

- Unzip

- Open the config file 

- Set your country code

- If country code is DK, set ZipCode to danish zipcode. Else write the GeonamesID of the city.

- Run exe file

## Setup (advanced)

- You can use the source code to make your own build

- You can set it to automatically update using task scheduler

## Todo:

- Implement auto detection of zip code
