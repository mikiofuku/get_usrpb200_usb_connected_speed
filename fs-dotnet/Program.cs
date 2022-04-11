using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibUsbDotNet;
using LibUsbDotNet.WinUsb;

namespace fs_dotnet
{
	class Program
	{
		static void Main(string[] args)
		{			

			// 認識している全デバイスから指定したVendorId, ProductIdで抽出する。

			var dev = UsbDevice.AllDevices.Where(d => 
			{
				return d.Vid == 0x2500 && d.Pid == 0x21;
			});

			foreach(WinUsbRegistry d in dev)
			{
				var wd = (WinUsbDevice)d.Device;
				Console.WriteLine(wd.Info.Descriptor);
				Console.WriteLine("{0:x}", wd.Info.Descriptor.BcdUsb);
			}

			Console.ReadLine();
		}
	}
}
