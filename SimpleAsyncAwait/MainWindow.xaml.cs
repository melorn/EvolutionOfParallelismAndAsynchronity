using System;
using System.Collections.Generic;
using System.Linq;
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

namespace SimpleAsyncAwait
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

		private string CrazyCompute(string input)
		{
			StringBuilder sb = new StringBuilder();
			foreach (var item in input)
			{
				sb.Append(((char)(((int)item * DateTime.UtcNow.Millisecond) % 255)).ToString());
				Thread.Sleep(1000);
			}

			return sb.ToString();
		}

		#region NoTask
		private void btnCompute_Click(object sender, RoutedEventArgs e)
		{
			txtResult.Text = CrazyCompute(txbInput.Text);
		}
		#endregion

		#region SimpleTask
		//private void btnCompute_Click(object sender, RoutedEventArgs e)
		//{
		//	var str = txbInput.Text;
		//	var task = Task.Run(() =>
		//	{
		//		return CrazyCompute(str);
		//	}).ContinueWith((result) =>
		//	{
		//		txtResult.Text = result.Result;
		//	}, TaskScheduler.FromCurrentSynchronizationContext());
		//}
		#endregion

		#region AsyncTask
		//private async void btnCompute_Click(object sender, RoutedEventArgs e)
		//{
		//	var str = txbInput.Text;
		//	var result = await Task.Run(() =>
		//	{
		//		return CrazyCompute(str);
		//	});

		//	txtResult.Text = result;
		//}
		#endregion

		#region BeautyAsync

		//private async Task<string> CrazyComputeAsync(string input)
		//{
		//	return await Task.Run(() => { return CrazyCompute(input); });
		//}

		//private async void btnCompute_Click(object sender, RoutedEventArgs e)
		//{
		//	var str = txbInput.Text;
		//	var result = await CrazyComputeAsync(str);
		//	txtResult.Text = result;
		//}
		#endregion
	}
}
