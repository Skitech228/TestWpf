#region Using derectives

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using OxyPlot;
using TestWpf.Infrostructure.Commands;
using TestWpf.Models;
using DataPoint= OxyPlot.DataPoint;

#endregion

namespace TestWpf.ViewModels.Base
{
    internal sealed class MainWindowViewModel : ViewModel
    {
        private string _Title = "Анимэ";

        #region TestDataPoin:IList<DataPoint> - Текстовый набор данных для визуализации графиков

        public IList<DataPoint> TestDataPoints { get; private set; }

        #endregion

        /// <summary>
        ///     Заголовок окна
        /// </summary>
        public string Title
        {
            get => _Title;

            set => Set(ref _Title, value);
        }

        private ICommand CloseAppCommand { get; }

        private static bool CanCloseAppCommandExecute(object p) => true;

        private void OnCloseAppCommandExecute(object p)
        {
            Application.Current.Shutdown();
        }

        public IEnumerable<int> TicketGenerator()
        {
            var rnd = new Random();

            while (true)
                yield return rnd.Next(100000, 1000000);
        }

        private bool IsLucky(int number)
        {
            int firstHalf = int.Parse(number.ToString().Substring(0, 3));
            int secondHalf = int.Parse(number.ToString().Substring(3, 3));

            return firstHalf.ToString().Select(x => int.Parse(x.ToString())).Sum() ==
                   secondHalf.ToString().Select(x => int.Parse(x.ToString())).Sum();
        }
        public MainWindowViewModel()
        {
            #region Commands

            CloseAppCommand = new LambdaCommand(OnCloseAppCommandExecute, CanCloseAppCommandExecute);

            #endregion

            TestDataPoints = new List<DataPoint>();

            //for (var x = 0d; x < 360; x+=0.1)
            //{
            //    const double to_rad = Math.PI / 180;
            //    var y = Math.Sin(x * to_rad);
            //    TestDataPoints.Add(new DataPoint (x,(double)y));
            //}
            for (int i = 1; i <= 10; i++)
            {
                var nums = TicketGenerator().Take(1000).ToArray();
                int luckyTicketsCount = nums.Count(x => IsLucky(x));
                TestDataPoints.Add(new DataPoint(i, (double)luckyTicketsCount / 1000 * 100));
                Debug.WriteLine($"Всего билетов: {1000}\nСчастливых билетов: {luckyTicketsCount}\nПроцент счастливых билетов: {((double)luckyTicketsCount / 1000 * 100):0.###}%");
            }
        }
    }
}