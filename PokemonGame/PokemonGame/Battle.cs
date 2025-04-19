using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokemonGame
{
    public partial class Battle : Form
    {
        private List<PictureBox> CPUpokemon;
        private List<Image> PlayerPokemon;
        private Dictionary<Image, List<String>> PlayerPokeAndMoves;
        private Dictionary<Image, int> PlayerPokeAndHealth;
        private Dictionary<Image, List<String>> CPUPokeAndMoves;
        private Dictionary<Image, int> CPUPokeAndHealth;
        private List<Button> Move;


        public Battle(Image tm1BackgroundImage1, Image tm1BackgroundImage2, Image tm1BackgroundImage3, Image tm1BackgroundImage4, Image tm1BackgroundImage5, Image tm1BackgroundImage6, Image butCharizard, Image butBlaziken, Image butBlastoise, Image butBarbaracle, Image butIncineroar, Image butAerodactyl, Image butArticuno, Image butDragapult, Image butDragonite, Image butFroslass, Image butGardevoir, Image butGengar, Image butGroudon, Image butKrookodile, Image butKyogre, Image butLucario, Image butGarchomp, Image butMewtwo, Image butPikachu, Image butSceptile, Image butShedinja, Image butSteelix, Image butSylveon, Image butTalonflame, Image butToxapex, Image butToxicroak, Image butTyranitar, Image butVenusaur, Image butVikavolt, Image butZapdos)
        {
            InitializeComponent();

            //Set health

            Move = new List<Button> { Move1, Move2, Move3, Move4 };
            //Array Lists of Computer Pokemon and Player Pokemon
            CPUpokemon = new List<PictureBox>() { team2Poke, team2Poke2, team2Poke3, team2Poke4, team2Poke5, team2Poke6 };
            PlayerPokemon = new List<Image>() { tm1BackgroundImage1, tm1BackgroundImage2, tm1BackgroundImage3, tm1BackgroundImage4, tm1BackgroundImage5, tm1BackgroundImage6 };

            PlayerPokeAndMoves = new Dictionary<Image, List<String>>();

            CPUHealth.Maximum = 404;
            CPUHealth.Minimum = 0;
            PlayerHealth.Maximum = 404;
            PlayerHealth.Minimum = 0;

            /*for (int i = 0; i < 6; i++)
            {
                if (CPUpokemon[i].BackgroundImage == butAerodactyl)
                {
                    //type: rock and water
                    //weak against rock, electric, water, steel, ice
                    //cannot be hit by ground type moves
                    //resist normal, fire, poison, flying, bug
                    CPUPokeAndMove[CPUpokemon[i]] = new List<String> { "Taunt", "Stealth Rock", "Stone Edge", "Aeiral Ace" };
                    // Stone Edge 80% accuracy
                    //Aeiral Ace 100% accuracy
                }
                else if (CPUpokemon[i].BackgroundImage == butArticuno)
                {
                    CPUPokeAndMove[CPUpokemon[i]] = new List<String> { "Brave Bird", "Hurricane", "Ice Shard", "Frost Breath" };
                    //Brave Bird Flying 120 damage, special 1/3 of the damage to the user
                    //Hurricane Flying type, 130 damage 70% accuracy, 30% confussion
                    //Ice Shard Ice type, 40 damage
                    //Frost Breath always a crit hit, 60 damage, 90% accuracy
                    //Weaknesses 4x rock, 2x fire, electric, and steel
                    //0.5, grass and bug
                    //Immune to ground
                }
                else if (CPUpokemon[i].BackgroundImage == butBarbaracle)
                {
                    CPUPokeAndMove[CPUpokemon[i]] = new List<String> { "Shell Smash", "Dragon Claw", "Razor Shell", "Stone Edge" };
                    //Dragon Claw 80 damage, 100% accuracy
                    //Razor Shell 95% accuracy, 75 damage
                    //4x grass, 2x electric, 2x fighting, 2x ground <- weaknesses
                    //0.5x normal, ice, poision, flying
                    // 0.25x fire
                    // Stone Edge 80% accuracy
                }
                else if (CPUpokemon[i].BackgroundImage == butBlastoise)
                {
                    CPUPokeAndMove[CPUpokemon[i]] = new List<String> { "Water Pulse", "Aura Sphere", "Dragon Pulse", "Dark Pulse" };
                    //Water pulse 60 damage, 20% confusion
                    //Aura Sphere fighitng, 80 damage, 100% acc
                    //Dragon Pulse dragon, 85 damage
                    //Dark dark, 80 damage
                    //Weaknesses 2x electric and grass
                    //0.5x fire, water, ice, and steel
                }
                else if (CPUpokemon[i].BackgroundImage == butBlaziken)
                {
                    CPUPokeAndMove[CPUpokemon[i]] = new List<String> { "Stone Edge", "Hone Claws", "Blaze Kick", "High Jump Kick" };
                    //Stone Edge 80% accuracy
                    //Hone Claws raise attack
                    //Blaze Kick fire type, 85 damage, 90% acc
                    //High Jump Kick fighting type, if misses half health to yourself, 100 damage, 85% acc
                    //Weaknesses 2x water, ground, flying, psychic
                    //0.5x fire, grass, ice, dark, steel
                    //0.25 bug

                }
                else if (CPUpokemon[i].BackgroundImage == butCharizard)
                {
                    CPUPokeAndMove[CPUpokemon[i]] = new List<String> { "Earthquake", "Dragon Claw", "Dragon Dance", "Fire Blitz" };
                    //Earthquake ground, 100 damage
                    //Dragon Claw 80 damage, 100% accuracy
                    //Dragon Dance raises attack, and speed, by one stage
                    //Fire Blitz fire, hits, 120 damage, 1/3 of damage to user (brave bird but fire)
                    //Weakness 4x rock, 2x water and electric,
                    //0.5x fire, fighting, steel, fairy,
                    //0.25x grass, bug
                    //immune ground

                }
                else if (CPUpokemon[i].BackgroundImage == butDragapult)
                {
                    CPUPokeAndMove[CPUpokemon[i]] = new List<String> { "Dragon Darts", "Dragon Dance", "Night Shade", "Shadow Ball" };
                    //Dragon Darts Dragon type, 100 damage
                    //Dragon Dance raises attack, and speed, by one stage
                    //Night Shade 50 damage
                    //Shadow Ball ghost type, 20% chance to raise attack, 80 dmg
                    //Weakness 2x ice, ghost, dragon, dark, fairy
                    //0.5x fire, water, electic, grass, posion, bug
                    //Immune cannot be hit by normal or fighting
                }
                else if (CPUpokemon[i].BackgroundImage == butKrookodile)
                {
                    CPUPokeAndMove[CPUpokemon[i]] = new List<String> { "Outrage", "Earthquake", "Crunch", "Stone Edge" };
                    //Outrage:
                    //Stone Edge 80% accuracy
                    //Earthquake ground, 100 damage
                    //Crunch Dark type move, 80 damage
                    //Weaknesses 2x water, grass, ice, fighting, bug, and fairy
                    //0.5x poision, rock, ghost, and dark
                    //Immune (not hit) electric, and psychic
                }
                else if (CPUpokemon[i].BackgroundImage == butKyogre)
                {

                    CPUPokeAndMove[CPUpokemon[i]] = new List<String> { "Water Spout", "Thunder", "Ice beam", "Origin Pulse" };
                    //Water spout (150 x crhp) / hpmax
                    //Thunder 3/10 chance for par, 110 damage, 70% acc
                    //Ice Beam Ice type, 10% freeze, 90 damage
                    //Origin Pulse 180 damage, 80% acc
                    //Weaknesses 2x electric and grass
                    //0.5x fire, water, ice, and steel
                }
                else if (CPUpokemon[i].BackgroundImage == butMewtwo)
                {
                    CPUPokeAndMove[CPUpokemon[i]] = new List<String> { "Aura Sphere", "Thunder", "Shadow Ball", "Ice Beam" };
                    //Aura Sphere fighitng, 80 damage, 100% acc
                    //Thunder 3/10 chance for par, 110 damage, 70% acc
                    //Ice Beam Ice type, 10% freeze, 90 damage
                    //Shadow Ball ghost type, 20 % chance to raise attack, 80 dmg
                    //Weakness 2x bug, ghost, dark
                    //0.5 fighting and psychic
                }
                else if (CPUpokemon[i].BackgroundImage == butPikachu)
                {
                    CPUPokeAndMove[CPUpokemon[i]] = new List<String> { "Brick Break", "Thunderbolt", "Thunder Punch", "Quick Attack" };
                    //Brick Break fighting type, 75 dmh
                    //Thunder type elctric, 10% par, 90 dmg
                    //Thunder Punc 10% par, 75 dmg
                    //Quick Attack  40 damage, always hits first (set speed nuts cause why not)
                    //Weakness 2x ground
                    //0.5x electric flying and steel
                }
                else if (CPUpokemon[i].BackgroundImage == butSceptile)
                {
                    //Grass Type
                    CPUPokeAndMove[CPUpokemon[i]] = new List<String> { "Hone Claws", "Leaf Blade", "Dynamic Punch", "Rock Slide" };
                    //Leaf Blade grass, 90 dmg, crit 1/8
                    //Dynamic Punch, 100% confussion, 100 dmg, 50% acc
                    //Rock Slide rock, 75 dmg, 90% acc
                    //Weakness 2x fire, ice, posion, flying, bug
                    //0.5 water, electric, grass, ground
                }
                else if (CPUpokemon[i].BackgroundImage == butShedinja)
                {
                    CPUPokeAndMove[CPUpokemon[i]] = new List<String> { "Shadow Snake", "Sword Stance", "Giga Impact", "X-Scissor" };
                    //Shadow Snake ghost type, always goes first, 40dmg
                    //Sword Stanceraises attack 2 stages
                    //giga impact, normal type, no turn next run, 150 dmg, 90% acc
                    //X-Scissior bug type, 80 dmg
                    //Can only be hit by fire, flyimg, rock, ghost, dark
                    //Immune to everything else ^
                }
                else if (CPUpokemon[i].BackgroundImage == butVenusaur)
                {
                    CPUPokeAndMove[CPUpokemon[i]] = new List<String> { "Solar Beam", "Earthquake", "Hidden Power", "Growth" };
                    //Solar Beam damage on second turn 120 dmg, grass type
                    //Hidden Power fire type, 60 dmg
                    //Growth raises attack by one stage
                    //Weakness 2x fire, ice, flying, psychic
                    //0.5x water, electric, fighting, fairy
                    //0.25x grass
                }
                else if (CPUpokemon[i].BackgroundImage == butDragonite)
                {
                    CPUPokeAndMove[CPUpokemon[i]] = new List<String> { "Dragon Dance", "Roost", "Dragon Claw", "Fire Punch" };
                    //Roost restores half of users max hp
                    //Fire Punch 10% burn,
                    //Weak 4x ice, 2x rock, dragon, fairy
                    //0.5x fire, water, fighting, and bug
                    //0.25x grass
                    //Immune to ground
                }
                else if (CPUpokemon[i].BackgroundImage == butFroslass)
                {
                    CPUPokeAndMove[CPUpokemon[i]] = new List<String> { "Shadow Claw", "Thunder Wave", "Shadow Ball", "Ice Beam" };
                    //Shadow Claw Ghost Type, 70 damage
                    //Thunder Wave 100% par
                    //weak 2x fire, rock, ghost, dark, steel
                    //0.5 ice, poision, bug
                }
                else if (CPUpokemon[i].BackgroundImage == butGarchomp)
                {
                    CPUPokeAndMove[CPUpokemon[i]] = new List<String> { "Sword Stance", "Earthquake", "Dragon Claw", "Outrage" };
                    //weakness 4x ice, 2x dragon, and fiary
                    //0.5 fire poision and rock
                    //immune to electric
                }
                else if (CPUpokemon[i].BackgroundImage == butGardevoir)
                {
                    CPUPokeAndMove[CPUpokemon[i]] = new List<String> { "Psychic", "Thunderboly", "Shadow Ball", "Misty Explosion" };
                    //Psychic 10% raise attack, 90dmg
                    //Misty Explosion 100 dmg
                    //Weak 2x posions, ghost, and steel
                    //0.5x psychic
                    //0.25x fighting
                    //Immune to dragon
                }
                else if (CPUpokemon[i].BackgroundImage == butGengar)
                {
                    CPUPokeAndMove[CPUpokemon[i]] = new List<String> { "Shadow Ball", "Thunderbolt", "Poltergeist", "Sludge Ball" };
                    //Poltergiest 100dmg, 90%acc, can only use 5 times
                    //Sludge Ball poision type, 30% posion, 90 dmg
                    //weak 2x ground, psychic, ghost, and dark
                    //0.5x grass and fiary
                    //0.25 posion and bug
                    //immune to normal and fighting
                }
                else if (CPUpokemon[i].BackgroundImage == butGroudon)
                {
                    CPUPokeAndMove[CPUpokemon[i]] = new List<String> { "Fire Blast", "Earthquake", "Stone Edge", "Solar Beam" };
                    //fire blast fire type, 10% burn, 110 damage, 85% acc
                    //weak 2x water, grass, ice
                    //0.5 poision, rock
                    //Immune to electric
                }
                else if (CPUpokemon[i].BackgroundImage == butIncineroar)
                {
                    CPUPokeAndMove[CPUpokemon[i]] = new List<String> { "Darkest Lariat", "Flame Charge", "Earthquake", "Sword Stance" };
                    //Darkest Lariat dark type, 85 dmg, hits, ignores if paralyzed or high def
                    //Flame Charge fire type, raises speed by one stage, 50 dmg
                    //Weak 2x water, ground and rock, fighting
                    //0.5 fire, grass, ice, ghost, dark, and steel
                    //immune psychic
                }
                else if (CPUpokemon[i].BackgroundImage == butLucario)
                {
                    CPUPokeAndMove[CPUpokemon[i]] = new List<String> { "Sword Stance", "High Jump Kick", "Shadow Claw", "Ice Punch" };
                    //Ice Punch 75 dmg
                    //weak 2x fire, fighting, and ground
                    //half to noraml,grass,ice,dragon,dark, and steel
                    //quarter to bug and rock
                    //immune to posion
                }
                else if (CPUpokemon[i].BackgroundImage == butSteelix)
                {
                    CPUPokeAndMove[CPUpokemon[i]] = new List<String> { "Iron Tail", "Earthquake", "Rock Slide", "Crunch" };
                    //Iron Tail steel type, 30% raise attack by one stage, 100 dmg, 75% acc
                    //Rock Slide rock type, 30% flinch, 75dmg, 90% acc
                    //Crunch dark type, 20% attack by one stage, 80dmg, hits
                    //weak 2x fire, water, fighting, ground
                    //0.5 to normal, flying, psychic, bug, dragon, steel, and fairy
                    //0.25 rock
                    //immune to elxtric and posion
                }
                else if (CPUpokemon[i].BackgroundImage == butSylveon)
                {
                    CPUPokeAndMove[CPUpokemon[i]] = new List<String> { "Hypervoice", "Psyschock", "Shadow Ball", "Calm mind" };
                    //Psyshock 80 dmg
                    //Calm mind raises attack by one stage
                    //weak 2x poision, steel
                    //0.5 fighitng, bug, dark
                    //immune to dragon
                }
                else if (CPUpokemon[i].BackgroundImage == butTalonflame)
                {
                    CPUPokeAndMove[CPUpokemon[i]] = new List<String> { "Sword Stance", "Hurricane", "Flair Blitz", "Roost" };
                    //Flair Blitz 120 dmg, causes 0.25 damage of its max health to itself, 100% accurate
                    //weaknesses 4x rock, 2x water, electic
                    //0.5 fire fighting, steel, and fairy
                    //0.25 grass and bug
                    //immune to ground

                }
                else if (CPUpokemon[i].BackgroundImage == butToxapex)
                {
                    CPUPokeAndMove[CPUpokemon[i]] = new List<String> { "Gunk Shot", "Scald", "Liquidation", "Mud Slap" };
                    //Gunk Shot poision type move, 120 dmg, 80% acc
                    //Scald water, 30% burning, 80 dmg
                    //Liquidation water, 20% lowering defence by one stage, 85 dmg
                    //Mud Slap ground, 20dmg
                    //weak 2x electric, ground, psychic
                    //0.5x fire, water, ice, fighting, posion, bug, steel, fairy

                }
                else if (CPUpokemon[i].BackgroundImage == butToxicroak)
                {
                    CPUPokeAndMove[CPUpokemon[i]] = new List<String> { "Acid Spray", "Gunk Shot", "Mud Slap", "Ice Punch" };
                    //Acid Spray lowers def by 2 stages
                    //weak 4x psychic, 2x ground and flying
                    //0.5x grass, fighiting, posion, rock , dark
                    //0.25 bug
                }
                else if (CPUpokemon[i].BackgroundImage == butTyranitar)
                {
                    CPUPokeAndMove[CPUpokemon[i]] = new List<String> { "Fire Punch", "Dragon Dnace", "Stone Edge", "Ice Punch" };
                    //weak 4x fighting, 2x water, grass, ground, steel, bug, fairy
                    //0.5 normal, fire, poision, flying, ghost, and dark
                    //Immune Psychic
                }
                else if (CPUpokemon[i].BackgroundImage == butVikavolt)
                {
                    CPUPokeAndMove[CPUpokemon[i]] = new List<String> { "Bug Buzz", "Thunder", "Flash Cannon", "Crunch" };
                    //Bug Buzz bug type 90 damage, 10% lowering def by one stage
                    //Flash Cannon steel type, 80 dmg, 10% lowering def by one stage
                    //weak 2x fire, rock
                    //0.5x electric grass, fighting and steel
                }
                else if (CPUpokemon[i].BackgroundImage == butZapdos)
                {
                    CPUPokeAndMove[CPUpokemon[i]] = new List<String> { "Thunderbolt", "Thunder", "Roost", "Gunk Shot" };
                    //weak 2x ice and rock
                    //0.5 grass, fighting, flying, bug, and steel
                    //immune to ground
                }
            }*/
            //To Show players first pokemon in battle
            team1Poke.Image = PlayerPokemon[0];

            //team 2 and 2 speed, attack, and health variables
            int speed1, speed2, attack1, attack2, health1, health2, defense1, defense2 = 0;

            //Randomly selecting computer team
            Random rnd = new Random();
            for (int i = 0; i < 6; i++)
            {
                int ranNum = rnd.Next(1, 30);
                if (ranNum == 1)
                {
                    if (team2Poke.Image == null)
                    {
                        team2Poke.Image = butCharizard;
                    }
                    else if (team2Poke2.Image == null)
                    {
                        team2Poke2.Image = butCharizard;
                    }
                    else if (team2Poke3.Image == null)
                    {
                        team2Poke3.Image = butCharizard;
                    }
                    else if (team2Poke4.Image == null)
                    {
                        team2Poke4.Image = butCharizard;
                    }
                    else if (team2Poke5.Image == null)
                    {
                        team2Poke5.Image = butCharizard;
                    }
                    else if (team2Poke6.Image == null)
                    {
                        team2Poke6.Image = butCharizard;
                    }
                    speed2 = 100;
                    attack2 = 84;
                    health2 = 78;
                    defense2 = 78;

                    CPUHealth.Maximum = health2;
                    CPUHealth.Value = health2;
                    CPUHealth.Refresh();
                }
                else if (ranNum == 2)
                {
                    if (team2Poke.Image == null)
                    {
                        team2Poke.Image = butBlaziken;
                    }
                    else if (team2Poke2.Image == null)
                    {
                        team2Poke2.Image = butBlaziken;
                    }
                    else if (team2Poke3.Image == null)
                    {
                        team2Poke3.Image = butBlaziken;
                    }
                    else if (team2Poke4.Image == null)
                    {
                        team2Poke4.Image = butBlaziken;
                    }
                    else if (team2Poke5.Image == null)
                    {
                        team2Poke5.Image = butBlaziken;
                    }
                    else if (team2Poke6.Image == null)
                    {
                        team2Poke6.Image = butBlaziken;
                    }

                    speed2 = 80;
                    attack2 = 120;
                    health2 = 80;
                    defense2 = 70;
                    CPUHealth.Maximum = health2;
                    CPUHealth.Value = health2;
                    CPUHealth.Refresh();
                }
                else if (ranNum == 3)
                {
                    if (team2Poke.Image == null)
                    {
                        team2Poke.Image = butBlastoise;
                    }
                    else if (team2Poke2.Image == null)
                    {
                        team2Poke2.Image = butBlastoise;
                    }
                    else if (team2Poke3.Image == null)
                    {
                        team2Poke3.Image = butBlastoise;
                    }
                    else if (team2Poke4.Image == null)
                    {
                        team2Poke4.Image = butBlastoise;
                    }
                    else if (team2Poke5.Image == null)
                    {
                        team2Poke5.Image = butBlastoise;
                    }
                    else if (team2Poke6.Image == null)
                    {
                        team2Poke6.Image = butBlastoise;
                    }
                    speed2 = 78;
                    attack2 = 83;
                    health2 = 79;
                    defense2 = 100;

                    CPUHealth.Maximum = health2;
                    CPUHealth.Value = health2;
                    CPUHealth.Refresh();

                }
                else if (ranNum == 4)
                {
                    if (team2Poke.Image == null)
                    {
                        team2Poke.Image = butBarbaracle;
                    }
                    else if (team2Poke2.Image == null)
                    {
                        team2Poke2.Image = butBarbaracle;
                    }
                    else if (team2Poke3.Image == null)
                    {
                        team2Poke3.Image = butBarbaracle;
                    }
                    else if (team2Poke4.Image == null)
                    {
                        team2Poke4.Image = butBarbaracle;
                    }
                    else if (team2Poke5.Image == null)
                    {
                        team2Poke5.Image = butBarbaracle;
                    }
                    else if (team2Poke6.Image == null)
                    {
                        team2Poke6.Image = butBarbaracle;
                    }
                    speed2 = 258;
                    attack2 = 339;
                    health2 = 348;

                    CPUHealth.Maximum = health2;
                    CPUHealth.Value = health2;
                    CPUHealth.Refresh();
                }
                else if (ranNum == 5)
                {
                    if (team2Poke.Image == null)
                    {
                        team2Poke.Image = butIncineroar;
                    }
                    else if (team2Poke2.Image == null)
                    {
                        team2Poke2.Image = butIncineroar;
                    }
                    else if (team2Poke3.Image == null)
                    {
                        team2Poke3.Image = butIncineroar;
                    }
                    else if (team2Poke4.Image == null)
                    {
                        team2Poke4.Image = butIncineroar;
                    }
                    else if (team2Poke5.Image == null)
                    {
                        team2Poke5.Image = butIncineroar;
                    }
                    else if (team2Poke6.Image == null)
                    {
                        team2Poke6.Image = butIncineroar;
                    }
                    speed2 = 240;
                    attack2 = 361;
                    health2 = 394;

                    CPUHealth.Maximum = health2;
                    CPUHealth.Value = health2;
                    CPUHealth.Refresh();
                }
                else if (ranNum == 6)
                {
                    if (team2Poke.Image == null)
                    {
                        team2Poke.Image = butAerodactyl;
                    }
                    else if (team2Poke2.Image == null)
                    {
                        team2Poke2.Image = butAerodactyl;
                    }
                    else if (team2Poke3.Image == null)
                    {
                        team2Poke3.Image = butAerodactyl;
                    }
                    else if (team2Poke4.Image == null)
                    {
                        team2Poke4.Image = butAerodactyl;
                    }
                    else if (team2Poke5.Image == null)
                    {
                        team2Poke5.Image = butAerodactyl;
                    }
                    else if (team2Poke6.Image == null)
                    {
                        team2Poke6.Image = butAerodactyl;
                    }
                    speed2 = 394;
                    attack2 = 339;
                    health2 = 364;

                    CPUHealth.Maximum = health2;
                    CPUHealth.Value = health2;
                    CPUHealth.Refresh();
                }
                else if (ranNum == 7)
                {
                    if (team2Poke.Image == null)
                    {
                        team2Poke.Image = butArticuno;
                    }
                    else if (team2Poke2.Image == null)
                    {
                        team2Poke2.Image = butArticuno;
                    }
                    else if (team2Poke3.Image == null)
                    {
                        team2Poke3.Image = butArticuno;
                    }
                    else if (team2Poke4.Image == null)
                    {
                        team2Poke4.Image = butArticuno;
                    }
                    else if (team2Poke5.Image == null)
                    {
                        team2Poke5.Image = butArticuno;
                    }
                    else if (team2Poke6.Image == null)
                    {
                        team2Poke6.Image = butArticuno;
                    }
                    speed2 = 295;
                    attack2 = 295;
                    health2 = 384;

                    CPUHealth.Maximum = health2;
                    CPUHealth.Value = health2;
                    CPUHealth.Refresh();
                }
                else if (ranNum == 8)
                {
                    if (team2Poke.Image == null)
                    {
                        team2Poke.Image = butDragapult;
                    }
                    else if (team2Poke2.Image == null)
                    {
                        team2Poke2.Image = butDragapult;
                    }
                    else if (team2Poke3.Image == null)
                    {
                        team2Poke3.Image = butDragapult;
                    }
                    else if (team2Poke4.Image == null)
                    {
                        team2Poke4.Image = butDragapult;
                    }
                    else if (team2Poke5.Image == null)
                    {
                        team2Poke5.Image = butDragapult;
                    }
                    else if (team2Poke6.Image == null)
                    {
                        team2Poke6.Image = butDragapult;
                    }
                    speed2 = 421;
                    attack2 = 372;
                    health2 = 380;

                    CPUHealth.Maximum = health2;
                    CPUHealth.Value = health2;
                    CPUHealth.Refresh();
                }
                else if (ranNum == 9)
                {
                    if (team2Poke.Image == null)
                    {
                        team2Poke.Image = butDragonite;
                    }
                    else if (team2Poke2.Image == null)
                    {
                        team2Poke2.Image = butDragonite;
                    }
                    else if (team2Poke3.Image == null)
                    {
                        team2Poke3.Image = butDragonite;
                    }
                    else if (team2Poke4.Image == null)
                    {
                        team2Poke4.Image = butDragonite;
                    }
                    else if (team2Poke5.Image == null)
                    {
                        team2Poke5.Image = butDragonite;
                    }
                    else if (team2Poke6.Image == null)
                    {
                        team2Poke6.Image = butDragonite;
                    }
                    speed2 = 284;
                    attack2 = 403;
                    health2 = 386;

                    CPUHealth.Maximum = health2;
                    CPUHealth.Value = health2;
                    CPUHealth.Refresh();
                }
                else if (ranNum == 10)
                {
                    if (team2Poke.Image == null)
                    {
                        team2Poke.Image = butFroslass;
                    }
                    else if (team2Poke2.Image == null)
                    {
                        team2Poke2.Image = butFroslass;
                    }
                    else if (team2Poke3.Image == null)
                    {
                        team2Poke3.Image = butFroslass;
                    }
                    else if (team2Poke4.Image == null)
                    {
                        team2Poke4.Image = butFroslass;
                    }
                    else if (team2Poke5.Image == null)
                    {
                        team2Poke5.Image = butFroslass;
                    }
                    else if (team2Poke6.Image == null)
                    {
                        team2Poke6.Image = butFroslass;
                    }
                    speed2 = 350;
                    attack2 = 284;
                    health2 = 344;

                    CPUHealth.Maximum = health2;
                    CPUHealth.Value = health2;
                    CPUHealth.Refresh();
                }
                else if (ranNum == 11)
                {
                    if (team2Poke.Image == null)
                    {
                        team2Poke.Image = butGardevoir;
                    }
                    else if (team2Poke2.Image == null)
                    {
                        team2Poke2.Image = butGardevoir;
                    }
                    else if (team2Poke3.Image == null)
                    {
                        team2Poke3.Image = butGardevoir;
                    }
                    else if (team2Poke4.Image == null)
                    {
                        team2Poke4.Image = butGardevoir;
                    }
                    else if (team2Poke5.Image == null)
                    {
                        team2Poke5.Image = butGardevoir;
                    }
                    else if (team2Poke6.Image == null)
                    {
                        team2Poke6.Image = butGardevoir;
                    }
                    speed2 = 284;
                    attack2 = 251;
                    health2 = 340;

                    CPUHealth.Maximum = health2;
                    CPUHealth.Value = health2;
                    CPUHealth.Refresh();
                }
                else if (ranNum == 12)
                {
                    if (team2Poke.Image == null)
                    {
                        team2Poke.Image = butGengar;
                    }
                    else if (team2Poke2.Image == null)
                    {
                        team2Poke2.Image = butGengar;
                    }
                    else if (team2Poke3.Image == null)
                    {
                        team2Poke3.Image = butGengar;
                    }
                    else if (team2Poke4.Image == null)
                    {
                        team2Poke4.Image = butGengar;
                    }
                    else if (team2Poke5.Image == null)
                    {
                        team2Poke5.Image = butGengar;
                    }
                    else if (team2Poke6.Image == null)
                    {
                        team2Poke6.Image = butGengar;
                    }
                    speed2 = 350;
                    attack2 = 251;
                    health2 = 324;

                    CPUHealth.Maximum = health2;
                    CPUHealth.Value = health2;
                    CPUHealth.Refresh();
                }
                else if (ranNum == 13)
                {
                    if (team2Poke.Image == null)
                    {
                        team2Poke.Image = butGroudon;
                    }
                    else if (team2Poke2.Image == null)
                    {
                        team2Poke2.Image = butGroudon;
                    }
                    else if (team2Poke3.Image == null)
                    {
                        team2Poke3.Image = butGroudon;
                    }
                    else if (team2Poke4.Image == null)
                    {
                        team2Poke4.Image = butGroudon;
                    }
                    else if (team2Poke5.Image == null)
                    {
                        team2Poke5.Image = butGroudon;
                    }
                    else if (team2Poke6.Image == null)
                    {
                        team2Poke6.Image = butGroudon;
                    }
                    speed2 = 306;
                    attack2 = 438;
                    health2 = 404;

                    CPUHealth.Maximum = health2;
                    CPUHealth.Value = health2;
                    CPUHealth.Refresh();
                }
                else if (ranNum == 14)
                {
                    if (team2Poke.Image == null)
                    {
                        team2Poke.Image = butKrookodile;
                    }
                    else if (team2Poke2.Image == null)
                    {
                        team2Poke2.Image = butKrookodile;
                    }
                    else if (team2Poke3.Image == null)
                    {
                        team2Poke3.Image = butKrookodile;
                    }
                    else if (team2Poke4.Image == null)
                    {
                        team2Poke4.Image = butKrookodile;
                    }
                    else if (team2Poke5.Image == null)
                    {
                        team2Poke5.Image = butKrookodile;
                    }
                    else if (team2Poke6.Image == null)
                    {
                        team2Poke6.Image = butKrookodile;
                    }
                    speed2 = 311;
                    attack2 = 366;
                    health2 = 394;

                    CPUHealth.Maximum = health2;
                    CPUHealth.Value = health2;
                    CPUHealth.Refresh();
                }
                else if (ranNum == 15)
                {
                    if (team2Poke.Image == null)
                    {
                        team2Poke.Image = butKyogre;
                    }
                    else if (team2Poke2.Image == null)
                    {
                        team2Poke2.Image = butKyogre;
                    }
                    else if (team2Poke3.Image == null)
                    {
                        team2Poke3.Image = butKyogre;
                    }
                    else if (team2Poke4.Image == null)
                    {
                        team2Poke4.Image = butKyogre;
                    }
                    else if (team2Poke5.Image == null)
                    {
                        team2Poke5.Image = butKyogre;
                    }
                    else if (team2Poke6.Image == null)
                    {
                        team2Poke6.Image = butKyogre;
                    }
                    speed2 = 306;
                    attack2 = 328;
                    health2 = 404;

                    CPUHealth.Maximum = health2;
                    CPUHealth.Value = health2;
                    CPUHealth.Refresh();
                }
                else if (ranNum == 16)
                {
                    if (team2Poke.Image == null)
                    {
                        team2Poke.Image = butLucario;
                    }
                    else if (team2Poke2.Image == null)
                    {
                        team2Poke2.Image = butLucario;
                    }
                    else if (team2Poke3.Image == null)
                    {
                        team2Poke3.Image = butLucario;
                    }
                    else if (team2Poke4.Image == null)
                    {
                        team2Poke4.Image = butLucario;
                    }
                    else if (team2Poke5.Image == null)
                    {
                        team2Poke5.Image = butLucario;
                    }
                    else if (team2Poke6.Image == null)
                    {
                        team2Poke6.Image = butLucario;
                    }
                    speed2 = 306;
                    attack2 = 350;
                    health2 = 344;

                    CPUHealth.Maximum = health2;
                    CPUHealth.Value = health2;
                    CPUHealth.Refresh();
                }
                else if (ranNum == 18)
                {
                    if (team2Poke.Image == null)
                    {
                        team2Poke.Image = butGarchomp;
                    }
                    else if (team2Poke2.Image == null)
                    {
                        team2Poke2.Image = butGarchomp;
                    }
                    else if (team2Poke3.Image == null)
                    {
                        team2Poke3.Image = butGarchomp;
                    }
                    else if (team2Poke4.Image == null)
                    {
                        team2Poke4.Image = butGarchomp;
                    }
                    else if (team2Poke5.Image == null)
                    {
                        team2Poke5.Image = butGarchomp;
                    }
                    else if (team2Poke6.Image == null)
                    {
                        team2Poke6.Image = butGarchomp;
                    }
                    speed2 = 0;
                    attack2 = 0;
                    health2 = 0;

                    CPUHealth.Maximum = health2;
                    CPUHealth.Value = health2;
                    CPUHealth.Refresh();
                }
                else if (ranNum == 19)
                {
                    if (team2Poke.Image == null)
                    {
                        team2Poke.Image = butMewtwo;
                    }
                    else if (team2Poke2.Image == null)
                    {
                        team2Poke2.Image = butMewtwo;
                    }
                    else if (team2Poke3.Image == null)
                    {
                        team2Poke3.Image = butMewtwo;
                    }
                    else if (team2Poke4.Image == null)
                    {
                        team2Poke4.Image = butMewtwo;
                    }
                    else if (team2Poke5.Image == null)
                    {
                        team2Poke5.Image = butMewtwo;
                    }
                    else if (team2Poke6.Image == null)
                    {
                        team2Poke6.Image = butMewtwo;
                    }
                    speed2 = 262;
                    attack2 = 405;
                    health2 = 364;

                    CPUHealth.Maximum = health2;
                    CPUHealth.Value = health2;
                    CPUHealth.Refresh();
                }
                else if (ranNum == 20)
                {
                    if (team2Poke.Image == null)
                    {
                        team2Poke.Image = butPikachu;
                    }
                    else if (team2Poke2.Image == null)
                    {
                        team2Poke2.Image = butPikachu;
                    }
                    else if (team2Poke3.Image == null)
                    {
                        team2Poke3.Image = butPikachu;
                    }
                    else if (team2Poke4.Image == null)
                    {
                        team2Poke4.Image = butPikachu;
                    }
                    else if (team2Poke5.Image == null)
                    {
                        team2Poke5.Image = butPikachu;
                    }
                    else if (team2Poke6.Image == null)
                    {
                        team2Poke6.Image = butPikachu;
                    }
                    speed2 = 306;
                    attack2 = 229;
                    health2 = 274;

                    CPUHealth.Maximum = health2;
                    CPUHealth.Value = health2;
                    CPUHealth.Refresh();
                }
                else if (ranNum == 21)
                {
                    if (team2Poke.Image == null)
                    {
                        team2Poke.Image = butSceptile;
                    }
                    else if (team2Poke2.Image == null)
                    {
                        team2Poke2.Image = butSceptile;
                    }
                    else if (team2Poke3.Image == null)
                    {
                        team2Poke3.Image = butSceptile;
                    }
                    else if (team2Poke4.Image == null)
                    {
                        team2Poke4.Image = butSceptile;
                    }
                    else if (team2Poke5.Image == null)
                    {
                        team2Poke5.Image = butSceptile;
                    }
                    else if (team2Poke6.Image == null)
                    {
                        team2Poke6.Image = butSceptile;
                    }
                    speed2 = 372;
                    attack2 = 295;
                    health2 = 344;

                    CPUHealth.Maximum = health2;
                    CPUHealth.Value = health2;
                    CPUHealth.Refresh();
                }
                else if (ranNum == 22)
                {
                    if (team2Poke.Image == null)
                    {
                        team2Poke.Image = butShedinja;
                    }
                    else if (team2Poke2.Image == null)
                    {
                        team2Poke2.Image = butShedinja;
                    }
                    else if (team2Poke3.Image == null)
                    {
                        team2Poke3.Image = butShedinja;
                    }
                    else if (team2Poke4.Image == null)
                    {
                        team2Poke4.Image = butShedinja;
                    }
                    else if (team2Poke5.Image == null)
                    {
                        team2Poke5.Image = butShedinja;
                    }
                    else if (team2Poke6.Image == null)
                    {
                        team2Poke6.Image = butShedinja;
                    }
                    speed2 = 196;
                    attack2 = 306;
                    health2 = 1;

                    CPUHealth.Maximum = health2;
                    CPUHealth.Value = health2;
                    CPUHealth.Refresh();
                }
                else if (ranNum == 23)
                {
                    if (team2Poke.Image == null)
                    {
                        team2Poke.Image = butSteelix;
                    }
                    else if (team2Poke2.Image == null)
                    {
                        team2Poke2.Image = butSteelix;
                    }
                    else if (team2Poke3.Image == null)
                    {
                        team2Poke3.Image = butSteelix;
                    }
                    else if (team2Poke4.Image == null)
                    {
                        team2Poke4.Image = butSteelix;
                    }
                    else if (team2Poke5.Image == null)
                    {
                        team2Poke5.Image = butSteelix;
                    }
                    else if (team2Poke6.Image == null)
                    {
                        team2Poke6.Image = butSteelix;
                    }
                    speed2 = 251;
                    attack2 = 295;
                    health2 = 354;

                    CPUHealth.Maximum = health2;
                    CPUHealth.Value = health2;
                    CPUHealth.Refresh();
                }
                else if (ranNum == 24)
                {
                    if (team2Poke.Image == null)
                    {
                        team2Poke.Image = butSylveon;
                    }
                    else if (team2Poke2.Image == null)
                    {
                        team2Poke2.Image = butSylveon;
                    }
                    else if (team2Poke3.Image == null)
                    {
                        team2Poke3.Image = butSylveon;
                    }
                    else if (team2Poke4.Image == null)
                    {
                        team2Poke4.Image = butSylveon;
                    }
                    else if (team2Poke5.Image == null)
                    {
                        team2Poke5.Image = butSylveon;
                    }
                    else if (team2Poke6.Image == null)
                    {
                        team2Poke6.Image = butSylveon;
                    }
                    speed2 = 394;
                    attack2 = 251;
                    health2 = 240;

                    CPUHealth.Maximum = health2;
                    CPUHealth.Value = health2;
                    CPUHealth.Refresh();
                }
                else if (ranNum == 25)
                {
                    if (team2Poke.Image == null)
                    {
                        team2Poke.Image = butTalonflame;
                    }
                    else if (team2Poke2.Image == null)
                    {
                        team2Poke2.Image = butTalonflame;
                    }
                    else if (team2Poke3.Image == null)
                    {
                        team2Poke3.Image = butTalonflame;
                    }
                    else if (team2Poke4.Image == null)
                    {
                        team2Poke4.Image = butTalonflame;
                    }
                    else if (team2Poke5.Image == null)
                    {
                        team2Poke5.Image = butTalonflame;
                    }
                    else if (team2Poke6.Image == null)
                    {
                        team2Poke6.Image = butTalonflame;
                    }
                    speed2 = 386;
                    attack2 = 287;
                    health2 = 360;

                    CPUHealth.Maximum = health2;
                    CPUHealth.Value = health2;
                    CPUHealth.Refresh();
                }
                else if (ranNum == 26)
                {
                    if (team2Poke.Image == null)
                    {
                        team2Poke.Image = butToxapex;
                    }
                    else if (team2Poke2.Image == null)
                    {
                        team2Poke2.Image = butToxapex;
                    }
                    else if (team2Poke3.Image == null)
                    {
                        team2Poke3.Image = butToxapex;
                    }
                    else if (team2Poke4.Image == null)
                    {
                        team2Poke4.Image = butToxapex;
                    }
                    else if (team2Poke5.Image == null)
                    {
                        team2Poke5.Image = butToxapex;
                    }
                    else if (team2Poke6.Image == null)
                    {
                        team2Poke6.Image = butToxapex;
                    }
                    speed2 = 386;
                    attack2 = 287;
                    health2 = 360;

                    CPUHealth.Maximum = health2;
                    CPUHealth.Value = health2;
                    CPUHealth.Refresh();
                }
                else if (ranNum == 27)
                {
                    if (team2Poke.Image == null)
                    {
                        team2Poke.Image = butTyranitar;
                    }
                    else if (team2Poke2.Image == null)
                    {
                        team2Poke2.Image = butTyranitar;
                    }
                    else if (team2Poke3.Image == null)
                    {
                        team2Poke3.Image = butTyranitar;
                    }
                    else if (team2Poke4.Image == null)
                    {
                        team2Poke4.Image = butTyranitar;
                    }
                    else if (team2Poke5.Image == null)
                    {
                        team2Poke5.Image = butTyranitar;
                    }
                    else if (team2Poke6.Image == null)
                    {
                        team2Poke6.Image = butTyranitar;
                    }
                    speed2 = 243;
                    attack2 = 403;
                    health2 = 404;

                    CPUHealth.Maximum = health2;
                    CPUHealth.Value = health2;
                    CPUHealth.Refresh();
                }
                else if (ranNum == 28)
                {
                    if (team2Poke.Image == null)
                    {
                        team2Poke.Image = butToxicroak;
                    }
                    else if (team2Poke2.Image == null)
                    {
                        team2Poke2.Image = butToxicroak;
                    }
                    else if (team2Poke3.Image == null)
                    {
                        team2Poke3.Image = butToxicroak;
                    }
                    else if (team2Poke4.Image == null)
                    {
                        team2Poke4.Image = butToxicroak;
                    }
                    else if (team2Poke5.Image == null)
                    {
                        team2Poke5.Image = butToxicroak;
                    }
                    else if (team2Poke6.Image == null)
                    {
                        team2Poke6.Image = butToxicroak;
                    }
                    speed2 = 295;
                    attack2 = 342;
                    health2 = 370;

                    CPUHealth.Maximum = health2;
                    CPUHealth.Value = health2;
                    CPUHealth.Refresh();
                }
                else if (ranNum == 29)
                {
                    if (team2Poke.Image == null)
                    {
                        team2Poke.Image = butVenusaur;
                    }
                    else if (team2Poke2.Image == null)
                    {
                        team2Poke2.Image = butVenusaur;
                    }
                    else if (team2Poke3.Image == null)
                    {
                        team2Poke3.Image = butVenusaur;
                    }
                    else if (team2Poke4.Image == null)
                    {
                        team2Poke4.Image = butVenusaur;
                    }
                    else if (team2Poke5.Image == null)
                    {
                        team2Poke5.Image = butVenusaur;
                    }
                    else if (team2Poke6.Image == null)
                    {
                        team2Poke6.Image = butVenusaur;
                    }
                    speed2 = 284;
                    attack2 = 289;
                    health2 = 364;

                    CPUHealth.Maximum = health2;
                    CPUHealth.Value = health2;
                    CPUHealth.Refresh();
                }
                else if (ranNum == 30)
                {
                    if (team2Poke.Image == null)
                    {
                        team2Poke.Image = butVikavolt;
                    }
                    else if (team2Poke2.Image == null)
                    {
                        team2Poke2.Image = butVikavolt;
                    }
                    else if (team2Poke3.Image == null)
                    {
                        team2Poke3.Image = butVikavolt;
                    }
                    else if (team2Poke4.Image == null)
                    {
                        team2Poke4.Image = butVikavolt;
                    }
                    else if (team2Poke5.Image == null)
                    {
                        team2Poke5.Image = butVikavolt;
                    }
                    else if (team2Poke6.Image == null)
                    {
                        team2Poke6.Image = butVikavolt;
                    }
                    speed2 = 203;
                    attack2 = 262;
                    health2 = 358;

                    CPUHealth.Maximum = health2;
                    CPUHealth.Value = health2;
                    CPUHealth.Refresh();

                }
                else if (ranNum == 30)
                {
                    if (team2Poke.Image == null)
                    {
                        team2Poke.Image = butZapdos;
                    }
                    else if (team2Poke2.Image == null)
                    {
                        team2Poke2.Image = butZapdos;
                    }
                    else if (team2Poke3.Image == null)
                    {
                        team2Poke3.Image = butZapdos;
                    }
                    else if (team2Poke4.Image == null)
                    {
                        team2Poke4.Image = butZapdos;
                    }
                    else if (team2Poke5.Image == null)
                    {
                        team2Poke5.Image = butZapdos;
                    }
                    else if (team2Poke6.Image == null)
                    {
                        team2Poke6.Image = butZapdos;
                    }
                    speed2 = 328;
                    attack2 = 306;
                    health2 = 384;

                    CPUHealth.Maximum = health2;
                    CPUHealth.Value = health2;
                    CPUHealth.Refresh();
                }

            }


            if (PlayerPokemon[0] == butArticuno)
            {
                PlayerPokeAndMoves[PlayerPokemon[0]] = new List<String> { "Brave Bird", "Hurricane", "Ice Shard", "Frost Breath" };
                for (int j = 0; j < Move.Count; j++) { Move[j].Text = PlayerPokeAndMoves[PlayerPokemon[0]][j]; }
                speed1 = 295;
                attack1 = 295;
                health1 = 384;

                PlayerHealth.Maximum = health1;
                PlayerHealth.Value = health1;

            }
            else if (PlayerPokemon[0] == butAerodactyl)
            {
                PlayerPokeAndMoves[PlayerPokemon[0]] = new List<String> { "Taunt", "Stealth Rock", "Stone Edge", "Aeiral Ace" };
                for (int j = 0; j < Move.Count; j++) { Move[j].Text = PlayerPokeAndMoves[PlayerPokemon[0]][j]; }
                speed1 = 394;
                attack1 = 339;
                health1 = 364;

                PlayerHealth.Maximum = health1;
                PlayerHealth.Value = health1;
            }
            else if (PlayerPokemon[0] == butBarbaracle)
            {
                PlayerPokeAndMoves[PlayerPokemon[0]] = new List<String> { "Shell Smash", "Dragon Claw", "Razor Shell", "Stone Edge" };
                for (int j = 0; j < Move.Count; j++) { Move[j].Text = PlayerPokeAndMoves[PlayerPokemon[0]][j]; }
                speed1 = 258;
                attack1 = 339;
                health1 = 348;

                PlayerHealth.Maximum = health1;
                PlayerHealth.Value = health1;
            }
            else if (PlayerPokemon[0] == butBlastoise)
            {
                PlayerPokeAndMoves[PlayerPokemon[0]] = new List<String> { "Water Pulse", "Aura Sphere", "Dragon Pulse", "Dark Pulse" };
                for (int j = 0; j < Move.Count; j++) { Move[j].Text = PlayerPokeAndMoves[PlayerPokemon[0]][j]; }

                speed1 = 280;
                attack1 = 291;
                health1 = 362;

                PlayerHealth.Maximum = health1;
                PlayerHealth.Value = health1;
            }
            else if (PlayerPokemon[0] == butBlaziken)
            {
                PlayerPokeAndMoves[PlayerPokemon[0]] = new List<String> { "Stone Edge", "Hone Claws", "Blaze Kick", "High Jump Kick" };
                for (int j = 0; j < Move.Count; j++) { Move[j].Text = PlayerPokeAndMoves[PlayerPokemon[0]][j]; }

                speed1 = 284;
                attack1 = 372;
                health1 = 364;
                PlayerHealth.Maximum = health1;
                PlayerHealth.Value = health1;
            }
            else if (PlayerPokemon[0] == butCharizard)
            {
                PlayerPokeAndMoves[PlayerPokemon[0]] = new List<String> { "Earthquake", "Dragon Claw", "Dragon Dance", "Fire Blitz" };
                for (int j = 0; j < Move.Count; j++) { Move[j].Text = PlayerPokeAndMoves[PlayerPokemon[0]][j]; }
                speed1 = 328;
                attack1 = 293;
                health1 = 360;

                PlayerHealth.Maximum = health1;
                PlayerHealth.Value = health1;
            }
            else if (PlayerPokemon[0] == butDragapult)
            {
                PlayerPokeAndMoves[PlayerPokemon[0]] = new List<String> { "Dragon Darts", "Dragon Dance", "Night Shade", "Shadow Ball" };
                for (int j = 0; j < Move.Count; j++) { Move[j].Text = PlayerPokeAndMoves[PlayerPokemon[0]][j]; }
                speed1 = 421;
                attack1 = 372;
                health1 = 380;

                PlayerHealth.Maximum = health1;
                PlayerHealth.Value = health1;
            }
            else if (PlayerPokemon[0] == butDragonite)
            {
                PlayerPokeAndMoves[PlayerPokemon[0]] = new List<String> { "Outrage", "Earthquake", "Crunch", "Stone Edge" };
                for (int j = 0; j < Move.Count; j++) { Move[j].Text = PlayerPokeAndMoves[PlayerPokemon[0]][j]; }
                speed1 = 284;
                attack1 = 403;
                health1 = 386;

                PlayerHealth.Maximum = health1;
                PlayerHealth.Value = health1;
            }
            else if (PlayerPokemon[0] == butFroslass)
            {
                PlayerPokeAndMoves[PlayerPokemon[0]] = new List<String> { "Shadow Claw", "Thunder Wave", "Shadow Ball", "Ice Beam" };
                for (int j = 0; j < Move.Count; j++) { Move[j].Text = PlayerPokeAndMoves[PlayerPokemon[0]][j]; }
                speed1 = 350;
                attack1 = 284;
                health1 = 344;

                PlayerHealth.Maximum = health1;
                PlayerHealth.Value = health1;
            }
            else if (PlayerPokemon[0] == butGardevoir)
            {
                PlayerPokeAndMoves[PlayerPokemon[0]] = new List<String> { "Psychic", "Thunderbolt", "Shadow Ball", "Misty Explosion" };
                for (int j = 0; j < Move.Count; j++) { Move[j].Text = PlayerPokeAndMoves[PlayerPokemon[0]][j]; }
                speed1 = 284;
                attack1 = 251;
                health1 = 340;

                PlayerHealth.Maximum = health1;
                PlayerHealth.Value = health1;
            }
            else if (PlayerPokemon[0] == butGengar)
            {
                PlayerPokeAndMoves[PlayerPokemon[0]] = new List<String> { "Shadow Ball", "Thunderbolt", "Poltergeist", "Sludge Ball" };
                for (int j = 0; j < Move.Count; j++) { Move[j].Text = PlayerPokeAndMoves[PlayerPokemon[0]][j]; }
                speed1 = 350;
                attack1 = 251;
                health1 = 324;

                PlayerHealth.Maximum = health1;
                PlayerHealth.Value = health1;
            }
            else if (PlayerPokemon[0] == butGroudon)
            {
                PlayerPokeAndMoves[PlayerPokemon[0]] = new List<String> { "Fire Blast", "Earthquake", "Stone Edge", "Solar Beam" };
                for (int j = 0; j < Move.Count; j++) { Move[j].Text = PlayerPokeAndMoves[PlayerPokemon[0]][j]; }
                speed1 = 306;
                attack1 = 438;
                health1 = 404;

                PlayerHealth.Maximum = health1;
                PlayerHealth.Value = health1;
            }
            else if (PlayerPokemon[0] == butKrookodile)
            {
                PlayerPokeAndMoves[PlayerPokemon[0]] = new List<String> { "Outrage", "Earthquake", "Crunch", "Stone Edge" };
                for (int j = 0; j < Move.Count; j++) { Move[j].Text = PlayerPokeAndMoves[PlayerPokemon[0]][j]; }
                speed1 = 311;
                attack1 = 366;
                health1 = 394;

                PlayerHealth.Maximum = health1;
                PlayerHealth.Value = health1;
            }
            else if (PlayerPokemon[0] == butKyogre)
            {
                PlayerPokeAndMoves[PlayerPokemon[0]] = new List<String> { "Water Spout", "Thunder", "Ice beam", "Origin Pulse" };
                for (int j = 0; j < Move.Count; j++) { Move[j].Text = PlayerPokeAndMoves[PlayerPokemon[0]][j]; }
                speed1 = 306;
                attack1 = 328;
                health1 = 404;

                PlayerHealth.Maximum = health1;
                PlayerHealth.Value = health1;
            }
            else if (PlayerPokemon[0] == butLucario)
            {
                PlayerPokeAndMoves[PlayerPokemon[0]] = new List<String> { "Sword Stance", "High Jump Kick", "Shadow Claw", "Ice Punch" };
                for (int j = 0; j < Move.Count; j++) { Move[j].Text = PlayerPokeAndMoves[PlayerPokemon[0]][j]; }
                speed1 = 306;
                attack1 = 350;
                health1 = 344;

                PlayerHealth.Maximum = health1;
                PlayerHealth.Value = health1;
            }
            else if (PlayerPokemon[0] == butGarchomp)
            {
                PlayerPokeAndMoves[PlayerPokemon[0]] = new List<String> { "Sword Stance", "Earthquake", "Dragon Claw", "Outrage" };
                for (int j = 0; j < Move.Count; j++) { Move[j].Text = PlayerPokeAndMoves[PlayerPokemon[0]][j]; }
                speed1 = 333;
                attack1 = 394;
                health1 = 420;

                PlayerHealth.Maximum = health1;
                PlayerHealth.Value = health1;
            }
            else if (PlayerPokemon[0] == butMewtwo)
            {
                PlayerPokeAndMoves[PlayerPokemon[0]] = new List<String> { "Aura Sphere", "Thunder", "Shadow Ball", "Ice Beam" };
                for (int j = 0; j < Move.Count; j++) { Move[j].Text = PlayerPokeAndMoves[PlayerPokemon[0]][j]; }
                speed1 = 262;
                attack1 = 405;
                health1 = 364;

                PlayerHealth.Maximum = health1;
                PlayerHealth.Value = health1;
            }
            else if (PlayerPokemon[0] == butPikachu)
            {
                PlayerPokeAndMoves[PlayerPokemon[0]] = new List<String> { "Brick Break", "Thunderbolt", "Thunder Punch", "Quick Attack" };
                for (int j = 0; j < Move.Count; j++) { Move[j].Text = PlayerPokeAndMoves[PlayerPokemon[0]][j]; }
                speed1 = 306;
                attack1 = 229;
                health1 = 274;

                PlayerHealth.Maximum = health1;
                PlayerHealth.Value = health1;
            }
            else if (PlayerPokemon[0] == butSceptile)
            {
                PlayerPokeAndMoves[PlayerPokemon[0]] = new List<String> { "Hone Claws", "Leaf Blade", "Dynamic Punch", "Rock Slide" };
                for (int j = 0; j < Move.Count; j++) { Move[j].Text = PlayerPokeAndMoves[PlayerPokemon[0]][j]; }
                speed1 = 372;
                attack1 = 295;
                health1 = 344;

                PlayerHealth.Maximum = health1;
                PlayerHealth.Value = health1;
            }
            else if (PlayerPokemon[0] == butShedinja)
            {
                PlayerPokeAndMoves[PlayerPokemon[0]] = new List<String> { "Shadow Snake", "Sword Stance", "Giga Impact", "X-Scissor" };
                for (int j = 0; j < Move.Count; j++) { Move[j].Text = PlayerPokeAndMoves[PlayerPokemon[0]][j]; }
                speed1 = 196;
                attack1 = 306;
                health1 = 1;

                PlayerHealth.Maximum = health1;
                PlayerHealth.Value = health1;
            }
            else if (PlayerPokemon[0] == butSteelix)
            {
                PlayerPokeAndMoves[PlayerPokemon[0]] = new List<String> { "Iron Tail", "Earthquake", "Rock Slide", "Crunch" };
                for (int j = 0; j < Move.Count; j++) { Move[j].Text = PlayerPokeAndMoves[PlayerPokemon[0]][j]; }
                speed1 = 251;
                attack1 = 295;
                health1 = 354;

                PlayerHealth.Maximum = health1;
                PlayerHealth.Value = health1;
            }
            else if (PlayerPokemon[0] == butSylveon)
            {
                PlayerPokeAndMoves[PlayerPokemon[0]] = new List<String> { "Hypervoice", "Psyschock", "Shadow Ball", "Calm mind" };
                for (int j = 0; j < Move.Count; j++) { Move[j].Text = PlayerPokeAndMoves[PlayerPokemon[0]][j]; }
                speed1 = 394;
                attack1 = 251;
                health1 = 240;

                PlayerHealth.Maximum = health1;
                PlayerHealth.Value = health1;
            }
            else if (PlayerPokemon[0] == butTalonflame)
            {
                PlayerPokeAndMoves[PlayerPokemon[0]] = new List<String> { "Sword Stance", "Hurricane", "Flair Blitz", "Roost" };
                for (int j = 0; j < Move.Count; j++) { Move[j].Text = PlayerPokeAndMoves[PlayerPokemon[0]][j]; }
                speed1 = 386;
                attack1 = 287;
                health1 = 360;

                PlayerHealth.Maximum = health1;
                PlayerHealth.Value = health1;
            }
            else if (PlayerPokemon[0] == butToxapex)
            {
                PlayerPokeAndMoves[PlayerPokemon[0]] = new List<String> { "Gunk Shot", "Scald", "Liquidation", "Mud Slap" };
                for (int j = 0; j < Move.Count; j++) { Move[j].Text = PlayerPokeAndMoves[PlayerPokemon[0]][j]; }
                speed1 = 386;
                attack1 = 287;
                health1 = 360;

                PlayerHealth.Maximum = health1;
                PlayerHealth.Value = health1;
            }
            else if (PlayerPokemon[0] == butTyranitar)
            {
                PlayerPokeAndMoves[PlayerPokemon[0]] = new List<String> { "Fire Punch", "Dragon Dance", "Stone Edge", "Ice Punch" };
                for (int j = 0; j < Move.Count; j++) { Move[j].Text = PlayerPokeAndMoves[PlayerPokemon[0]][j]; }
                speed1 = 243;
                attack1 = 403;
                health1 = 404;

                PlayerHealth.Maximum = health1;
                PlayerHealth.Value = health1;
            }
            else if (PlayerPokemon[0] == butToxicroak)
            {
                PlayerPokeAndMoves[PlayerPokemon[0]] = new List<String> { "Acid Spray", "Gunk Shot", "Mud Slap", "Ice Punch" };
                for (int j = 0; j < Move.Count; j++) { Move[j].Text = PlayerPokeAndMoves[PlayerPokemon[0]][j]; }
                speed1 = 295;
                attack1 = 342;
                health1 = 370;

                PlayerHealth.Maximum = health1;
                PlayerHealth.Value = health1;
            }
            else if (PlayerPokemon[0] == butVenusaur)
            {
                PlayerPokeAndMoves[PlayerPokemon[0]] = new List<String> { "Solar Beam", "Earthquake", "Hidden Power", "Growth" };
                for (int j = 0; j < Move.Count; j++) { Move[j].Text = PlayerPokeAndMoves[PlayerPokemon[0]][j]; }
                speed1 = 284;
                attack1 = 289;
                health1 = 364;

                PlayerHealth.Maximum = health1;
                PlayerHealth.Value = health1;
            }
            else if (PlayerPokemon[0] == butVikavolt)
            {
                PlayerPokeAndMoves[PlayerPokemon[0]] = new List<String> { "Bug Buzz", "Thunder", "Flash Cannon", "Crunch" };
                for (int j = 0; j < Move.Count; j++) { Move[j].Text = PlayerPokeAndMoves[PlayerPokemon[0]][j]; }
                speed1 = 203;
                attack1 = 262;
                health1 = 358;

                PlayerHealth.Maximum = health1;
                PlayerHealth.Value = health1;
            }
            else if (PlayerPokemon[0] == butZapdos)
            {
                PlayerPokeAndMoves[PlayerPokemon[0]] = new List<String> { "Thunderbolt", "Thunder", "Roost", "Gunk Shot" };
                for (int j = 0; j < Move.Count; j++) { Move[j].Text = PlayerPokeAndMoves[PlayerPokemon[0]][j]; }
                speed1 = 328;
                attack1 = 306;
                health1 = 384;

                PlayerHealth.Maximum = health1;
                PlayerHealth.Value = health1;
            }
        }
        private int Rockslide(int CPUHealthCur)
        {
            Random rnd = new Random();
            int ran = rnd.Next(1, 10);
            int dmg = 75;
            if (ran / 10 <= 0.1)
            {
                return CPUHealthCur - dmg;
            }
            return 0;
        }

        private int StoneEdge()
        {
            Random rnd = new Random();
            int ran = rnd.Next(1, 5);
            int dmg = 100;
            if (ran / 5 <= .20)
            {
                return 0;
            }
            else
            {
                return dmg;
            }
        }

        private int RazorShell()
        {
            Random rnd = new Random();
            int ran = rnd.Next(1, 20);
            int dmg = 75;

            if (ran / 20 <= .20)
            {
                return 0;
            }
            else
            {
                return dmg;
            }

        }

        private int DragonClaw()
        {
            int dmg = 80;
            return dmg;
        }

        private int Earthquake()
        {
            int dmg = 100;
            return dmg;
        }

        private int Crunch()
        {
            int dmg = 80;
            return dmg;
        }

        private int WaterPulse(int CPUHealthCur)
        {
            Random rnd = new Random();
            int ran = rnd.Next(1, 5);
            if (ran == 2)
            {
                int dmg = 80;
                if (CPUHealthCur - dmg <= 0)
                {
                    return 0;
                }
                else
                    return CPUHealthCur - dmg;
            }
            else
            {
                int dmg = 60;
                if (CPUHealthCur - dmg <= 0)
                {
                    return 0;
                }
                else
                    return CPUHealthCur - dmg;
            }
        }

        private int AuraSphere()
        {
            int dmg = 80;
            return dmg;
        }

        private int DragonPulse()
        {
            int dmg = 85;
            return dmg;
        }
        private int DarkPulse()
        {
            int dmg = 80;
            return dmg;
        }

        private int BraveBird(int PokemonHealth)
        {
            double dmg_to_self = PokemonHealth * 0.25;
            int dmg = 120;
            return dmg;
        }

        private int Hurricane()
        {
            Random rnd = new Random();
            int ran = rnd.Next(1, 10);
            //do three numbers
            int dmg = 130;
            if (ran / 10 <= .20)
            {
                return 0;
            }
            else
            {
                return dmg;
            }

        }

        private int IceShard()
        {
            int dmg = 40;
            return dmg;
        }

        private int FrostBreath()
        {
            Random rnd = new Random();
            int ran = rnd.Next(1, 10);
            int dmg = 60;
            if (ran / 10 <= .20)
            {
                return 0;
            }
            else
            {
                return dmg;
            }
        }

        private int BlazeKick()
        {
            Random rnd = new Random();
            int ran = rnd.Next(1, 10);
            int dmg = 85;
            if (ran / 10 <= .20)
            {
                return 0;
            }
            else
            {
                return dmg;
            }
        }

        private int HighJumpKick(double PokemaxHealth)
        {
            bool hit = false;
            Random rnd = new Random();
            int ran = rnd.Next(1, 5);
            int dmg = 85;
            if (ran / 5 <= .20)
            {
                return 0;
            }
            else
            {
                return dmg;
            }
        }

        private int FlairBlitz(double PokemaxHealth)
        {
            double dmg_to_self = PokemaxHealth * 0.25;
            int dmg = 120;
            return dmg;
        }

        private int DragonDarts()
        {
            int dmg = 100;
            return dmg;
        }

        private int NightShade()
        {
            int dmg = 50;
            return dmg;
        }
        private int ShadowBall()
        {
            //1 in 5 def lower
            int dmg = 80;
            return dmg;
        }

        private int WaterSpout(int pokecurhealth, int pokeHPmax)
        {
            //deals damage based on current user hp
            //(150 * hpcur) / hpmax
            int dmg = (150 * pokecurhealth) / pokeHPmax;
            return dmg;
        }

        private int Thunder()
        {
            Random rnd = new Random();
            int ran = rnd.Next(1, 10);
            //do three numbers
            int dmg = 110;
            if (ran / 10 <= .20)
            {
                return 0;
            }
            else
            {
                return dmg;
            }
        }

        private int IceBeam()
        {
            int dmg = 90;
            return dmg;
        }

        private int OriginPulse()
        {
            Random rnd = new Random();
            int ran = rnd.Next(1, 5);
            int dmg = 190;
            if (ran / 5 <= .20)
            {
                return 0;
            }
            else
            {
                return dmg;
            }

        }

        private int BrickBreak()
        {
            int dmg = 75;
            return dmg;
        }

        private int ThunderBolt()
        {
            int dmg = 90;
            return dmg;
        }

        private int ThunderPunch()
        {
            int dmg = 75;
            return dmg;
        }

        private int QuickAttack()
        {
            int speed = 999;
            int dmg = 40;
            return dmg;
        }

        private int LeafBlade()
        {
            int dmg = 90;
            return dmg;
        }

        private int DynamicPunch()
        {
            //50% acc 100% confussion
            int dmg = 100;
            return dmg;
        }

        private int ShadowSneak()
        {
            int speed = 999;
            int dmg = 40;
            return dmg;
        }

        private int XScissor()
        {
            int dmg = 80;
            return dmg;
        }

        private int HiddenPower()
        {
            int dmg = 60;
            return dmg;
        }

        private int FirePunch()
        {
            int dmg = 75;
            return dmg;
        }

        private int ShadowClaw()
        {
            int dmg = 70;
            return dmg;
        }

        private int Psychic()
        {
            Random rdn = new Random();
            int ran = rdn.Next(1, 10);
            int dmg = 90;

            if (ran == 3)
            {
                dmg += 10;
            }

            return dmg;
        }

        private int MistyExplosion()
        {
            int dmg = 100;
            return dmg;
        }

        private int Poltergeist()
        {
            int dmg = 40;
            return dmg;
        }

        private int SludgeBall()
        {
            int dmg = 90;
            return dmg;
        }

        private int FireBlast()
        {
            //80% acc
            int dmg = 110;
            return dmg;
        }

        private int FlameCharge()
        {
            //raises speed by one stage
            int dmg = 50;
            return dmg;
        }

        private int DarkestLariat()
        {
            int dmg = 85;
            return dmg;
        }

        private int IcePunch()
        {
            int dmg = 75;
            return dmg;
        }

        private int HyperVoice()
        {
            int dmg = 90;
            return dmg;
        }

        private int IronTail()
        {
            //30% chance of lowering def by one stage by lower 70%acc
            int dmg = 100;
            return dmg;
        }

        private int PsyShock()
        {
            int dmg = 80;
            return dmg;
        }

        private int GunkShot()
        {
            //80% acc
            int dmg = 120;
            return dmg;
        }

        private int Scald()
        {
            int dmg = 80;
            return dmg;
        }

        private int Liquidation()
        {
            int dmg = 85;
            return dmg;
        }

        private int MudSlap()
        {
            int dmg = 20;
            return dmg;
        }

        private int BugBuzz()
        {
            //10% lowering targ def by one stage
            int dmg = 90;
            return dmg;
        }

        private int FlashCannon()
        {
            //10% lowering targ def by one stage
            int dmg = 80;
            return dmg;
        }

        //Move Battle System
        private void CPUMoves(List<Image> CPUpokemon)
        {
            for (int i = 0; i < CPUpokemon.Count; i++)
            {

            }
        }


        private void Move1_Click(object sender, EventArgs e)
        {
            if (Move1.Text == "Water Pulse")
            {
                CPUHealth.Value = WaterPulse(CPUHealth.Value);
                if (CPUHealth.Value == CPUHealth.Minimum)
                {
                    team2Poke.Image = team2Poke2.Image;
                    team2Poke2.Image = team2Poke3.Image;
                    team2Poke3.Image = team2Poke4.Image;
                    team2Poke4.Image = team2Poke5.Image;
                    team2Poke5.Image = team2Poke6.Image;
                    team2Poke6.Image = team2Poke7.Image;
                }
            }
            else if (Move1.Text == "BraveBird")
            {
                CPUHealth.Value = BraveBird(CPUHealth.Value);
                if (CPUHealth.Value == CPUHealth.Minimum)
                {
                    team2Poke.Image = team2Poke2.Image;
                    team2Poke2.Image = team2Poke3.Image;
                    team2Poke3.Image = team2Poke4.Image;
                    team2Poke4.Image = team2Poke5.Image;
                    team2Poke5.Image = team2Poke6.Image;
                    team2Poke6.Image = team2Poke7.Image;
                }
            }
            else if (Move1.Text == "Taunt")
            {

            }
            else if (Move1.Text == "Shell Smash")
            {

            }
            else if (Move1.Text == "Stone Edge")
            {

            }
            else if (Move1.Text == "Earthquake")
            {

            }
            else if (Move1.Text == "Dragon Darts")
            {

            }
            else if (Move1.Text == "Outrage")
            {

            }
            else if (Move1.Text == "Shadow Claw")
            {

            }
            else if (Move1.Text == "Psychic")
            {

            }
            else if (Move1.Text == "Shadow Ball")
            {

            }
            else if (Move1.Text == "Fire Blast")
            {

            }
            else if (Move1.Text == "Water Spout")
            {

            }
            else if (Move1.Text == "Sword Stance")
            {

            }
            else if (Move1.Text == "Aura Sphere")
            {

            }
            else if (Move1.Text == "Brick Break")
            {

            }
            else if (Move1.Text == "Hone Claws")
            {

            }
            else if (Move1.Text == "Shadow Snake")
            {

            }
            else if (Move1.Text == "Iron Tail")
            {

            }
            else if (Move1.Text == "Hypervoice")
            {

            }
            else if (Move1.Text == "Gunk Shot")
            {

            }
            else if (Move1.Text == "Fire Punch")
            {

            }
            else if (Move1.Text == "Acid Spray")
            {

            }
            else if (Move1.Text == "Solar Beam")
            {

            }
            else if (Move1.Text == "Bug Buzz")
            {

            }
            else if (Move1.Text == "Thunderbolt")
            {

            }
        }

        private void Move2_Click(object sender, EventArgs e)
        {

            if (Move2.Text == "Hurricane")
            {

            }
            else if (Move2.Text == "Stealth Rock")
            {

            }
            else if (Move2.Text == "Dragon Claw")
            {

            }
            else if (Move2.Text == "Aura Sphere")
            {

            }
            else if (Move2.Text == "Hone Claws")
            {

            }
            else if (Move2.Text == "Dragon Dance")
            {

            }
            else if (Move2.Text == "Thunder Wave")
            {

            }
            else if (Move2.Text == "Thunderbolt")
            {

            }
            else if (Move2.Text == "Thunder")
            {

            }
            else if (Move2.Text == "Leaf Blade")
            {

            }
            else if (Move2.Text == "High Jump Kick")
            {

            }
            else if (Move2.Text == "Sword Stance")
            {

            }
            else if (Move2.Text == "Psyschock")
            {

            }
            else if (Move2.Text == "Scald")
            {

            }
            else if (Move2.Text == "Gunk Shot")
            {

            }
        }

        private void Move3_Click(object sender, EventArgs e)
        {
            if (Move3.Text == "Rock Slide")
            {
                CPUHealth.Value = Rockslide(CPUHealth.Value);
                if (CPUHealth.Value <= CPUHealth.Minimum)
                {
                    team2Poke.Image = team2Poke2.Image;
                    team2Poke2.Image = team2Poke3.Image;
                    team2Poke3.Image = team2Poke4.Image;
                    team2Poke4.Image = team2Poke6.Image;
                    team2Poke5.Image = team2Poke6.Image;
                    team2Poke6.Image = team2Poke7.Image;
                }
            }
            else if (Move3.Text == "Ice Shard")
            {

            }
            else if (Move3.Text == "Stone Edge")
            {

            }
            else if (Move3.Text == "Razor Shell")
            {

            }
            else if (Move3.Text == "Dragon Pulse")
            {

            }
            else if (Move3.Text == "Blaze Kick")
            {

            }
            else if (Move3.Text == "Dragon Dance")
            {

            }
            else if (Move3.Text == "Night Shade")
            {

            }
            else if (Move3.Text == "Crunch")
            {

            }
            else if (Move3.Text == "Shadow Ball")
            {

            }
            else if (Move3.Text == "Poltergeist")
            {

            }
            else if (Move3.Text == "Stone Edge")
            {

            }
            else if (Move3.Text == "Ice beam")
            {

            }
            else if (Move3.Text == "Shadow Claw")
            {

            }
            else if (Move3.Text == "Thunder Punch")
            {

            }
            else if (Move3.Text == "Dynamic Punch")
            {

            }
            else if (Move3.Text == "Giga Impact")
            {

            }
            else if (Move3.Text == "Flair Blitz")
            {

            }
            else if (Move3.Text == "Liquidation")
            {

            }
            else if (Move3.Text == "Mud Slap")
            {

            }
            else if (Move3.Text == "Hidden Power")
            {

            }
            else if (Move3.Text == "Flash Cannon")
            {

            }
            else if (Move3.Text == "Roost")
            {

            }

        }

        private void Move4_Click(object sender, EventArgs e)
        {
            if (Move4.Text == "Frost Breath")
            {

            }
            else if (Move4.Text == "Aeiral Ace")
            {

            }
            else if (Move4.Text == "Stone Edge")
            {

            }
            else if (Move4.Text == "Dark Pulse")
            {

            }
            else if (Move4.Text == "High Jump Kick")
            {

            }
            else if (Move4.Text == "Fire Blitz")
            {

            }
            else if (Move4.Text == "Shadow Ball")
            {

            }
            else if (Move4.Text == "Ice Beam")
            {

            }
            else if (Move4.Text == "Misty Explosion")
            {

            }
            else if (Move4.Text == "Sludge Ball")
            {

            }
            else if (Move4.Text == "Solar Beam")
            {

            }
            else if (Move4.Text == "Origin Pulse")
            {

            }
            else if (Move4.Text == "Ice Punch")
            {

            }
            else if (Move4.Text == "Outrage")
            {

            }
            else if (Move4.Text == "Quick Attack")
            {

            }
            else if (Move4.Text == "Rock Slide")
            {

            }
            else if (Move4.Text == "X-Scissor")
            {

            }
            else if (Move4.Text == "Crunch")
            {

            }
            else if (Move4.Text == "Calm mind")
            {

            }
            else if (Move4.Text == "Roost")
            {

            }
            else if (Move4.Text == "Growth")
            {

            }
            else if (Move4.Text == "Gunk Shot")
            {

            }

            
            
            
        }


        /*This function will be the cpu's moves*/
        public void team2Turn(Image butCharizard, Image butBlaziken, Image butBlastoise, Image butBarbaracle, Image butIncineroar, Image butAerodactyl, Image butArticuno, Image butDragapult, Image butDragonite, Image butFroslass, Image butGardevoir, Image butGengar, Image butGroudon, Image butKrookodile, Image butKyogre, Image butLucario, Image butGarchomp, Image butMewtwo, Image butPikachu, Image butSceptile, Image butShedinja, Image butSteelix, Image butSylveon, Image butTalonflame, Image butToxapex, Image butToxicroak, Image butTyranitar, Image butVenusaur, Image butVikavolt, Image butZapdos)
        {
            String move;
            int selectMove;


            if (CPUpokemon[0].Image == butAerodactyl)
            {

                List<string> moves = new List<string> { "Taunt", "Stealth Rock", "Stone Edge", "Aeiral Ace" };
                Random ran = new Random();
                selectMove = ran.Next(1, 5);

                move = moves[selectMove];

                if (move == "Taunt")
                {

                }
                else if (move == "Stealth Rock")
                {

                }
                else if (move == "Stone Edge")
                {

                }
                else if (move == "Aeiral Ace")
                {

                }
                moves.Clear();
            }

            else if (CPUpokemon[0].Image == butArticuno)
            {

                List<string> moves = new List<string> { "Brave Bird", "Hurricane", "Ice Shard", "Frost Breath" };
                Random ran = new Random();
                selectMove = ran.Next(1, 5);

                move = moves[selectMove];

                if (move == "Brave Bird")
                {

                }
                else if (move == "Hurricane")
                {

                }
                else if (move == "Ice Shard")
                {

                }
                else if (move == "Frost Breath")
                {

                }
                moves.Clear();
            }

            else if (CPUpokemon[0].Image == butBarbaracle)
            {

                List<string> moves = new List<string> { "Shell Smash", "Dragon Claw", "Razor Shell", "Stone Edge" };
                Random ran = new Random();
                selectMove = ran.Next(1, 5);

                move = moves[selectMove];

                if(move == "Shell Smash")
                {

                }
                else if(move == "Dragon Claw")
                {

                }
                else if (move == "Razor Shell")
                {

                }
                else if(move == "Stone Edge")
                {

                }
                moves.Clear();
            }

            else if (CPUpokemon[0].Image == butBlastoise)
            {
                List<string> moves = new List<string> { "Water Pulse", "Aura Sphere", "Dragon Pulse", "Dark Pulse" };
                Random ran = new Random();
                selectMove = ran.Next(1, 5);

                move = moves[selectMove];

                if (move == "Water Pulse")
                {

                }
                else if (move == "Aura Sphere")
                {
                    AuraSphere();
                }
                else if (move == "Dragon Pulse")
                {
                    DragonPulse();
                }
                else if (move == "Dark Pulse")
                {
                    DarkPulse();
                }

                moves.Clear();
            }

            else if (CPUpokemon[0].Image == butBlaziken) 
            {

                List<string> moves = new List<string> { "Stone Edge", "Hone Claws", "Blaze Kick", "High Jump Kick" };
                Random ran = new Random();
                selectMove = ran.Next(1, 5);

                move = moves[selectMove];

                if (move == "Stone Edge")
                {

                }
                else if (move == "Hone Claws")
                {
                    
                }
                else if (move == "Blaze Kick")
                {
                   
                }
                else if (move == "High Jump Kick")
                {
                    
                }
                moves.Clear();
            }

            else if (CPUpokemon[0].Image == butCharizard)
            {

                List<string> moves = new List<string> { "Earthquake", "Dragon Claw", "Dragon Dance", "Fire Blitz" };
                Random ran = new Random();
                selectMove = ran.Next(1, 5);

                move = moves[selectMove];

                if (move == "Earthquake")
                {

                }
                else if (move == "Dragon Claw")
                {

                }
                else if (move == "Dragon Dance")
                {

                }
                else if (move == "Fire Blitz")
                {

                }
                moves.Clear();
            }

            else if (CPUpokemon[0].Image == butDragapult)
            {

                List<string> moves = new List<string> { "Dragon Darts", "Dragon Dance", "Night Shade", "Shadow Ball" };
                
                
                Random ran = new Random();
                selectMove = ran.Next(1, 5);

                move = moves[selectMove];

                if (move == "Dragon Darts")
                {

                }
                else if (move == "Dragon Dance")
                {

                }
                else if (move == "Night Shade")
                {

                }
                else if (move == "Shadow Ball")
                {

                }
                moves.Clear();
            }

            else if (CPUpokemon[0].Image == butDragonite)
            {

                List<string> moves = new List<string> { "Dragon Dance", "Roost", "Dragon Claw", "Fire Punch" };


                Random ran = new Random();
                selectMove = ran.Next(1, 5);

                move = moves[selectMove];

                if (move == "Dragon Dance")
                {

                }
                else if (move == "Roost")
                {

                }
                else if (move == "Dragon Claw")
                {

                }
                else if (move == "Fire Punch")
                {

                }
                moves.Clear();
            }

            else if (CPUpokemon[0].Image == butFroslass)
            {

                List<string> moves = new List<string> { "Shadow Claw", "Thunder Wave", "Shadow Ball", "Ice Beam" };


                Random ran = new Random();
                selectMove = ran.Next(1, 5);

                move = moves[selectMove];

                if (move == "Shadow Claw")
                {

                }
                else if (move == "Thunder Wave")
                {

                }
                else if (move == "Shadow Ball")
                {

                }
                else if (move == "Ice Beam")
                {

                }
                moves.Clear();
            }

            else if (CPUpokemon[0].Image == butGarchomp)
            {

                List<string> moves = new List<string> { "Sword Stance", "Earthquake", "Dragon Claw", "Outrage" };
                


                Random ran = new Random();
                selectMove = ran.Next(1, 5);

                move = moves[selectMove];

                if (move == "Sword Stance")
                {

                }
                else if (move == "Earthquake")
                {

                }
                else if (move == "Dragon Claw")
                {

                }
                else if (move == "Outrage")
                {

                }
                moves.Clear();
            }

            else if (CPUpokemon[0].Image == butGardevoir)
            {

                List<string> moves = new List<string> { "Psychic", "Thunderboly", "Shadow Ball", "Misty Explosion" };



                Random ran = new Random();
                selectMove = ran.Next(1, 5);

                move = moves[selectMove];

                if (move == "Psychic")
                {

                }
                else if (move == "Thunderboly")
                {

                }
                else if (move == "Shadow Ball")
                {

                }
                else if (move == "Misty Explosion")
                {

                }
                moves.Clear();
            }

            else if (CPUpokemon[0].Image == butGengar)
            {

                List<string> moves = new List<string> { "Shadow Ball", "Thunderbolt", "Poltergeist", "Sludge Ball" };



                Random ran = new Random();
                selectMove = ran.Next(1, 5);

                move = moves[selectMove];

                if (move == "Shadow Ball")
                {

                }
                else if (move == "Thunderbolt")
                {

                }
                else if (move == "Poltergeist")
                {

                }
                else if (move == "Sludge Ball")
                {

                }
                moves.Clear();
            }

            else if (CPUpokemon[0].Image == butGroudon)
            {

                List<string> moves = new List<string> { "Fire Blast", "Earthquake", "Stone Edge", "Solar Beam" };



                Random ran = new Random();
                selectMove = ran.Next(1, 5);

                move = moves[selectMove];

                if (move == "Fire Blast")
                {

                }
                else if (move == "Earthquake")
                {

                }
                else if (move == "Stone Edge")
                {

                }
                else if (move == "Solar Beam")
                {

                }
                moves.Clear();
            }

            else if (CPUpokemon[0].Image == butIncineroar)
            {

                List<string> moves = new List<string> { "Darkest Lariat", "Flame Charge", "Earthquake", "Sword Stance" };



                Random ran = new Random();
                selectMove = ran.Next(1, 5);

                move = moves[selectMove];

                if (move == "Darkest Lariat")
                {

                }
                else if (move == "Flame Charge")
                {

                }
                else if (move == "Earthquake")
                {

                }
                else if (move == "Sword Stance")
                {

                }
                moves.Clear();
            }

            else if (CPUpokemon[0].Image == butKrookodile)
            {

                List<string> moves = new List<string> { "Outrage", "Earthquake", "Crunch", "Stone Edge" };



                Random ran = new Random();
                selectMove = ran.Next(1, 5);

                move = moves[selectMove];

                if (move == "Outrage")
                {

                }
                else if (move == "Earthquake")
                {

                }
                else if (move == "Crunch")
                {

                }
                else if (move == "Stone Edge")
                {

                }
                moves.Clear();
            }

            else if (CPUpokemon[0].Image == butKyogre)
            {

                List<string> moves = new List<string> { "Water Spout", "Thunder", "Ice beam", "Origin Pulse" };



                Random ran = new Random();
                selectMove = ran.Next(1, 5);

                move = moves[selectMove];

                if (move == "Water Spout")
                {

                }
                else if (move == "Thunder")
                {

                }
                else if (move == "Ice beam")
                {

                }
                else if (move == "Origin Pulse")
                {

                }
                moves.Clear();
            }

            else if (CPUpokemon[0].Image == butLucario)
            {

                List<string> moves = new List<string> { "Sword Stance", "High Jump Kick", "Shadow Claw", "Ice Punch" };



                Random ran = new Random();
                selectMove = ran.Next(1, 5);

                move = moves[selectMove];

                if (move == "Sword Stance")
                {

                }
                else if (move == "High Jump Kick")
                {

                }
                else if (move == "Shadow Claw")
                {

                }
                else if (move == "Ice Punch")
                {

                }
                moves.Clear();
            }

            else if (CPUpokemon[0].Image == butMewtwo)
            {

                List<string> moves = new List<string> { "Aura Sphere", "Thunder", "Shadow Ball", "Ice Beam" };



                Random ran = new Random();
                selectMove = ran.Next(1, 5);

                move = moves[selectMove];

                if (move == "Aura Sphere")
                {

                }
                else if (move == "Thunder")
                {

                }
                else if (move == "Shadow Ball")
                {

                }
                else if (move == "Ice Beam")
                {

                }
                moves.Clear();
            }

            else if (CPUpokemon[0].Image == butPikachu)
            {

                List<string> moves = new List<string> { "Brick Break", "Thunderbolt", "Thunder Punch", "Quick Attack" };



                Random ran = new Random();
                selectMove = ran.Next(1, 5);

                move = moves[selectMove];

                if (move == "Brick Break")
                {

                }
                else if (move == "Thunderbolt")
                {

                }
                else if (move == "Thunder Punch")
                {

                }
                else if (move == "Quick Attack")
                {

                }
                moves.Clear();
            }

            else if (CPUpokemon[0].Image == butSceptile)
            {

                List<string> moves = new List<string> { "Hone Claws", "Leaf Blade", "Dynamic Punch", "Rock Slide" };



                Random ran = new Random();
                selectMove = ran.Next(1, 5);

                move = moves[selectMove];

                if (move == "Hone Claws")
                {

                }
                else if (move == "Leaf Blade")
                {

                }
                else if (move == "Dynamic Punch")
                {

                }
                else if (move == "Rock Slide")
                {

                }
                moves.Clear();
            }

            else if (CPUpokemon[0].Image == butShedinja)
            {

                List<string> moves = new List<string> { "Shadow Snake", "Sword Stance", "Giga Impact", "X-Scissor" };



                Random ran = new Random();
                selectMove = ran.Next(1, 5);

                move = moves[selectMove];

                if (move == "Shadow Snake")
                {

                }
                else if (move == "Sword Stance")
                {

                }
                else if (move == "Giga Impact")
                {

                }
                else if (move == "X-Scissor")
                {

                }
                moves.Clear();
            }

            else if (CPUpokemon[0].Image == butSteelix)
            {

                List<string> moves = new List<string> { "Iron Tail", "Earthquake", "Rock Slide", "Crunch" };



                Random ran = new Random();
                selectMove = ran.Next(1, 5);

                move = moves[selectMove];

                if (move == "Iron Tail")
                {

                }
                else if (move == "Earthquake")
                {

                }
                else if (move == "Rock Slide")
                {

                }
                else if (move == "Crunch")
                {

                }
                moves.Clear();
            }

            else if (CPUpokemon[0].Image == butSylveon)
            {

                List<string> moves = new List<string> { "Hypervoice", "Psyschock", "Shadow Ball", "Calm Mind" };



                Random ran = new Random();
                selectMove = ran.Next(1, 5);

                move = moves[selectMove];

                if (move == "Hypervoice")
                {

                }
                else if (move == "Psyschock")
                {

                }
                else if (move == "Shadow Ball")
                {

                }
                else if (move == "Calm Mind")
                {

                }
                moves.Clear();
            }

            else if (CPUpokemon[0].Image == butTalonflame)
            {

                List<string> moves = new List<string> { "Sword Stance", "Hurricane", "Flair Blitz", "Roost" };



                Random ran = new Random();
                selectMove = ran.Next(1, 5);

                move = moves[selectMove];

                if (move == "Sword Stance")
                {

                }
                else if (move == "Hurricane")
                {

                }
                else if (move == "Flair Blitz")
                {

                }
                else if (move == "Roost")
                {

                }
                moves.Clear();
            }

            else if (CPUpokemon[0].Image == butToxapex)
            {

                List<string> moves = new List<string> { "Gunk Shot", "Scald", "Liquidation", "Mud Slap" };



                Random ran = new Random();
                selectMove = ran.Next(1, 5);

                move = moves[selectMove];

                if (move == "Gunk Shot")
                {

                }
                else if (move == "Scald")
                {

                }
                else if (move == "Liquidation")
                {

                }
                else if (move == "Mud Slap")
                {

                }
                moves.Clear();
            }

            else if (CPUpokemon[0].Image == butToxicroak)
            {

                List<string> moves = new List<string> { "Acid Spray", "Gunk Shot", "Mud Slap", "Ice Punch" };



                Random ran = new Random();
                selectMove = ran.Next(1, 5);

                move = moves[selectMove];

                if (move == "Acid Spray")
                {

                }
                else if (move == "Gunk Shot")
                {

                }
                else if (move == "Mud Slap")
                {

                }
                else if (move == "Ice Punch")
                {

                }
                moves.Clear();
            }

            else if (CPUpokemon[0].Image == butTyranitar)
            {

                List<string> moves = new List<string> { "Fire Punch", "Dragon Dance", "Stone Edge", "Ice Punch" };



                Random ran = new Random();
                selectMove = ran.Next(1, 5);

                move = moves[selectMove];

                if (move == "Fire Punch")
                {

                }
                else if (move == "Dragon Dance")
                {

                }
                else if (move == "Stone Edge")
                {

                }
                else if (move == "Ice Punch")
                {

                }
                moves.Clear();
            }

            else if (CPUpokemon[0].Image == butVenusaur)
            {

                List<string> moves = new List<string> { "Solar Beam", "Earthquake", "Hidden Power", "Growth" };



                Random ran = new Random();
                selectMove = ran.Next(1, 5);

                move = moves[selectMove];

                if (move == "Solar Beam")
                {

                }
                else if (move == "Earthquake")
                {

                }
                else if (move == "Hidden Power")
                {

                }
                else if (move == "Growth")
                {

                }
                moves.Clear();
            }

            else if (CPUpokemon[0].Image == butVikavolt)
            {

                List<string> moves = new List<string> { "Bug Buzz", "Thunder", "Flash Cannon", "Crunch" };



                Random ran = new Random();
                selectMove = ran.Next(1, 5);

                move = moves[selectMove];

                if (move == "Bug Buzz")
                {

                }
                else if (move == "Thunder")
                {

                }
                else if (move == "Flash Cannon")
                {

                }
                else if (move == "Crunch")
                {

                }
                moves.Clear();
            }

            else if (CPUpokemon[0].Image == butZapdos)
            {

                List<string> moves = new List<string> { "Thunderbolt", "Thunder", "Roost", "Gunk Shot" };



                Random ran = new Random();
                selectMove = ran.Next(1, 5);

                move = moves[selectMove];

                if (move == "Thunderbolt")
                {

                }
                else if (move == "Thunder")
                {

                }
                else if (move == "Roost")
                {

                }
                else if (move == "Gunk Shot")
                {

                }
                moves.Clear();
            }
        }
        
        /*Maybe seperate cpu battle attack function?*/
    









    }

}
