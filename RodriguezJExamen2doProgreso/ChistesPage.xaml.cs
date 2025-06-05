using System.Text.Json;

namespace RodriguezJExamen2doProgreso;

public partial class ChistesPage : ContentPage
{
	HttpClient client = new HttpClient();
    public ChistesPage()
	{
		InitializeComponent();
		LoadJoke();
	}

	private async void LoadJoke()
    {
       
            var response = await client.GetStringAsync("https://official-joke-api.appspot.com/random_joke");
            var joke = JsonSerializer.Deserialize<Joke>(response);
            JokeLabel.Text = $"{joke.Setup}\n\n{joke.Punchline}";
        }
            private void OnJokeClicked(object sender, EventArgs e)
            {
            LoadJoke();
            }
        }
    public class Joke
    {
    public string Setup { get; set; }
    public string Punchline { get; set; }
   
    }
