using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.IO;
using System.Media;
using System.Net;

namespace EchoLang { 

class Assistant
{
    class OpenAI
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("generated_text")]
        public string GeneratedText { get; set; }
    }
    class OpenAIAudio
    {
        [JsonProperty("audio_resource_url")]
        public string Audio { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
    }
    class AI
    {
        [JsonProperty("openai")]
        public OpenAI openAI { get; set; }
    }
    class AIAudio
    {
        [JsonProperty("openai")]
        public OpenAIAudio openAI { get; set; }
    }

    public static async Task<string> Request(string apiUrl, string jsonPayload)
    {

        using (HttpClient client = new HttpClient())
        {
            try
            {

                HttpContent content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyX2lkIjoiZDk3ZThiMjgtYWFmMC00ZTgyLThjMDktZWExZDZhMTdiZDFiIiwidHlwZSI6ImFwaV90b2tlbiJ9.0y5raNnPU3y2pVI85wpw5R8uIryRc1X_5tvvzCsaRsE");

                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    // Read the response content as a string
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return responseBody;

                }
            }
            catch (HttpRequestException e)
            {
                // Handle any exceptions that occurred during the request
                Console.WriteLine($"Request failed: {e.Message}");
            }
        }
        throw new Exception("Error: making a request");
    }
    public static async Task<string> Action(string text, string command)
    {
        string globalCommand = $"You are an assistant that translates words and answers questions about language. please keep your answers very short to 1 or 2 words unless you are asked to explain something. {command}";

        try
        {
            string jsonPayload = $@"{{
                    ""providers"": ""openai"",
                    ""text"": ""{text}"",
                    ""chatbot_global_action"":  ""{globalCommand}"",
                    ""previous_history"": [],
                    ""temperature"": 0.0,
                    ""max_tokens"": 150,
                    ""fallback_providers"": """",
                    ""openai"": ""gpt-4-1106-preview""
                }}";
            string response = await Request("https://api.edenai.run/v2/text/chat", jsonPayload);
            AI aiResponse = JsonConvert.DeserializeObject<AI>(response);
            // Do something with the response data
            if (aiResponse.openAI.Status == "success")
            {
                return aiResponse.openAI.GeneratedText;
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        return "AI is not working. Maybe he's asleep!";
    }
    public static async Task<string> Speech(string text, string lang)
    {
            string jsonPayload = $@"{{
                    ""providers"": ""openai"",
                    ""language"": ""{lang}"",
                    ""text"": ""{text}"",
                    ""option"": ""FEMALE"",
                    ""fallback_providers"": """"
                }}";
        string response = await Request("https://api.edenai.run/v2/audio/text_to_speech", jsonPayload);
        AIAudio aiResponse = JsonConvert.DeserializeObject<AIAudio>(response);
        // Do something with the response data
        if (aiResponse.openAI.Status == "success")
        {
            return aiResponse.openAI.Audio;
        }
        throw new Exception();
    }
    public static void PlaySoundFromUrl(string soundUrl)
    {
        try
        {
            // Download the sound file
            WebClient webClient = new WebClient();
            byte[] soundBytes = webClient.DownloadData(soundUrl);

            // Create a stream from the downloaded bytes
            MemoryStream memoryStream = new MemoryStream(soundBytes);

            // Play the sound
            SoundPlayer soundPlayer = new SoundPlayer(memoryStream);
            soundPlayer.Play();

            // Clean up resources
            memoryStream.Dispose();
            soundPlayer.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error playing sound: " + ex.Message);
            // Handle the exception as needed
        }
    }
}
    /*
class Program
{
    static async Task Main()
    {

        Console.WriteLine(await Assistant.Action("Give me a list of languages you are trained on. List all of them", "explain what it is in detail"));
        Console.ReadKey();
    }
}
    */

class TextComp
{
    public string url;
    public Panel panel;
    public string text;
    public string lang;
    public TextComp(string t, int x, int y, string langCode)
    {
        text = t;
        lang = langCode;
        panel = new Panel();
        panel.Size = new Size(300, 50);
        panel.Location = new Point(x, y);

        // Create a label for text
        Label label = new Label();
        label.Text = t;
        label.Font = new Font("Segoe UI", 12F);
        label.AutoSize = true;
        label.Location = new Point(0, 15); // Center vertically
        panel.Controls.Add(label);

        // Create a button with a volume emoji
        Button volumeButton = new Button();
        volumeButton.Font = new Font("Segoe UI Emoji", 12F);
        volumeButton.Text = "🔊"; // Volume emoji
        volumeButton.Size = new Size(50, 50);
        volumeButton.Location = new Point(label.Right + 10, 0); // Align to the right of the label
        volumeButton.Click += (sender, e) =>
        {
            this.Speak();
        };
            panel.Controls.Add(volumeButton);
        }
    public async void Speak()
    {
       
        try
        {
            if (url == null)
            {
                try
                {
                    url = await Assistant.Speech(text, lang);

                }
                catch (Exception e)
                {
                        MessageBox.Show(e.Message);
                }
            }
            if (url != null)
            {
                // speak stuff
                Assistant.PlaySoundFromUrl(url);
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

}

}