using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIMS_12
{
    public partial class Form1 : Form
    {
        Team[] teams = new Team[20];
        Dictionary<Label, Team> ts;
        List<Label> labels = new List<Label>();
        List<Label> gamesLabel = new List<Label>();
        Tournament tournament = new Tournament();      

        public Form1()
        {
            InitializeComponent();
            ts = new Dictionary<Label, Team>();
            createTeams();
            for (int i = 0; i < 20; i++)
            {
                ts.Add(labels[i], teams[i]);
                labels[i].Text = teams[i].name + "  " + teams[i].points.ToString();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void createTeams()
        {
            for (int i = 0; i < 20; i++)
            {
                teams[i] = new Team();
                if (i != 0)
                {
                    Tournament.circle[i - 1] = teams[i];
                }                
            }
            Tournament.firstTeam = teams[0];
            teams[0].name = "Манчестер Сити";
            teams[0].lambda = 5;
            teams[1].name = "Манчестер Юнайтед";
            teams[1].lambda = 4;
            teams[2].name = "Ливерпуль";
            teams[2].lambda = 3;
            teams[3].name = "Челси";
            teams[3].lambda = 3;
            teams[4].name = "Лестер Сити";
            teams[5].name = "Вест Хэм";
            teams[6].name = "Тоттенхэм Хотспур";
            teams[7].name = "Арсенал";
            teams[8].name = "Лидс Юнайтед";
            teams[9].name = "Эвертон";
            teams[10].name = "Астон Вилла";
            teams[11].name = "Ньюкасл Юнайтед";
            teams[12].name = "Вулверхэмптон Уондерерс";
            teams[13].name = "Кристал Пэлас";
            teams[14].name = "Саутгемптон";
            teams[15].name = "Брайтон-энд-Хоув Альбион";
            teams[16].name = "Бернли";
            teams[17].name = "Фулхэм";
            teams[17].lambda = 1;
            teams[18].name = "Вест Бромвич Альбион";
            teams[18].lambda = 1;
            teams[19].name = "Шеффилд Юнайтед";    
            teams[19].lambda = 0;

            labels.Add(label1);
            labels.Add(label2);
            labels.Add(label3);
            labels.Add(label4);
            labels.Add(label5);
            labels.Add(label6);
            labels.Add(label7);
            labels.Add(label8);
            labels.Add(label9);
            labels.Add(label10);
            labels.Add(label11);
            labels.Add(label12);
            labels.Add(label13);
            labels.Add(label14);
            labels.Add(label15);
            labels.Add(label16);
            labels.Add(label17);
            labels.Add(label18);
            labels.Add(label19);
            labels.Add(label20);

            gamesLabel.Add(label21);
            gamesLabel.Add(label22);
            gamesLabel.Add(label23);
            gamesLabel.Add(label24);
            gamesLabel.Add(label25);
            gamesLabel.Add(label26);
            gamesLabel.Add(label27);
            gamesLabel.Add(label28);
            gamesLabel.Add(label29);
            gamesLabel.Add(label30);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Tournament.tour < 38)
            {
                string[] games;
                games = tournament.playTour(teams);
                for (int i = 0; i < 10; i++)
                {
                    gamesLabel[i].Text = games[i];
                }
                updateTable();
            }
            else
            {
                MessageBox.Show("Конец сезона!");
                for(int i = 0; i < 20; i++)
                {
                    teams[i].points = 0;
                    teams[i].goals = 0;                    
                }
                Tournament.tour = 0;
                updateTable();
            }
        }

        private void updateTable()
        {
            tourLabel.Text = "Тур: "+Tournament.tour.ToString();
            for(int j = 0; j < 20; j++)
            {
                for (int i = 0; i < 20; i++)
                {
                    if (teams[j].points > teams[i].points)
                    {
                        Team bf = teams[j];
                        teams[j] = teams[i];
                        teams[i] = bf;
                    }
                }
            }                  
            for (int i = 0; i < 20; i++)
            {
                labels[i].Text = teams[i].name + "  " + teams[i].points.ToString();
            }                
        }
    }
}
