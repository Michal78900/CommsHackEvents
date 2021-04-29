# How to configure

## Step 0:
This plugin requires [CommsHack](https://github.com/VirtualBrightPlayz/CommsHack) plugin by Virtual to work. Install it first before using the CommsHackEvents plugin. It's recommended to setup up the CommsHack config too.

Both of plugins require from you to convert `.mp3` files to `.raw` format. To do this you need to use some kind of converter for example **ffmpeg** that you can [download from here.](https://www.gyan.dev/ffmpeg/builds/ffmpeg-release-full.7z) You only need the executable and you can get rid of the other files.


## Step 1:
In your `EXILED/Configs` folder the `CommsHackAudio` directory will be generated, when the plugin is first run. This is the folder where you're gonna to put your audio files.

### Now I will show the 2 methods of converting `.mp3` file to `.raw` using `ffmpeg.exe`
*Keep in mind that you only need to convert the file once, then you don't need to convert it once again so you can use one with `.raw` extension in a config.*

***Method 1: Using the `ffmpeg.exe` in-game:***
In base CommsHack plugin you need to give a full path to `ffmpeg.exe` in `f_f_m_p_e_g` config option. For example: `f_f_m_p_e_g: C:\Users\User\AppData\Roaming\EXILED\Configs\CommsHackAudio\ffmpeg.exe`.
**The executable must be in the CommsHackAudio folder.**

Now every time when the plugin tries to run a `.mp3` file it will automatically convert it to `.raw` file and use that one.

***Method 2: Converting the file yourself:***
You need to run the `ffmpeg.exe` via Windows CMD / Linux Terminal. You open one of these in a directory where the executable is located and type this, replacing `name` with the name of the file:
```
ffmpeg.exe -i "name.mp3" -f f32le -ar 48000 -ac 1 name.mp3.raw
```
Via this method you don't need to use the executable in game and you don't need to state path to it in base CommsHack.

## Step 2:
Put your files in a `CommsHackAudio` folder if they aren't there already. The file extension should  `.mp3` or `.raw` (.mp3.raw).

The `raw` files will not run the `ffmpeg.exe`
The `.mp3` will run the executable every time, so as I said earlier once the file have been converted you can switch to `.raw` to prevent that.

## Step 3:
Now choose the event in which you want to play the sound and give a file name and a sound volume.
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
    file_name: epsilon-old.mp3
    volume: 0.3
 ```
This will cause to play `epsilon-old.mp3` located in your `directory_path` when the NTF are respawned.
Since the file has `.mp3` extension it will be converted to `.raw` format if you are using the first method of file converstion.

## Step 4:
Now listen carefully, because this is the most important step:
**TEST THE MUSIC / SOUND BEFORE PUTTING IT ON A PUBLIC SERVER, BECAUSE IF IT IS TOO LOUD, NORTHWOOD WILL YEET YOUR SERVER OUT OF THE SERVER LIST. YOU HAVE BEEN WARNED.**
*Note: Does not apply if your server is not on a Verified Server List.*

## Step 5:
Congratulations, you've configured the plugin and it's ready to go.