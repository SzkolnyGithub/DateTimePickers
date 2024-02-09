using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Zadanie9._02Badowski4c;

public partial class MainPage : ContentPage
{
	class Daty
	{
		public string Start { get; set; }
		public string End { get; set; }
		public string StartTime { get; set; }
		public string EndTime { get; set; }
	}

	public MainPage()
	{
		InitializeComponent();
	}

	private void getJson(object sender, EventArgs e)
	{
		Daty data = new Daty
		{
			Start = dateStart.Date.ToShortDateString(),
			End = dateEnd.Date.ToShortDateString(),
			StartTime = timeStart.Time.ToString(),
			EndTime = timeEnd.Time.ToString()
        };
		string dane = JsonConvert.SerializeObject(data, Formatting.Indented);
        string path = Path.Combine(FileSystem.Current.AppDataDirectory, "data.json");
        File.Delete(path);
        File.WriteAllText(path, dane);
		jsonTu.Text = File.ReadAllText(path);
    }
	
}