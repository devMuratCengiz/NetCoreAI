using Tesseract;

class Program
{

	static void Main(string[] args)
	{
		Console.WriteLine("Karakter okuması yapılacak resmin yolu: ");
		string imagePath = Console.ReadLine();

		string tessDataPath = @"C:\tessdata";
		try
		{
			using (var engine = new TesseractEngine(tessDataPath, "eng", EngineMode.Default))
			{
				using (var img = Pix.LoadFromFile(imagePath))
				{
					using (var page = engine.Process(img))
					{
						string text = page.GetText();
						Console.WriteLine("Resimden okunana metin:");
						Console.WriteLine(text);
					}
				}
			}
		}
		catch (Exception ex)
		{

			Console.WriteLine($"Bir hata oluştu: {ex.Message}");
		}
	}
}