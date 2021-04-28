# How to configure

## Step 0:
This plugin requires [CommsHack](https://github.com/VirtualBrightPlayz/CommsHack) plugin by Virtual to work. Install it and test it if it works before moving to the next step.


## Step 1:
Select your directory where your files will be stored.
For example, if it is a folder named "FunnyFolder" on your desktop the path will be: `C:\Users\User\Desktop\FunnyFolder`
Write a path here: `directory_path: C:\Users\User\Desktop\FunnyFolder`

## Step 2:
Put your files in a selected folder. The file extension should  `.mp3`.

## Step 3:
Now choose the event in which you want to play the sound and give a filename and a sound volume.
For example:
```yml
  # Called when the NTF are spawned:
  ntf_entrance:
    file_name: epsilon-old.mp3
    volume: 0.3
 ```
This will cause to play `epsilon-old.mp3` located in your `directory_path` when the NTF are respawned.

## Step 4:
Now listen carefully, because this is the most important step:
**TEST THE MUSIC / SOUND BEFORE PUTTING IT ON A PUBLIC SERVER, BECAUSE IF IT IS TOO LOUD, NORTHWOOD WILL YEET YOUR SERVER OUT OF THE SERVER LIST. YOU HAVE BEEN WARNED.**
*Note: Does not apply if your server is not on a Verified Server List.*

## Step 5:
Congratulations, you've configured the plugin. If it does not work make sure you provided the valid path and a file name.
