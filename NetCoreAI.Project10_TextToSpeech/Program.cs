using System.Speech.Synthesis;

class Program
{
    static void Main(string[] args)
    {
        SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
        speechSynthesizer.Volume = 100;
        speechSynthesizer.Rate = 0;
        Console.WriteLine("Metni giriniz: ");
        string input = Console.ReadLine();
        if(!string.IsNullOrEmpty(input))
        {
            speechSynthesizer.Speak(input);
        }
    }
}