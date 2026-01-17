# thunder-hud
Project goal is get access to extended public (localhosted) in-game War Thunder data, that is not available via standart game hud.

## Current state
Gonna achieve proof of concept.

Reading game data kinda works.\
For start I work with aircrafts only. Support of other types of vehicles highly likely would be much later.\
Platform for development and tests: Windows. Propably the tool can work on Mac OS and Linux, but I do not test it for now.

Next steps:
- add some simple useful calculations (actual fuel time left, critical speed, etc)
- set up pipeline for better refresh rate of data
- handle possible problems on localhost requests (http errors; 'valid' field is false)
- render data on game screen (full screen window mode for start - gonna be easier to implement plus it's my actual game mode)
- store static data (game datamines) about vehicles
- automate converting game datamine (integration with some github project looks like the way)

## Thanks
- https://mesofthorny.github.io/WTRTI/ - obviosuly original idea of the extended hud. Check theese guys if you need ready to use product, it's awesome. Free version looks out of support for now - new planes often have problems with some indicators =(
- https://github.com/lucasvmx/WarThunder-localhost-documentation - the very good start understanding game data. I don't know where to start if not this repository.