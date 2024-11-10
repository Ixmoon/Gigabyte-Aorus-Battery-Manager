using System;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using ComHeader;
using SmartManager;

namespace BatteryChargeControlUI
{
    public partial class PowerLimit : Form
    {
        private enum ChargePolicy
        {
            Standard = 0,
            Custom = 4
        }

        private static readonly string ConfigFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "user_settings.json");

        public PowerLimit()
        {
            InitializeComponent();
            LoadSettingsFromJson();
            UpdateCurrentSettings();
        }

        private void btnStandardPolicy_Click(object sender, EventArgs e)
        {
            SetChargePolicy((int)ChargePolicy.Standard);
            UpdateCurrentSettings();
            SaveSettingsToJson();
        }

        private void btnCustomPolicy_Click(object sender, EventArgs e)
        {
            SetChargePolicy((int)ChargePolicy.Custom);
            UpdateCurrentSettings();
            SaveSettingsToJson();
        }

        private void btnSetThreshold_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtChargeThreshold.Text, out int newThreshold) && newThreshold >= 0 && newThreshold <= 100)
            {
                SetChargeStop(newThreshold);
                MessageBox.Show($"充电阈值已更新为: {newThreshold}");
                UpdateCurrentSettings();
                SaveSettingsToJson();
            }
            else
            {
                MessageBox.Show("无效输入，请输入0到100之间的数字。");
            }
        }

        // 加载JSON文件中的用户设置
        public void LoadSettingsFromJson()
        {
            if (File.Exists(ConfigFilePath))
            {
                string json = File.ReadAllText(ConfigFilePath);
                var settings = JsonSerializer.Deserialize<UserSettings>(json);

                if (settings != null)
                {
                    SetChargePolicy(settings.ChargePolicy);
                    SetChargeStop(settings.ChargeStopThreshold);
                }
            }
            else
            {
                // 文件不存在时设置默认值并保存
                SetChargePolicy((int)ChargePolicy.Custom);
                SetChargeStop(85);
                SaveSettingsToJson();  // 保存默认值到文件
            }
        }

        // 将当前用户设置保存到JSON文件
        public void SaveSettingsToJson()
        {
            var settings = new UserSettings
            {
                ChargePolicy = (int)GetCurrentChargePolicy(),
                ChargeStopThreshold = (int)GetCurrentChargeStop()
            };

            string json = JsonSerializer.Serialize(settings);
            File.WriteAllText(ConfigFilePath, json);
        }

        // 获取当前充电策略
        private uint GetCurrentChargePolicy()
        {
            uint chargePolicy = 0;
            GetChargePolicy(ref chargePolicy);
            return chargePolicy;
        }

        // 获取当前充电阈值
        private uint GetCurrentChargeStop()
        {
            uint chargeStopStatus = 0;
            GetChargeStop(ref chargeStopStatus);
            return chargeStopStatus;
        }

        // 更新当前策略和阈值显示
        private void UpdateCurrentSettings()
        {
            uint chargeStopStatus = GetCurrentChargeStop();
            uint chargePolicy = GetCurrentChargePolicy();

            lblCurrentPolicy.Text = "当前充电策略: " + (chargePolicy == (uint)ChargePolicy.Custom ? "自定义" : "标准");
            lblCurrentThreshold.Text = $"当前充电阈值: {chargeStopStatus}";

            bool isCustomPolicy = (chargePolicy == (uint)ChargePolicy.Custom);
            txtChargeThreshold.Visible = isCustomPolicy;
            btnSetThreshold.Visible = isCustomPolicy;
        }

        // WMI方法实现
        private static void SetChargeStop(int iVal)
        {
            CWMI cWMI = new CWMI();
            WMI_ARGS[] args = { new WMI_ARGS { DataType = "Data", value = iVal } };
            cWMI.CallMethod("ROOT\\WMI", "GB_WMIACPI_Set", "SetChargeStop", args);
        }

        private static void SetChargePolicy(int iVal)
        {
            CWMI cWMI = new CWMI();
            WMI_ARGS[] args = { new WMI_ARGS { DataType = "Data", value = iVal } };
            cWMI.CallMethod("ROOT\\WMI", "GB_WMIACPI_Set", "SetChargePolicy", args);
        }

        private static void GetChargeStop(ref uint uiVal)
        {
            CWMI cWMI = new CWMI();
            uiVal = cWMI.GetWMIData("ROOT\\WMI", "GB_WMIACPI_Get", "GetChargeStop");
        }

        private static void GetChargePolicy(ref uint uiVal)
        {
            CWMI cWMI = new CWMI();
            uiVal = cWMI.GetWMIData("ROOT\\WMI", "GB_WMIACPI_Get", "GetChargePolicy");
        }
    }

    // 用于保存用户设置的类
    public class UserSettings
    {
        public int ChargePolicy { get; set; }
        public int ChargeStopThreshold { get; set; }
    }
}
