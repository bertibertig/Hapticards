## Assistive Technologies Winter Semester 2023/24 Group Project 08

This is the repository for the group project number 8: Exploring Charts and Diagrams (2D) with vibration.
We created an AR phone app that helps people with vision empairments or hearing empairment, play with poker cards.
The needed cards can be downloaded in the repocitory, however exisiting poker cards can also be used.

## Members
 - Tobias Hinum k11905157
 - Benjamin Luchici k11917268
 - Corina Pötscher k11904026
 - Sascha Bertleff k11908754

## How it works
Every time a card from the deck that can be downloaded in VuforiaData\Images\Cards is recognized the phone tells the user it's value with Text-To-Speech and vibrates its value. If the card gets removed while the vibration or TTS is still active the TTS stops, and the vibration waits for 1 second and then vibrates four times to signal the user the card was removed.


## How does the vibration work
Each time a card is recognized the vibration is started. It first vibrates the card suits with a 0.5 second interval. The values being:\
1 - Clubs\
2 - Diamonds\
3 - Hearts\
4 - Spades\
5 - Joker\
\
After that is done there is a two second break and then the card value is vibrated. With Jokers having no value.

## How does Text-To-Speak work.
Text to speak uses the integrated Google TTS features found in the package com.google.android.tts which can be downlaoded here [https://play.google.com/store/apps/details?id=com.google.android.tts](https://play.google.com/store/apps/details?id=com.google.android.tts).
It uses the locale settings of the Unity Player which in return uses the ones of Android. Currently English and German are supported.

## Libraries and Frameworks used
Vuforia - [https://developer.vuforia.com](https://developer.vuforia.com)
Unity 2022.3.17f1 - [https://unity.com/products/unity-engine](https://unity.com/products/unity-engine)
Android Native Dialogs and Functions Plugin (TTS) - [https://assetstore.unity.com/packages/tools/gui/android-native-dialogs-and-functions-plugin-106497](https://assetstore.unity.com/packages/tools/gui/android-native-dialogs-and-functions-plugin-106497
)