using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using Firebase.Storage;
using Neasure.Properties;

namespace Neasure {
	public class Database
    {
        private string _bucket = "neasure-5ed3e.appspot.com";

        public async Task<int> Send(string country, string city, string postalCode, string isp, string type, string speed, string pingFile, string speedFile)
		{
            try
            {
                // Authenticate Anonymously with Firebase
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyAjc7Gk9LydAEKG--oCeeuNM0YG4XGihDg"));
                var auth = await authProvider.SignInAnonymouslyAsync();
                var firebase = new FirebaseClient("https://neasure-5ed3e.firebaseio.com/", new FirebaseOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(auth.FirebaseToken)
                });

                // Upload Ping file to Bucket
                UploadToBucket(pingFile, "ping_", auth);

                // Upload Speed file to Bucket
                UploadToBucket(speedFile, "speed_", auth);

                // Upload Information to Database

                var data = new Data
                {
                    country = country,
                    city = city,
                    postalCode = postalCode,
                    ISP = isp,
                    type = type,
                    speed = speed,
                    #if DEBUG
                    debug = true
                    #else
                    debug = false
                    #endif
                };

                await firebase.Child("data").Child(auth.User.LocalId).PostAsync(data);

                // Write sent Data into File and upload to Firebase
                using (var surveyWriter = File.AppendText("survey_" + auth.User.LocalId + ".txt"))
                {
                    surveyWriter.WriteLine("Data Sent to Firebase: ");
                    surveyWriter.WriteLine("Country: " + country);
                    surveyWriter.WriteLine("City: " + city);
                    surveyWriter.WriteLine("Postal Code: " + postalCode);
                    surveyWriter.WriteLine("ISP: " + isp);
                    surveyWriter.WriteLine("Internet Type: " + type);
                    surveyWriter.WriteLine("Internet Speed: " + speed);
                    #if DEBUG   
                    surveyWriter.WriteLine("Warning: Result Created by Debug Build");
                    #endif
                    
                }

                // Upload Survey to Bucket
                UploadToBucket("survey_" + auth.User.LocalId + ".txt", "survey_", auth);

                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Resources.Error_FirebaseSend + ex.Message, Resources.ErrorTitle, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return 0;
            }
        }

        private async void UploadToBucket(string file, string destination, FirebaseAuth auth)
        {
            var _file = File.Open(file, FileMode.Open);
            var upload = new FirebaseStorage(_bucket, new FirebaseStorageOptions
            {
                AuthTokenAsyncFactory = () => Task.FromResult(auth.FirebaseToken),
                ThrowOnCancel = true
            }).Child("data").Child(auth.User.LocalId).Child(destination + auth.User.LocalId + ".txt").PutAsync(_file);
            await upload;
        }
	}
}
