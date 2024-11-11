using System;
using ComHeader;
using SmartManager;

namespace BatteryChargeControl
{
    // Enum to define charge policies
    enum ChargePolicy
    {
        Standard = 0, // Standard charge policy
        Custom = 4    // Custom charge policy
    }

    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                uint chargeStopStatus = 0; // Variable to store charge stop threshold
                uint chargePolicy = 0;     // Variable to store charge policy

                GetChargeStop(ref chargeStopStatus);   // Retrieve current charge stop threshold
                GetChargePolicy(ref chargePolicy);     // Retrieve current charge policy

                DisplayCurrentSettings(chargeStopStatus, (ChargePolicy)chargePolicy);

                Console.WriteLine("Please enter charge policy (standard or custom), or type 'exit' to quit, or any other key to skip:");
                string input = Console.ReadLine().ToLower();

                if (input == "exit") break;

                switch (input)
                {
                    case "standard":
                        SetChargePolicy((int)ChargePolicy.Standard); // Set policy to Standard
                        break;
                    case "custom":
                        SetChargePolicy((int)ChargePolicy.Custom);   // Set policy to Custom
                        break;
                    default:
                        Console.WriteLine("Skipping charge policy setting...");
                        break;
                }

                Console.WriteLine("Please enter custom charge threshold (0-100), or type 'exit' to quit:");
                input = Console.ReadLine().ToLower();

                if (input == "exit") break;

                if (int.TryParse(input, out int newThreshold) && newThreshold >= 0 && newThreshold <= 100)
                {
                    SetChargeStop(newThreshold); // Set new charge stop threshold
                    Console.WriteLine($"Charge threshold updated to: {newThreshold}");
                }
                else
                {
                    Console.WriteLine("Invalid input, please enter a number between 0 and 100.");
                }

                GetChargeStop(ref chargeStopStatus);   // Refresh charge stop threshold
                GetChargePolicy(ref chargePolicy);     // Refresh charge policy

                DisplayCurrentSettings(chargeStopStatus, (ChargePolicy)chargePolicy);

                Console.WriteLine("Press any key to continue, or 'exit' to quit...");
                if (Console.ReadLine().ToLower() == "exit") break;
            }
        }

        // Display current charge settings
        private static void DisplayCurrentSettings(uint chargeStop, ChargePolicy chargePolicy)
        {
            Console.WriteLine($"Current charge threshold: {chargeStop}");
            Console.WriteLine("Current charge policy: " + (chargePolicy == ChargePolicy.Custom ? "Custom" : "Standard"));
        }

        // Set charge stop threshold
        private static void SetChargeStop(int iVal)
        {
            CWMI cWMI = new CWMI();
            WMI_ARGS[] args = { new WMI_ARGS { DataType = "Data", value = iVal } };
            cWMI.CallMethod("ROOT\\WMI", "GB_WMIACPI_Set", "SetChargeStop", args);
        }

        // Set charge policy
        private static void SetChargePolicy(int iVal)
        {
            CWMI cWMI = new CWMI();
            WMI_ARGS[] args = { new WMI_ARGS { DataType = "Data", value = iVal } };
            cWMI.CallMethod("ROOT\\WMI", "GB_WMIACPI_Set", "SetChargePolicy", args);
        }

        // Get current charge stop threshold
        private static void GetChargeStop(ref uint uiVal)
        {
            CWMI cWMI = new CWMI();
            uiVal = cWMI.GetWMIData("ROOT\\WMI", "GB_WMIACPI_Get", "GetChargeStop");
        }

        // Get current charge policy
        private static void GetChargePolicy(ref uint uiVal)
        {
            CWMI cWMI = new CWMI();
            uiVal = cWMI.GetWMIData("ROOT\\WMI", "GB_WMIACPI_Get", "GetChargePolicy");
        }
    }
}
