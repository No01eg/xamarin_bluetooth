﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace BlueTooth_test
{
	public partial class App : Application
	{
		public App ()
		{
			try
			{
				InitializeComponent();

				MainPage = new BlueTooth_test.MainPage();
			}catch(Exception e)
			{
				int x = 1;
			}
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
