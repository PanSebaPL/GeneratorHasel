
namespace GeneratorHasel
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private string Output;
        Random CharSign = new Random();
        Random TypeSign = new Random();
        private char[][] TabZnakow =
        {
            new char[]{ 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' },
            new char[]{'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'},
            new char[]{'0','1', '2', '3', '4', '5', '6', '7', '8', '9'},
            new char[]{ '!', '@', '#', '$', '%', '^', '&', '*', '(', ')','[',']','/','<','>','?','|','`','~','\\'}
        };
    private void OnGenerujClicked(object sender, EventArgs e)
        {
            bool[] Types = new bool[4] { false, false, false, false };
            Output = "";
            if (IsMaleLitery.IsChecked)
                Types[0] = true;
            if (IsDuzeLitery.IsChecked)
                Types[1] = true;
            if (IsCyfry.IsChecked)
                Types[2] = true;
            if (IsSpecjalne.IsChecked)
                Types[3] = true;
            if (!Types[0] && !Types[1] && !Types[2] && !Types[3]||Dlugosc.Text=="") { }
            else {
                
                OutputLbl.Text = Output;
                int PasLenght;
                bool czyLiczba = int.TryParse(Dlugosc.Text, out PasLenght);
                if (czyLiczba&&PasLenght>3)
                {
                    int TypeRand;
                    int CharRand;
                    for (int i = 0; i < PasLenght; i++)
                    {
                        TypeRand = TypeSign.Next(0, 4);
                        if (Types[TypeRand])
                        {
                            CharRand = CharSign.Next(0, TabZnakow[TypeRand].Length);

                            Output += TabZnakow[TypeRand][CharRand];
                        }
                        else
                            i--;
                    }
                    OutputLbl.Text = Output;

                    SemanticScreenReader.Announce(OutputLbl.Text);
                }
                else
                {
                    OutputLbl.Text = "Hasla nie da sie wygenerowac";
                    SemanticScreenReader.Announce(OutputLbl.Text);

                }
            }
        }
    }
}