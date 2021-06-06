using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS_12
{
    class Tournament
    {
        Random rnd = new Random();
        public static Team[] circle = new Team[19];
        public static Team firstTeam;
        public static int tour = 0;
        int generateGoals(float lambda)
        {
            double s = 0;
            int m = 0;
            double alpha;
            while (s >= -lambda)
            {
                alpha = rnd.NextDouble();
                s += Math.Log(alpha);
                m++;
            }
            return m;
        }
        public string[] playTour(Team[] teams)
        {
            string[] games = new string[10];
            foreach (var team in teams)
            {
                team.goals = generateGoals(team.lambda);
            }
            playGame(firstTeam, circle[9]);
            games[0] = firstTeam.name.ToString() +" "+ firstTeam.goals.ToString() + ":" + circle[9].goals.ToString()+ " "+circle[9].name.ToString();
            for (int i = 0; i < 9; i++)
            {
                playGame(circle[i], circle[i + 10]);
                games[i+1] = circle[i].name.ToString()+" " + circle[i].goals.ToString() + ":" + circle[i + 10].goals.ToString() +" "+ circle[i+10].name.ToString();
            }
            roundCircle();
            tour++;
            return games;
        }

        void playGame(Team t1, Team t2)
        {
            if (t1.goals > t2.goals)
                t1.points += 3;
            else if (t1.goals < t2.goals)
                t2.points += 3;
            else
            {
                t1.points++;
                t2.points++;
            }
        }

        void roundCircle()
        {
            Team[] mirror = new Team[19];
            mirror[0] = circle[18];
            for(int i = 1; i < 19; i++)
            {
                mirror[i] = circle[i - 1];
            }
            circle = mirror;
        }
    }
}
