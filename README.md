PowerLimit 充电阈值控制程序
简介 (Introduction)
PowerLimit 是一个简单的工具，旨在帮助用户自定义笔记本的充电阈值，避免被技嘉控制中心控制充电阈值。通过此工具，用户可以手动设置充电限制，保护电池寿命。

PowerLimit is a lightweight tool designed to help users customize their laptop charging threshold, getting rid of the Gigabyte Control Center's control over charging settings. With this tool, users can manually set the charging limit to protect battery health.

系统要求 (System Requirements)
Windows 操作系统 (Windows OS)
使用说明 (Usage Instructions)

配置技嘉控制中心 (Configure Gigabyte Control Center)
需要将技嘉控制中心的安装包解压，将其中的 acpimof.dll 文件复制到 C:\Windows\SysWOW64 目录下。
然后在注册表 Computer\HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\WmiAcpi 路径下创建一个字符串值 MofImagePath，并将其值设置为 C:\Windows\SysWOW64\acpimof.dll。
完成后重启计算机。

If you're interested in getting rid of Gigabyte Control Center, you'll need to extract the Gigabyte Control Center installer, copy the acpimof.dll file to C:\Windows\SysWOW64, and create a string value in the Registry at Computer\HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\WmiAcpi called MofImagePath with the value C:\Windows\SysWOW64\acpimof.dll. Then, reboot your computer.

启动 PowerLimit 程序 (Launch the PowerLimit Program)
打开 PowerLimit 程序，界面会显示当前的充电策略和当前充电阈值。

设置充电阈值 (Set Charging Threshold)

点击“标准”按钮可将充电阈值设置为默认值。
点击“自定义”按钮，手动输入所需的充电阈值百分比（如 85），然后点击“保存”以应用该设置。
Open the PowerLimit program, and the interface will display the current charging policy and threshold.

Click the "Standard" button to set the default charging threshold.
Click the "Customize" button, enter the desired charging threshold percentage (e.g., 85), and click "Save" to apply the setting.
保存并退出 (Save and Exit)
点击“保存”后，您的设置将会应用。程序退出后设置依然生效。

After clicking "Save," your settings will be applied, and they will remain active even after closing the program.

注意事项 (Notes)
请确保操作系统和驱动程序版本支持此工具的设置更改。

更改注册表有一定风险，建议备份注册表以防出现问题。

Ensure that your OS and drivers support the settings change. Modifying the Registry carries some risk, so it's recommended to back up the Registry to avoid issues.
