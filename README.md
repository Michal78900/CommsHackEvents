# How to configure

## Step 0:
This plugin requires [CommsHack](https://github.com/VirtualBrightPlayz/CommsHack) plugin by Virtual to work. Install it before using the CommsHackEvents plugin. It's recommended to setup up the CommsHack config as well.

Both plugins require the files to be converted from `.mp3` to `.raw` format. To do this you need to use a converter such as **ffmpeg** that you can [download from here.](https://www.gyan.dev/ffmpeg/builds/ffmpeg-release-full.7z) You will only need the executable and you can get rid of the other files.


## Step 1:
After running your server with the plugin installed, the `CommsHackAudio` folder will be generated in the `EXILED/Configs` folder. This is the folder where you're going to put your audio files.

### Here are 2 methods of converting `.mp3` file to `.raw` using `ffmpeg.exe`
*Keep in mind that you only need to convert the file once, you don't need to convert it again.

***Method 1: Convert Using CommsHack***
In the base CommsHack plugin set your `f_f_m_p_e_g:` path to `C:/Users/User/AppData/Roaming/EXILED/Configs/CommsHackAudio/ffpmeg.exe`. (or wherever the CommsHackAudio folder is located)
You can also just leave the path the same and manually move the converted files to the `CommsHackAudio` folder.

Now every time the plugin runs a `.mp3` file (ie you run `audio` command from CommsHack) it will automatically convert it to a `.raw` file and use that one.


***Method 2: Converting the File Manually:***
With this method you manually run the `ffmpeg.exe` via Windows CMD / Linux Terminal. To do this go to the directory where the executable is located and type the following, replacing `example.mp3` with your file name:
```
ffmpeg.exe -i "example.mp3" -f f32le -ar 48000 -ac 1 example.mp3.raw
```
Using this method you don't need manually use the CommsHacks plugin and run it in-game.

## Step 2:
Put your files in a `CommsHackAudio` folder if they aren't there already. The file extension should  `.mp3` or `.raw` (.mp3.raw).

The `raw` files will not run the `ffmpeg.exe`
The `.mp3` will run the executable every time, so as said earlier once the file has been converted you can switch to `.raw` file to prevent running it every time and improve efficiency and latency between when the event happens and the audio plays.

## Step 3:
Now choose the event that you would like to play the sound from and then input the file name and volume.
```
List of currently supported events:
- Round started
- NTF respawn
- CI respawn
- Warhead started
```
Example:
```yml
  # Called when the NTF are spawned:
  ntf_entrance:
    file_name: example.mp3.raw
    volume: 0.3
 ```
This will play the `example.mp3.raw` located in your `CommsHackAudio` folder when NTF are respawned.

## Step 4:
Now listen carefully, because this is the most important step:
**TEST THE MUSIC / SOUND BEFORE PUTTING IT ON A PUBLIC SERVER!!! IF IT IS TOO LOUD NORTHWOOD WILL YEET YOUR SERVER FROM THE SERVER LIST. YOU HAVE BEEN WARNED!**
*Note: Does not apply if your server is not on a Verified Server List but it is a general rule of thumb not to earrape players on your server.*

## Step 5:
Congratulations! You have configured the plugin and it should be ready to go.
