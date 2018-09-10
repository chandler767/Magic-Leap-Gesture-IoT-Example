#include <ESP8266WiFi.h>
#define PubNub_BASE_CLIENT WiFiClient
#include <PubNub.h>
 
const static char ssid[] = "pubnub-visitor";
const static char pass[] = "data-stream!"; 

int controlpin = 14; // The pin the relay is attached to.

int mode = 0;
bool on = false;

void setup() {
    pinMode(controlpin, OUTPUT);

    Serial.begin(9600);
    WiFi.begin(ssid, pass);
    if(WiFi.waitForConnectResult() == WL_CONNECTED){
      PubNub.begin("pub-c-931b4ee3-e758-4c5d-b6b9-1133c03e4f20", "sub-c-83a10382-b06a-11e8-96e7-b288138ed50a");
    } else {
      Serial.println("Couldn't get a wifi connection");
      while(1) delay(100);
    }
}
 
void loop() {
    PubNub_BASE_CLIENT *client;
    
    Serial.println("waiting for a message (subscribe)");
    PubSubClient *pclient = PubNub.subscribe("control"); // Subscribe to the control channel.
    if (!pclient) {
        Serial.println("subscription error");
        delay(1000);
        return;
    }
    String message;
    while (pclient->wait_for_data()) {
        char c = pclient->read();
        //Serial.print(c);
        message = message+String(c); // Append to string.
    }
    pclient->stop();

    if(message.indexOf("on") > 0) {
        on = true;
        Serial.print("on");
    } else if (message.indexOf("off") > 0) {
        on = false;
    } else if (message.indexOf("changel") > 0) {
      if (mode > 0) {
        mode=mode-1;
      } else if (mode == 0) {
        mode=5;
      }
    } else if (message.indexOf("changer") > 0) {
      if (mode < 5) {
        mode=mode+1;
      } else if (mode == 5) {
        mode=0;
      }
    }

    if (on == true) { // Turn on.
      /*if (mode == 0) { 
        analogWrite(controlpin, 255);
      } else if (mode == 1) { 
        analogWrite(controlpin, 212);
      } else if (mode == 2) {
        analogWrite(controlpin, 169);
      } else if (mode == 3) {
        analogWrite(controlpin, 127);
      } else if (mode == 4) {
        analogWrite(controlpin, 84);
      } else if (mode == 5) {
        analogWrite(controlpin, 40);
      }*/
      digitalWrite(controlpin, HIGH);
    } else { // Turn off.
      digitalWrite(controlpin, LOW);
    }
    Serial.print(message);
    Serial.println();
    delay(5);
}

