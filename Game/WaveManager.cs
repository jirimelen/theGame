using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Game
{
    class WaveManager
    {
        public static DispatcherTimer WMTimer = new DispatcherTimer()
        {
            Interval = TimeSpan.FromMilliseconds(1000),
            IsEnabled = true
        };
        Canvas LevelCanvas;


        private JsonSerializerSettings JsonSettings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Objects };


        // make it load from a file - different level = different file

        List<Wave> waves = new List<Wave> {
            /*new Wave {
                Enemies = new List<EnemyInfo>
                {
                    new EnemyInfo { W = 60, H = 60, HP = 30, Coordinates = new Point { X = 300, Y = 50 } },
                    new EnemyInfo { W = 60, H = 60, HP = 30, Coordinates = new Point { X = 490, Y = 50 } },
                    new EnemyInfo { W = 60, H = 60, HP = 30, Coordinates = new Point { X = 680, Y = 50 } },
                }
            },
            new Wave {
                Enemies = new List<EnemyInfo>
                {
                    new EnemyInfo { W = 60, H = 60, HP = 30, Coordinates = new Point { X = 380, Y = 50 } },
                    new EnemyInfo { W = 60, H = 60, HP = 30, Coordinates = new Point { X = 490, Y = 50 } },
                    new EnemyInfo { W = 60, H = 60, HP = 30, Coordinates = new Point { X = 600, Y = 50 } },
                    
                    new EnemyInfo { W = 60, H = 60, HP = 30, Coordinates = new Point { X = 490, Y = 140 } },
                }
            },
            new Wave {
                Enemies = new List<EnemyInfo>
                {
                    new EnemyInfo { W = 60, H = 60, HP = 30, Coordinates = new Point { X = 270, Y = 50 } },
                    new EnemyInfo { W = 60, H = 60, HP = 30, Coordinates = new Point { X = 380, Y = 50 } },
                    new EnemyInfo { W = 60, H = 60, HP = 30, Coordinates = new Point { X = 490, Y = 50 } },
                    new EnemyInfo { W = 60, H = 60, HP = 30, Coordinates = new Point { X = 600, Y = 50 } },
                    new EnemyInfo { W = 60, H = 60, HP = 30, Coordinates = new Point { X = 710, Y = 50 } },

                    new EnemyInfo { W = 60, H = 60, HP = 30, Coordinates = new Point { X = 380, Y = 140 } },
                    new EnemyInfo { W = 60, H = 60, HP = 30, Coordinates = new Point { X = 490, Y = 140 } },
                    new EnemyInfo { W = 60, H = 60, HP = 30, Coordinates = new Point { X = 600, Y = 140 } },
                }
            },
            new Wave {
               Enemies = new List<EnemyInfo>
                {
                    new EnemyInfo { W = 160, H = 160, HP = 300, Coordinates = new Point { X = 440, Y = 50 } },
                }
            },*/
        };
        
        public WaveManager(Canvas checkCanvas, int level)
        {
            LevelCanvas = checkCanvas;

            waves = LoadLevel(level);
            //SaveLevel(1);

            waves[0].Activate(LevelCanvas);
            waves[0].MoveToPlace();
            waves.Remove(waves[0]);

            WMTimer.Tick += CheckWaveCompletion;
        }

        public void CheckWaveCompletion(object sender, EventArgs e)
        {
            List<Enemy> Enemies = LevelCanvas.Children.OfType<Enemy>().ToList();

            if (Enemies.Count == 0)
            {
                if (waves.Count != 0)
                {
                    waves[0].Activate(LevelCanvas);
                    waves[0].MoveToPlace();
                    waves.Remove(waves[0]);
                }
                else
                {
                    var level = ((LevelCanvas.Parent as Grid).Parent as Pages.Level);
                    level.EndLevel(true);
                    WMTimer.Tick -= CheckWaveCompletion;
                }
            }
        }







        public bool SaveLevel(int num)
        {
            try
            {
                string jsonString = JsonConvert.SerializeObject(waves, JsonSettings);
                File.WriteAllText(@"D:/school/Level" + num + ".json", jsonString);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Wave> LoadLevel(int num)
        {
            string jsonString = File.ReadAllText(@"D:/school/Level" + num + ".json");
            return JsonConvert.DeserializeObject<List<Wave>>(jsonString, JsonSettings);
        }
    }
}
