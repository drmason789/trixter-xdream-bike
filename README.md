# trixter-xdream-bike
An API and set of utilities for interaction with a [Trixter X-Dream V1 Exercise Bike](https://www.amazon.co.uk/Trixter-X-Dream-Interactive-Exercise-Bike/dp/B008VOQXDA).

---

The "Trixter" company or companies that made this bike and the X-Dream mountain biking simulator are now dissolved.  
This repository and the associated discussions / wikis are not associated with these companies or any that acquired them.

---

The source code in this repository is intended to provide developers with an API to interact with this bike, and some diagnostic tools to demonstrate its use, and to eventually become better alternatives to the equivalent utilities provided with the original X-Dream software.

Help with the X-Dream mountain biking simulation software itself can be found in the Discussions.

# Trixer.XDream.API

A .NET Standard 2.0 client API which provides classes to:
- read status from and send resistance to a Trixter V1 X-Dream Bike.
- emulate a Trixter V1 X-Dream Bike.

# Trixter.XDream.Console

A replacement for the test application supplied with the X-Dream software.

So far the improvements over the original are:
- it detects the COM port the bike is on
- it detects backpedalling and shows the crank RPM in the backwards direction
- it calculates flywheel and crank cumulative revolutions.
- it is maintainable

![image](https://user-images.githubusercontent.com/29954900/146271192-187b01aa-af90-4301-acab-8ea95e26bbd9.png)


# Trixter.XDream.UI

A graphic user interface showing the state of the various controls and a slider bar to set flywheel resistance.
Each brake applies 50% flywheel resistance.

In addition to reading and displaying values from the bike, it also calculates flywheel and crank cumulative revolutions.

![image](https://user-images.githubusercontent.com/29954900/147611052-6f039786-b207-4956-9828-129ab35dabfb.png)

