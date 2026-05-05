#  Smart Room – Digital Twin

## 📌 Project Overview
This project creates a **digital twin of a smart room**, enabling interactive control and visualization of various room components.  
The simulation is built using **Unity** and scripted in **C#**, demonstrating smart environment automation concepts.

---

##  Features

-  **Door Control with PIN**  
  Secure access system where doors can be locked/unlocked using a PIN code.

-  **Lighting System**  
  Toggle room lights on/off interactively.

-  **Fan Simulation**  
  Multiple fan controllers (`SpinFan1.cs` to `SpinFan4.cs`) simulate realistic fan behavior.

-  **LED Indicators**  
  Manage LED states within the room.

-  **First-Person Controller**  
  Navigate the virtual room using FPS controls.

---

## 📂 Repository Structure

- `DoorWithPIN.cs` → Door locking mechanism with PIN verification  
- `LightController.cs` → Lighting system control  
- `FanController.cs` → Fan operation control  
- `LEDController.cs` → LED indicator management  
- `FPSController.cs` → First-person navigation  
- `SpinFan1.cs – SpinFan4.cs` → Individual fan simulation scripts  
- `Unity Screenshot 1.png – Unity Screenshot 4.png` → Project visuals  

---

##  Important Note

> This repository contains **only the C# scripts and screenshots**.

-  Unity assets (scenes, models, prefabs, materials) are **NOT included**
- To run the project:
  1. Create a new Unity project  
  2. Import these scripts  
  3. Attach them to appropriate GameObjects  
  4. Recreate the scene setup  

---

##  Prerequisites

- Unity (recommended latest version)
- (Optional) Arduino IDE  
- Basic understanding of ESP8266 / Arduino (for hardware integration concepts)

---

##  Screenshot

###  Smart Room Simulation
##  Screenshots

![](Unity%20Screenshot%201.png)
![](Unity%20Screenshot%202.png)
![](Unity%20Screenshot%203.png)
![](Unity%20Screenshot%204.png)


##  How It Works

- User navigates the room using **FPSController**
- Interacts with objects:
  - Enter PIN → Unlock door  
  - Toggle switches → Control lights, LEDs, fans  
- Fan scripts simulate **rotation and dynamic behavior**

---

##  Use Cases

- Digital Twin Simulation
- Smart Home Automation Prototype
- Unity + IoT Learning Project
- Academic Demonstrations

