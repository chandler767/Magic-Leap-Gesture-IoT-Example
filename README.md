# Magic Leap Gesture IoT Example

### Gesture controlled smart light powered by [PubNub](https://www.pubnub.com/?devrel_gh=Magic-Leap-Gesture-IoT-Example).

Imagine a world where you walk in a smart home, look at a smart light in the room, make a gesture with your hands, and the light turns off or on. Swipe with a hand to change the channel on your TV. Glance at a thermostat and speak your preferred temperature aloud. This isn't the future. This is all possible now with the Magic Leap One and PubNub.

<a href="https://www.pubnub.com/blog/?devrel_gh=Magic-Leap-Gesture-IoT-Example">
    <img src="https://i.imgur.com/b8WDyY1.gif" width="300" align="right" />
</a>

This project demonstrates how to control an RGB LED with an Arduino using Magic Leap Gestures and PubNub. Learn more about how to build your own smart home with Magic Leap and PubNub from the tutorial (Coming Soon).

<a href="https://www.pubnub.com/blog/?devrel_gh=Magic-Leap-Gesture-IoT-Example">
    <img alt="PubNub Blog" src="https://i.imgur.com/aJ927CO.png" width=260 height=98/>
</a>

## Why PubNub and Magic Leap?

Developers have been building multiplayer games and other multi-user experiences with PubNub for years, and PubNub definitely sees AR as next on the horizon. PubNub is a natural fit in the AR world and their technology can power the realtime interaction between AR headsets or physical objects in the same location, or even across the Earth.

For example, when a Magic Leap user throws a ball in the virtual world, that motion is synchronized in realtime across every other connected user. Or if a user uses a hand gesture to turn on a light, PubNub is sending the message to that light to turn on. Multi-user experiences, or the relationship between the AR headset and the physical world around us, is where PubNub is required and excels.

## Getting Started
 
- You’ll first need to sign up for a [PubNub account](https://dashboard.pubnub.com/signup/?devrel_gh=Magic-Leap-Gesture-IoT-Example). Once you sign up, you can get your unique PubNub keys from the [PubNub Developer Portal](https://admin.pubnub.com/?devrel_gh=Magic-Leap-Gesture-IoT-Example).

<a href="https://dashboard.pubnub.com/signup?devrel_gh=agic-Leap-Gesture-IoT-Example">
    <img alt="PubNub Signup" src="https://i.imgur.com/og5DDjf.png" width=260 height=97/>
</a>

This project consists of three components:
    - The Control app built in Unity for Magic Leap.
    - The LED Arduino sketch for controlling a RGB LED from the Control app.
    - The PowerStrip Arduino sketch for controlling a relay connected to a power strip. 

## 
