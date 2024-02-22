namespace learning;

public partial class MainPage : ContentPage
{
	int count = 0;
	model.Net net;

	public MainPage()
	{
		InitializeComponent();
		this.net = new model.Net(new int[] { 20, 100, 100, 10 });
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count+=100;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}


