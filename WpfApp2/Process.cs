using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    class Process
    {

        Process()
        {
            arriveTime = 0;
            burstTime = 0;
            assigned = false;
            finished = false;
            priority = 0;
        }

        Process(int arrive, int burst)
        {
            arriveTime = arrive;
            burstTime = burst;
            assigned = false;
            finished = false;
            priority = 0;
        }

        Process(int arrive, int burst, bool pAssigned, bool pFinished)
        {
            arriveTime = arrive;
            burstTime = burst;
            assigned = pAssigned;
            finished = pFinished;
            priority = 0;
        }

        Process(int arrive, int burst, int p, bool pAssigned, bool pFinished)
        {
            arriveTime = arrive;
            burstTime = burst;
            assigned = pAssigned;
            finished = pFinished;
            priority = p;
        }

        int CompareArriveTime(Process p)
        {
            if (this.arriveTime < p.arriveTime)
                return -1;
            else if (this.arriveTime == p.arriveTime)
                return 0;
            else
                return 1;
        }

        int CompareBurstTime(Process p)
        {
            if (this.burstTime < p.burstTime)
                return -1;
            else if (this.burstTime == p.burstTime)
                return 0;
            else
                return 1;
        }

        bool CheckPriority(Process p)
        {
            if (this.priority < p.priority)
                return false;
            else
                return true;
        }

        bool IsAssigned()
        {
            return assigned;
        }

        bool IsFinished()
        {
            return finished;
        }

        void MarkAssigned()
        {
            assigned = true;
        }

        void MarkFinished()
        {
            finished = true;
        }

        private int arriveTime, burstTime, priority;
        private bool assigned, finished;
    };
}
