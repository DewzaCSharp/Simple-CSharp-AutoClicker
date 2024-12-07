using System.Data;
using System.Reflection;
using System.Runtime.InteropServices;


[DllImport("user32.dll")]
static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, IntPtr dwExtraInfo);

[DllImport("user32.dll")]
static extern short GetAsyncKeyState(int vKey); //hotkey

const uint LEFTDOWN = 0x02;
const uint LEFTUP = 0x04;
const int HOTKEY = 0x70;

bool enableClicker = false;
int clickInterval = 1; //miliseconds

Console.WriteLine("Press F1 to Enable or Disable The AutoClicker");

while (true)
{
    Console.Title = "AutoClicker | Press F1 to Enable/disable | current clickInterval: 5 miliseconds";
    if (GetAsyncKeyState(HOTKEY)<0)
    {
        enableClicker = !enableClicker;
        if (enableClicker)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Title = "AutoClicker ON";
            Console.WriteLine("[Enabled] Autoclicker");
        }
        else if (!enableClicker)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Title = "AutoClicker OFF";
            Console.WriteLine("[Disabled] Autoclicker");
        }
        Thread.Sleep(300);
    }
    if (enableClicker)
    {
        MouseClick();
    }
    Thread.Sleep(clickInterval);
}
void MouseClick()
{
    mouse_event(LEFTDOWN,0,0,0,IntPtr.Zero);

    mouse_event(LEFTUP,0,0,0, IntPtr.Zero);
}