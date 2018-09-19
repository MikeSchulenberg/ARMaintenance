# AR Maintenance
This is a prototype for an AR application designed to guide users performing maintenance tasks. It was built as a team assignment for an undergraduate course in Software Development Practices.

## Authors
- James Rodgers
- Mike Schulenberg
- Jerry Lacefield
- Christopher Scheller
- Rolando Rivera
- Prativa Devkota

## Version
1.1

## Development
This prototype was built using the Unity game development platform, the Vuforia augmented reality SDK, and was programmed in C#.

## Download an APK for Android
[AR Maintenance](https://www.dropbox.com/s/j3gy3d07kt82yto/ARMaintenance.zip?dl=1)

#### ZIP File Contents
- AR Maintenance.apk
- InstallFlashlightBatteries.jpg
- readme.txt

#### Installation
Unzip the contents of ARMaintenance.zip and copy 'AR Maintenance.apk' to an Android device. Browse to the .apk on the device and tap the file to install.

## Using the Application
On an Android device, tap the 'AR Maintenance' icon to start the application.

The Home screen displays icons for 4 broad categories of maintenance jobs. Tap one of the icons to view the jobs available in each category. Tap one of the Job icons to start the augmented reality camera.

A job is represented as a sequence of instructions with corresponding AR objects. The top of the screen displays the current instruction. The right arrow advances the job to the next instruction, or requests user confirmation to complete the job if on the last instruction. The left arrow reverts the job to the previous instruction, or returns to the Home screen if on the first instruction.

The Home button allows the user to return to the Home screen at any time. The Call Expert button activates a placeholder for functionality that would enable users to videoconference with a support representative if additional assistance is required. Implementing this functionality was beyond the scope of the assignment.

Most of the Job icons activate a placeholder job with a single instruction.

'Regular Schedule Electrical Maintenance->Install Batteries Into Flashlight' is a job with 5 instructions using an Image Target available in ARMaintenance.zip.

'Regular Schedule Mechanical Maintenance->Replace Washer' is a job with 4 instructions using a specific real-world object as an Object Target. Because that object cannot be made available, the application does not demonstrate this job to its full potential.

## To View an Example Job
1. Print InstallFlashlightBatteries.jpg on a standard sheet of paper.  
   The example job uses this graphic as an Image Target.
2. On an Android device, start the AR Maintenance application.
3. On the Home screen, tap the 'Regular Schedule Mechanical Maintenance' icon.
4. On the Electrical Maintenance screen, tap the 'Install Batteries Into Flashlight' icon.
5. Once the AR mode has been activated, point the Android device's camera at the InstallFlashlightBatteries.jpg printout. Adjust the distance between the device and the printout as needed for the AR objects to appear on the device's screen.
6. Navigate through the job as described above in 'Using the Application.'

![alt text](https://github.com/MikeSchulenberg/ARMaintenance/blob/master/ARMaintenance-img.png)
