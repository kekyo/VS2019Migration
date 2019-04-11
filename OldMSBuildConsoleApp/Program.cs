using Nagoya.LifelongLearningCenter;
using System;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace OldMSBuildConsoleApp
{
    class Program
    {
        private static async Task MainAsync(string[] args) =>
            await InformationController.FetchSchedulesOnConcurrent()
                .Where(schedule =>
                     schedule.Date.Year == 2019 &&
                     schedule.Date.DayOfWeek == DayOfWeek.Saturday &&
                     (schedule.TimeSlot == TimeSlot.Afternoon || schedule.TimeSlot == TimeSlot.Evening) &&
                     schedule.Status == Status.Free)
                .ForEachAsync(schedule => Console.WriteLine(schedule.ToString()));

        static void Main(string[] args) =>
            MainAsync(args).Wait();
    }
}
