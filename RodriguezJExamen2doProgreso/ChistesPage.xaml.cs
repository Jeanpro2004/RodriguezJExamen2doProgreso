using System.Text.Json;

namespace RodriguezJExamen2doProgreso;

public partial class ChistesPage : ContentPage
{
    private readonly HttpClient client = new HttpClient();

    public ChistesPage()
    {
        InitializeComponent();
        LoadJoke();
    }

    private async void LoadJoke()
    {
        try
        {
            JokeLabel.Text = "Cargando chiste...";

            var response = await client.GetStringAsync("https://official-joke-api.appspot.com/random_joke");
            var joke = JsonSerializer.Deserialize<Joke>(response, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (joke != null)
            {
                JokeLabel.Text = $"{joke.Setup}\n\n{joke.Punchline}";
            }
            else
            {
                JokeLabel.Text = "No se pudo cargar el chiste";
            }
        }
        catch (Exception ex)
        {
            JokeLabel.Text = $"Error al cargar el chiste: {ex.Message}";
        }
    }

    private void OnJokeClicked(object sender, EventArgs e)
    {
        LoadJoke();
    }
}

public class Joke
{
    public string Setup { get; set; } = string.Empty;
    public string Punchline { get; set; } = string.Empty;
}