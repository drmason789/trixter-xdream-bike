# trixter-xdream-bike
An API and diagnostic utility for interaction with a [Trixter X-Dream V1 Exercise Bike](https://www.amazon.co.uk/Trixter-X-Dream-Interactive-Exercise-Bike/dp/B008VOQXDA) for use on modern PCs, not the original Trixter ones.

Also, a [discussion forum](https://github.com/xdream-biking/trixter-xdream-bike/discussions) and [wiki](https://github.com/xdream-biking/trixter-xdream-bike/wiki) for the X-Dream Mountain Biking software supplied with that bike.
It is not necessary to use the diagnostic utility from this repository to utilise the advice in the discussions or wiki.

---

The "Trixter" company or companies that made this bike and the X-Dream mountain biking simulator are now dissolved.  
This repository and the associated discussions / wikis are not associated with these companies or any that acquired them.

---

The source code in this repository is intended to provide developers with an API to interact with this bike, and some diagnostic tools to demonstrate its use, and to provide a better alternative to the equivalent utilities provided with the original X-Dream software.

Help with the X-Dream mountain biking simulation software itself can be found in the Discussions.

# Trixer.XDream.API

A .NET Standard 2.0 client API which provides classes to:
- read status from and send resistance to a Trixter V1 X-Dream Bike.
- emulate a Trixter V1 X-Dream Bike.

# Trixter.XDream.Diagnostics

A replacement for the console and UI test applications that were supplied with the X-Dream software.

So far the improvements over the originals are:
- console and GUI options in a single application
- detects the COM port the bike is on
- detects backpedalling and shows the crank RPM in the backwards direction
- calculates flywheel and crank cumulative revolutions.
- estimates of the power being applied to the flywheel (not accounting for resistance, until #101 is released) momentarily and cumulatively
- is maintainable

The default mode of the utility has a graphic user interface that shows the state of the various controls and a slider bar to set flywheel resistance.
Each brake applies 50% flywheel resistance.

![image](https://user-images.githubusercontent.com/29954900/162640166-e0d6912e-a6b0-4f4a-92c7-48d8626969c6.png)

The utility also has a console mode to provide a similar experience to the original.
If the utility is invoked with the --console command line option, or through the program menu short cut for the console mode, it shows a console application.

![image](https://user-images.githubusercontent.com/29954900/148430888-c37726aa-3c2b-47d3-87fc-34d3f5ecd4e9.png)








