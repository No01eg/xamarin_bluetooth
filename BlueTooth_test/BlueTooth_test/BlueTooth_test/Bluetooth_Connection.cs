using System;
using System.Collections.Generic;
using System.Text;
using static BlueTooth_test.MainPage;

namespace BlueTooth_test
{
    public interface Bluetooth_Connection
	{
		void Initialize(voidMeth method);
		void SendToPi(string value);
	}
}
