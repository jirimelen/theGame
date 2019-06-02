using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Game
{
    class Wave
    {
        public static DispatcherTimer WTimer = new DispatcherTimer()
        {
            Interval = TimeSpan.FromMilliseconds(10),
            IsEnabled = true
        };


        public List<EnemyInfo> Enemies = new List<EnemyInfo>();
        public List<Enemy> EnemyObjects = new List<Enemy>();

        public Wave()
        {/*
            Enemies.Add(new Enemy { Width = 60, Height = 60 });
            Enemies.Add(new Enemy { Width = 60, Height = 60 });
            
            EnemiesPositions.Add(new Point { X = 210, Y = 50 });
            EnemiesPositions.Add(new Point { X = 320, Y = 50 });
        */}

        public void Activate(Canvas parent)
        {
            /*for (int i = 0; i < Enemies.Count; i++)
            {
                parent.Children.Add(Enemies[i]);
                Canvas.SetTop(Enemies[i], EnemiesPositions[i].Y - 250);
                Canvas.SetLeft(Enemies[i], EnemiesPositions[i].X);
            }*/
            foreach (var info in Enemies)
            {
                var enemy = new Enemy(info.HP);
                enemy.Width = info.W;
                enemy.Height = info.H;

                parent.Children.Add(enemy);
                EnemyObjects.Add(enemy);

                Canvas.SetTop(enemy, info.Coordinates.Y - 250);
                Canvas.SetLeft(enemy, info.Coordinates.X);
            }
        }

        public void MoveToPlace()
        {
            for (int i = 0; i < EnemyObjects.Count; i++)
            {
                WTimer.Tick += EnemyObjects[i].MoveDown;
            }
        }
    }
}
