# PowerLimit Charging Threshold Control Program

## Choose Language
- [English Version](./README_en.md)
- [中文版本](./README_zh.md)

## Introduction
PowerLimit is a lightweight tool designed to help users customize their laptop charging threshold, getting rid of the Gigabyte Control Center's control over charging settings. With this tool, users can manually set the charging limit to protect battery health.

## Special Thanks
[The alfc project by s-h-a-d-o-w](https://github.com/s-h-a-d-o-w/alfc) for its support and assistance.

## Compatibility

| Model        | System        | 
|--------------|---------------|
| Aorus 15P XD | Windows 10/11 |

As far as I know, the Control Center can no longer be opened in the Windows 11 24H2 version. That's why I developed this tool. However, there may be some issues with this tool on other versions of the system as well. Please submit a PR or issue if you can confirm something that's not yet in the table. I have also provided a command-line version in the code for reference. If there are compatibility issues on other models or systems, please feel free to submit a PR.

## System Requirements
- **Operating System (OS)**: Windows

## Usage Instructions

### Configure Gigabyte Control Center
1. Extract the installer of the Gigabyte Control Center.
2. Copy the `acpimof.dll` file to `C:\Windows\SysWOW64`.
3. Open the Registry Editor, create a string value `MofImagePath` under `Computer\HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\WmiAcpi`, and set its value to `C:\Windows\SysWOW64\acpimof.dll`.
4. Reboot your computer after completing these steps.

### Launch the PowerLimit Program
Open the PowerLimit program, and the interface will display the current charging policy and threshold.

### Set Charging Threshold
- Click the "Standard" button to restore the default charging threshold.
- Click the "Customize" button, enter the desired charging threshold percentage (e.g., 85%), and click "Save" to apply the setting.

### Save and Exit
After clicking "Save," your settings will be applied immediately and will remain active even after closing the program.

## Set PowerLimit to Start Automatically
If you want PowerLimit to start automatically every time the computer boots and keep the settings active, you can add `PowerLimit.exe` to the startup list via Task Scheduler with the `background` parameter.

### Setup Process
1. Open "Task Scheduler" and click on "Create Basic Task" on the right.
2. Enter "PowerLimit" in the "Name" field and click "Next."
3. Choose "When the computer starts" to trigger the task, and click "Next."
4. Select "Start a program" and click "Next."
5. In the "Program/script" box, browse and select the path of `PowerLimit.exe`.
6. In the "Add arguments" box, enter `background` so that PowerLimit will run in the background.
7. Click "Finish" to save the task.

This way, PowerLimit will automatically run every time your computer starts, ensuring that the charging threshold remains active without taking up screen space.

## Settings Expiration Note
- PowerLimit settings will expire only when the computer is powered off and rebooted. However, by setting up the auto-start task, you can ensure that the settings are reapplied each time the computer boots.

## Notes
- Ensure that your OS and drivers support the settings change.
- Modifying the Registry carries some risk, so it's recommended to back up the Registry before making changes.
