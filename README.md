# Magic Leap Gesture IoT Example

### Gesture controlled smart light powered by [PubNub](https://www.pubnub.com/?devrel_gh=Magic-Leap-Gesture-IoT-Example).

Imagine a world where you walk in a smart home, look at a smart light in the room, make a gesture with your hands, and the light turns off or on. Swipe with a hand to change the channel on your TV. Glance at a thermostat and speak your preferred temperature aloud. This isn't the future. This is all possible now with the Magic Leap One and PubNub.

<a href="https://www.pubnub.com/blog/?devrel_gh=Magic-Leap-Gesture-IoT-Example">
    <img src="https://i.imgur.com/b8WDyY1.gif" width="300" align="right" />
</a>

This project demonstrates how to control an RGB LED or a power strip with an Arduino using Magic Leap Gestures and PubNub. Learn more about how to build your own smart home with Magic Leap and PubNub from the [tutorial](https://www.pubnub.com/blog/magic-leap-controlling-internet-connected-devices-lights-doors-with-hand-gestures/).

<a href="https://www.pubnub.com/blog/?devrel_gh=Magic-Leap-Gesture-IoT-Example">
    <img alt="PubNub Blog" src="https://i.imgur.com/aJ927CO.png" width=260 height=98/>
</a>

## Why PubNub and Magic Leap?

Developers have been building multiplayer games and other multi-user experiences with PubNub for years, and PubNub definitely sees AR as next on the horizon. PubNub is a natural fit in the AR world and their technology can power the realtime interaction between AR headsets or physical objects in the same location, or even across the Earth.

For example, when a Magic Leap user throws a ball in the virtual world, that motion is synchronized in realtime across every other connected user. Or if a user uses a hand gesture to turn on a light, PubNub is sending the message to that light to turn on. Multi-user experiences, or the relationship between the AR headset and the physical world around us, is where PubNub is required and excels.

## Getting Started
 
- You’ll first need to sign up for a [PubNub account](https://dashboard.pubnub.com/signup/?devrel_gh=Magic-Leap-Gesture-IoT-Example). Once you sign up, you can get your unique PubNub keys from the [PubNub Developer Portal](https://admin.pubnub.com/?devrel_gh=Magic-Leap-Gesture-IoT-Example).

<a href="https://dashboard.pubnub.com/signup?devrel_gh=magic-Leap-Gesture-IoT-Example">
    <img alt="PubNub Signup" src="https://i.imgur.com/og5DDjf.png" width=260 height=97/>
</a>

This project consists of three components:

<img src="https://pubnub.com/blog/wp-content/uploads/2018/10/Magic-Leap-LED-IoT.gif" alt="Magic Leap LED IoT Toggle" width="300" align="right" />
<img src="https://pubnub.com/blog/wp-content/uploads/2018/10/Magic-Leap-LED-IoT-change.gif" alt="Magic Leap LED IoT Change Mode" width="300" align="right" />

- The Control app built in Unity for Magic Leap.
    
- The LED Arduino sketch for controlling a RGB LED from the Control app.

- The PowerStrip Arduino sketch for controlling a relay connected to a power strip.
    
Read the [Getting Started with Magic Leap and Unity tutorial](https://www.pubnub.com/blog/getting-started-with-magic-leap-and-unity?devrel_gh=magic-Leap-Gesture-IoT-Example) to familiarize yourself with Unity Video Game Engine development for Magic Leap and setup your development environment.

The tutorial *[Controlling Internet-connected Devices with Magic Leap Hand Gestures](https://www.pubnub.com/blog/magic-leap-controlling-internet-connected-devices-lights-doors-with-hand-gestures/)* details how to run this project and correctly setup your development environment for Magic Leap and Arduino development with PubNub.

## What's Next?

Use this project as a seed to build your own Magic Leap IoT application. A few ideas:

- Use a IR blaster to control your TV or game console.
- Use weather sensors and stream the information to a HUD on the Magic Leap device.
- [Use the PowerStrip Sketch](https://github.com/chandler767/Magic-Leap-Device-Control/tree/master/PowerStrip) to control high voltage devices like a coffee maker or a fan (always be careful with high voltage electronics).

### Have suggestions or questions about this project? Reach out at devrel@pubnub.com.
