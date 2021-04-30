using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using task8_11;

namespace form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            AddNewObject(new CosmonautWrapper(new SlowCosmonaut()));
            AddNewObject(new CosmonautWrapper(new FastCosmonaut()));
            AddNewObject(new CosmonautWrapper(new VeryFastCosmonaut()));
            AddNewObject(new Rocket("QWER"));
        }

        private void Slow_Click(object sender, EventArgs e)
        {
            AddNewObject(new CosmonautWrapper(new SlowCosmonaut()));
        }

        private void Fast_Click(object sender, EventArgs e)
        {
            AddNewObject(new CosmonautWrapper(new FastCosmonaut()));
        }

        private void VeryFast_Click(object sender, EventArgs e)
        {
            AddNewObject(new CosmonautWrapper(new VeryFastCosmonaut()));
        }
        
        private void AddNewObject(AbstractActor actor)
        {
            var view = new ListBox();
            view.Items.Add($"Тип: {actor.GetType().Name}");
            view.Items.Add($"Имя: {actor.Name}");
            view.Items.Add($"Состояние: летит в ракете.");
            view.Size = new Size(510, 50);
            actor.ActorEvent += state => view.Items[2] = $"Состояние: {state}";
            this.Panel.Controls.Add(view);
        }

        private void AddHouse_Click(object sender, EventArgs e)
        {
            var rnd = new Random();
            var rndName = string.Join("", Enumerable.Range(1, 4).Select(x => rnd.Next(64, 90)).Select(x => (char)x));
            AddNewObject(new Rocket(rndName));
        }
    }
}
