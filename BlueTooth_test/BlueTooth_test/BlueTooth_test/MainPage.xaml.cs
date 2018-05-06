using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BlueTooth_test
{
	public partial class MainPage : ContentPage
	{
		Bluetooth_Connection connection;
		public delegate void voidMeth(string message);

		public MainPage()
		{
			try
			{
				InitializeComponent();
				connection = DependencyService.Get<Bluetooth_Connection>();
			}
			catch(Exception e)
			{
				status.Text = "Something failed: " + e.Message;
			}
		}

		void SetUp(object sender, EventArgs e)
		{
			try
			{
				connection.Initialize(SetStatus);
				
			}
			catch (Exception ex)
			{
				status.Text = "Something failed: " + ex.Message;
			}
		}

		public void SetStatus(string message)
		{
			status.Text = message;
		}

		void On_Click(object sender, EventArgs e)
		{
			try
			{
				connection.SendToPi("1");
			}
			catch (Exception ex)
			{
				status.Text = "Something failed: " + ex.Message;
			}
		}

		void Off_Click(object sender, EventArgs e)
		{
			try
			{
				connection.SendToPi("0");
			}
			catch (Exception ex)
			{
				status.Text = "Something failed: " + ex.Message;
			}
		}
	}
}
