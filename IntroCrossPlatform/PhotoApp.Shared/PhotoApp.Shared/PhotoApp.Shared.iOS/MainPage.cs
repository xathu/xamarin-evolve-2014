﻿using System;
using Xamarin.Media;
using Xamarin.Forms;

namespace PhotoApp.Shared
{
    public partial class MainPage
    {
		async partial void OnTakePhoto()
		{
			var picker = new MediaPicker ();
			if (!picker.IsCameraAvailable)
				await DisplayAlert("Error", "No Camera Available!", "OK");
			else 
			{
				try 
				{
					MediaFile file = await picker.TakePhotoAsync (new StoreCameraMediaOptions {
						Name = "test.jpg",
						Directory = "photos",
						DefaultCamera = CameraDevice.Rear,
					});

					Image image = new Image() { Source = new FileImageSource { File = file.Path } };
					this.Content = image;
				} 
				catch (OperationCanceledException) 
				{
					Console.WriteLine ("Canceled");
				}
			}
		}
    }
}

