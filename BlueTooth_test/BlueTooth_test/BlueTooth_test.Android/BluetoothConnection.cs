using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Bluetooth;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BlueTooth_test.Droid;
using Java.Util;
using Xamarin.Forms;
using static BlueTooth_test.MainPage;

[assembly: Dependency(typeof(BluetoothConnection))]
namespace BlueTooth_test.Droid
{
	class BluetoothConnection : Bluetooth_Connection
	{
		BluetoothAdapter adapter;
		BluetoothDevice rpi;
		BluetoothSocket socket;


		public BluetoothConnection()
		{
			//Initialize();
		}

		async public void Initialize(voidMeth set_status)
		{
			try
			{
				adapter = BluetoothAdapter.DefaultAdapter;
				if (adapter == null)
					throw new Exception("Adapter not found.");
				if (!adapter.IsEnabled)
					throw new Exception("Bluetooth not enabled.");

				rpi = adapter.BondedDevices.FirstOrDefault(x => x.Name == "raspberrypi");
				if (rpi == null)
					throw new Exception("raspberrypi couldn't be found.");

				//ParcelUuid[] uuids = null;
				//if (rpi.FetchUuidsWithSdp())
				//{
				//	uuids = rpi.GetUuids();
				//}

				//if((uuids != null) && (uuids.Length > 0))
				//{
				//	foreach(var uuid in uuids)
				//	{
				//		try
				//		{
				//			socket = rpi.CreateRfcommSocketToServiceRecord(uuid.Uuid);
				//			await socket.ConnectAsync();
				//			set_status("Connection complete");
				//			return;
				//		}
				//		catch(Exception ex)
				//		{
				//			int y = 0;
				//		}
				//	}
				//}
				socket = rpi.CreateRfcommSocketToServiceRecord(UUID.FromString("94f39d29-7d6d-437d-973b-fba39e49d4ee"));
				await socket.ConnectAsync();
				set_status("Should have worked.");
			}
			catch (Exception e)
			{
				set_status("Connection failed:" + e.Message);
			}
		}

		async public void SendToPi(string value)
		{
			byte[] buffer = Encoding.ASCII.GetBytes(value);
			await socket.OutputStream.WriteAsync(buffer, 0, buffer.Length);
		}
	}
}