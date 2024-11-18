using ScreenSound_04.Modelos;
using System.Text.Json;
using ScreenSound_04.Filtros;

using (HttpClient client = new HttpClient())
{
    try
    {
        string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
        var musicas = JsonSerializer.Deserialize<List<Musica>>(resposta)!;

        LinqFilter.FiltrarTodasMusicasPorTonalidade(musicas);


        //musicas[1].ExibirDetalhesDaMusica();
        //LinqFilter.FiltrarTodosOsGenerosMusicais(musicas);
        //LinqOrder.ExibirListaDeArtistasOrdenados(musicas);
        //LinqFilter.FiltrarArtistasPorGeneroMusical(musicas, "rock");
        //LinqFilter.FiltrarMusicasDeUmArtista(musicas, "U2");


        var musicaPreferidas = new MusicasPreferidas("yago");
        musicaPreferidas.AdicionarMusicasFavoritas(musicas[1]);
        musicaPreferidas.AdicionarMusicasFavoritas(musicas[377]);
        musicaPreferidas.AdicionarMusicasFavoritas(musicas[4]);
        musicaPreferidas.AdicionarMusicasFavoritas(musicas[6]);
        musicaPreferidas.AdicionarMusicasFavoritas(musicas[1467]);

        musicaPreferidas.ExibirMusicasFavoritas();

        musicaPreferidas.GerarArquivoJson();


    }
    catch (Exception ex)
    {
        Console.WriteLine($"Temos um problema: {ex.Message}");
    }
}
