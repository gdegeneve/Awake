# Awake

Awake is a tool, that resides in system tray and prevents the computer from entering the idle state, thus successfully preventing it from automatically entering sleep/hibernation/the lock screen.

[[https://github.com/gdegeneve/Awake/blob/master/img/awake_forever.png|alt=awake]]

### Purpose

Awake was designed for those who cannot change the timings in their power settings, because of some enforced policy.
If you have full administrative access to your PC or no exchange policy or other group policy interfering with your power settings / screen lock timings you do not need awake.

### How does it work?

Awake does not change any system settings, therefore it does not require administrative privileges. It merely calls Windows API functions to reset the idle timers. This is basically what video players (at least the better ones) do to avoid screen savers and power settings interfering with video playback.

### Latest Feature

Since last release a new menu was added, that allows you to define actions, when the lock screen (WIN+L) is (manually) entered.

[[https://github.com/gdegeneve/Awake/blob/master/img/lock_screen_action.png|alt=lockscreen]]

### Installation

Download the latest release put it somewhere, start it and make your selections. 

## Acknowledgments

Icons by: <a href="http://www.fasticon.com">FastIcon.com</a>