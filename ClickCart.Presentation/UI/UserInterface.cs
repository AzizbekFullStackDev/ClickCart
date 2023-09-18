using NAudio.Wave;

namespace ClickCart.Presentation.UI
{
    public class UserInterface
    {
        public async Task RunCodeAsync()
        {

            #region 

            string audioFilePath2 = "D:\\Net new Source Codes\\ClickCart\\ClickCart.Presentation\\UI\\sword.m4a"; // Replace with the actual path to your audio file

            // Check if the audio file exists
            if (!File.Exists(audioFilePath2))
            {
                Console.WriteLine("Audio file not found.");
                return;
            }

            using (var audioFile = new AudioFileReader(audioFilePath2))
            using (var outputDevice = new WaveOutEvent())
            {
                outputDevice.Init(audioFile);
                outputDevice.PlaybackStopped += (sender, args) => OnAudioPlaybackStopped();
                outputDevice.Play();
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                string prompt = @"
                       ____   _   _          _       ____                  _   
                      / ___| | | (_)   ___  | | __  / ___|   __ _   _ __  | |_ 
                     | |     | | | |  / __| | |/ / | |      / _` | | '__| | __|
                     | |___  | | | | | (__  |   <  | |___  | (_| | | |    | |_ 
                      \____| |_| |_|  \___| |_|\_\  \____|  \__,_| |_|     \__|

";
                Console.WriteLine(prompt);
                // Wait for the audio to finish playing
                while (outputDevice.PlaybackState == PlaybackState.Playing)
                {
                    // You can add optional code here while waiting for the audio to finish
                }
            }

            string audioFilePath = "D:\\Net new Source Codes\\ClickCart\\ClickCart.Presentation\\UI\\intro.m4a"; // Replace with the actual path to your audio file

            // Check if the audio file exists
            if (!File.Exists(audioFilePath))
            {
                Console.WriteLine("Audio file not found.");
                return;
            }

            using (var audioFile = new AudioFileReader(audioFilePath))
            using (var outputDevice = new WaveOutEvent())
            {
                outputDevice.Init(audioFile);
                outputDevice.PlaybackStopped += (sender, args) => OnAudioPlaybackStopped();
                outputDevice.Play();

                // Wait for the audio to finish playing
                while (outputDevice.PlaybackState == PlaybackState.Playing)
                {
                    // You can add optional code here while waiting for the audio to finish
                }
            }



            Console.WriteLine("1 => Create");
            string[] options = { " Create", " Update", " GetById", " GetAll", " Delete", " Exit" };

            Menu mainMenu = new Menu(options, prompt);

            int selectIndex = mainMenu.Run();

            switch (selectIndex)
            {
                case 0:
                    {
                        Console.WriteLine("Create");
                    }
                    break;
                case 1:
                    {
                        Console.WriteLine("Update");
                    }
                    break;
                case 2:
                    {
                        Console.WriteLine("GetById");
                    }
                    break;
                case 3:
                    {
                        Console.WriteLine("GetAll");
                    }
                    break;
                case 4:
                    {
                        Console.WriteLine("Delete");
                    }
                    break;
                case 5:
                    {
                        Console.WriteLine("Exit");
                    }
                    break;
            }

            Console.ReadKey(true);
        }
            #endregion
            while (true)
            {

            }
        }
        static void OnAudioPlaybackStopped()
        {
        }
    }
}
