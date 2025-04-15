using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokemonGame
{
    public partial class Choose_your_team : Form
    {
        public static Choose_your_team instance;
        public TextBox tb1;
        private List<Button> pokemon;
        private List<PictureBox> Selectedpokemon;


        public Choose_your_team()
        {
            InitializeComponent();
            instance = this;

        }
        Image defaultPokeball = Properties.Resources.Pokeball;
        public static int index1 = 0;
        public static int index2 = 0;
        public static int index3 = 0;
        public static int index4 = 0;
        public static int index5 = 0;
        public static int index6 = 0;




        private void Choose_your_team_Load(object sender, EventArgs e)
        {
            /*pokemon1.BackgroundImage = defaultPokeball;
            pokemon2.BackgroundImage = defaultPokeball;
            pokemon3.BackgroundImage = defaultPokeball;
            pokemon4.BackgroundImage = defaultPokeball;
            pokemon5.BackgroundImage = defaultPokeball;
            pokemon6.BackgroundImage = defaultPokeball;*/

            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            pokemon = new List<Button>(30) {butAerodactyl, butArticuno, butBarbaracle, butBlastoise, butBlaziken, butCharizard, butDragapult,
                butDragonite, butFroslass, butGardevoir, butGengar, butGroudon, butIncineroar, butKrookodile, butKyogre, butLucario, butGarchomp, butMewtwo,
                butPikachu, butSceptile, butShedinja, butSteelix, butSylveon, butTalonflame, butToxapex, butToxicroak, butTyranitar, butVenusaur, butVikavolt, butZapdos };
            Selectedpokemon = new List<PictureBox>(6) { pokemon1, pokemon2, pokemon3, pokemon4, pokemon5, pokemon6 };

            /*
            Selectedpokemon.Add(pokemon1.BackgroundImage);
            Selectedpokemon.Add(pokemon2.BackgroundImage);
            Selectedpokemon.Add(pokemon3.BackgroundImage);
            Selectedpokemon.Add(pokemon4.BackgroundImage);
            Selectedpokemon.Add(pokemon5.BackgroundImage);
            Selectedpokemon.Add(pokemon6.BackgroundImage);*/

            for (int i = 0; i < Selectedpokemon.Count; i++)
            {
                Selectedpokemon[i].BackgroundImage = defaultPokeball;
            }

            foreach (Button button in pokemon)
            {
                button.Click += pokemon_click;
            }
        }

        //quit button
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void pokemon_click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (button == null) { return; }

            Image image = button.BackgroundImage;

            foreach (PictureBox slot in Selectedpokemon)
            {
                if (slot.BackgroundImage == defaultPokeball)
                {
                    slot.BackgroundImage = image;
                    break;
                }
            }
            checkLeg(Selectedpokemon);
        }

        private void checkLeg(List<PictureBox> pokemon)
        {
            bool legendary = false;
            for (int i = 0; i < pokemon.Count; i++)
            {
                if (pokemon[i].BackgroundImage == butKyogre.BackgroundImage)
                {
                    legendary = true;
                }
                else if (pokemon[i].BackgroundImage == butArticuno.BackgroundImage)
                {
                    legendary = true;
                }
                else if (pokemon[i].BackgroundImage == butZapdos.BackgroundImage)
                {
                    legendary = true;
                }
                else if (pokemon[i].BackgroundImage == butMewtwo.BackgroundImage)
                {
                    legendary = true;
                }
                else if (pokemon[i].BackgroundImage == butGroudon.BackgroundImage)
                {
                    legendary = true;
                }

                if (legendary)
                {
                    butKyogre.Enabled = false;
                    butArticuno.Enabled = false;
                    butZapdos.Enabled = false;
                    butMewtwo.Enabled = false;
                    butGroudon.Enabled = false;
                }
                else
                {
                    butKyogre.Enabled = true;
                    butArticuno.Enabled = true;
                    butZapdos.Enabled = true;
                    butMewtwo.Enabled = true;
                    butGroudon.Enabled = true;
                }
            }
        }


        private void pokemon1_Click(object sender, EventArgs e)
        {
            pokemon1.BackgroundImage = defaultPokeball;
        }


        private void pokemon3_Click(object sender, EventArgs e)
        {
            pokemon3.BackgroundImage = defaultPokeball;
        }

        private void pokemon4_Click(object sender, EventArgs e)
        {
            pokemon4.BackgroundImage = defaultPokeball;
        }

        private void pokemon5_Click(object sender, EventArgs e)
        {
            pokemon5.BackgroundImage = defaultPokeball;
        }

        private void pokemon6_Click(object sender, EventArgs e)
        {
            pokemon6.BackgroundImage = defaultPokeball;
        }

        private void butChoosePoke_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Battle = new Battle(pokemon1.BackgroundImage, pokemon2.BackgroundImage, pokemon3.BackgroundImage, pokemon4.BackgroundImage, pokemon5.BackgroundImage, pokemon6.BackgroundImage, butCharizard.BackgroundImage, butBlaziken.BackgroundImage, butBlastoise.BackgroundImage, butBarbaracle.BackgroundImage, butIncineroar.BackgroundImage, butAerodactyl.BackgroundImage, butArticuno.BackgroundImage, butDragapult.BackgroundImage, butDragonite.BackgroundImage, butFroslass.BackgroundImage, butGardevoir.BackgroundImage, butGengar.BackgroundImage, butGroudon.BackgroundImage, butKrookodile.BackgroundImage, butKyogre.BackgroundImage, butLucario.BackgroundImage, butGarchomp.BackgroundImage, butMewtwo.BackgroundImage, butPikachu.BackgroundImage, butSceptile.BackgroundImage, butShedinja.BackgroundImage, butSteelix.BackgroundImage, butSylveon.BackgroundImage, butTalonflame.BackgroundImage, butToxapex.BackgroundImage, butToxicroak.BackgroundImage, butTyranitar.BackgroundImage, butVenusaur.BackgroundImage, butVikavolt.BackgroundImage, butZapdos.BackgroundImage);
            Battle.Closed += (s, args) => this.Close();
            Battle.Show();
        }

        private void butGarchomp_Click(object sender, EventArgs e)
        {

        }

        private void pokemon2_Click(object sender, EventArgs e)
        {
            pokemon2.BackgroundImage = defaultPokeball;
        }

        //For pokemon sprites use the Gen 7 sprites as buttons to select.

    }
}
