using System;

public interface IMediaDevice
{
    void On();
    void Off();
}

public class TV : IMediaDevice
{
    public void On() => Console.WriteLine("TV включен.");
    public void Off() => Console.WriteLine("TV выключен.");
    public void SetChannel(int channel) => Console.WriteLine($"Канал TV установлен на {channel}.");
}

public class AudioSystem : IMediaDevice
{
    public void On() => Console.WriteLine("Аудиосистема включена.");
    public void Off() => Console.WriteLine("Аудиосистема выключена.");
    public void SetVolume(int volume) => Console.WriteLine($"Громкость установлена на {volume}.");
}

public class DVDPlayer : IMediaDevice
{
    public void On() => Console.WriteLine("DVD-проигрыватель включен.");
    public void Off() => Console.WriteLine("DVD-проигрыватель выключен.");
    public void Play() => Console.WriteLine("Воспроизведение DVD.");
    public void Pause() => Console.WriteLine("Пауза DVD.");
    public void Stop() => Console.WriteLine("Остановка DVD.");
}

public class GameConsole : IMediaDevice
{
    public void On() => Console.WriteLine("Игровая консоль включена.");
    public void Off() => Console.WriteLine("Игровая консоль выключена.");
    public void StartGame(string game) => Console.WriteLine($"Игра {game} запущена.");
}

public class HomeTheaterFacade
{
    private readonly TV _tv;
    private readonly AudioSystem _audio;
    private readonly DVDPlayer _dvd;
    private readonly GameConsole _console;

    public HomeTheaterFacade(TV tv, AudioSystem audio, DVDPlayer dvd, GameConsole console)
    {
        _tv = tv;
        _audio = audio;
        _dvd = dvd;
        _console = console;
    }

    public void WatchMovie()
    {
        _tv.On();
        _audio.On();
        _dvd.On();
        _dvd.Play();
        _audio.SetVolume(20);
        Console.WriteLine("Система готова для просмотра фильма.");
    }

    public void StopMovie()
    {
        _dvd.Stop();
        _dvd.Off();
        _tv.Off();
        _audio.Off();
        Console.WriteLine("Система выключена после просмотра фильма.");
    }

    public void PlayGame(string game)
    {
        _tv.On();
        _console.On();
        _console.StartGame(game);
        _audio.On();
        _audio.SetVolume(15);
        Console.WriteLine("Система готова для игры.");
    }

    public void ListenToMusic()
    {
        _tv.On();
        _audio.On();
        _audio.SetVolume(25);
        Console.WriteLine("Система готова для прослушивания музыки.");
    }

    public void AdjustVolume(int volume) => _audio.SetVolume(volume);
}

public class Program
{
    public static void Main()
    {
        var tv = new TV();
        var audio = new AudioSystem();
        var dvd = new DVDPlayer();
        var console = new GameConsole();
        
        var homeTheater = new HomeTheaterFacade(tv, audio, dvd, console);
        
        homeTheater.WatchMovie();
        homeTheater.AdjustVolume(30);
        homeTheater.StopMovie();
        
        homeTheater.PlayGame("Cyber Adventure");
        
        homeTheater.ListenToMusic();
    }
}
