using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WindowsTouchScreen
{
	public static class Keyboard
	{
		static int WM_SYSCOMMAND = 0x0112;
		static int SC_CLOSE = 0xF060;

		[DllImport("user32.dll")]
		static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		[DllImport("user32.dll")]
		static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

		public static void Open()
		{
			Process.Start(@"C:\Program Files\Common Files\microsoft shared\ink\TabTip.exe");
		}

		public static void Close()
		{
			var hWnd = FindWindow("IPTip_Main_Window", "");
			if (hWnd != null)
			{
				SendMessage(hWnd, WM_SYSCOMMAND, SC_CLOSE, 0);
			}
		}
	}
}
