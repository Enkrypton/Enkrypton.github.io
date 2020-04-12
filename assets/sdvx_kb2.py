"""
Version 2.0 Changelog:
	- More user friendly comments by Superoswald
	- Simplified process to configure the script
	- Removed useless code
"""


"""
SDVX Keyboard Knobs FreePIE Script
Configures a vJoy controller with the analog x and y axes controlled by keyboard input
by Enkrypton and Superoswald

Instructions:
1. Configure vJoy device 1 with the following settings:
   - all axes unchecked except for x and y
   - 0 buttons
   - 0 POVs
   - enable effects unchecked
2. Edit the constants for the key bindings and interval (i.e. sensitivity) to your liking.
3. Run the script.
"""

if starting:
    # key bindings
    # refer to https://github.com/AndersMalmgren/FreePIE/wiki/Reference for key constants
    VOLL_LEFT = Key.Q
    VOLL_RIGHT = Key.W
    VOLR_LEFT = Key.LeftBracket
    VOLR_RIGHT = Key.RightBracket

    # amount to move each knob by when key is pressed
    INTERVAL = 200

    system.setThreadTiming(TimingTypes.ThreadYield)

if keyboard.getKeyDown(VOLL_LEFT):
    vJoy[0].x -= INTERVAL
if keyboard.getKeyDown(VOLL_RIGHT):
    vJoy[0].x += INTERVAL
if keyboard.getKeyDown(VOLR_LEFT):
    vJoy[0].y -= INTERVAL
if keyboard.getKeyDown(VOLR_RIGHT):
    vJoy[0].y += INTERVAL