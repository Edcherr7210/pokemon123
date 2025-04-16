using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokemonGame
{
    public partial class Battle : Form
    {
        private List <PictureBox> CPUpokemon;
        private List <Image> PlayerPokemon;
        private List<String> Moves;
        private Dictionary <Image, List<String>> PlayerPokeAndMoves;
        private Dictionary<Image, int> PlayerPokeAndHealth;
        private Dictionary<Image, List<String>> CPUPokeAndMoves;
        private Dictionary<Image, int> CPUPokeAndHealth;
        public Battle(Image tm1BackgroundImage1, Image tm1BackgroundImage2, Image tm1BackgroundImage3, Image tm1BackgroundImage4, Image tm1BackgroundImage5, Image tm1BackgroundImage6, Image butCharizard, Image butBlaziken, Image butBlastoise, Image butBarbaracle, Image butIncineroar, Image butAerodactyl, Image butArticuno, Image butDragapult, Image butDragonite, Image butFroslass, Image butGardevoir, Image butGengar, Image butGroudon, Image butKrookodile, Image butKyogre, Image butLucario, Image butGarchomp, Image butMewtwo, Image butPikachu, Image butSceptile, Image butShedinja, Image butSteelix, Image butSylveon, Image butTalonflame, Image butToxapex, Image butToxicroak, Image butTyranitar, Image butVenusaur, Image butVikavolt, Image butZapdos)
        {
            InitializeComponent();

            //Set health
            int MaxHealth = 0;
            int CurrHealth = 0;


            //Set Moves
            Moves = new List<String>() { };

            //Array Lists of Computer Pokemon and Player Pokemon
            CPUpokemon = new List<PictureBox>();
            PlayerPokemon = new List<Image>() {tm1BackgroundImage1,tm1BackgroundImage2, tm1BackgroundImage3, tm1BackgroundImage4, tm1BackgroundImage5, tm1BackgroundImage6 };

            PlayerPokeAndMoves = new Dictionary<Image, List<String>>();
            for (int i = 0; i < 6; i++)
            {
                if (PlayerPokemon[i] == butAerodactyl)
                {
                    //type: rock and water
                    //weak against rock, electric, water, steel, ice
                    //cannot be hit by ground type moves
                    //resist normal, fire, poison, flying, bug
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Taunt", "Stealth Rock", "Stone Edge", "Aeiral Ace" };
                    // Stone Edge 80% accuracy
                    //Aeiral Ace 100% accuracy 
                }
                else if (PlayerPokemon[i] == butArticuno)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Brave Bird", "Hurricane", "Ice Shard", "Frost Breath" };
                    //Brave Bird Flying 120 damage, special 1/3 of the damage to the user
                    //Hurricane Flying type, 130 damage 70% accuracy, 30% confussion
                    //Ice Shard Ice type, 40 damage
                    //Frost Breath always a crit hit, 60 damage, 90% accuracy
                    //Weaknesses 4x rock, 2x fire, electric, and steel
                    //0.5, grass and bug
                    //Immune to ground
                }
                else if (PlayerPokemon[i] == butBarbaracle)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Shell Smash", "Dragon Claw", "Razor Shell", "Stone Edge" };
                    //Dragon Claw 80 damage, 100% accuracy
                    //Razor Shell 95% accuracy, 75 damage
                    //4x grass, 2x electric, 2x fighting, 2x ground <- weaknesses
                    //0.5x normal, ice, poision, flying
                    // 0.25x fire
                    // Stone Edge 80% accuracy
                }
                else if (PlayerPokemon[i] == butBlastoise)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Water Pulse", "Aura Sphere", "Dragon Pulse", "Dark Pulse" };
                    //Water pulse 60 damage, 20% confusion
                    //Aura Sphere fighitng, 80 damage, 100% acc
                    //Dragon Pulse dragon, 85 damage
                    //Dark dark, 80 damage
                    //Weaknesses 2x electric and grass
                    //0.5x fire, water, ice, and steel
                }
                else if (PlayerPokemon[i] == butBlaziken)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Stone Edge", "Hone Claws", "Blaze Kick", "High Jump Kick" };
                    //Stone Edge 80% accuracy
                    //Hone Claws raise attack
                    //Blaze Kick fire type, 85 damage, 90% acc
                    //High Jump Kick fighting type, if misses half health to yourself, 100 damage, 85% acc
                    //Weaknesses 2x water, ground, flying, psychic
                    //0.5x fire, grass, ice, dark, steel
                    //0.25 bug

                }
                else if (PlayerPokemon[i] == butCharizard)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Earthquake", "Dragon Claw", "Dragon Dance", "Fire Blitz" };
                    //Earthquake ground, 100 damage
                    //Dragon Claw 80 damage, 100% accuracy
                    //Dragon Dance raises attack, and speed, by one stage
                    //Fire Blitz fire, hits, 120 damage, 1/3 of damage to user (brave bird but fire)
                    //Weakness 4x rock, 2x water and electric,
                    //0.5x fire, fighting, steel, fairy,
                    //0.25x grass, bug
                    //immune ground

                }
                else if (PlayerPokemon[i] == butDragapult)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Dragon Darts", "Dragon Dance", "Night Shade", "Shadow Ball" };
                    //Dragon Darts Dragon type, 100 damage
                    //Dragon Dance raises attack, and speed, by one stage
                    //Night Shade 50 damage
                    //Shadow Ball ghost type, 20% chance to raise attack, 80 dmg
                    //Weakness 2x ice, ghost, dragon, dark, fairy
                    //0.5x fire, water, electic, grass, posion, bug
                    //Immune cannot be hit by normal or fighting
                }
                else if (PlayerPokemon[i] == butKrookodile)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Outrage", "Earthquake", "Crunch", "Stone Edge" };
                    //Outrage:
                    //Stone Edge 80% accuracy
                    //Earthquake ground, 100 damage
                    //Crunch Dark type move, 80 damage
                    //Weaknesses 2x water, grass, ice, fighting, bug, and fairy
                    //0.5x poision, rock, ghost, and dark
                    //Immune (not hit) electric, and psychic
                }
                else if (PlayerPokemon[i] == butKyogre)
                {

                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Water Spout", "Thunder", "Ice beam", "Origin Pulse" };
                    //Water spout (150 x crhp) / hpmax
                    //Thunder 3/10 chance for par, 110 damage, 70% acc
                    //Ice Beam Ice type, 10% freeze, 90 damage
                    //Origin Pulse 180 damage, 80% acc
                    //Weaknesses 2x electric and grass
                    //0.5x fire, water, ice, and steel
                }
                else if (PlayerPokemon[i] == butMewtwo)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Aura Sphere", "Thunder", "Shadow Ball", "Ice Beam" };
                    //Aura Sphere fighitng, 80 damage, 100% acc
                    //Thunder 3/10 chance for par, 110 damage, 70% acc
                    //Ice Beam Ice type, 10% freeze, 90 damage
                    //Shadow Ball ghost type, 20 % chance to raise attack, 80 dmg
                    //Weakness 2x bug, ghost, dark
                    //0.5 fighting and psychic
                }
                else if (PlayerPokemon[i] == butPikachu)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Brick Break", "Thunderbolt", "Thunder Punch", "Quick Attack" };
                    //Brick Break fighting type, 75 dmh
                    //Thunder type elctric, 10% par, 90 dmg
                    //Thunder Punc 10% par, 75 dmg
                    //Quick Attack  40 damage, always hits first (set speed nuts cause why not)
                    //Weakness 2x ground
                    //0.5x electric flying and steel
                }
                else if (PlayerPokemon[i] == butSceptile)
                {
                    //Grass Type
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Hone Claws", "Leaf Blade", "Dynamic Punch", "Rock Slide" };
                    //Leaf Blade grass, 90 dmg, crit 1/8
                    //Dynamic Punch, 100% confussion, 100 dmg, 50% acc
                    //Rock Slide rock, 75 dmg, 90% acc
                    //Weakness 2x fire, ice, posion, flying, bug
                    //0.5 water, electric, grass, ground
                }
                else if (PlayerPokemon[i] == butShedinja)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Shadow Snake", "Sword Stance", "Giga Impact", "X-Scissor" };
                    //Shadow Snake ghost type, always goes first, 40dmg
                    //Sword Stanceraises attack 2 stages
                    //giga impact, normal type, no turn next run, 150 dmg, 90% acc
                    //X-Scissior bug type, 80 dmg
                    //Can only be hit by fire, flyimg, rock, ghost, dark
                    //Immune to everything else ^
                }
                else if (PlayerPokemon[i] == butVenusaur)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Solar Beam", "Earthquake", "Hidden Power", "Growth" };
                    //Solar Beam damage on second turn 120 dmg, grass type
                    //Hidden Power fire type, 60 dmg
                    //Growth raises attack by one stage 
                    //Weakness 2x fire, ice, flying, psychic
                    //0.5x water, electric, fighting, fairy
                    //0.25x grass
                }
                else if (PlayerPokemon[i] == butDragonite)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Dragon Dance", "Roost", "Dragon Claw", "Fire Punch" };
                    //Roost restores half of users max hp
                    //Fire Punch 10% burn, 
                    //Weak 4x ice, 2x rock, dragon, fairy
                    //0.5x fire, water, fighting, and bug
                    //0.25x grass
                    //Immune to ground
                }
                else if (PlayerPokemon[i] == butFroslass)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Shadow Claw", "Thunder Wave", "Shadow Ball", "Ice Beam" };
                    //Shadow Claw Ghost Type, 70 damage
                    //Thunder Wave 100% par
                    //weak 2x fire, rock, ghost, dark, steel
                    //0.5 ice, poision, bug
                }
                else if (PlayerPokemon[i] == butGarchomp)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Sword Stance", "Earthquake", "Dragon Claw", "Outrage" };
                    //weakness 4x ice, 2x dragon, and fiary
                    //0.5 fire poision and rock
                    //immune to electric
                }
                else if (PlayerPokemon[i] == butGardevoir)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Psychic", "Thunderboly", "Shadow Ball", "Misty Explosion" };
                    //Psychic 10% raise attack, 90dmg
                    //Misty Explosion 100 dmg
                    //Weak 2x posions, ghost, and steel
                    //0.5x psychic
                    //0.25x fighting
                    //Immune to dragon
                }
                else if (PlayerPokemon[i] == butGengar)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Shadow Ball", "Thunderbolt", "Poltergeist", "Sludge Ball" };
                    //Poltergiest 100dmg, 90%acc, can only use 5 times
                    //Sludge Ball poision type, 30% posion, 90 dmg
                    //weak 2x ground, psychic, ghost, and dark
                    //0.5x grass and fiary
                    //0.25 posion and bug
                    //immune to normal and fighting
                }
                else if (PlayerPokemon[i] == butGroudon)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Fire Blast", "Earthquake", "Stone Edge", "Solar Beam"};
                    //fire blast fire type, 10% burn, 110 damage, 85% acc
                    //weak 2x water, grass, ice
                    //0.5 poision, rock
                    //Immune to electric
                }
                else if (PlayerPokemon[i] == butIncineroar)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Darkest Lariat", "Flame Charge", "Earthquake", "Sword Stance" };
                    //Darkest Lariat dark type, 85 dmg, hits, ignores if paralyzed or high def
                    //Flame Charge fire type, raises speed by one stage, 50 dmg
                    //Weak 2x water, ground and rock, fighting
                    //0.5 fire, grass, ice, ghost, dark, and steel
                    //immune psychic
                }
                else if (PlayerPokemon[i] == butLucario)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Sword Stance", "High Jump Kick", "Shadow Claw", "Ice Punch" }; 
                    //Ice Punch 75 dmg
                    //weak 2x fire, fighting, and ground
                    //half to noraml,grass,ice,dragon,dark, and steel
                    //quarter to bug and rock
                    //immune to posion
                }
                else if (PlayerPokemon[i] == butSteelix)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Iron Tail", "Earthquake", "Rock Slide", "Crunch" };
                    //Iron Tail steel type, 30% raise attack by one stage, 100 dmg, 75% acc
                    //Rock Slide rock type, 30% flinch, 75dmg, 90% acc
                    //Crunch dark type, 20% attack by one stage, 80dmg, hits
                    //weak 2x fire, water, fighting, ground
                    //0.5 to normal, flying, psychic, bug, dragon, steel, and fairy
                    //0.25 rock
                    //immune to elxtric and posion
                }
                else if (PlayerPokemon[i] == butSylveon)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Hypervoice", "Psyschock", "Shadow Ball", "Calm mind" };
                    //Psyshock 80 dmg
                    //Calm mind raises attack by one stage
                    //weak 2x poision, steel
                    //0.5 fighitng, bug, dark
                    //immune to dragon
                }
                else if (PlayerPokemon[i] == butTalonflame)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Sword Stance", "Hurricane", "Flair Blitz", "Roost" };
                    //Flair Blitz 120 dmg, causes 0.25 damage of its max health to itself, 100% accurate
                    //weaknesses 4x rock, 2x water, electic
                    //0.5 fire fighting, steel, and fairy
                    //0.25 grass and bug
                    //immune to ground

                }
                else if (PlayerPokemon[i] == butToxapex)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Gunk Shot", "Scald", "Liquidation", "Mud Slap"};
                    //Gunk Shot poision type move, 120 dmg, 80% acc
                    //Scald water, 30% burning, 80 dmg
                    //Liquidation water, 20% lowering defence by one stage, 85 dmg
                    //Mud Slap ground, 20dmg
                    //weak 2x electric, ground, psychic
                    //0.5x fire, water, ice, fighting, posion, bug, steel, fairy

                }
                else if (PlayerPokemon[i] == butToxicroak)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Acid Spray", "Gunk Shot", "Mud Slap", "Ice Punch" };
                    //Acid Spray lowers def by 2 stages
                    //weak 4x psychic, 2x ground and flying
                    //0.5x grass, fighiting, posion, rock , dark
                    //0.25 bug
                }
                else if (PlayerPokemon[i] == butTyranitar)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Fire Punch", "Dragon Dnace", "Stone Edge", "Ice Punch" };
                    //weak 4x fighting, 2x water, grass, ground, steel, bug, fairy
                    //0.5 normal, fire, poision, flying, ghost, and dark
                    //Immune Psychic
                }
                else if (PlayerPokemon[i] == butVikavolt)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Bug Buzz", "Thunder", "Flash Cannon", "Crunch" };
                    //Bug Buzz bug type 90 damage, 10% lowering def by one stage
                    //Flash Cannon steel type, 80 dmg, 10% lowering def by one stage
                    //weak 2x fire, rock
                    //0.5x electric grass, fighting and steel
                }
                else if (PlayerPokemon[i] == butZapdos)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Thunderbolt", "Thunder", "Roost", "Gunk Shot" };
                    //weak 2x ice and rock
                    //0.5 grass, fighting, flying, bug, and steel
                    //immune to ground
                }
            }
            //To Show players first pokemon in battle
            team1Poke.Image = PlayerPokemon[0];

            //team 2 and 2 speed, attack, and health variables
            int speed1, speed2, attack1, attack2, health1, health2 = 0;

            //Randomly selecting computer team
            Random rnd = new Random();
            for (int i = 0; i < 6; i++)
            {
                int ranNum = rnd.Next(1, 30);
                if (ranNum == 1)
                {
                    if(team2Poke.Image == null)
                    {
                        team2Poke.Image = butCharizard;
                    }
                    else if(team2Poke2.Image == null)
                    {
                        team2Poke2.Image = butCharizard;
                    }
                    else if(team2Poke3.Image == null)
                    {  
                        team2Poke3.Image  = butCharizard; 
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
                    speed2 = 328;
                    attack2 = 293;
                    health2 = 360;
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

                    speed2 = 284;
                    attack2 = 372;
                    health2 = 364;                 
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
                    speed2 = 280;
                    attack2 = 291;        
                    health2 = 362;
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
                }
            }

            for (int i = 0; i < 6; i++)
            {
                if (PlayerPokemon[i] == butArticuno)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Brave Bird", "Hurricane", "Ice Shard", "Frost Breath" };
                    speed1 = 295;
                    attack1 = 295;
                    health1 = 384;
                }
                else if (PlayerPokemon[i] == butAerodactyl)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Taunt", "Stealth Rock", "Stone Edge", "Aeiral Ace" };
                    speed1 = 394;
                    attack1 = 339;
                    health1 = 364;
                }
                else if (PlayerPokemon[i] == butBarbaracle)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Shell Smash", "Dragon Claw", "Razor Shell", "Stone Edge" };
                    speed1 = 258;
                    attack1 = 339;
                    health1 = 348;
                }
                else if (PlayerPokemon[i] == butBlastoise)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Water Pulse", "Aura Sphere", "Dragon Pulse", "Dark Pulse" };
                    speed1 = 280;
                    attack1 = 291;
                    health1 = 362;
                }
                else if (PlayerPokemon[i] == butBlaziken)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Stone Edge", "Hone Claws", "Blaze Kick", "High Jump Kick" };
                    speed1 = 284;
                    attack1 = 372;
                    health1 = 364;
                }
                else if (PlayerPokemon[i] == butCharizard)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Earthquake", "Dragon Claw", "Dragon Dance", "Fire Blitz" };
                    speed1 = 328;
                    attack1 = 293;
                    health1 = 360;
                }
                else if (PlayerPokemon[i] == butDragapult)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Dragon Darts", "Dragon Dance", "Night Shade", "Shadow Ball" };
                    speed1 = 421;
                    attack1 = 372;
                    health1 = 380;
                }
                else if (PlayerPokemon[i] == butDragonite)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Outrage", "Earthquake", "Crunch", "Stone Edge" };
                    speed1 = 284;
                    attack1 = 403;
                    health1 = 386;
                }
                else if (PlayerPokemon[i] == butFroslass)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Shadow Claw", "Thunder Wave", "Shadow Ball", "Ice Beam" };
                    speed1 = 350;
                    attack1 = 284;
                    health1 = 344;
                }
                else if (PlayerPokemon[i] == butGardevoir)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Psychic", "Thunderboly", "Shadow Ball", "Misty Explosion" };
                    speed1 = 284;
                    attack1 = 251;
                    health1 = 340;
                }
                else if (PlayerPokemon[i] == butGengar)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Shadow Ball", "Thunderbolt", "Poltergeist", "Sludge Ball" };
                    speed1 = 350;
                    attack1 = 251;
                    health1 = 324;
                }
                else if (PlayerPokemon[i] == butGroudon)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Fire Blast", "Earthquake", "Stone Edge", "Solar Beam" };
                    speed1 = 306;
                    attack1 = 438;
                    health1 = 404;
                }
                else if (PlayerPokemon[i] == butKrookodile)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Outrage", "Earthquake", "Crunch", "Stone Edge" };
                    speed1 = 311;
                    attack1 = 366;
                    health1 = 394;
                }
                else if (PlayerPokemon[i] == butKyogre)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Water Spout", "Thunder", "Ice beam", "Origin Pulse" };
                    speed1 = 306;
                    attack1 = 328;
                    health1 = 404;
                }
                else if (PlayerPokemon[i] == butLucario)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Sword Stance", "High Jump Kick", "Shadow Claw", "Ice Punch" };
                    speed1 = 306;
                    attack1 = 350;
                    health1 = 344;
                }
                else if (PlayerPokemon[i] == butGarchomp)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Sword Stance", "Earthquake", "Dragon Claw", "Outrage" };
                    speed1 = 0;
                    attack1 = 0;
                    health1 = 0;
                }
                else if (PlayerPokemon[i] == butMewtwo)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Aura Sphere", "Thunder", "Shadow Ball", "Ice Beam" };
                    speed1 = 262;
                    attack1 = 405;
                    health1 = 364;
                }
                else if (PlayerPokemon[i] == butPikachu)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Brick Break", "Thunderbolt", "Thunder Punch", "Quick Attack" };
                    speed1 = 306;
                    attack1 = 229;
                    health1 = 274;
                }
                else if (PlayerPokemon[i] == butSceptile)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Hone Claws", "Leaf Blade", "Dynamic Punch", "Rock Slide" };
                    speed1 = 372;
                    attack1 = 295;
                    health1 = 344;
                }
                else if (PlayerPokemon[i] == butShedinja)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Shadow Snake", "Sword Stance", "Giga Impact", "X-Scissor" };
                    speed1 = 196;
                    attack1 = 306;
                    health1 = 1;
                }
                else if (PlayerPokemon[i] == butSteelix)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Iron Tail", "Earthquake", "Rock Slide", "Crunch" };
                    speed1 = 251;
                    attack1 = 295;
                    health1 = 354;
                }
                else if (PlayerPokemon[i] == butSylveon)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Hypervoice", "Psyschock", "Shadow Ball", "Calm mind" };
                    speed1 = 394;
                    attack1 = 251;
                    health1 = 240;
                }
                else if (PlayerPokemon[i] == butTalonflame)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Sword Stance", "Hurricane", "Flair Blitz", "Roost" };
                    speed1 = 386;
                    attack1 = 287;
                    health1 = 360;
                }
                else if (PlayerPokemon[i] == butToxapex)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Gunk Shot", "Scald", "Liquidation", "Mud Slap" };
                    speed1 = 386;
                    attack1 = 287;
                    health1 = 360;
                }
                else if (PlayerPokemon[i] == butTyranitar)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Fire Punch", "Dragon Dnace", "Stone Edge", "Ice Punch" };
                    speed1 = 243;
                    attack1 = 403;
                    health1 = 404;
                }
                else if (PlayerPokemon[i] == butToxicroak)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Acid Spray", "Gunk Shot", "Mud Slap", "Ice Punch" };
                    speed1 = 295;
                    attack1 = 342;
                    health1 = 370;
                }
                else if (PlayerPokemon[i] == butVenusaur)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Solar Beam", "Earthquake", "Hidden Power", "Growth" };
                    speed1 = 284;
                    attack1 = 289;
                    health1 = 364;
                }
                else if (PlayerPokemon[i] == butVikavolt)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Bug Buzz", "Thunder", "Flash Cannon", "Crunch" };
                    speed1 = 203;
                    attack1 = 262;
                    health1 = 358;
                }
                else if (PlayerPokemon[i] == butZapdos)
                {
                    PlayerPokeAndMoves[PlayerPokemon[i]] = new List<String> { "Thunderbolt", "Thunder", "Roost", "Gunk Shot" };
                    speed1 = 328;
                    attack1 = 306;
                    health1 = 384;
                }
            }
        }
        private int Rockslide()
        {
            Random rnd = new Random();
            int ran = rnd.Next(1, 10);
            int dmg = 75;
            while(ran != 1)
            {
                return dmg;
            }
            return 0;
        }

        private int StoneEdge()
        {
            Random rnd = new Random();
            int ran = rnd.Next(1, 5);
            int dmg = 100;
            if(ran / 5 <= .20)
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

            if(ran / 20 <= .20)
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

        private int WaterPulse()
        {
            Random rnd = new Random();
            int dmg;
            int ran = rnd.Next(1, 5);
            if(ran == 2)
            {
                dmg = 80;
            }
            else
            {
                dmg = 60;
            }
            return dmg;
        }

        private int AuraSphere()
        {
            int dmg = 80;
            return dmg;
        }

        private int DragonPulse ()
        {
            int dmg = 85;
            return dmg;
        }
        private int DarkPulse()
        {
            int dmg = 80;
            return dmg;
        }

        private int BraveBird(double PokemaxHealth)
        {
            double dmg_to_self = PokemaxHealth * 0.25;
            int dmg = 120;
            return dmg;
        }

        private int Hurricane()
        {
            Random rnd = new Random();
            int ran = rnd.Next(1, 10);
            //do three numbers
            int dmg = 130;
            if(ran / 10 <= .20)
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
            if(ran / 10 <= .20)
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
            if(ran / 10 <= .20)
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
            if(ran / 5 <= .20)
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
            int dmg = (150* pokecurhealth) / pokeHPmax;
            return dmg;
        }

        private int Thunder()
        {
            Random rnd = new Random();
            int ran = rnd.Next(1, 10);
            //do three numbers
            int dmg = 110;
            if(ran / 10 <= .20)
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
            if(ran / 5 <= .20)
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

        private void PlayerMoves(List<Image> PlayerPokemon)
        {
            for (int i = 0; i < PlayerPokemon.Count; i++)
            {

            }
        }
        





























    }    
}

