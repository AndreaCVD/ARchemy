# 🧪 ARchemy: The AR mushroom collector, and potion brewing

**ARchemy** is an immersive Augmented Reality (AR) prototype developed with **Unity** and **AR Foundation**. Transform your real-world environment into a forest where you must forage for magical ingredients.
---

## 🌟 Core Features

### 🍄 1. AR Ingredient Foraging
The app scans your physical room (floors, tables, shelves) to "grow" different species of magical mushrooms and plants. Using **AR Plane Detection**, every session is unique to your environment.

### 🖐️ 2. Click to save
Simple click on your screen to select the mushroom you wish. It will go to your inventory so you can use it latter!

### 📍 3. Spatial Persistence
The app remembers where you placed your items. Thanks to **AR Anchors**, if you leave a potion on your desk and move to the other side of the room, the object stays exactly where you left it.

### ⚗️ 4. Potion & Spell Crafting *(not available currently)*
Combine the collected ingredients to discover new recipes. 
* **Visual Feedback:** High-quality particle systems (spores, glow, smoke) that react to your movements.
* **Recipe Book:** Unlock new spells as you find rarer fungi.

---

## 🛠️ Technical Stack

* **Engine:** Unity 6000.0.50f1
* **AR Framework:** AR Foundation (ARCore for Android)
* **Input System:** Touch Screen
* **Rendering:** Universal Render Pipeline (URP) for optimized mobile performance.
* **Persistence:** AR Anchor Manager & Plane Subsystems.

---

## 🚀 Getting Started

### Prerequisites
* Android device with **ARCore** support.
* Android 11.0 (API level 30) or higher.
* Unity Hub installed.

### Installation
1.  Clone the repository:
    ```bash
    git clone https://github.com/AndreaCVD/ARchemy
    ```
2.  Open the project in **Unity**.
3.  Ensure the **Build Settings** are set to Android.
4.  Build and Run on your connected device.

---

## 📖 How to Play
1.  **Scan:** Move your phone around to detect surfaces.
2.  **Explore:** Look for mushrooms growing on your furniture.
3.  **Interact:** Touch your screen to grab ingredients.
4.  **Brew:** *(not available currently)* Bring your ingredients to the virtual cauldron to create your **Archemy** spells.

---
