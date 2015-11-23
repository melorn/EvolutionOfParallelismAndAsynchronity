using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ComplexAsyncAwait
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private async void btnCompute_Click(object sender, RoutedEventArgs e)
		{
			WebClient wc = new WebClient();
			string resp = await wc.DownloadStringTaskAsync(new Uri("http://www.index.hu", UriKind.Absolute));

			txtResult.Inlines.Add(new LineBreak());
			txtResult.Inlines.Add(resp.Split('\n').First());

			txtResult.Inlines.Add(new LineBreak());
			txtResult.Inlines.Add(await CrazyComputeAsync("Hi Guys!"));

			txtResult.Inlines.Add(new LineBreak());
			txtResult.Inlines.Add(await readFirstLineAsync());
		}

		private async Task<string> CrazyComputeAsync(string input)
		{
			return await Task.Run(() =>
			{
				StringBuilder sb = new StringBuilder();
				foreach (var item in input)
				{
					sb.Append(((char)(((int)item * DateTime.UtcNow.Millisecond) % 255)).ToString());
					Thread.Sleep(1000);
				}

				return sb.ToString();
			});
        }

		public async Task<string> readFirstLineAsync()
		{
			using (FileStream sourceStream = new FileStream("c:\\temp\\meetup", FileMode.Open, FileAccess.Read, FileShare.Read))
			using(StreamReader sr = new StreamReader(sourceStream))
			{
				return await sr.ReadLineAsync();
			}
		}
	}
}
