# PowerLimit 充电阈值控制程序 / PowerLimit Charging Threshold Control Program

## 选择语言 / Choose Language
- [English Version](./README_en.md)
- [中文版本](./README_zh.md)

## 简介 (Introduction)
PowerLimit 是一个轻量级工具，旨在帮助用户自定义笔记本的充电阈值，避免技嘉控制中心对充电设置的控制。通过此工具，用户可以手动设置充电限制，从而保护电池寿命。

PowerLimit is a lightweight tool designed to help users customize their laptop charging threshold, getting rid of the Gigabyte Control Center's control over charging settings. With this tool, users can manually set the charging limit to protect battery health.

## 特别感谢(Special Thanks)
[s-h-a-d-o-w 的 alfc 项目](https://github.com/s-h-a-d-o-w/alfc) 提供的支持与帮助。  
[The alfc project by s-h-a-d-o-w](https://github.com/s-h-a-d-o-w/alfc) for its support and assistance.

## 系统要求 (System Requirements)
- **操作系统 (OS)**: Windows

- **Operating System (OS)**: Windows

## 使用说明 (Usage Instructions)

### 配置技嘉控制中心 (Configure Gigabyte Control Center)
1. 解压技嘉控制中心的安装包。
2. 将其中的 `acpimof.dll` 文件复制到 `C:\Windows\SysWOW64` 目录下。
3. 打开注册表编辑器，在 `Computer\HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\WmiAcpi` 路径下创建一个字符串值 `MofImagePath`，并将其值设置为 `C:\Windows\SysWOW64\acpimof.dll`。
4. 完成后，重启计算机。

**To disable the Gigabyte Control Center:**
1. Extract the installer of the Gigabyte Control Center.
2. Copy the `acpimof.dll` file to `C:\Windows\SysWOW64`.
3. Open the Registry Editor, create a string value `MofImagePath` under `Computer\HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\WmiAcpi`, and set its value to `C:\Windows\SysWOW64\acpimof.dll`.
4. Reboot your computer after completing these steps.

### 启动 PowerLimit 程序 (Launch the PowerLimit Program)
打开 PowerLimit 程序后，界面将显示当前的充电策略和阈值。

**Open the PowerLimit program**, and the interface will display the current charging policy and threshold.

### 设置充电阈值 (Set Charging Threshold)
- 点击“标准”按钮以恢复默认充电阈值。
- 点击“自定义”按钮，输入所需的充电阈值（如 85%），然后点击“保存”以应用设置。

**Click the "Standard" button** to restore the default charging threshold.  
**Click the "Customize" button**, enter the desired charging threshold percentage (e.g., 85%), and click "Save" to apply the setting.

### 保存并退出 (Save and Exit)
点击“保存”后，您的设置将立即生效，并且即使退出程序，设置也会保持。

After clicking "Save," your settings will be applied immediately and will remain active even after closing the program.

## 设置 PowerLimit 自启 (Set PowerLimit to Start Automatically)
如果希望 PowerLimit 在每次启动时自动运行并保持设置生效，可以通过任务计划程序添加 `PowerLimit.exe` 为开机自启程序，并使用 `background` 参数。

**If you want PowerLimit to start automatically** every time the computer boots and keep the settings active, you can add `PowerLimit.exe` to the startup list via Task Scheduler with the `background` parameter.

### 设置流程 (Setup Process)
1. 打开“任务计划程序”，点击右侧的“创建基本任务”。
   **Open "Task Scheduler"** and click on "Create Basic Task" on the right.
2. 在“名称”中输入“PowerLimit”，点击“下一步”。
   **Enter "PowerLimit"** in the "Name" field and click "Next."
3. 选择“当计算机启动时”触发任务，点击“下一步”。
   **Choose "When the computer starts"** to trigger the task, and click "Next."
4. 选择“启动程序”并点击“下一步”。
   **Select "Start a program"** and click "Next."
5. 在“程序/脚本”框中浏览并选择 `PowerLimit.exe` 文件的路径。
   **In the "Program/script" box**, browse and select the path of `PowerLimit.exe`.
6. 在“添加参数”框中输入 `background`，以确保 PowerLimit 在后台运行。
   **In the "Add arguments" box**, enter `background` so that PowerLimit will run in the background.
7. 点击“完成”以保存任务。
   **Click "Finish"** to save the task.

这样，PowerLimit 就会在每次计算机启动时自动运行，确保充电阈值始终生效，并且不会占用屏幕空间。

This way, PowerLimit will automatically run every time your computer starts, ensuring that the charging threshold remains active without taking up screen space.

## 设置失效说明 (Settings Expiration Note)
- PowerLimit 设置将在计算机断电并且重启后失效，但通过设置自启任务，您可以确保每次开机时 PowerLimit 会重新应用设置。

**PowerLimit settings will expire** only when the computer is powered off and rebooted. However, by setting up the auto-start task, you can ensure that the settings are reapplied each time the computer boots.

## 注意事项 (Notes)
- 请确保操作系统和驱动程序版本支持此工具的设置更改。
- 更改注册表存在一定风险，建议在操作前备份注册表。

**Ensure that your OS and drivers support the settings change.**  
Modifying the Registry carries some risk, so it's recommended to back up the Registry before making changes.

