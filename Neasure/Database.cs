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
                var streamPing = File.Open(pingFile, FileMode.Open);
                var fileUpload = new FirebaseStorage(_bucket, new FirebaseStorageOptions
                    {
                        AuthTokenAsyncFactory = () => Task.FromResult(auth.FirebaseToken),
                        ThrowOnCancel = true
                    }).Child("data").Child(auth.User.LocalId).Child("ping_" + auth.User.LocalId + ".txt").PutAsync(streamPing);
                await fileUpload;
                
                // Upload Speed file to Bucket
                var streamSpeed = File.Open(speedFile, FileMode.Open);
                var speedUpload = new FirebaseStorage(_bucket, new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(auth.FirebaseToken),
                    ThrowOnCancel = true
                }).Child("data").Child(auth.User.LocalId).Child("speed_" + auth.User.LocalId + ".txt").PutAsync(streamSpeed); 
                await speedUpload;

                // Upload Information to Database

                var data = new Data
                {
                    country = country,
                    city = city,
                    postalCode = postalCode,
                    ISP = isp,
                    type = type,
                    speed = speed
                };

                await firebase.Child("data").Child(auth.User.LocalId).PostAsync(data);

                // Write sent Data into File and upload to Firebase
                using (var surveyWriter = File.AppendText("@survey_" + auth.User.LocalId))
                {
                    surveyWriter.WriteLine("Data Sent to Firebase: ");
                    surveyWriter.WriteLine("Country: " + country);
                    surveyWriter.WriteLine("City: " + city);
                    surveyWriter.WriteLine("Postal Code: " + postalCode);
                    surveyWriter.WriteLine("ISP: " + isp);
                    surveyWriter.WriteLine("Internet Type: " + type);
                    surveyWriter.WriteLine("Internet Speed: " + speed);
                }

                var surveyFile = File.Open("@survey_" + auth.User.LocalId, FileMode.Open);
                var surveyUpload = new FirebaseStorage(_bucket, new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(auth.FirebaseToken),
                    ThrowOnCancel = true
                }).Child("data").Child(auth.User.LocalId).Child("speed_" + auth.User.LocalId + ".txt").PutAsync(surveyFile); 
                await surveyUpload;

                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Resources.Error_FirebaseSend + ex.Message, Resources.ErrorTitle, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return 0;
            }
        }
	}
}
