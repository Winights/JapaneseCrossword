using JapaneseCrossword.Levels.Heart;

namespace JapaneseCrossword
{
    public partial class JapaneseCrossword : Form
    {
        private string[] _levels = new string[] { "neco arc", "cat", "heart" };
        private string _selectedLevel = string.Empty;
        public JapaneseCrossword()
        {
            InitializeComponent();
            SelectLevelComboBox.DataSource = _levels;
            SelectLevelComboBox.SelectedIndex = -1;
        }

        private void SelectLevelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectLevelComboBox.Text != null)
            {
                _selectedLevel = SelectLevelComboBox.Text;
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            switch (_selectedLevel)
            {
                case "cat":

                    break;
                case "neco arc":

                    break;

                case "heart":
                    var newScreen = new Heart();
                    newScreen.ShowDialog();
                    break;   
            }
        }
    }
}
